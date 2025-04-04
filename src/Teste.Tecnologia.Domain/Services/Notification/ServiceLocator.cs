using Teste.Tecnologia.Domain.Interfaces.Notification;

namespace Teste.Tecnologia.Domain.Services.Notification
{
    public static class ServiceLocator
    {
        public static IContainer Container { get; private set; }

        public static void Initialize(IContainer container)
        {
            Container = container;
        }
    }
}
