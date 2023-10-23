using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.UserId).HasColumnType("int").HasColumnName("UserId").IsRequired();
            builder.Property(p => p.RoleId).HasColumnType("int").HasColumnName("RoleId").IsRequired();

        }
    }
}
