using Microsoft.AspNetCore.Mvc;
using erpsimples.Data;
using erpsimples.Models;

namespace erpsimples.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly Bancodedados _context;

    public ClienteController(Bancodedados context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Clientes.ToList());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _context.Clientes.Find(id);
        return produto == null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public IActionResult Create(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = cliente.IdCliente }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Cliente cliente)
    {
        if (id != cliente.IdCliente) return BadRequest();
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null) return NotFound();
        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}