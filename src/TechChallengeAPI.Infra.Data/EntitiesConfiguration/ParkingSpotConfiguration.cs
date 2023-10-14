using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{

    public class ParkingSpotConfiguration : IEntityTypeConfiguration<ParkingSpot>
    {
        public void Configure(EntityTypeBuilder<ParkingSpot> builder)
        {
            builder.ToTable("ParkingSpot");
        }
    }
}