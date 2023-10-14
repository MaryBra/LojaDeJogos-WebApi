using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Carrinho
{
    [Key]
    public int IdCarrinho { get; set; }
    public List<Produto> ItensCarrinho { get; set; } = new List<Produto>();
    
}
