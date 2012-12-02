using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Generators
{

    public class DummyServiceType : DummyItemBase
    {
        public int Number { get; set; }

        public DummyQueue Queue { get; set; }
        public string TicketPrefix { get; set; }
        public string NextTicketName { get { return TicketPrefix + (_number).ToString("000"); } }
        
        private int _number = 100;
        private TicketsCollection servedTickets = new TicketsCollection();
        
        public DummyServiceType() 
        { 
            Queue = new DummyQueue();
        }

        public DummyTicket GetTicket(bool enqueue = true)
        {
            var t = new DummyTicket
            {
                Name = NextTicketName,
                ServiceType = this
            };
            _number++;
            if (enqueue) Queue.Enqueue(t);
            return t;
        }
        public override string ToString()
        {
            return string.Format("ST #{0} ({1} in queue) (nt={2})", Number, Queue.Count, NextTicketName);
        }

        internal void TicketServed(DummyTicket dummyTicket)
        {
            if (dummyTicket.ServiceEnd.HasValue == false) throw new ArgumentException("Ticket not served");
            servedTickets.Add(dummyTicket);
        }

        

        public TimeSpan GetEstimatedWaitTime(int? limitCount = null)
        {
            TimeSpan longestWt = this.Queue.Max(t => t.WaitTime);
            return TimeSpan.FromMilliseconds(this.Queue.Count * longestWt.TotalMilliseconds);
        }
    }

}
