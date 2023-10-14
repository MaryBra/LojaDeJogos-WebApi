using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Classificacao
{
    [Key]
    public int IdClassificacao{get;set;}

    private string? Genero{get;set;}

    private string? Analise{get;set;}

}
