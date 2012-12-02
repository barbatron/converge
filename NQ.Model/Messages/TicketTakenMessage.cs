using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQ.Model.Messages
{
    /// <summary>
    /// Indicates a ticket was enqueued at a branch.
    /// </summary>
    public class TicketTakenMessage : BranchMessage
    {
        // What ticket was given?
        public string TicketName { get; set; }

        public int LocalServiceTypeNumber { get; set; }
        
    }
}
