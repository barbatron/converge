using Converge.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Services
{
    public class CompositeSubscriber : IDisposableSubscriber
    {
        private List<IDisposableSubscriber> subscribers = new List<IDisposableSubscriber>();

        public void RegisterSubscribers(IEnumerable<IDisposableSubscriber> subscribers)
        {
            this.subscribers.AddRange(subscribers.Where(ids => ids.GetType() != typeof(CompositeSubscriber)));
        }

        public void Subscribe()
        {
            subscribers.ForEach(s => s.Subscribe());
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) // Managed:
                {
                    subscribers.ForEach(s => s.Dispose());
                    subscribers.Clear();
                }
                // Unmanaged:
            }
            disposed = true;
        }

        ~CompositeSubscriber()
        {
            Dispose(false);
        }
    }
    
}
