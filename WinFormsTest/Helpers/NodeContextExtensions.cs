//using Converge.Messages;
//using Converge.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WinFormsTest.Helpers
//{
//    public static class NodeContextExtensions
//    {
//        public static NodeAppConnectedMessage ToClientConnectMessage(this NodeContext nodeContext, Guid transactionId)
//        {
//            return new NodeAppConnectedMessage
//             {
//                 CorrelationId = transactionId,
//                 NodeId = nodeContext.Record.NodeId,
//             };

//        }
//    }
//}
