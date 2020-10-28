using bootcamp_asp_academy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp_asp_academy.Entidades
{
    public class Aluno
    {
        protected Aluno() { } 
        public Aluno(string nome, string endereco, DateTime datanascimento)
        {
            Nome = nome;
            Endereco = endereco;
            DataNascimento = datanascimento;
            Status = StatusAlunoEnum.Ativo;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public StatusAlunoEnum Status { get; set; }

        public int IdUnidade { get; set; }

        public Unidade Unidade { get;  set; }

        public int IdProfessor { get; set; }

        public Professor Professor { get; set; }

    }
}
