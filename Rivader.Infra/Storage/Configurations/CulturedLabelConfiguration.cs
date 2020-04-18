using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivader.Domain.Models;

namespace Rivader.Infra.Storage.Configurations
{
    public class CulturedLabelConfiguration : IEntityTypeConfiguration<CulturedLabel>
    {
        public void Configure(EntityTypeBuilder<CulturedLabel> builder)
        {
            builder.ToTable("CulturedLabels", RivaderDbContext.DboSchema);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Value).HasColumnName("Value").IsRequired().HasMaxLength(1000);
            builder.Property(c => c.Lcid).HasColumnName("Lcid").IsRequired();
            builder.Property(c => c.TranslationId).HasColumnName("TranslationId");

            builder.HasOne(c => c.Translation).WithMany(t => t.CulturedLabels)
                .IsRequired();

            builder.HasIndex(c => new { c.TranslationId, c.Lcid }).IsUnique();
        }
    }
}
