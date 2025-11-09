using Microsoft.AspNetCore.Mvc;
using erpsimples.Data;
using erpsimples.Models;

namespace erpsimples.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendedorController : ControllerBase
{
    private readonly Bancodedados _context;

    public VendedorController(Bancodedados context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Vendedores.ToList());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _context.Produtos.Find(id);
        return produto == null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public IActionResult Create(Vendedor vendedor)
    {
        _context.Vendedores.Add(vendedor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = vendedor.IdVendedor }, vendedor);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Vendedor vendedor)
    {
        if (id != vendedor.IdVendedor) return BadRequest();
        _context.Vendedores.Update(vendedor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var vendedor = _context.Vendedores.Find(id);
        if (vendedor == null) return NotFound();
        _context.Vendedores.Remove(vendedor);
        _context.SaveChanges();
        return NoContent();
    }
}