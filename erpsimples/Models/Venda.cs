using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace erpsimples.Models;

public class Venda
{
    [Key] public int IdVenda { get; set; }
    
    [Required]
    [ForeignKey(nameof(Produto))] public int IdProduto { get; set; }
    public Produto Produto { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(Vendedor))] public int IdVendedor { get; set; }
    public Vendedor Vendedor { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(Cliente))] public int IdCliente { get; set; }
    
    [Required]
    public int Quantidade { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorTotal { get; set; }
}