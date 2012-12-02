using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Messages
{
    public class GenericEventMessage
        //:  CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public string NodeId { get; set; }
        
        // LocalNodeVista describes the "universe" as it looks from the submitting node's
        // point of view. Branch-local identifiers etc.
        public string LocalNodeVista { get; set; }

        public int DataFormatVersion { get; set; }
        public string EventDataFormat { get; set; }
        public string EventData { get; set; }

        public GenericEventMessage()
        {
            EventDataFormat = "application/json";
            DataFormatVersion = 1;
            EventData = "{ }";
        }

        public override string ToString()
        {
            return string.Format("GEN.EVENT> CorrId={5} SourceNode={0}, CorrId={1}, EventVer={2} as {3}: \n->{4}\n",
                NodeId, CorrelationId,
                DataFormatVersion, EventDataFormat,
                EventData, 
                CorrelationId);
        }

    }
}
