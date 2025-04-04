using Teste.Tecnologia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Teste.Tecnologia.Infrastructure.Data.Configuration
{
    public class ItemCompraConfig : IEntityTypeConfiguration<ItemCompra>
    {
        public void Configure(EntityTypeBuilder<ItemCompra> builder)
        {
            builder.ToTable("ItemCompra");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.CodigoProduto)
                .IsRequired();

            builder
                .Property(x => x.Quantidade)
                .IsRequired();

            builder
                .Property(x => x.ValorUnitario)
                .IsRequired();

            builder
                .Property(x => x.Desconto)
                .IsRequired();
        }
    }
}
