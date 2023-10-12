using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{
    internal class CostumerConfiguration : IEntityTypeConfiguration<Costumer>
    {
        public void Configure(EntityTypeBuilder<Costumer> builder)
        {
            builder.ToTable("Costumer");
        }
    }
}