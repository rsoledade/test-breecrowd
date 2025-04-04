using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Teste.Tecnologia.Infrastructure.Data.Repository
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            // Aqui você pode carregar a cadeia de conexão de um arquivo de configuração (como appsettings.json)
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();

            // Altere para a cadeia de conexão correta
            optionsBuilder.UseNpgsql("DefaultConnection");

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
