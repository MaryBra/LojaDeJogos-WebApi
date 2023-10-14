
using System.ComponentModel.DataAnnotations;

public class Cliente{

    [Key]
    public int IdCliente{get;set;}

    public string? NomeCliente{get;set;}
    public string? Endereco{get;set;}
    public long Telefone{get;set;}

}