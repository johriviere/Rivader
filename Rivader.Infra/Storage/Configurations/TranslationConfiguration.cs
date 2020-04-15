using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivader.Domain.Models;

namespace Rivader.Infra.Storage.Configurations
{
    public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.ToTable("Translations", RivaderDbContext.DboSchema);
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.HasMany(t => t.CulturedLabels).WithOne(c => c.Translation)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
