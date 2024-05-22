using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosCategorias : ControllerBase
    {
        private readonly estoque_treinamentoContext _context;

        public ProdutosCategorias(estoque_treinamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosCategoria>>> GetProdutosCategorias()
        {
            return await _context.ProdutosCategorias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosCategoria>> GetProdutosCategoria(int id)
        {
            var produtosCategoria = await _context.ProdutosCategorias.FindAsync(id);

            if (produtosCategoria == null)
            {
                return NotFound();
            }

            return produtosCategoria;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutosCategoria(int id, ProdutosCategoria produtosCategoria)
        {
            if (id != produtosCategoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtosCategoria).State = EntityState.Modified;

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

        [HttpPost]
        public async Task<ActionResult<ProdutosCategoria>> PostProdutosCategoria(ProdutosCategoria produtosCategoria)
        {
            _context.ProdutosCategorias.Add(produtosCategoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutosCategoria", new { id = produtosCategoria.Id }, produtosCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutosCategoria(int id)
        {
            var produto = await _context.ProdutosCategorias.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.ProdutosCategorias.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    

    }
}
