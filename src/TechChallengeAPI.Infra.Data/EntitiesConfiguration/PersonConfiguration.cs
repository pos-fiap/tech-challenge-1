using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.ToTable("Person");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name).HasColumnType("varchar(50)").HasColumnName("Name").IsRequired();
            builder.Property(p => p.Status).HasColumnType("int").HasColumnName("Status").IsRequired();
            builder.Property(p => p.Document).HasColumnType("varchar(15)").HasColumnName("Document").IsRequired();

        }
    }
}