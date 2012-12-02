using Converge.Contracts;
using Converge.Sagas;
using MassTransit;
using MassTransit.Saga;
using System;

namespace Converge.Supports
{
    public class NodeInstaller : IDisposableSubscriber
    {
        private readonly ISagaRepository<NodeSetupSaga> installerSagaRepo;
        private readonly IServiceBus bus;

        private UnsubscribeAction unsubscribeSaga = null;

        private bool disposed = false;

        public NodeInstaller(IServiceBus bus, ISagaRepository<NodeSetupSaga> installerSagaRepo)
        {
            this.bus = bus;
            this.installerSagaRepo = installerSagaRepo ?? new InMemorySagaRepository<NodeSetupSaga>();
        }

        public void Subscribe()
        {
            if (unsubscribeSaga != null) unsubscribeSaga();
            unsubscribeSaga = bus.SubscribeSaga(installerSagaRepo);
        }

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
                    if (unsubscribeSaga != null) unsubscribeSaga();
                }
                // Unmanaged:
            }
            disposed = true;
        }

        ~NodeInstaller()
        {
            Dispose(false);
        }
    }

}
