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
    public class EditorasController : ControllerBase
    {
        private readonly BibliotecaContexto _context;

        public EditorasController(BibliotecaContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editora>>> Get()
        {
            return await _context.Editoras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editora>> Get(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);

            if (editora == null)            
                return NotFound();            

            return editora;
        }

        [HttpPost]
        public async Task<ActionResult<Editora>> Post(Editora editora)
        {
            _context.Editoras.Add(editora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = editora.Id }, editora);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Editora editora)
        {
            if (id != editora.Id)            
                return BadRequest();

            var editoraBanco = await _context.Editoras.FindAsync(id);

            if (editoraBanco == null)
                return NotFound();

            editoraBanco.Nome = editora.Nome;
            editoraBanco.Apresentacao = editora.Apresentacao;
            
            await _context.SaveChangesAsync();
          
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Editora>> Delete(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);
            if (editora == null)            
                return NotFound();            

            _context.Editoras.Remove(editora);
            await _context.SaveChangesAsync();

            return editora;
        }

        [HttpGet("{id}/livros")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivrosDaEditoraId(int id)
            => await _context.Livros.Where(t => t.EditoraId == id).ToListAsync();
    }
}