using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxCalculator.DataAccess.SqlDb.DbModels;

namespace TaxCalculator.DataAccess.SqlDb.EntityConfigurations;

public class TaxBandEntityConfiguration : IEntityTypeConfiguration<TaxBand>
{
    public void Configure(EntityTypeBuilder<TaxBand> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Name).HasColumnType("nvarchar(255)");
        builder.Property(x => x.LowRange).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();

        builder.ToTable("TaxBands");
    }
}