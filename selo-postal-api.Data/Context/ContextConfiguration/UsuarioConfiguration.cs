using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using selo_postal_api.Core.Domain.Entities;

namespace selo_postal_api.Data.Context.ContextConfiguration
{
    [ExcludeFromCodeCoverage]
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder
               .Property(e => e.Login)
               .HasColumnName("login");
            
            builder
               .Property(e => e.Password)
               .HasColumnName("password");

            builder
               .Property(e => e.Role)
               .HasColumnName("role");
        }

    }
}