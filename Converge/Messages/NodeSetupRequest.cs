using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Messages
{
    public class NodeSetupRequest
        : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        
        public string NodeId { get; set; }
        public int NqApplicationId { get;set;}
        public int NqInstanceNumber { get;set;}
        public string NqApplicationVersionInfo { get; set; }

        public override string ToString()
        {
            return string.Format("NodeSetupRequest [{0}]: NodeId={1}", CorrelationId, NodeId);
        }
    }

    public class NodeSetupResponse
        : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return string.Format("NodeSetupResponse [{0}]: {1}", CorrelationId, Message);
        }
    }
}
