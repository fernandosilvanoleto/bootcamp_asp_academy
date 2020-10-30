using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp_asp_academy.Entidades;
using bootcamp_asp_academy.InputModel;
using bootcamp_asp_academy.Persistence;
using bootcamp_asp_academy.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_asp_academy.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly BancoContext _bancoContext;
        //ctor -- PARA CRIAR CONSTRUTOR
        public AlunosController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        // SISTEMA SER RECONHECIDO COMO API
        [HttpGet]
        public IActionResult Index()
        {
            var alunos = _bancoContext
                .Alunos
                .ToList();
            var alunosViewModel = alunos
                .Select(a => new AlunoViewModel(a.Nome, a.Status))
                .ToList();
            return Ok(alunosViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _bancoContext.Alunos.SingleOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        /*
        [HttpGet("{id}")]
        public IActionResult BuscarPor_Id(int id)
        {
            // TODO: Trazer unidade e professor
            var aluno = _bancoContext
                .Alunos
                .SingleOrDefault(u => u.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }
        */
        [HttpPost]
        public IActionResult Post([FromBody] AlunoInputModel alunoInputModel)
        {
            /* _bancoContext.Alunos.Add(aluno);
             _bancoContext.SaveChanges();

             return CreatedAtAction(nameof(BuscarPor_Id), aluno, new { id = aluno.Id });
             */
            var professor = new Professor("professor 1", "endereco 1", alunoInputModel.IdUnidade);
            _bancoContext.Professores.Add(professor);
            _bancoContext.SaveChanges();

            //USAR AUTO-MAPPER
            //INSTANCIAR UM ALUNO
            // NÃO DEIXO O ENCAPSULAMENTO DO MEU ENTIDADE/ALUNO ZUADO HEHEHEHE
            var aluno = new Aluno(alunoInputModel.Nome, alunoInputModel.Endereco,
                alunoInputModel.DataNascimento);

            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlunoUpdateInputModel alunoUpdateInputModel)
        {
            var aluno = _bancoContext.Alunos.SingleOrDefault(a => a.Id == id);
            // verificar se existe aluno
            if (aluno == null)
            {
                // ALUNO NÃO ENCONTRADO
                return NotFound();
            }

            aluno.Endereco = alunoUpdateInputModel.Endereco;

            // FAZER UPDATE E ALUNO EXISTENTE
            //_bancoContext.Alunos.Update(aluno);
            _bancoContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _bancoContext.Alunos.SingleOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }
            // EM VEZ DE EXCLUIR -- ALTERAR O STATUS DE ALUNO
            aluno.MudarStatusParaInativo();
            _bancoContext.SaveChanges();

            return Ok();
            
        }

    }
}
