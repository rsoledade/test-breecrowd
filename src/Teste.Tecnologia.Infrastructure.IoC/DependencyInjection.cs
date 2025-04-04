using Teste.Tecnologia.Domain.Entities;
using Teste.Tecnologia.Domain.Interfaces.Notification;
using Teste.Tecnologia.Domain.Services.Notification;
using Teste.Tecnologia.Infrastructure.Data.Repository;
using Teste.Tecnologia.Infrastructure.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Teste.Tecnologia.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            //Notification
            service.AddScoped<INotification, NotificationService>();
            service.AddSingleton<IContainer, ServiceProviderProxy>();

            //Dependency Injection of Services and Repositories
            service.AddDependencyByName(typeof(EventPublisherBase<>).Assembly, "Publisher");
            service.AddDependencyByName(typeof(RepositoryContext).Assembly, "Repository");
            service.AddDependencyByName(typeof(EntityBase).Assembly, "Service");
        }

        private static void AddDependencyByName(this IServiceCollection service, Assembly assembly, string endFileName)
        {
            var services = assembly.GetTypes().Where(type =>
            type.GetTypeInfo().IsClass && type.Name.EndsWith(endFileName) &&
            !type.GetTypeInfo().IsAbstract);

            foreach (var serviceType in services)
            {
                var allInterfaces = serviceType.GetInterfaces();
                var mainInterfaces = allInterfaces.Except(allInterfaces.SelectMany(t => t.GetInterfaces()));

                foreach (var iServiceType in mainInterfaces)
                {
                    service.AddScoped(iServiceType, serviceType);
                }
            }
        }
    }
}
