using System;
namespace Converge.Messages
{
    public interface ICommandMessage 
    {
        string Command { get; set; }
        Guid CorrelationId { get; set; }
        string IssuingPrincipal { get; set; }
        string Parameters { get; set; }
        string TargetNodeApplication { get; set; }
        string TargetNodeId { get; set; }
    }
}
