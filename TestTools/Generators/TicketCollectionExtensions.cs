using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.Generators
{
    public class TicketsCollection : IList<DummyTicket>
    {
        protected readonly IList<DummyTicket> innerCollection;

        public TicketsCollection(IList<DummyTicket> collection)
        {
            innerCollection = collection;
         
            
        }

        public TicketsCollection()
            : this(new List<DummyTicket>(100))
        { }

        public IEnumerable<DummyTicket> AllServed { get { return innerCollection.Where(t => t.ServiceEnd.HasValue); } }
        public IEnumerable<DummyTicket> AllWaiting { get { return innerCollection.Where(t => t.ServiceStart.HasValue == false); } }

        #region ICollection wrapper methods 

        public void Add(DummyTicket item)
        {
            innerCollection.Add(item);
        }

        public void Clear()
        {
            innerCollection.Clear();
        }

        public bool Contains(DummyTicket item)
        {
            return innerCollection.Contains(item);
        }

        public void CopyTo(DummyTicket[] array, int arrayIndex)
        {
            innerCollection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return innerCollection.Count; }
        }

        public bool IsReadOnly
        {
            get { return innerCollection.IsReadOnly; }
        }

        public bool Remove(DummyTicket item)
        {
            return innerCollection.Remove(item);
        }

        public IEnumerator<DummyTicket> GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }
        public int IndexOf(DummyTicket item)
        {
            return innerCollection.IndexOf(item);
        }

        public void Insert(int index, DummyTicket item)
        {
            innerCollection.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            innerCollection.RemoveAt(index);
        }

        public DummyTicket this[int index]
        {
            get { return innerCollection[index]; }
            set { innerCollection[index] = value; }
        }
        #endregion

    }

    public static class ServedTicketsExtensions
    {
        public static TimeSpan AverageServingTime(this IEnumerable<DummyTicket> tickets)
        {
            var served = from t in tickets
                             where t.IsServed
                             select t;
            if (served.Count() == 0) return TimeSpan.Zero;

            double avg = served.Average(t => t.ServeTime.TotalMilliseconds);
            return TimeSpan.FromMilliseconds(avg);
        }
        public static TimeSpan LongestWaitingTime(this IEnumerable<DummyTicket> tickets)
        {
            if (tickets.Count() == 0)
                return TimeSpan.Zero;

            return TimeSpan.FromMilliseconds(tickets.Max(t => t.WaitTime.TotalMilliseconds));
        }
        public static TimeSpan AverageWaitingTime(this IEnumerable<DummyTicket> tickets)
        {
            var served = from t in tickets
                         //where t.ServiceStart.HasValue
                         select t;
            if (served.Count() == 0)
                return TimeSpan.Zero;

            double avg = served.Average(t => t.WaitTime.TotalMilliseconds);
            return TimeSpan.FromMilliseconds(avg);
        }
    }
}
