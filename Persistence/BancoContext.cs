using bootcamp_asp_academy.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp_asp_academy.Persistence
{
    public class BancoContext : DbContext
    {
        // BAIXAR NOS PACOTES NEGUET => 25/10/2020
        // ENTITY.SQLSERVER
        // ENTITY.INMEMORY
        // ENTITY.TOOLS

        public BancoContext(DbContextOptions<BancoContext> options)
            :base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Unidade> Unidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Professor>()
                .HasKey(a => a.Id);

            // REFERENCIAR FKS EM ENTITY
            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Alunos)
                .WithOne(a => a.Professor)
                .HasForeignKey(a => a.IdProfessor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Unidade>()
                .HasKey(u => u.Id);

            // REFERENCIAR FKS EM ENTITY
            modelBuilder.Entity<Unidade>()
                .HasMany(u => u.Alunos)
                .WithOne(a => a.Unidade)
                .HasForeignKey(a => a.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict); // OU CASCADE

            // REFERENCIAR FKS EM ENTITY
            modelBuilder.Entity<Unidade>()
                .HasMany(u => u.Professores)
                .WithOne(p => p.Unidade)
                .HasForeignKey(p => p.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict); // OU CASCADE
        }

    }
}
