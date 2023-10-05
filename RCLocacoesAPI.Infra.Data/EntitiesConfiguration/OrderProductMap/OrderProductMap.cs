using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Entity.OrderProductMap
{
    public class OrderProductMap : IEntityTypeConfiguration<Domain.Entities.OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");
            builder.HasKey(p => new { p.ProductId, p.OrderId });
            builder.Property(p => p.RentPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.ReplacementCost).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
