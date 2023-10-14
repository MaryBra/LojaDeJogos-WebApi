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
    public class EstoqueController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public EstoqueController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<Estoque>> Listar()
        {
            if (_dbContext is null)
                return NotFound();

            var estoque = new Estoque
            {
                Produtos = await _dbContext.Produto.ToListAsync()
            };

            return estoque;
        }

        [HttpPost]
        [Route("adicionarProduto/{produtoId}")]
        public async Task<ActionResult> AdicionarProduto(int produtoId)
        {
            if (_dbContext is null)
                return NotFound();
            if (_dbContext.Produto is null)
                return NotFound();

            var produto = await _dbContext.Produto.FindAsync(produtoId);
            if (produto is null)
                return NotFound();

            // Supondo que a lista de produtos do estoque já existe no banco de dados
            var estoque = await _dbContext.Estoque.FirstOrDefaultAsync();

            if (estoque == null)
            {
                estoque = new Estoque
                {
                    Produtos = new List<Produto>()
                };
            }

            estoque.Produtos.Add(produto);

            if (estoque.Id == 0)
            {
                _dbContext.Estoque.Add(estoque);
            }
            else
            {
                _dbContext.Estoque.Update(estoque);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
