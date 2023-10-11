using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");


            builder.Property(p => p.Username).HasColumnType("varchar(50)").HasColumnName("Username").IsRequired();
            builder.Property(p => p.PasswordHash).HasColumnType("varchar(250)").HasColumnName("PasswordHash").IsRequired();

        }
    }
}
