using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQ.Model.Messages
{
    public class BranchMessage
    {
        /// <summary>
        /// Gets or sets the branch id (office guid, usually).
        /// </summary>
        /// <value>
        /// The branch id.
        /// </value>
        public string BranchId { get; set; }
    }
}
