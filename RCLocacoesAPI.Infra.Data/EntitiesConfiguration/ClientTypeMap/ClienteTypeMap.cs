using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Entity.ClientTypeMap
{
    public class ClientTypeMap : IEntityTypeConfiguration<Domain.Entities.ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder.ToTable("ClientType");
            builder.HasKey(p => p.Id);
        }
    }
}
