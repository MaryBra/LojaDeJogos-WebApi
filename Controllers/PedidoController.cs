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
    public class PedidoController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public PedidoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult> Cadastrar(Pedido pedido)
        {
            if (_dbContext is null)
                return NotFound();

            await _dbContext.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return Created("", pedido);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Pedido>> > Listar()
        {
            if (_dbContext is null)
                return NotFound();

            return await _dbContext.Pedido.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{Id}")]
        public async Task<ActionResult<Pedido>> Buscar(int idPedido)
        {
            if (_dbContext is null)
                return NotFound();

            var pedidoTemp = await _dbContext.Pedido.FindAsync(idPedido);
            if (pedidoTemp is null)
                return NotFound();

            return pedidoTemp;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Pedido pedido)
        {
            if (_dbContext is null)
                return NotFound();

            var pedidoTemp = await _dbContext.Pedido.FindAsync(pedido.IdPedido);
            if (pedidoTemp is null)
                return NotFound();

            _dbContext.Pedido.Update(pedido);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int idPedido)
        {
            if (_dbContext is null)
                return NotFound();

            var pedidoTemp = await _dbContext.Pedido.FindAsync(idPedido);
            if (pedidoTemp is null)
                return NotFound();

            _dbContext.Remove(pedidoTemp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
