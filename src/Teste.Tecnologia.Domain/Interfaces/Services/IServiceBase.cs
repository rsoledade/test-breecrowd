using Teste.Tecnologia.Domain.Entities;

namespace Teste.Tecnologia.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : EntityBase
    {
        Task<Guid> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<T> GetAsync(Guid id);
    }
}
