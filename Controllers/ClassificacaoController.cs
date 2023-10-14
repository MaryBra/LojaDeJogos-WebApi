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
    public class ClassificacaoController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public ClassificacaoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult> Cadastrar(Classificacao classificacao)
        {
            if (_dbContext is null)
                return NotFound();

            await _dbContext.AddAsync(classificacao);
            await _dbContext.SaveChangesAsync();
            return Created("", classificacao);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Classificacao>> > Listar()
        {
            if (_dbContext is null)
                return NotFound();

            return await _dbContext.Classificacao.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{Id}")]
        public async Task<ActionResult<Classificacao>> Buscar(int idClassificacao)
        {
            if (_dbContext is null)
                return NotFound();

            var classificacaoTemp = await _dbContext.Classificacao.FindAsync(idClassificacao);
            if (classificacaoTemp is null)
                return NotFound();

            return classificacaoTemp;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Classificacao classificacao)
        {
            if (_dbContext is null)
                return NotFound();

            var classificacaoTemp = await _dbContext.Classificacao.FindAsync(classificacao.IdClassificacao);
            if (classificacaoTemp is null)
                return NotFound();

            _dbContext.Classificacao.Update(classificacao);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int idClassificacao)
        {
            if (_dbContext is null)
                return NotFound();

            var classificacaoTemp = await _dbContext.Classificacao.FindAsync(idClassificacao);
            if (classificacaoTemp is null)
                return NotFound();

            _dbContext.Remove(classificacaoTemp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
