using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Entity.LocalMap
{
    public class LocalMap : IEntityTypeConfiguration<Domain.Entities.Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            builder.ToTable("Local");
            builder.HasKey(p => p.Id);


            //Exemplo:
            //builder.HasIndex(p => p.Hash);
            //builder.HasIndex(p => p.RegistroAcademico).IsUnique();

            //builder.Property(p => p.Nome).IsRequired();
            //builder.Property(p => p.NomeSocial).IsRequired();
            //builder.Property(p => p.SexoId).IsRequired();

            //builder.Property(p => p.EscolaId).IsRequired(false);

            //builder.HasOne(p => p.Sexo)
            //    .WithMany(f => f.Alunos)
            //    .HasForeignKey(p => p.SexoId);

            //builder.HasOne(p => p.Usuario)
            //    .WithMany(f => f.Alunos)
            //    .HasForeignKey(p => p.UsuarioId);

            //builder.HasMany(p => p.AlunoContatos)
            //    .WithOne(f => f.Aluno)
            //    .HasForeignKey(f => f.AlunoId);
        }
    }
}
