using Microsoft.EntityFrameworkCore;
using erpsimples.Models;

namespace erpsimples.Data;

public class Bancodedados : DbContext
{
    public Bancodedados(DbContextOptions<Bancodedados> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Vendedor> Venda { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Venda> Vendas { get; set; }
}