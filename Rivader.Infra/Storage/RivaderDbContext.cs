using Microsoft.EntityFrameworkCore;
using Rivader.Domain.Models;
using Rivader.Infra.Storage.Configurations;
using System;

namespace Rivader.Infra.Storage
{
    public class RivaderDbContext : DbContext
    {
        public const string DboSchema = "dbo";

        public RivaderDbContext(DbContextOptions<RivaderDbContext> options)
            : base(options) { }

        public DbSet<SpaceInvader> SpaceInvaders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			if (modelBuilder == null)
			{
				throw new ArgumentNullException(nameof(ModelBuilder));
			}

			modelBuilder.HasDefaultSchema(DboSchema);
			modelBuilder.ApplyConfiguration(new SpaceInvaderConfiguration());
			modelBuilder.ApplyConfiguration(new TranslationConfiguration());
			modelBuilder.ApplyConfiguration(new CulturedLabelConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
