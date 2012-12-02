using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Messages
{
    public class PingMessage :
        CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }

        public string NodeId { get; set; }
        public string AppId { get; set; }

        public int OrgId { get; set; }
        public string OrgFriendlyName { get; set; }
        public string LocalTime { get; set; }

        public PingMessage()
        {
            OrgId = new Random().Next(1, 100);
            OrgFriendlyName = string.Format("Office_{0}_{1}", OrgId, DateTime.Now.ToString("YYMMdd-HHmmss"));
        }
        public override string ToString()
        {
            return string.Format("PING> CorrId={0} (Node={1} App={2}):   LocalTime={3}", 
                CorrelationId, 
                NodeId,
                AppId,
                LocalTime);
        }
    }
}
