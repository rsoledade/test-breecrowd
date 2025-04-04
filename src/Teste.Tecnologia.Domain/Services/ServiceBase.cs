using Teste.Tecnologia.Domain.Entities;
using Teste.Tecnologia.Domain.Interfaces.Repositories;
using Teste.Tecnologia.Domain.Interfaces.Services;

namespace Teste.Tecnologia.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual Task<Guid> CreateAsync(T entity)
        {
            return _repository.CreateAsync(entity);
        }

        public virtual Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        public virtual Task<T> GetAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public virtual Task UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
