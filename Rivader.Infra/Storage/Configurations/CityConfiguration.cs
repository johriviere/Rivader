using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivader.Domain.Models;

namespace Rivader.Infra.Storage.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities", RivaderDbContext.DboSchema);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code).HasColumnName("Code").HasMaxLength(3).IsRequired().HasDefaultValue("PA");
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasOne(c => c.Translation).WithMany().IsRequired()
                .HasForeignKey(c => c.TranslationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Country).WithMany().IsRequired()
                .HasForeignKey(c => c.CountryCode)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(c => c.CountryCode).HasMaxLength(3).HasDefaultValue("FRA");
        }
    }
}
