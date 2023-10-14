using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Produto{

    [Key]
    public  int IdProduto {get; set;}
    public  string? NomeProduto{get; set;}
    public string?  Descricao {get; set;}
    public float Preco {get; set;}
    public string? Classificacao {get; set;}
    public string?  Desenvolvedor{get; set;}
    public string?  Plataforma{get; set;}
    public string? Estoque{get; set;}


}