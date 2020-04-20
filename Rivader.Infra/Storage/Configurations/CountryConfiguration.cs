using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivader.Domain.Models;

namespace Rivader.Infra.Storage.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries", RivaderDbContext.DboSchema);
            builder.HasKey(c => c.Code);
            builder.Property(c => c.Code).HasColumnName("Code").HasMaxLength(3);
            builder.HasOne(c => c.Translation).WithMany().IsRequired()
                .HasForeignKey(c => c.TranslationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
