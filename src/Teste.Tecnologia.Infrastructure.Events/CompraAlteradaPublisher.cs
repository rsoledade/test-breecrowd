using Teste.Tecnologia.Domain.Entities.EventMessage;
using Teste.Tecnologia.Domain.Interfaces.Events;
using Microsoft.Extensions.Logging;

namespace Teste.Tecnologia.Infrastructure.Events
{
    public class CompraAlteradaPublisher : EventPublisherBase<CompraAlteradaMessage>, ICompraAlteradaPublisher
    {
        public CompraAlteradaPublisher(ILogger<CompraAlteradaMessage> logger) : base(logger)
        {
        }
    }
}
