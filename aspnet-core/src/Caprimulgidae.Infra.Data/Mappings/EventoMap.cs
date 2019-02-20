using Caprimulgidae.Domain.Models.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caprimulgidae.Infra.Data.Mappings
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdAreaConhecimento)
                .HasColumnType("varchar(36)")
                .HasMaxLength(36);

            builder.Property(c => c.Token)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Padrao)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.AreaConhecimento)
                .WithMany(x => x.Eventos)
                .HasForeignKey(x => x.IdAreaConhecimento);

            builder.Property(c => c.ProbabilidadeAcontecer)
                .IsRequired();

            builder.Property(c => c.ProbabilidadeNaoAcontecer)
                .IsRequired();
        }
    }
}
