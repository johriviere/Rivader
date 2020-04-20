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
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id");

            builder.Property(s => s.Number).HasColumnName("Number").IsRequired();

            builder.Property(s => s.Latitude).HasColumnName("Latitude").HasColumnType("decimal(8,5)");
            builder.Property(s => s.Longitude).HasColumnName("Longitude").HasColumnType("decimal(8,5)");


            builder.HasOne(s => s.Country).WithMany().IsRequired()
                    .HasForeignKey(s => s.CountryCode)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.Property(s => s.CountryCode).HasMaxLength(3).HasDefaultValue("FRA");
        }
    }
}
