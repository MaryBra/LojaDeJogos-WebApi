using LojaDeJogos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LojaDeJogos.Controllers;

[ApiController]
[Route("[controller]")]
public class CarrinhoController : ControllerBase
{

    private ApplicationDbContext _dbContext;

    public CarrinhoController(ApplicationDbContext dbContext){
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route ("Cadastrar")]

    public async Task<ActionResult> Cadastrar (Carrinho carrinho){
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carrinho is null) return NotFound();
        await _dbContext.AddAsync(carrinho);
        await _dbContext.SaveChangesAsync();
        return Created ("",carrinho);
    }

    [HttpGet]
    [Route("listar")]

    public async Task<ActionResult<IEnumerable<Carrinho>>> Listar(){
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carrinho is null) return NotFound();
        return await _dbContext.Carrinho.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{Id}")]

    public async Task<ActionResult<Carrinho>> Buscar(int idCarrinho){
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carrinho is null) return NotFound();
        var carrinhoTemp = await _dbContext.Carrinho.FindAsync(idCarrinho);
        if(carrinhoTemp is null) return NotFound();
        return carrinhoTemp;
    }

    [HttpPut()]
    [Route("alterar")]

    public async Task<ActionResult> Alterar(Carrinho carrinho){
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carrinho is null) return NotFound();
        var carrinhoTemp = await _dbContext.Carrinho.FindAsync(carrinho.IdCarrinho);
        if(carrinhoTemp is null) return NotFound();       
        _dbContext.Carrinho.Update(carrinho);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
        [Route("adicionarProduto/{carrinho}/{produto}")]
        public async Task<ActionResult> AdicionarProduto(int carrinhoId, int produtoId)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Carrinho is null) return NotFound();
            if (_dbContext.Produto is null) return NotFound();

            var carrinhoTemp = await _dbContext.Carrinho.FindAsync(carrinhoId);
            if (carrinhoTemp is null) return NotFound();

            var produtoTemp = await _dbContext.Produto.FindAsync(produtoId);
            if (produtoTemp is null) return NotFound();

            carrinhoTemp.ItensCarrinho.Add(produtoTemp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }



    [HttpDelete()]
    [Route("excluir/{id}")]

    public async Task<ActionResult> Excluir(int idCarrinho){
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carrinho is null) return NotFound();
        var carrinhoTemp = await _dbContext.Carrinho.FindAsync(idCarrinho);
        if(carrinhoTemp is null) return NotFound();
        _dbContext.Remove(carrinhoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    
}
