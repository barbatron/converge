using Converge.Sagas;
using MassTransit;
using MassTransit.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge
{
    public class NodeService<TSaga>
         where TSaga : class, ISaga
    {
        private IServiceBus _bus;
        private ISagaRepository<TSaga> _sagaRepository;
        private UnsubscribeAction _unsubscribeAction;

        public NodeService(IServiceBus bus, ISagaRepository<TSaga> sagaRepository)
        {
            _bus = bus;
            _sagaRepository = sagaRepository;
        }

        public void Start()
        {
            // ninject doesn't have the brains for this one
            _unsubscribeAction = _bus.SubscribeSaga<TSaga>(_sagaRepository);
        }

        public void Stop()
        {
            _unsubscribeAction();
            _bus.Dispose();
        }
    }
}
