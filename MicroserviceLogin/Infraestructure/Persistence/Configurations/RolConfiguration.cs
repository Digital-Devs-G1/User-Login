using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Description).HasMaxLength(30).IsRequired();

            builder.HasData(
                new Rol
                {
                    Id = 1,
                    Description = "Admin"
                },
                new Rol
                {
                    Id = 2,
                    Description = "User"
                },
                new Rol
                {
                    Id = 3,
                    Description = "SuperAdmin"

                });
        }
    }
}
