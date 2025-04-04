using Teste.Tecnologia.Domain.Entities;

namespace Teste.Tecnologia.Domain.Interfaces.Repositories
{
    public interface IItemCompraRepository : IRepositoryBase<ItemCompra>
    {
        Task RemoveRangeAsync(IEnumerable<ItemCompra> items);
        Task AddRangeAsync(IEnumerable<ItemCompra> items);
    }
}
