using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Model
{
    public class NodeRecord
    {
        public string NodeId { get; set; }
        public string ParentNodeId { get; set; }

        public int OrgNodeId { get; set; }

        public string QueueBaseName { get; set; }
        public TransportSettings QueueTransportSettings { get; set; }

        public string QueueUri { get { return QueueTransportSettings.GetQueueUri(QueueBaseName); } }
        
        public DateTime? LastPingTime { get; set; }
        public object LastPingResult { get; set; }

        

    }
}
