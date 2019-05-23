using System.Collections.Generic;

namespace BibliotecaVirtual.Api.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public int AnoPublicacao { get; set; }
        public int EditoraId { get; set; }

        public Editora Editora { get; set; }
        public List<TemaDoLivro> Temas { get; set; }
    }
}
