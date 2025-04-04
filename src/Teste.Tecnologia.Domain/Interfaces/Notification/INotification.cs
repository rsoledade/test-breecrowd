using Teste.Tecnologia.Domain.Entities.Notification;

namespace Teste.Tecnologia.Domain.Interfaces.Notification
{
    public interface INotification
    {
        public IList<NotificationError> Errors { get; set; }
        public bool HasNotification { get; }
        void AddError(string context, string message);
    }
}
