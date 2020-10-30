using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp_asp_academy.InputModel
{
    public class AlunoInputModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdProfessor { get; set; }
        public int IdUnidade { get; set; }
    }
}
