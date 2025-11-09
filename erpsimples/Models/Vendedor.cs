using System.ComponentModel.DataAnnotations;

namespace erpsimples.Models;

public class Vendedor
{
    [Key]
    public int IdVendedor { get; set; }
    
    [Required]
    public string NomeVendedor { get; set; } = string.Empty;
}