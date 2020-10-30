using bootcamp_asp_academy.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp_asp_academy.Persistence.Configurations
{
    public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.HasKey(u => u.Id);

            // REFERENCIAR FKS EM ENTITY
            builder
                .HasMany(u => u.Alunos)
                .WithOne(a => a.Unidade)
                .HasForeignKey(a => a.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict); // OU CASCADE

            // REFERENCIAR FKS EM ENTITY
            builder
                .HasMany(u => u.Professores)
                .WithOne(p => p.Unidade)
                .HasForeignKey(p => p.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict); // OU CASCADE
        }
    }
}
