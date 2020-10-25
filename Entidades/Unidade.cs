﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp_asp_academy.Entidades
{
    public class Unidade
    {
        // CONSTRUTOR PÚBLICO SEM PARÂMETRO PARA ACESSO AO BANCO DE DADOS
        protected Unidade() { }
       
        public Unidade(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
            Alunos = new List<Aluno>();
            Professores = new List<Professor>();
        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public List<Aluno> Alunos { get; private set; }
        public List<Professor> Professores { get; private set; }


    }
}
