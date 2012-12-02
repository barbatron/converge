using MassTransit;
using MassTransit.BusConfigurators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Model
{
    public class TransportSettings
    {
        public string ProtocolUriPrefix { get; set; }
        public string PrimaryHost { get; set; }

        private Action<ServiceBusConfigurator> serviceBusConfigurations = sbc => { };

        public void AddGlobalSbc(Action<ServiceBusConfigurator> sbcOperation, bool first = false)
        {
            if (!first)
            {
                var currentConfig = serviceBusConfigurations;
                serviceBusConfigurations = sbc =>
                    {
                        currentConfig(sbc);
                        sbcOperation(sbc);
                    };
            }
            else
            {
                var currentConfig = serviceBusConfigurations;
                serviceBusConfigurations = sbc =>
                {
                    sbcOperation(sbc);
                    currentConfig(sbc);
                };
            }
            
        }

        public string GetQueueUri(string queueName)
        {
            return string.Format("{0}://{1}/{2}",
                ProtocolUriPrefix,
                PrimaryHost,
                queueName);
        }

        public void ApplyGlobalConfig(ServiceBusConfigurator sbc)
        {
            serviceBusConfigurations(sbc);
        }

        public static TransportSettings UseRabbitMq(string host)
        {
            TransportSettings ts = new TransportSettings
            {
                PrimaryHost = host,
                ProtocolUriPrefix = "rabbitmq"
            };
            ts.AddGlobalSbc(sbc => sbc.UseRabbitMq());
            return ts;
        }
    }
}
