using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Plataforma
{
    [Key]
    public int IdPlataforma{get;set;}
    public string? NomePlataforma{get;set;}
    public List<string>? Jogos{get;set;}

}
