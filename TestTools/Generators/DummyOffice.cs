using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTools.Generators
{
    public class DummyOfficeState
    {
        public TimeSpan TimeSinceLastTick;
        public IEnumerable<DummyUser> Users;
        public IEnumerable<DummyCashier> Cashiers;
        public IEnumerable<DummyServiceType> ServiceTypes;
    }
    public interface IOfficeProbabilityEvaluators
    {
        int GetNewTicketCount(DummyOfficeState state);
        int GetCashierActivationCount(DummyOfficeState state);
        int GetCashierEosActionCount(DummyOfficeState state);
    }

    //public class DefaultOfficeProbabilityEvaluators : IOfficeProbabilityEvaluators
    //{

    //    public int GetNewTicketCount(DummyOfficeState state)
    //    {
    //    }
    //    public int GetCashierActivationCount(DummyOfficeState state);
    //    public int GetCashierEosActionCount(DummyOfficeState state);
    //}

    /// <summary>
    /// Represents an office branch, with any number of service types, any
    /// number of employees (users) and any number of cashier stations.
    /// </summary>
    public class DummyOffice : DummyItemBase
    {
        public IEnumerable<DummyUser> Users { get { return users; } }
        public IEnumerable<DummyCashier> Cashiers { get { return cashiers; } }
        public IEnumerable<DummyServiceType> ServiceTypes { get { return serviceTypes; } }

        public int ServiceTypeCount { get; private set; }
        public int UserCount { get; private set; }
        public int CashierCount { get; private set; }

        public bool IsOpen { get { return thread != null; } }

        // Tick freq (hz)
        public int TicksPerSecond { get; set; }

        // Percentage of ticks resulting in a new ticket 
        public float TicketsDispensedPerTick { get; set; }

        // Percentage of ticks resulting in a cashier getting opened by an idle user:
        public float UserCashierOpeningsPerTick { get; set; }

        // Percentage of ticks resulting in an open-but-idle cashier calling next or closing 
        public float CashierReactionsPerTick { get; set; }

        // Duration interval for rate of serving customers (consuming tickets)
        public TimeSpan MinimumServingTime { get; set; }
        public TimeSpan MaximumServingTime { get; set; }

        private List<DummyUser> users = new List<DummyUser>();
        private List<DummyCashier> cashiers = new List<DummyCashier>();
        private List<DummyServiceType> serviceTypes = new List<DummyServiceType>();

        

        private Random r;
        private Thread thread = null;
        protected AutoResetEvent stopEvent = new AutoResetEvent(false);

        public DummyOffice(string branchId, int serviceTypes, int users, int cashiers)
        {
            ConfigureDefaultProbabilities(10);
            LogString = (s) => Console.WriteLine("{0:HH:mm:ss.fff} {1}", DateTime.Now, s);

            BranchId = branchId;

            ServiceTypeCount = serviceTypes;
            UserCount = users;
            CashierCount = cashiers;
            CreateDummies();
        }

        private void ConfigureDefaultProbabilities(int ticksPerSec)
        {
            TicksPerSecond = ticksPerSec;

            Func<float, float> timeBetweenHit_to_probabilityPerTick_convert = tbh =>
                {
                    float ticksPerTargetTimespan = tbh * ticksPerSec;

                    // Input value = avg time between hit
                    return 1f / ticksPerTargetTimespan;
                };
            TicketsDispensedPerTick = timeBetweenHit_to_probabilityPerTick_convert(5f);
            UserCashierOpeningsPerTick = timeBetweenHit_to_probabilityPerTick_convert(6f);
            CashierReactionsPerTick = timeBetweenHit_to_probabilityPerTick_convert(5f);

            MinimumServingTime = TimeSpan.FromSeconds(3d);
            MaximumServingTime = TimeSpan.FromSeconds(30d);
        }

        private void CreateDummies()
        {
            logFallback = this.LogString;

            #region Service types and queues
            serviceTypes.Clear();
            for (int i = 0; i < ServiceTypeCount; i++)
            {
                byte letterCharCode = (byte)(65 + i);
                char letter = Encoding.Default.GetChars(new[] { letterCharCode })[0];
                var st = new DummyServiceType
                {
                    Number = i + 1,
                    TicketPrefix = letter.ToString()
                };
                serviceTypes.Add(st);

            }
            #endregion
            #region Users
            users.Clear();
            for (int i = 0; i < UserCount; i++)
            {
                users.Add(new DummyUser
                {
                    Number = i + 1,
                    Cashier = null
                });
            }
            #endregion
            #region Cashiers
            cashiers.Clear();
            for (int i = 0; i < CashierCount; i++)
            {
                cashiers.Add(new DummyCashier
                {
                    Number = i + 1
                });
            }
            #endregion
        }

        // Open office for business
        public void Open()
        {
            Log("Opening");

            if (thread != null) Close();

            cashiers.ForEach(c => c.CurrentUser = null);
            users.ForEach(u => u.Cashier = null);
            serviceTypes.ForEach(st => st.Queue.Reset());
            thread = new Thread(SimulateBusiness)
            {
                IsBackground = true
            };
            thread.Start();

            Log("Opened");

        }

        public void Close()
        {
            Log("Closing");
            if (thread == null) return;

            stopEvent.Set();
            thread.Join(100);
            if (thread.IsAlive) thread.Abort();
            thread = null;

            Log("Closed");
        }


        private void SimulateBusiness()
        {
            r = new Random(Environment.TickCount ^ thread.ManagedThreadId);

            while (!stopEvent.WaitOne(0, false))
            {
                // Producing tickets in random service type queues
                DoArrivingCustomers();

                // Associating idle users with free cashiers 
                PutIdleUsersAtCashiers();

                // Begin ticket serving, make cashiers active
                MakeInactiveCashiersCallNextOrClose();

                // Un-flag cashiers from being active after ticket is served
                UpdateTicketsBeingServed();

                int sleepTime = TicksPerSecond > 0 ? (int)Math.Round(1000f / TicksPerSecond) : 10000;
                Thread.Sleep(sleepTime);
                Console.Write("\r" + TickChar);
            }
        }

        private void DoArrivingCustomers()
        {
            // Select a service type for the customer to request
            DummyServiceType st = GetRandom(serviceTypes);
            // Reduce willingness to enqueue where there are lots of ppl ahead in line
            float reconsideredProb = 1f;
            if (st.Queue.Count > 5)
                reconsideredProb /= (st.Queue.Count - 5);

            TestRandom(TicketsDispensedPerTick * reconsideredProb, () =>
            {
                // Take a ticket in that ST, enqueue it
                var ticket = st.GetTicket(true);
                ticket.TaskDuration = GetRandomTaskDuration();
                string durationDesc = ticket.TaskDuration.TotalSeconds > 5d
                    ? string.Format(" (case dur.: {0}s)", (int)(ticket.TaskDuration.TotalSeconds))
                    : string.Empty;
                Log("New customer got ticket {0}{1}", ticket, durationDesc);
            });
        }

        private void PutIdleUsersAtCashiers()
        {
            var availableUsers = users.Where(u => u.Cashier == null).ToList();
            if (availableUsers.Count == 0)
                return;

            // Any idle users, and any free cashier stations, and any non-served tickets?
            var availableCashiers = cashiers.Where(c => c.CurrentUser == null).ToList();
            var servableSeviceTypes = serviceTypes.Where(st => st.Queue.HasTickets).ToList();

            bool validOperation = (availableUsers.Count > 0) && (availableCashiers.Count > 0) && (servableSeviceTypes.Count > 0);
            if (!validOperation)
            {
                // This office is working at max capacity, or there are no waiting customers
                return;
            }

            float cashierOpenProbability = this.UserCashierOpeningsPerTick;
            TestRandom(cashierOpenProbability, () =>
            {
                DummyUser idleUser = GetRandom(availableUsers);
                DummyCashier freeCashier = GetRandom(availableCashiers);
                DummyServiceType serviceType = GetRandom(servableSeviceTypes);

                Log("{0} manning {1}, dealing with {2}", idleUser, freeCashier, serviceType);
                freeCashier.Open(idleUser, serviceType);
            });
        }

        private void MakeInactiveCashiersCallNextOrClose()
        {
            TestRandom(CashierReactionsPerTick, () =>
            {
                var mannedCashiers = from c in cashiers
                                     where c.IsOpen && (!c.IsActive)
                                     select c;

                // If the service type has customers, call next
                foreach (var mc in mannedCashiers)
                {
                    var u = mc.CurrentUser;

                    if (mc.ServiceType.Queue.HasTickets)
                    {
                        // Call next
                        var calledTicket = mc.CallNext();
                        Log("{0} called next ticket: {1}", mc, calledTicket);
                    }
                    else
                    {
                        // Close cashier
                        mc.Close();
                        Log("{0} closes {1} and is now idle", u, mc);
                    }
                }
            });
        }

        private void UpdateTicketsBeingServed()
        {
            var busyCashiers = from c in cashiers
                               where c.IsActive
                               select c;

            foreach (var bc in busyCashiers.ToList())
            {
                var t = bc.CurrentTicket;
                bc.TryServeCurrent();
                if (bc.IsActive == false)
                {
                    Log("EOS: {0} done serving {1}", bc, t);
                }
            }

        }

        #region private helpers

        private T GetRandom<T>(IEnumerable<T> source)
        {
            var list = source.ToList();
            if (list.Count == 0) throw new InvalidOperationException("No available entities in provided source");

            int selectedIndex = r.Next(0, list.Count);

            return list[selectedIndex];
        }

        private TimeSpan GetRandomTaskDuration()
        {
            double spanSizeMs = (MaximumServingTime - MinimumServingTime).TotalMilliseconds;
            
            return TimeSpan.FromMilliseconds(
                MinimumServingTime.TotalMilliseconds + 
                spanSizeMs * RandomUnit());

        }

        private bool TestRandom(float probability, Action action)
        {
            if (probability >= 0f && probability < 1f)
            {
                float prob = RandomUnit();         // 0.0 - 1.0, evaluated 10 times/sec
                bool hit = prob <= probability;
                if (hit)
                {
                    action();
                }
                return hit;
            }
            else
            {
                // Probability is > 1, so repeat action n times, always true
                for (int i = 0; i < (int)probability; i++) action();
                return true;
            }
        }

        private float RandomUnit()
        {
            const int intSpan = 65536;
            float prob = (r.Next() % intSpan) / (float)(intSpan - 1);
            return prob;
        }



        #endregion

        public override string ToString()
        {
            var activeUsers = users.Where(u => u.IsActive).ToList();
            var openCashiers = cashiers.Where(c => c.IsOpen).ToList();
            var activeCashiers = openCashiers.Where(c => c.IsActive);
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLF("Branch \"{0}\": {1}", 
                BranchId, thread != null ? "Open" : "Closed");

            sb.AppendLF("   SERVICE TYPES:");
            foreach (var st in serviceTypes.OrderBy(st => st.Number))
            {
                int cashierCount =  cashiers.Where(c => c.ServiceType == st).Count();
                sb.AppendLF("   ST# {0}   QueueSize={1}   TicketCursor={2}   Cashiers={3}", 
                    st.Number, 
                    st.Queue.Count,
                    st.NextTicketName,
                    cashierCount);
            }
            sb.AppendLF();
            
            sb.AppendLF("   SERVICE TYPES:");
            foreach (var st in serviceTypes.OrderBy(st => st.Number))
            {
                int cashierCount =  cashiers.Where(c => c.ServiceType == st).Count();
                sb.AppendLF("   ST# {0}   QueueSize={1}   TicketCursor={2}   Cashiers={3}", 
                    st.Number, 
                    st.Queue.Count,
                    st.NextTicketName,
                    cashierCount);
            }
            sb.AppendLF();


            return base.ToString();
        }

    }

    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendLF(this StringBuilder sb, string format = "", params object[] parms)
        {
            sb.AppendLine(string.Format(format, parms));
            return sb;
        }
    }
}
