using Teste.Tecnologia.Domain.Entities.EventMessage;

namespace Teste.Tecnologia.Domain.Interfaces.Events
{
    public interface IEventPublisherBase<T> where T : EventMessageBase
    {
        Task PublishAsync(T message);
    }
}
