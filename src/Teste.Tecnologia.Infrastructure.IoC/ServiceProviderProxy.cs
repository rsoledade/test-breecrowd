using Teste.Tecnologia.Domain.Interfaces.Notification;
using Microsoft.AspNetCore.Http;

namespace Teste.Tecnologia.Infrastructure.IoC
{
    public class ServiceProviderProxy : IContainer
    {
        private readonly IHttpContextAccessor _contextAcessor;

        public ServiceProviderProxy(IHttpContextAccessor contextAcessor)
        {
            _contextAcessor = contextAcessor;
        }
        public T GetService<T>(Type type)
        {
            return (T)_contextAcessor.HttpContext.RequestServices.GetService(type);
        }
    }
}
