using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vylexAPI.Data;
using vylexAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace vylexAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound();
            return curso;
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id) return BadRequest();
            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound();
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("with-reviews")]
        public async Task<ActionResult<IEnumerable<object>>> GetCursosWithReviews()
        {
            var cursos = await _context.Cursos
                .Include(c => c.Avaliacoes)
                    .ThenInclude(a => a.Estudante)
                .ToListAsync();

            var result = cursos.Select(curso => new
            {
                curso.Id,
                curso.Nome,
                curso.Descricao,
                Avaliacoes = curso.Avaliacoes.Select(a => new
                {
                    a.Id,
                    EstudanteId = a.EstudanteId,
                    EstudanteNome = a.Estudante.Nome,
                    a.Estrelas,
                    a.Comentario,
                    a.DataHora
                }).ToList()
            });

            return Ok(result);
        }
    }
}
