using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Estoque
{

    [Key]
    public int Id{get;set;}
    public List<Produto> Produtos{get;set;}

    public Estoque()
    {
        Produtos = new List<Produto>();
    }

}
