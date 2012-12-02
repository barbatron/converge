using Converge.Model;
using MassTransit;
using MassTransit.BusConfigurators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge
{
    public static class NodeConfigurator
    {
        #region T-T
        public static Func<object, object> MsmqTransportTranslator = (dynamic rmq) =>
        {
            string qn = string.Format("cvg_{0}_{1}",
                            rmq.NodeRecord.Subsystem,
                            rmq.NodeRecord.AppName);
            Action<ServiceBusConfigurator> sbcOps = sbc => sbc.UseMsmq();

            return new
            {
                QueueName = qn,
                Uri = string.Format("msmq://{0}/{1}", rmq.Host, qn),
                SBCAdjustments = sbcOps,
                Prefix = "msmq"
            };
        };
        public static Func<object, object> RabbitMqTransportTranslator = (dynamic rmq) =>
        {
            string qn = string.Format("cvg_{0}_{1}",
                            rmq.NodeRecord.Subsystem,
                            rmq.NodeRecord.AppName);
            Action<ServiceBusConfigurator> sbcOps = sbc => sbc.UseRabbitMq();

            return new
            {
                QueueName = qn,
                Uri = string.Format("rabbitmq://{0}/{1}", rmq.Host, qn),
                SBCAdjustments = sbcOps,
                Prefix = "rabbitmq"
            };
        };

        #endregion

        public static NodeContext ConnectNode(string host, NodeRecord node,
             Func<object, object> transportSpecificQueueNameTranslator,
            Action<ServiceBusConfigurator> customBusConfiguration = null)
        {
            transportSpecificQueueNameTranslator = transportSpecificQueueNameTranslator ?? MsmqTransportTranslator;
            dynamic queueSpecs = transportSpecificQueueNameTranslator(new
            {
                Format = "uri",
                Host = host,
                NodeRecord = node
            });

            Uri receiveFromUri = new Uri(queueSpecs.Uri);
            Action<ServiceBusConfigurator> sbcOps = queueSpecs.SBCAdjustments;
            TransportSettings ts = new TransportSettings
            {
                PrimaryHost = host,
                ProtocolUriPrefix = queueSpecs.Prefix
            };

            var serviceBus = ServiceBusFactory.New(sbc =>
            {
                sbc.ReceiveFrom(receiveFromUri);
                
                sbcOps(sbc);

                sbc.UseControlBus();
                //sbc.EnableRemoteIntrospection();

                if (customBusConfiguration != null)
                    customBusConfiguration(sbc);
            });



            return new NodeContext
            {
                Record = node,
                Bus = serviceBus,
                QueueName = queueSpecs.QueueName,
                Settings = ts
            };

        }
    }
}
