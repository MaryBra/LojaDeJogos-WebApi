using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Desenvolvedor{

    [Key]
    public int IdDesenvolvedor{get;set;}
    public string? NomeDesenvolvedor{get;set;}
    public string? Historico{get;set;}
    public string? JogosProduzidos{get;set;}

}