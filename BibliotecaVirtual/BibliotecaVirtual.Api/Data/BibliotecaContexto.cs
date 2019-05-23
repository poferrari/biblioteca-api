using BibliotecaVirtual.Api.Data.Mapeamentos;
using BibliotecaVirtual.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Api.Data
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options)
           : base(options) { }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<TemaDoLivro> TemasDoLivro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EditoraMap());
            modelBuilder.ApplyConfiguration(new TemaMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new TemaDoLivroMap());
        }
    }
}
