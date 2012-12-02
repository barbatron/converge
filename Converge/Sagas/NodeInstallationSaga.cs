using Converge.Messages;
using Magnum.StateMachine;
using MassTransit;
using MassTransit.Saga;
using System;
using System.Diagnostics;

namespace Converge.Sagas
{/*
    public class NodeInstallationSaga :
        SagaStateMachine<NodeInstallationSaga>,
        ISaga
    {
        static NodeInstallationSaga()
        {
            Define(() =>
            {
                Initially(
                    When(NodeConnected)
                        .Then((saga, message) => saga.RegisterNode(message))
                        .TransitionTo(NodeConfiguration)

                );

                During(NodeConfiguration,
                    When(NodeEvent)
                    .Then((saga, message) => saga.ProcessEventData(message))
                    .Complete()
                );
            });

        }

        public NodeInstallationSaga(Guid correlationId)
        {
            CorrelationId = correlationId;
            
        }

        public static State Initial { get; set; }
        public static State NodeConfiguration { get; set; }
        public static State Completed { get; set; }

        public static Event<GenericEventMessage> NodeEvent { get; set; }
        public static Event<NodeAppConnectedMessage> NodeConnected { get; set; }

        public Guid CorrelationId { get; set; }

        public IServiceBus Bus { get; set; }


        private void ProcessEventData(GenericEventMessage message, string specialRoute = null)
        {
            Console.WriteLine(LogPrefix() + "Event message received: " + message.ToString());
            if (!string.IsNullOrEmpty(specialRoute))
            {
                Console.WriteLine(LogPrefix() + "*** Node event with special route: " + specialRoute);
            }
        }

        private void RegisterNode(NodeAppConnectedMessage message)
        {
            Console.WriteLine(LogPrefix() + "Registering node: NodeID=" + message.NodeId + " and appId=" + message.AppId);
            
            PingMessage ping = new PingMessage
            {
                CorrelationId = this.CorrelationId,
                LocalTime = DateTime.Now.ToString(),
                NodeId = message.NodeId,
                AppId = message.AppId
            };

            Bus.Context().Respond(ping, x => x.SetResponseAddress(Bus.Endpoint.Address.Uri));

        }

        private string LogPrefix()
        {
            return "NodeInst [" + this.CorrelationId + "]: ";
        }
    }*/
}
