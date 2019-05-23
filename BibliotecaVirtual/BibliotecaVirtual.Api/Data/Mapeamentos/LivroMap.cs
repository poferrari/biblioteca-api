using BibliotecaVirtual.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaVirtual.Api.Data.Mapeamentos
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.Resumo)
                .HasMaxLength(500)                
                .IsRequired(false);

            builder.Property(t => t.AnoPublicacao)
                .IsRequired();

            builder.HasOne(t => t.Editora)
              .WithMany()
              .HasForeignKey(t => t.EditoraId);

            builder.ToTable(nameof(Livro));
        }
    }
}
