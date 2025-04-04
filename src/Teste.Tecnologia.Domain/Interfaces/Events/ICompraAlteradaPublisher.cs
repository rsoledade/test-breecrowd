using Teste.Tecnologia.Domain.Entities.EventMessage;

namespace Teste.Tecnologia.Domain.Interfaces.Events
{
    public interface ICompraAlteradaPublisher : IEventPublisherBase<CompraAlteradaMessage>
    {
    }
}
