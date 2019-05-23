using BibliotecaVirtual.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaVirtual.Api.Data.Mapeamentos
{
    public class TemaDoLivroMap : IEntityTypeConfiguration<TemaDoLivro>
    {
        public void Configure(EntityTypeBuilder<TemaDoLivro> builder)
        {
            builder.HasKey(t => new { t.TemaId, t.LivroId });

            builder.HasOne(t => t.Tema)
                .WithMany()
                .HasForeignKey(t => t.TemaId);

            builder.HasOne(t => t.Livro)
                .WithMany(t => t.Temas)
                .HasForeignKey(t => t.LivroId);

            builder.ToTable(nameof(TemaDoLivro));
        }
    }
}
