using Converge.Model;
using MassTransit;
using MassTransit.Saga;
using MassTransit.Services.Subscriptions.Server;
using MassTransit.Services.Timeout;
using MassTransit.Services.Timeout.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Converge.Supports
{
    public class SubscriptionServiceConfigurator
    {
        public const string STR_DefaultSubscriptionServiceQueueName = "mt_subscriptions";
        public const string STR_DefaultTimeoutServiceQueueName = "mt_timeouts";

        public string SubscriptionServiceQueueName { get; set; }
        public string TimeoutServiceQueueName { get; set; }

        public SubscriptionServiceConfigurator()
        {
            
        }

        public void Configure(TransportSettings settings)
        {
            StartSubscriptionService(settings);
            StartTimeoutService(settings);
        }

        private void StartTimeoutService(TransportSettings settings)
        {
            //
            // setup the time out service
            //
            string subscriptionQueueUri = settings.GetQueueUri(SubscriptionServiceQueueName ?? STR_DefaultSubscriptionServiceQueueName);
            string timeoutQueueUri = settings.GetQueueUri(TimeoutServiceQueueName ?? STR_DefaultTimeoutServiceQueueName);
            var timeoutBus = ServiceBusFactory.New(sbc =>
            {
                sbc.UseControlBus();

                sbc.ReceiveFrom(timeoutQueueUri);
                sbc.UseSubscriptionService(subscriptionQueueUri);
            });

            var timeoutService = new TimeoutService(timeoutBus, new InMemorySagaRepository<TimeoutSaga>());
            timeoutService.Start();
        }

        private string StartSubscriptionService(TransportSettings settings)
        {
            string subscriptionQueueUri = settings.GetQueueUri(SubscriptionServiceQueueName ?? STR_DefaultSubscriptionServiceQueueName);

            //
            // setup the subscription service
            //
            var subscriptionBus = ServiceBusFactory.New(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.SetConcurrentConsumerLimit(1);

                sbc.ReceiveFrom(subscriptionQueueUri);
            });

            var subscriptionSagas = new InMemorySagaRepository<SubscriptionSaga>();
            var subscriptionClientSagas = new InMemorySagaRepository<SubscriptionClientSaga>();
            var subscriptionService = new SubscriptionService(subscriptionBus, subscriptionSagas, subscriptionClientSagas);

            subscriptionService.Start();
            return subscriptionQueueUri;
        }

    }
}
