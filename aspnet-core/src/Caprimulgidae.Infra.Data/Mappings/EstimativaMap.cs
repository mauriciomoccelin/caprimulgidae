using Caprimulgidae.Domain.Models.Estimativas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caprimulgidae.Infra.Data.Mappings
{
    public class EstimativaMap : IEntityTypeConfiguration<Estimativa>
    {
        public void Configure(EntityTypeBuilder<Estimativa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("varchar(36)")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Priory)
                .IsRequired();

            builder.Property(c => c.Posteriory)
                .IsRequired();

            builder.Property(c => c.Probabilidade)
                .IsRequired();
        }
    }
}
