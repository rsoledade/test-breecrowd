using Teste.Tecnologia.Domain.Entities;

namespace Teste.Tecnologia.Domain.Interfaces.Services
{
    public interface ICompraService : IServiceBase<Compra>
    {
        Task UpdateAsync(Guid id, Compra compra);
        Task<IEnumerable<Compra>> GetAllAsync();
    }
}
