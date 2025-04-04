﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Teste.Tecnologia.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Teste.Tecnologia.Infrastructure.Data.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(256);

            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 2);
            
            configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp");

            configurationBuilder.Conventions.Remove(typeof(ManyToManyCascadeDeleteConvention));
            configurationBuilder.Conventions.Remove(typeof(OneToManyCascadeDeleteConvention));

            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
