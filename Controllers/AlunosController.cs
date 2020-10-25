using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp_asp_academy.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_asp_academy.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        // SISTEMA SER RECONHECIDO COMO API
        [HttpGet]
        public IActionResult Index()
        {
            var alunos = new List<Aluno> {
                new Aluno("fernando", "rua zero", DateTime.Now),
                new Aluno("leide", "rua 1", DateTime.Now),
                new Aluno("rogerio", "rua 9", DateTime.Now)
            };

            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
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
