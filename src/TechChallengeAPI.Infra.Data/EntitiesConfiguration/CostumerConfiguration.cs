using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.EntitiesConfiguration
{
<<<<<<<< HEAD:src/TechChallengeAPI.Infra.Data/EntitiesConfiguration/CustomerConfiguration.cs
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
========
    internal class CostumerConfiguration : IEntityTypeConfiguration<Costumer>
    {
        public void Configure(EntityTypeBuilder<Costumer> builder)
        {
            builder.ToTable("Costumer");
>>>>>>>> 2a00abc54098f34cf5a5a789647fd0c53560a41e:src/TechChallengeAPI.Infra.Data/EntitiesConfiguration/CostumerConfiguration.cs
        }
    }
}