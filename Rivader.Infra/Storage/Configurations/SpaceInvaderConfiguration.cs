using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivader.Domain.Models;

namespace Rivader.Infra.Storage.Configurations
{
    public class SpaceInvaderConfiguration : IEntityTypeConfiguration<SpaceInvader>
    {
        public void Configure(EntityTypeBuilder<SpaceInvader> builder)
        {
            builder.ToTable("SpaceInvaders", RivaderDbContext.DboSchema);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Number).HasColumnName("Number").IsRequired();
            builder.Property(c => c.Latitude).HasColumnName("Latitude").HasColumnType("decimal(8,5)");
            builder.Property(c => c.Longitude).HasColumnName("Longitude").HasColumnType("decimal(8,5)");
        }
    }
}
