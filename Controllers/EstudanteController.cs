using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using vylexAPI.Data;
using vylexAPI.Models;

namespace vylexAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudanteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstudanteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudante>>> GetEstudantes()
        {
            return await _context.Estudantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudante>> GetEstudante(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null) return NotFound();
            return estudante;
        }

        [HttpPost]
        public async Task<ActionResult<Estudante>> PostEstudante(Estudante estudante)
        {
            _context.Estudantes.Add(estudante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEstudante), new { id = estudante.Id }, estudante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudante(int id, Estudante estudante)
        {
            if (id != estudante.Id) return BadRequest();
            _context.Entry(estudante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudante(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null) return NotFound();
            _context.Estudantes.Remove(estudante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
