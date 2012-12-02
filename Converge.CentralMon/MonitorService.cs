using Converge.Contracts;
using Converge.Messages;
using Converge.Model;
using Converge.Sagas;
using Converge.Services;
using Converge.Supports;
using Magnum;
using MassTransit;
using MassTransit.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.CentralMon
{
    public class MonitorService
    {
        private IServiceBus Bus { get { return bus; } }
        private IServiceBus bus;


        private System.Threading.Timer commandTimer;
        private IDisposableSubscriber subscribers;

        public MonitorService(IServiceBus bus, CompositeSubscriber subscribers)
        {
            this.bus = bus;
            this.subscribers = subscribers;
        }

        public void Start()
        {
            Console.WriteLine("*** CMon started");

            if (subscribers != null) subscribers.Subscribe();
            
            //nodeInstaller.Subscribe();
            GenerateCommandMessages();
        }

        private void GenerateCommandMessages()
        {
            commandTimer = new System.Threading.Timer((st) =>
            {
                var commandCorrId = CombGuid.Generate();

                var cmd = new CommandMessage
                {
                    CorrelationId = commandCorrId,
                    IssuingPrincipal = "CMon",
                    MessageVersion = 1,
                    TargetNodeApplication = "",
                    TargetNodeId = "",
                    Command = "Increase power",
                    Parameters = "All units"
                };
                Console.WriteLine("Sending command: " + cmd.ToString());

                Bus.Publish(cmd, x => x.SetResponseAddress(Bus.Endpoint.Address.Uri.ToString()));

            }, null, 15000, 3000);
        }

        public void Stop()
        {
            Console.WriteLine("*** CMon stopping");

            if (subscribers != null) subscribers.Dispose();
        }

    }
}
