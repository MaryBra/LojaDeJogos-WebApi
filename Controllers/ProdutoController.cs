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
    public class ProdutoController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public ProdutoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Produto>> > Listar()
        {
            if (_dbContext is null)
                return NotFound();

            return await _dbContext.Produto.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Produto>> Buscar(int id)
        {
            if (_dbContext is null)
                return NotFound();

            var produto = await _dbContext.Produto.FindAsync(id);

            if (produto is null)
                return NotFound();

            return produto;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] Produto produto)
        {
            if (_dbContext is null)
                return NotFound();

            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return Created("", produto);
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Produto produto)
        {
            if (_dbContext is null)
                return NotFound();

            var produtoExistente = await _dbContext.Produto.FindAsync(id);

            if (produtoExistente is null)
                return NotFound();

            produtoExistente.NomeProduto = produto.NomeProduto;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Classificacao = produto.Classificacao;
            produtoExistente.Desenvolvedor = produto.Desenvolvedor;
            produtoExistente.Plataforma = produto.Plataforma;
            produtoExistente.Estoque = produto.Estoque;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_dbContext is null)
                return NotFound();

            var produto = await _dbContext.Produto.FindAsync(id);

            if (produto is null)
                return NotFound();

            _dbContext.Produto.Remove(produto);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
