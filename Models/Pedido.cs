using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido
{
    [Key]
    public int IdPedido { get; set; }

    public DateTime DataPedido { get; set; }

    // Define the foreign key property for the Cliente relationship
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente Cliente { get; set; }

    // Define the foreign key property for the Carrinho relationship
    public int CarrinhoId { get; set; }

    [ForeignKey("CarrinhoId")]
    public Carrinho Carrinho { get; set; }

    // Define the foreign key property for the Pagamento relationship
    public int PagamentoId { get; set; }

    [ForeignKey("PagamentoId")]
    public Pagamento Pagamento { get; set; }

    public string Status { get; set; }
}