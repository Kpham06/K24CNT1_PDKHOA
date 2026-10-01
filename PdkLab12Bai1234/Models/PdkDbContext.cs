using Microsoft.EntityFrameworkCore;

namespace PdkLab12Bai1234.Models
{
	public class PdkDbContext : DbContext
	{
		public PdkDbContext(DbContextOptions<PdkDbContext> pdkOptions) : base(pdkOptions) { }

		public DbSet<PdkProduct> PdkProducts { get; set; }
		public DbSet<PdkCategory> PdkCategories { get; set; }
		public DbSet<PdkBanner> PdkBanners { get; set; }
	}
}