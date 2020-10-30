using bootcamp_asp_academy.Entidades;
using bootcamp_asp_academy.Persistence.Configurations;
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
            // CARREGAR AS CONFIGURAÇÕES POR ENTIDADE EM "persistence/configurations"
            modelBuilder.ApplyConfiguration(new UnidadeConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());


        }

    }
}
