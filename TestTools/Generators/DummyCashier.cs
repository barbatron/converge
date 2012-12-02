using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Generators
{

    /// <summary>
    /// Represents a physical cashier station / clerk workstation, where a customer
    /// and a user meet in order to conduct business.
    /// </summary>
    public class DummyCashier : DummyItemBase
    {
        public int Number { get; set; }

        // If open:
        public bool IsOpen { get { return CurrentUser != null; } }
        public bool IsActive { get { return IsOpen && CurrentTicket != null; } }

        public DummyUser CurrentUser { get; set; }
        public DummyServiceType ServiceType { get; set; }

        // Stats
        public bool SaveServedTickets = true;
        public IEnumerable<DummyTicket> ServedTickets { get { return servedTickets; } }
        public int ServedTicketCount { get { return servedTickets.Count; } }
        private List<DummyTicket> servedTickets = new List<DummyTicket>(100);

        // If open + in service:
        public DummyTicket CurrentTicket { get; set; }

        public void Open(DummyUser user, DummyServiceType serviceType)
        {
            if (CurrentUser != null) throw new InvalidOperationException("Cashier already occupied");
            CurrentUser = user;
            ServiceType = serviceType;
            user.Cashier = this;
        }
        public void Close()
        {
            if (CurrentTicket != null) throw new InvalidOperationException("Cannot close while in service");
            CurrentUser.Cashier = null;
            CurrentUser = null;
            ServiceType = null;
        }
        public override string ToString()
        {
            string status = "";
            if (verbose)
            {
                if (CurrentUser != null) status += "(user " + CurrentUser.Number + ")";
                if (CurrentTicket != null) status += "(serving " + CurrentTicket.Name + ")";
            }
            else
            {
                //if (IsOpen) status += "Open ";
                //if (IsActive) status += "Active ";
            }
            return string.Format("Cashier #{0}: {1}", Number, status);
        }

        internal void TryServeCurrent()
        {
            if (CurrentTicket == null) return;

            bool eos = CurrentTicket.TryEndService();
            if (eos)
            {
                var eosTicket = CurrentTicket;
                CurrentTicket = null;

                if (SaveServedTickets)
                    servedTickets.Add(eosTicket);
            }
        }

        internal DummyTicket CallNext()
        {
            var nextTicket = ServiceType.Queue.ServeNext();
            CurrentTicket = nextTicket;
            
            return nextTicket;
        }
    }
}
