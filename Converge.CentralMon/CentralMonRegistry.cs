using Converge.Contracts;
using Converge.Model;
using Converge.Sagas;
using Converge.Services;
using Magnum;
using MassTransit;
using MassTransit.Saga;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.CentralMon
{
    public class CentralMonRegistry : Registry
    {
        public CentralMonRegistry()
        {
            Scan(cfg =>
            {
                cfg.TheCallingAssembly();
                cfg.AssemblyContainingType<IDisposableSubscriber>();
                
                //cfg.ConnectImplementationsToTypesClosing(typeof(SagaStateMachine<>));
                //cfg.AddAllTypesOf(typeof(IDisposableSubscriber));

                //cfg.AddAllTypesOf(typeof(Consumes<>));
                //cfg.AddAllTypesOf(typeof(ISaga));

            });
        }

        public static IContainer Build(IContainer container)
        {
            container.Configure(cfg =>
            {
                //cfg.For(typeof(ISagaRepository<>))
                //    .Singleton()
                //    .Use(typeof(InMemorySagaRepository<>));

                cfg.For<ISagaRepository<NodeSetupSaga>>()
                    .Singleton()
                    .Use(context => new InMemorySagaRepository<NodeSetupSaga>());

                // Subscribers
                cfg.For<NodeSetupProvider>().Singleton().Use<NodeSetupProvider>();

                cfg.For<Guid>().Use(() => CombGuid.Generate());

                // Domain services
                cfg.For<NodeGraphManager>()
                    .Singleton()
                    .Use<NodeGraphManager>();

                // Services 

                cfg.For<MonitorService>()
                    .Singleton()
                    .Use<MonitorService>();

            });

            return container;
        }
    }
}
