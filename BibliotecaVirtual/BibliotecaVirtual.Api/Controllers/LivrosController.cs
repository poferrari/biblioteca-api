using BibliotecaVirtual.Api.Data;
using BibliotecaVirtual.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly BibliotecaContexto _context;

        public LivrosController(BibliotecaContexto context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> Get()
        {
            var livros = await _context.Livros               
                .ToListAsync();

            return livros;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> Get(int id)
        {
            var livro = await _context.Livros
                .Include(t => t.Editora)
                .Include(t => t.Temas)
                    .ThenInclude(s => s.Tema)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (livro == null)            
                return NotFound();            

            return livro;
        }       
        
        [HttpPost]
        public async Task<ActionResult<Livro>> Post(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = livro.Id }, livro);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livro>> Delete(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)            
                return NotFound();            

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        [HttpGet("{id}/temas")]
        public async Task<ActionResult<IEnumerable<TemaDoLivro>>> GetTemasDoLivroId(int id)
           => await _context.TemasDoLivro
                       .Include(t => t.Tema)
                       .Where(t => t.LivroId == id).ToListAsync();       
    }
}
