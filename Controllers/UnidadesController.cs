using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp_asp_academy.Entidades;
using bootcamp_asp_academy.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Put(int id, [FromBody] Unidade unidade)
        {
            // verificar se existe UNIDADE
            if (!(await _bancoContext.Unidades.AnyAsync(a => a.Id == id)))
            {
                // UNIDADE NÃO ENCONTRADA
                return NotFound();
            }

            // FAZER UPDATE DE UNIDADE EXISTENTE
            //_bancoContext.Unidades.Update(unidade);
            _bancoContext.Entry(unidade).State = EntityState.Modified;
            await _bancoContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
