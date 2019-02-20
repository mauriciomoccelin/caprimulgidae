using Caprimulgidae.Domain.Models.AreasConhecimentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caprimulgidae.Infra.Data.Mappings
{
    public class AreaConhecimentoMap : IEntityTypeConfiguration<AreaConhecimento>
    {
        public void Configure(EntityTypeBuilder<AreaConhecimento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
