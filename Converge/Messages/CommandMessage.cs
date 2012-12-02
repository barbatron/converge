using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Messages
{
    /// <summary>
    /// Command messages generally go from top level out toward leaf nodes in the org graph.
    /// </summary>
    public class CommandMessage :
        CorrelatedBy<Guid>, Converge.Messages.ICommandMessage
    {
        public Guid CorrelationId { get; set; }

        public string TargetNodeId { get; set; }
        public string TargetNodeApplication { get; set; }

        public int MessageVersion { get; set; }
        public string Command { get; set; }
        public string Parameters { get; set; }

        public string IssuingPrincipal { get; set; }

        public override string ToString()
        {
            return string.Format("CMD> CorrId={0} (TargNode={1} TargApp={2}) MVer={3}:\n   Command={4}\n   Params={5}\n   Issuer={6}",
                CorrelationId,
                TargetNodeId,
                TargetNodeApplication,
                MessageVersion,
                Command,
                Parameters, 
                IssuingPrincipal);
        }
    }
}
