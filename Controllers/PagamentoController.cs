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
    public class PagamentoController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public PagamentoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult> Cadastrar(Pagamento pagamento)
        {
            if (_dbContext is null)
                return NotFound();

            await _dbContext.AddAsync(pagamento);
            await _dbContext.SaveChangesAsync();
            return Created("", pagamento);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Pagamento>> > Listar()
        {
            if (_dbContext is null)
                return NotFound();

            return await _dbContext.Pagamento.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{Id}")]
        public async Task<ActionResult<Pagamento>> Buscar(int idPagamento)
        {
            if (_dbContext is null)
                return NotFound();

            var pagamentoTemp = await _dbContext.Pagamento.FindAsync(idPagamento);
            if (pagamentoTemp is null)
                return NotFound();

            return pagamentoTemp;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Pagamento pagamento)
        {
            if (_dbContext is null)
                return NotFound();

            var pagamentoTemp = await _dbContext.Pagamento.FindAsync(pagamento.IdPagamento);
            if (pagamentoTemp is null)
                return NotFound();

            _dbContext.Pagamento.Update(pagamento);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int idPagamento)
        {
            if (_dbContext is null)
                return NotFound();

            var pagamentoTemp = await _dbContext.Pagamento.FindAsync(idPagamento);
            if (pagamentoTemp is null)
                return NotFound();

            _dbContext.Remove(pagamentoTemp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
