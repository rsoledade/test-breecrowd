using Teste.Tecnologia.Domain.Entities;
using Teste.Tecnologia.Domain.Interfaces.Repositories;

namespace Teste.Tecnologia.Infrastructure.Data.Repository
{
    public class ItemCompraRepository : RepositoryBase<ItemCompra>, IItemCompraRepository
    {
        public ItemCompraRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task AddRangeAsync(IEnumerable<ItemCompra> items)
        {
            _dbSet.AddRange(items);
            _context.SaveChanges();
        }

        public async Task RemoveRangeAsync(IEnumerable<ItemCompra> items)
        {
            _dbSet.RemoveRange(items);
            _context.SaveChanges();
        }
    }
}
