namespace BibliotecaVirtual.Api.Models
{
    public class TemaDoLivro
    {
        public int TemaId { get; set; }
        public int LivroId { get; set; }

        public Tema Tema { get; set; }
        public Livro Livro { get; set; }
    }
}
