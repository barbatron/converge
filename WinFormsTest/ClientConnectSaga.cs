//using Converge.Messages;
//using Converge.Sagas;
//using Magnum.StateMachine;
//using MassTransit;
//using MassTransit.Saga;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WinFormsTest
//{
//    public class ClientConnectSaga  :
//        SagaStateMachine<ClientConnectSaga>,
//        ISaga
//    {
//        static ClientConnectSaga()
//        {
//         Define(() =>
//            {
//                Initially(
//                    When(ServerConnectionAck)
//                        .Then((saga, message) => saga.RegisterNode(message))
//                        .TransitionTo(MonitoringNode)

//                );

//                During(MonitoringNode,
//                    // Special event. EventData == "exiting", completes the saga.
//                    When(NodeEvent)
//                    .Where(gem => gem.EventData.StartsWith("exit"))
//                    .Then((saga, message) => saga.ProcessEventData(message, "Exiting"))
//                    .Complete(),

//                    // Default event handler
//                    When(NodeEvent)
//                    .Then((saga, message) => saga.ProcessEventData(message))
//                );
//            });

//        }


//        public ClientConnectSaga(Guid correlationId)
//        {
//            CorrelationId = correlationId;
            
//        }

//        public static State Initial { get; set; }
//        public static State MonitoringNode { get; set; }
//        public static State Completed { get; set; }

//        public static Event<PingMessage> ServerConnectionAck { get; set; }
//        public static Event<NodeAppConnectedMessage> NodeConnected { get; set; }

//        public Guid CorrelationId { get; set; }

//        public IServiceBus Bus { get; set; }

//    }
//}
