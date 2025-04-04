using Teste.Tecnologia.Domain.Entities.EventMessage;

namespace Teste.Tecnologia.Domain.Interfaces.Events
{
    public interface ICompraCanceladaPublisher : IEventPublisherBase<CompraCanceladaMessage>
    {
    }
}
