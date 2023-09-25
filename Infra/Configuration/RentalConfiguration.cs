using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebExercicios.Infra.Database.Models;

namespace WebExercicios.Infra.Configuration;
public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("rental");
        builder.HasKey(x => x.Rental_id);

        builder.Property(s => s.Situacao)
            .HasColumnName("situacao")
            .HasConversion(
                s => s.TipoSituacaoToString(),
                s => s.StringToTipoSituacao()
            );
    }
}
