using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{

    public class CustomerVehicleConfiguration : IEntityTypeConfiguration<CustomerVehicle>
    {
        public void Configure(EntityTypeBuilder<CustomerVehicle> builder)
        {
            builder.ToTable("CustomerVehicle");
        }
    }
}