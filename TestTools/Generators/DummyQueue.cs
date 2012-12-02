using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Generators
{

    public class DummyQueue : TicketsCollection
    {
        public bool HasTickets { get { return innerCollection.Count > 0; } }

        // Ugly horror boogie
        private readonly object queueOpLock = new object();

        public DummyQueue()
            : base(new List<DummyTicket>())
        { }

        /// <summary>
        /// Enqueues the specified ticket at the end of this list.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public void Enqueue(DummyTicket ticket)
        {
            Add(ticket);
        }

        /// <summary>
        /// Dequeues the ticket at index 0, and marks them as being served.
        /// </summary>
        /// <returns>The next ticket in queue.</returns>
        public DummyTicket ServeNext()
        {
            if (!HasTickets) return null;

            var t = innerCollection[0];
            innerCollection.RemoveAt(0);

            t.StartService();
            return t;
        }

        public void Reset()
        {
            Clear();
        }
        public IEnumerable<DummyTicket> PeekAll()
        {
            return innerCollection;
        }

        public override string ToString()
        {
            bool stats = Count > 0;
            return string.Format("{0} tickets ({1})",
                Count, stats 
                    ? string.Format("awt={1:0.0}s lwt={2:0.0}s",               
                        innerCollection.AverageWaitingTime(),
                        innerCollection.LongestWaitingTime())
                    : "stats n/a");
        }
    }
}
