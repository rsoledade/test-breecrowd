using Microsoft.Extensions.Logging;
using Teste.Tecnologia.Domain.Interfaces.Events;
using Teste.Tecnologia.Domain.Entities.EventMessage;

namespace Teste.Tecnologia.Infrastructure.Events
{
    public class EventPublisherBase<T> : IEventPublisherBase<T> where T : EventMessageBase
    {
        private readonly ILogger<T> _logger;

        public EventPublisherBase(ILogger<T> logger)
        {
            _logger = logger;
        }

        public Task PublishAsync(T message)
        {
            _logger.LogInformation(LogLevel.Information.ToString(), typeof(T).Name, message);

            return Task.CompletedTask;
        }
    }
}
