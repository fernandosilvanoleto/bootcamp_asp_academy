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
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; private set; }
        public StatusAlunoEnum Status { get; private set; }

        public int IdUnidade { get; private set; }

        public Unidade Unidade { get; private set; }

        public int IdProfessor { get; private set; }

        public Professor Professor { get; private set; }

        public void MudarStatusParaInativo()
        {
            if (Status != StatusAlunoEnum.Ativo)
            {
                throw new Exception("Estado inválido.");
            }

            Status = StatusAlunoEnum.Inativo;
        }

    }
}
