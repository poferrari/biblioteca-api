using BibliotecaVirtual.Api.Data;
using BibliotecaVirtual.Api.Dtos;
using BibliotecaVirtual.Api.Filtros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Api.Controllers
{
    [Route("api/relatorio-livros")]
    [ApiController]
    public class RelatorioDeLivrosController : ControllerBase
    {
        private readonly BibliotecaContexto _context;

        public RelatorioDeLivrosController(BibliotecaContexto context)
        {
            _context = context;
        }

        [HttpGet("include")]
        public async Task<ActionResult<IEnumerable<RelatorioDeLivroDto>>> GetComInclude([FromQuery]LivroFiltro filtro)
        {
            return await _context.Livros
                             .Include(t => t.Editora)
                             .Where(t => (!filtro.EditoraId.HasValue || t.EditoraId == filtro.EditoraId)
                                && (string.IsNullOrEmpty(filtro.Titulo) || t.Titulo.Contains(filtro.Titulo)))
                             .Select(t => new RelatorioDeLivroDto
                             {
                                 LivroId = t.Id,
                                 AnoPublicacao = t.AnoPublicacao,
                                 TituloDoLivro = t.Titulo,
                                 NomeDaEditora = t.Editora.Nome
                             })
                             .ToListAsync();
        }

        [HttpGet("linq-query-syntax")]
        public async Task<ActionResult<IEnumerable<RelatorioDeLivroDto>>> GetComLinqQuerySyntax([FromQuery]LivroFiltro filtro)
        {
            return await (from liv in _context.Livros
                          join edi in _context.Editoras
                              on liv.EditoraId equals edi.Id
                          where (!filtro.EditoraId.HasValue || liv.EditoraId == filtro.EditoraId)
                            && (string.IsNullOrEmpty(filtro.Titulo) || liv.Titulo.Contains(filtro.Titulo))
                          select new RelatorioDeLivroDto
                          {
                              LivroId = liv.Id,
                              AnoPublicacao = liv.AnoPublicacao,
                              TituloDoLivro = liv.Titulo,
                              NomeDaEditora = edi.Nome
                          }).ToListAsync();
        }

        [HttpGet("linq-method-syntax")]
        public async Task<ActionResult<IEnumerable<RelatorioDeLivroDto>>> GetComLinqMethodSyntax([FromQuery]LivroFiltro filtro)
        {
            return await _context.Livros
                            .Join(_context.Editoras,
                                itemJoin => itemJoin.EditoraId,
                                pedJoin => pedJoin.Id,
                                (itemJoin, pedJoin) => new { liv = itemJoin, edi = pedJoin })
                            .Where(t => (!filtro.EditoraId.HasValue || t.liv.EditoraId == filtro.EditoraId)
                                && (string.IsNullOrEmpty(filtro.Titulo) || t.liv.Titulo.Contains(filtro.Titulo)))
                            .Select(t => new RelatorioDeLivroDto
                            {
                                LivroId = t.liv.Id,
                                AnoPublicacao = t.liv.AnoPublicacao,
                                TituloDoLivro = t.liv.Titulo,
                                NomeDaEditora = t.edi.Nome
                            })
                            .ToListAsync();
        }
    }
}