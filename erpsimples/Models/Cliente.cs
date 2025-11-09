using System.ComponentModel.DataAnnotations;

namespace erpsimples.Models;

public class Cliente
{
    [Key] public int IdCliente { get; set; }

    [Required] public string NomeCliente { get; set; }

    [Required] [Phone] [MaxLength(20)] public string Telefone { get; set; } = string.Empty;
}