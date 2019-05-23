using System.Collections.Generic;

namespace BibliotecaVirtual.Api.Models
{
    public class Tema
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<TemaDoLivro> Livros { get; set; }
    }
}
