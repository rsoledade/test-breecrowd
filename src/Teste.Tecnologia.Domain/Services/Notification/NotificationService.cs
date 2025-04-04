using Teste.Tecnologia.Domain.Entities.Notification;
using Teste.Tecnologia.Domain.Interfaces.Notification;

namespace Teste.Tecnologia.Domain.Services.Notification
{
    public class NotificationService : INotification
    {
        public NotificationService()
        {
            Errors = new List<NotificationError>();
        }

        public IList<NotificationError> Errors { get ; set; }
        public bool HasNotification { get => Errors.Any(); }

        public void AddError(string context, string message)
        {
            Errors.Add(new NotificationError { Context = context, Message = message});
        }
    }
}
