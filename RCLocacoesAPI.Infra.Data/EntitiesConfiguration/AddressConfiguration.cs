using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Infra.Data.EntitiesConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Country).HasColumnType("varchar(50)").HasColumnName("Country").IsRequired();
            builder.Property(p => p.ZipCode).HasColumnType("int").HasColumnName("ZipCode").IsRequired();
            builder.Property(p => p.State).HasColumnType("varchar(50)").HasColumnName("State").IsRequired();
            builder.Property(p => p.City).HasColumnType("varchar(50)").HasColumnName("City").IsRequired();
            builder.Property(p => p.Street).HasColumnType("varchar(250)").HasColumnName("Street").IsRequired();
            builder.Property(p => p.Number).HasColumnType("varchar(20)").HasColumnName("Number").IsRequired();
            builder.Property(p => p.AdditionalDetails).HasColumnType("varchar(250)").HasColumnName("AdditionalDetails").IsRequired();

        }
    }
}
