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
    public class ClienteController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public ClienteController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        /// <param name="cliente">Os dados do cliente a serem cadastrados.</param>
        /// <returns>O cliente cadastrado.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult> Cadastrar(Cliente cliente)
        {
            if (_dbContext is null)
                return NotFound();

            await _dbContext.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return Created("", cliente);
        }

        /// <summary>
        /// Lista todos os clientes.
        /// </summary>
        /// <returns>Uma lista de clientes.</returns>
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            if (_dbContext is null)
                return NotFound();

            return await _dbContext.Cliente.ToListAsync();
        }
        
        /// <summary>
        /// Busca um cliente pelo ID.
        /// </summary>
        /// <param name="Id">O ID do cliente a ser buscado.</param>
        /// <returns>O cliente encontrado.</returns>
        [HttpGet]
        [Route("buscar/{Id}")]
        public async Task<ActionResult<Cliente>> Buscar(int Id)
        {
            if (_dbContext is null)
                return NotFound();

            var clienteTemp = await _dbContext.Cliente.FindAsync(Id);
            if (clienteTemp is null)
                return NotFound();

            return clienteTemp;
        }

        /// <summary>
        /// Altera os dados de um cliente.
        /// </summary>
        /// <param name="cliente">Os novos dados do cliente.</param>
        /// <returns>Um status Ok se a alteração foi bem-sucedida.</returns>
        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Cliente cliente)
        {
            if (_dbContext is null)
                return NotFound();

            var clienteTemp = await _dbContext.Cliente.FindAsync(cliente.IdCliente);
            if (clienteTemp is null)
                return NotFound();

            _dbContext.Cliente.Update(cliente);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Exclui um cliente pelo ID.
        /// </summary>
        /// <param name="idCliente">O ID do cliente a ser excluído.</param>
        /// <returns>Um status Ok se a exclusão foi bem-sucedida.</returns>
        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int idCliente)
        {
            if (_dbContext is null)
                return NotFound();

            var clienteTemp = await _dbContext.Cliente.FindAsync(idCliente);
            if (clienteTemp is null)
                return NotFound();

            _dbContext.Remove(clienteTemp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
