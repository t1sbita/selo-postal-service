using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Data.Context.ContextConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco");

            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

             builder
                .Property(e => e.Nome)
                .HasColumnName("nome");

            builder
                .Property(e => e.Bairro)
                .HasColumnName("bairro");

            builder
                .Property(e => e.CidadeId)
                .HasDefaultValueSql("1");

            builder
                .Property(e => e.CodigoPostal)
                .IsRequired()
                .HasColumnName("codigoPostal");

            builder
                .Property(e => e.CriadoEm)
                .HasColumnType("date")
                .HasColumnName("criadoEm");

            builder
                .Property(e => e.EnderecoCasa)
                .IsRequired()
                .HasColumnName("enderecoCasa");

            builder
                .Property(e => e.ModificadoEm)
                .HasColumnType("date")
                .HasColumnName("modificadoEm");

            builder
                .Property(e => e.NumeroCasa)
                .IsRequired()
                .HasColumnName("numeroCasa");

            builder
                .HasOne(d => d.Cidade)
                .WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.CidadeId)
                .HasConstraintName("CidadeId");
        }
    }
}