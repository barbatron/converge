using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Model
{
    public class NodeContext : IDisposable
    {
        public IServiceBus Bus { get; internal set; }
        public NodeRecord Record { get; internal set; }
        public TransportSettings Settings { get; internal set; }
        public string QueueName { get; internal set; }

        private bool disposed = false;

        internal NodeContext() { }

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
                    if (this.Bus != null)
                    {
                        Bus.Dispose();
                        Bus = null;
                    }
                }
                // Unmanaged:
            }
            disposed = true;
        }

        ~NodeContext()
        {
            Dispose(false);
        }
    }
}
