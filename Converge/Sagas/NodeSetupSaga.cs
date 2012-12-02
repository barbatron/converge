using Converge.Messages;
using Magnum.StateMachine;
using MassTransit;
using MassTransit.Saga;
using System;
using System.Diagnostics;

namespace Converge.Sagas
{
    public class NodeSetupSaga :
        SagaStateMachine<NodeSetupSaga>,
        ISaga
    {
        static NodeSetupSaga()
        {
            Define(() =>
            {
                Initially(
                    When(NodeConnects)
                        .Then((saga, message) => saga.HandleNodeConnection(message))
                        .TransitionTo(NodeSetupNegotiation)
                );

                //During(NodeSetupNegotiation,
                //    When(NodeEvent)
                //    .Then((saga, message) => saga.ProcessEventData(message))
                //    .Complete()
                //);
            });

        }

        public NodeSetupSaga(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public static State Initial { get; set; }
        public static State NodeSetupNegotiation { get; set; }
        public static State Completed { get; set; }

        public static Event<NodeSetupRequest> NodeConnects { get; set; }

        public Guid CorrelationId { get; set; }
        public IServiceBus Bus { get; set; }

        private void HandleNodeConnection(NodeSetupRequest message)
        {
            // Register the node as active and monitorable


            // Provide response (TODO: what could a node want to know?)
            ProvideNodeSetup(message);
        }

        private void ProvideNodeSetup(NodeSetupRequest message)
        {
            // Base comm setup
            var responseMsg = new NodeSetupResponse
            {
                CorrelationId = this.CorrelationId
            };

        }

        private string LogPrefix()
        {
            return "NodeInst [" + this.CorrelationId + "]: ";
        }
    }
}
