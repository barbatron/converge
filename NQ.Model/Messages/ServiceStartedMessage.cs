using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQ.Model.Messages
{
    /// <summary>
    /// Indicates a cashier has started dealing with customers in a service type.
    /// </summary>
    public class ServiceStartedMessage : BranchMessage
    {
        public int LocalServiceTypeNumber { get; set; }
        public int LocalUserNumber { get; set; }
        public int LocalCashierNumber { get; set; }

    }
}
