using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidasController : ControllerBase
    {
        private readonly estoque_treinamentoContext _context;

        public UnidadesMedidasController(estoque_treinamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadesMedida>>> GetUnidadesMedidas()
        {
            return await _context.UnidadesMedidas.ToListAsync();
        }

        [HttpGet("{sigla}")]
        public async Task<ActionResult<UnidadesMedida>> GetUnidadesMedida(string sigla)
        {
            var unidadesMedida = await _context.UnidadesMedidas.FindAsync(sigla);

            if (unidadesMedida == null)
            {
                return NotFound();
            }

            return unidadesMedida;
        }

        [HttpPut("{sigla}")]
        public async Task<IActionResult> PutUnidadesMedida(string sigla, UnidadesMedida unidadesMedida)
        {
            if (sigla != unidadesMedida.Sigla)
            {
                return BadRequest();
            }

            _context.Entry(unidadesMedida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpDelete("{sigla}")]
        public async Task<IActionResult> DeleteUnidadesMedida(string sigla)
        {
            var unidadesMedida = await _context.UnidadesMedidas.FindAsync(sigla);
            if (unidadesMedida == null)
            {
                return NotFound();
            }

            _context.UnidadesMedidas.Remove(unidadesMedida);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<UnidadesMedida>> PostUnidadesMedida(UnidadesMedida unidadesMedida)
        {
            _context.UnidadesMedidas.Add(unidadesMedida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadesMedida", new { sigla = unidadesMedida.Sigla }, unidadesMedida);
        }
    }
}