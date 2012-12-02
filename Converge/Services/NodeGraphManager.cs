using Converge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Services
{
    public class NodeGraphManager
    {
        private Dictionary<string, NodeRecord> records = new Dictionary<string, NodeRecord>();

        public NodeGraphManager()
        { 
        }

        public NodeRecord GetRecord(string nodeId)
        {
            if (records.ContainsKey(nodeId))
                return records[nodeId];
            return null;
        }

    }
}
