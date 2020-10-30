using bootcamp_asp_academy.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp_asp_academy.Persistence.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(a => a.Id);

            // REFERENCIAR FKS EM ENTITY
            builder.HasMany(p => p.Alunos)
                .WithOne(a => a.Professor)
                .HasForeignKey(a => a.IdProfessor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
