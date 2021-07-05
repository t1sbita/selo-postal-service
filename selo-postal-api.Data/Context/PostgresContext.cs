using Microsoft.EntityFrameworkCore;
using System;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Data.Context.ContextConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace selo_postal_api.Data.Context
{
    [ExcludeFromCodeCoverage]
    public partial class PostgresContext : DbContext
    {
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

        public PostgresContext() { }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder
                .UseNpgsql("PostgresContext");
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CidadeConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        }

    }

}
