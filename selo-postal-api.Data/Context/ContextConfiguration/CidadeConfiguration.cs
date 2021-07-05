using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Data.Context.ContextConfiguration
{
    [ExcludeFromCodeCoverage]
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {

            builder
                .ToTable("cidade");

            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder
                .Property(e => e.Estado)
                .HasColumnName("estado");

            builder
                .Property(e => e.Municipio)
                .HasColumnName("municipio");
     
        }
    }
}