using Microsoft.AspNetCore.Mvc;
using erpsimples.Data;
using erpsimples.Models;


namespace erpsimples.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly Bancodedados _context;

        public VendaController(Bancodedados context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Vendas.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var venda = _context.Vendas.Find(id);
            return venda == null ? NotFound() : Ok(venda);
        }

        [HttpPost]
        public IActionResult Create(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = venda.IdVenda }, venda);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Venda venda)
        {
            if (id != venda.IdVenda) return BadRequest();
            _context.Vendas.Update(venda);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var venda = _context.Vendas.Find(id);
            if (venda == null) return NotFound();
            _context.Vendas.Remove(venda);
            _context.SaveChanges();
            return NoContent();
        }
    }
}