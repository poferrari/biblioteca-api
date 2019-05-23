using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Api.Models
{
    public class Editora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apresentacao { get; set; }

        public List<Livro> Livros { get; set; }
    }
}
