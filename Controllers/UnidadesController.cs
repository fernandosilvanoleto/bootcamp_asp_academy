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
    [Route("api/unidade")]
    public class UnidadesController : ControllerBase
    {
        private readonly BancoContext _bancoContext;
        //ctor
        public UnidadesController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var unidades = _bancoContext.Unidades.ToList();
            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var unidade = _bancoContext.Unidades.SingleOrDefault(u => u.Id == id);
            if (unidade == null)
            {
                return NotFound();
            }
            return Ok(unidade);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Unidade unidade)
        {
            _bancoContext.Unidades.Add(unidade);
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
