using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQ.Model.Messages
{
    public class TicketServedMessage : BranchMessage
    {
        // What ticket was served?
        public string TicketName { get; set; }
        
        // What kind of service, in which cashier, and who served this ticket?
        public int LocalServiceTypeNumber { get; set; }
        public int LocalUserNumber { get; set; }
        public int LocalCashierNumber { get; set; }

        // Serve stats
        public int ServingTimeSeconds { get; set; }

    }
}
