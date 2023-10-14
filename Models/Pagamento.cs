
using System.ComponentModel.DataAnnotations;

public class Pagamento{

    [Key]
    public int IdPagamento{get;set;}
    private string? FormaPagamento{get;set;}
    private float Total{get;set;}
    private string? Endereco{get;set;}

}