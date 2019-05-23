using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Api.Dtos
{
    public class RelatorioDeLivroDto
    {
        public int LivroId { get; set; }
        public string TituloDoLivro { get; set; }
        public int AnoPublicacao { get; set; }
        public string NomeDaEditora { get; set; }
    }
}
