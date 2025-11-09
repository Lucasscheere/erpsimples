using System.ComponentModel.DataAnnotations;

namespace erpsimples.Models;

public class Produto
{
    [Key]
    public int IdProduto { get; set; }

    [Required]
    public string NomeProduto { get; set; } = string.Empty;

    [Required]
    public decimal PrecoProduto { get; set; }
}