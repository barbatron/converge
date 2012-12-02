using Converge.Messages;
using Converge.Model;
using Converge.Sagas;
using MassTransit;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Magnum;
using Magnum.StateMachine;
using Topshelf;
using MassTransit.Saga;
using MassTransit.Log4NetIntegration.Logging;
using Converge.Contracts;
using Converge.Services;

namespace Converge.CentralMon
{
    public class Program
    {
        public static void Main()
        {
            Log4NetLogger.Use(@"D:\code\net\Converge\log4net.xml");

            var transportSettings = TransportSettings.UseRabbitMq("localhost");
            var container = BootstrapContainer(transportSettings, "converge_centralmon");
            
            var appSubscribers = new CompositeSubscriber();
            //appSubscribers.RegisterSubscribers(container.GetAllInstances<IDisposableSubscriber>());

            // Roll out a service actnig as the primary app grunks
            HostFactory.Run(c =>
            {
                c.SetServiceName("ConvergeCMon");
                c.SetDisplayName("Converge Central monitor");
                c.SetDescription("Converge node activity monitor.");

                c.RunAsLocalSystem();

                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

                c.Service<MonitorService>(s =>
                {
                    s.ConstructUsing(builder => container.GetInstance<MonitorService>());
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o => o.Stop());
                });

            });

        }

        private static IContainer BootstrapContainer(TransportSettings transportSettings, string appNameBase)
        {
            ObjectFactory.Initialize(cfg =>
                {
                    cfg.AddRegistry<CentralMonRegistry>();
                  
                    cfg.For<TransportSettings>().Singleton().Use(transportSettings);

                    cfg.For<IServiceBus>().Use(context => ServiceBusFactory.New(sbc =>
                    {
                        string rcvQueueUri = transportSettings.GetQueueUri(appNameBase);
                        sbc.ReceiveFrom(rcvQueueUri);

                        transportSettings.ApplyGlobalConfig(sbc);

                        sbc.UseControlBus();

                        sbc.Subscribe(sub =>
                            {
                                sub.LoadFrom(ObjectFactory.Container);
                            });
                        
                    }));

                });

            var container = ObjectFactory.Container;
            CentralMonRegistry.Build(container);
            return container;
        }
    }
}
