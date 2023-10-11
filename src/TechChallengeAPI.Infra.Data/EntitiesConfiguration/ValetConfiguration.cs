using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{
    public class ValetConfiguration : IEntityTypeConfiguration<Valet>
    {
        public void Configure(EntityTypeBuilder<Valet> builder)
        {
            builder.ToTable("Valet");

            builder.Property(p => p.CNH).HasColumnType("varchar(15)").HasColumnName("UserId").IsRequired();
            builder.Property(p => p.CNHExpiration).HasColumnType("datetime").HasColumnName("RoleId").IsRequired();

        }
    }
}