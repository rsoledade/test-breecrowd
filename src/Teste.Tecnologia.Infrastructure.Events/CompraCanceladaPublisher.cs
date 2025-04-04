using Teste.Tecnologia.Domain.Entities.EventMessage;
using Teste.Tecnologia.Domain.Interfaces.Events;
using Microsoft.Extensions.Logging;

namespace Teste.Tecnologia.Infrastructure.Events
{
    public class CompraCanceladaPublisher : EventPublisherBase<CompraCanceladaMessage>, ICompraCanceladaPublisher
    {
        public CompraCanceladaPublisher(ILogger<CompraCanceladaMessage> logger) : base(logger)
        {
        }
    }
}
