using Teste.Tecnologia.Domain.Entities.EventMessage;
using Teste.Tecnologia.Domain.Interfaces.Events;
using Microsoft.Extensions.Logging;

namespace Teste.Tecnologia.Infrastructure.Events
{
    public class CompraCriadaPublisher : EventPublisherBase<CompraCriadaMessage>, ICompraCriadaPublisher
    {
        public CompraCriadaPublisher(ILogger<CompraCriadaMessage> logger) : base(logger)
        {
        }
    }
}
