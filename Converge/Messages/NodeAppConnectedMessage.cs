using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Messages
{
    public class NodeAppConnectedMessage :
        CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public string NodeId { get; set; }
        public string AppId { get; set; }

        public override string ToString()
        {
            return string.Format("NODE.CONNECT> CorrId={0} NodeId={1} AppId={2} \"{3}\"",
                CorrelationId,
                NodeId,
                AppId);
        }

        
    }
}
