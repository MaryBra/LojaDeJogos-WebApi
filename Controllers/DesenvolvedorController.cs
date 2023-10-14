using LojaDeJogos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaDeJogos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesenvolvedorController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public DesenvolvedorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult> Cadastrar(Desenvolvedor desenvolvedor)
        {
            if (_dbContext is null)
                return NotFound();

            await _dbContext.AddAsync(desenvolvedor);
            await _dbContext.SaveChangesAsync();
            return Created("", desenvolvedor);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Desenvolvedor>> > Listar()
        {
            if (_dbContext is null)
                return NotFound();

            return await _dbContext.Desenvolvedor.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{Id}")]
        public async Task<ActionResult<Desenvolvedor>> Buscar(int idDesenvolvedor)
        {
            if (_dbContext is null)
                return NotFound();

            var desenvolvedorTemp = await _dbContext.Desenvolvedor.FindAsync(idDesenvolvedor);
            if (desenvolvedorTemp is null)
                return NotFound();

            return desenvolvedorTemp;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Desenvolvedor desenvolvedor)
        {
            if (_dbContext is null)
                return NotFound();

            var desenvolvedorTemp = await _dbContext.Desenvolvedor.FindAsync(desenvolvedor.IdDesenvolvedor);
            if (desenvolvedorTemp is null)
                return NotFound();

            _dbContext.Desenvolvedor.Update(desenvolvedor);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int idDesenvolvedor)
        {
            if (_dbContext is null)
                return NotFound();

            var desenvolvedorTemp = await _dbContext.Desenvolvedor.FindAsync(idDesenvolvedor);
            if (desenvolvedorTemp is null)
                return NotFound();

            _dbContext.Remove(desenvolvedorTemp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
