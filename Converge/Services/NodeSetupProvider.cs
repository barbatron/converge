using Converge.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converge.Services
{
    /// <summary>
    /// Responds to node setup requests, providing basic identity and route information, in case
    /// going straight to HQ isn't a viable solution.
    /// </summary>
    public class NodeSetupProvider
        :  Consumes<NodeSetupRequest>.Context
    {
        public Guid CorrelationId { get; set; }

        public NodeSetupProvider(Guid correlationId)
        {
            Console.WriteLine("NodeSetupProvider created");
            CorrelationId = correlationId;
        }

        public void Consume(IConsumeContext<NodeSetupRequest> message)
        {
            var response = new NodeSetupResponse 
            { 
                CorrelationId = this.CorrelationId
            };
            message.Respond(response);
        }
    }
}
