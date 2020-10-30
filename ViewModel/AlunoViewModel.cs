using bootcamp_asp_academy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp_asp_academy.ViewModel
{
    public class AlunoViewModel
    {
        public AlunoViewModel(string nome, StatusAlunoEnum status)
        {
            Nome = nome;
            Status = status;
        }

        public string Nome { get; private set; }
        public StatusAlunoEnum Status { get; private set; }
    }
}
