using Microsoft.EntityFrameworkCore;
using selo_postal_api.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selo_postal_api.Data.Context
{
    public partial class PostgresContext : DbContext
    {
        public DbSet<Etiqueta> Etiqueta { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cidade> Cidade { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Server=localhost;Port=5432;Database=Particular;User Id=postgres;Password=elias1993;");
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging(true);

        }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252");

    //        modelBuilder.Entity<Cidade>(entity =>
    //        {
    //            entity.ToTable("cidade");

    //            entity.Property(e => e.Id)
    //                .HasColumnName("id")
    //                .UseIdentityAlwaysColumn();

    //            entity.Property(e => e.Estado).HasColumnName("estado");

    //            entity.Property(e => e.Municipio).HasColumnName("municipio");
    //        });

    //        modelBuilder.Entity<Endereco>(entity =>
    //        {
    //            entity.ToTable("endereco");

    //            entity.Property(e => e.Id)
    //                .HasColumnName("id")
    //                .UseIdentityAlwaysColumn();

    //            entity.Property(e => e.Bairro).HasColumnName("bairro");

    //            entity.Property(e => e.CidadeId).HasDefaultValueSql("1");

    //            entity.Property(e => e.CodigoPostal)
    //                .IsRequired()
    //                .HasColumnName("codigoPostal");

    //            entity.Property(e => e.CriadoEm)
    //                .HasColumnType("date")
    //                .HasColumnName("criadoEm");

    //            entity.Property(e => e.EnderecoCasa)
    //                .IsRequired()
    //                .HasColumnName("enderecoCasa");

    //            entity.Property(e => e.ModificadoEm)
    //                .HasColumnType("date")
    //                .HasColumnName("modificadoEm");

    //            entity.Property(e => e.NumeroCasa)
    //                .IsRequired()
    //                .HasColumnName("numeroCasa");

    //            entity.HasOne(d => d.Cidade)
    //                .WithMany(p => p.Enderecos)
    //                .HasForeignKey(d => d.CidadeId)
    //                .HasConstraintName("CidadeId");
    //        });

    //        modelBuilder.Entity<Etiqueta>(entity =>
    //        {
    //            entity.ToTable("etiqueta");

    //            entity.Property(e => e.Id)
    //                .HasColumnName("id")
    //                .HasIdentityOptions(1001L, null, null, null, null, null);

    //            entity.Property(e => e.CodigoQr)
    //                .IsRequired()
    //                .HasColumnName("codigoQr");

    //            entity.HasOne(d => d.Endereco)
    //                .WithOne(p => p.Etiqueta)
    //                .HasForeignKey<Endereco>(d => d.EnderecoId)
    //                .HasConstraintName("endereco_fk");
    //        });

    //        OnModelCreatingPartial(modelBuilder);
    //    }

    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    //}

    }

}
