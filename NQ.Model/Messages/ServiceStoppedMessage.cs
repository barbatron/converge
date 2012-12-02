using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQ.Model.Messages
{
    public class ServiceStoppedMessage : BranchMessage
    { 
        public int LocalServiceTypeNumber { get; set; }
        public int LocalUserNumber { get; set; }
        public int LocalCashierNumber { get; set; }
    }
}
