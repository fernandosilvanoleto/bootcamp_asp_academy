using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp_asp_academy.Entidades;
using bootcamp_asp_academy.Persistence;
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
            var alunos = _bancoContext.Alunos.ToList();

            return Ok(alunos);
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

        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            var professor = new Professor("professor 1", "endereco 1", aluno.IdUnidade);
            _bancoContext.Professores.Add(professor);
            _bancoContext.SaveChanges();

            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
