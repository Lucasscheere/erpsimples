using Microsoft.AspNetCore.Mvc;
using erpsimples.Data;
using erpsimples.Models;

namespace erpsimples.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly Bancodedados _context;

    public ProdutoController(Bancodedados context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Produtos.ToList());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _context.Produtos.Find(id);
        return produto == null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public IActionResult Create(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = produto.IdProduto }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Produto produto)
    {
        if (id != produto.IdProduto) return BadRequest();
        _context.Produtos.Update(produto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}