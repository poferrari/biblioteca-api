using BibliotecaVirtual.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Api.Data.Mapeamentos
{
    public class TemaMap : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.Nome)
                .IsUnique();

            builder.Property(t => t.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.ToTable(nameof(Tema));
        }
    }
}
