using Converge.Messages;
using Magnum;
using MassTransit;
using MassTransit.Services.HealthMonitoring.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class MessageSubscriber : IDisposable,
        Consumes<HealthUpdate>.All,
        Consumes<CommandMessage>.All,
        Consumes<PingMessage>.All
    {
        private IServiceBus _bus;
        private UnsubscribeAction _unsubscribe;

        private bool disposed = false;

        public MessageSubscriber(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Subscribe()
        {
            _unsubscribe = _bus.SubscribeInstance(this);
        }

        public void Consume(HealthUpdate message)
        {
            Show(message);
        }

        public void Consume(CommandMessage message)
        {
            Show(message);
        }

        public void Consume(PingMessage message)
        {
            Show(message);
        }

        private void Show(object message)
        {
            string report = string.Format("{0}: Got message of type {1}: {2}",
                DateTime.Now.ToString(),
                message.GetType().Name,
                message.ToString());

            Console.WriteLine(report);

            _bus.Publish(new GenericEventMessage
                {
                    CorrelationId = CombGuid.Generate(),
                    NodeId = "-",
                    DataFormatVersion = 1,
                    EventDataFormat = "-",
                    EventData = report
                });
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
                    if (_unsubscribe != null) _unsubscribe();
                    _unsubscribe = null;
                }
                // Unmanaged:
            }
            disposed = true;
        }

        ~MessageSubscriber()
        {
            Dispose(false);
        }
    
    }
}
