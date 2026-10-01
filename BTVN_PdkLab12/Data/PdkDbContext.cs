using Microsoft.EntityFrameworkCore;
using BTVN_PdkLab12.Models;

namespace BTVN_PdkLab12.Data
{
	public class PdkDbContext : DbContext
	{
		public PdkDbContext(DbContextOptions<PdkDbContext> options) : base(options)
		{
		}

		public DbSet<PdkCategory> PdkCategories { get; set; }
		public DbSet<PdkProduct> PdkProducts { get; set; }

		// BỔ SUNG DÒNG NÀY ĐỂ HẾT LỖI:
		public DbSet<PdkBanner> PdkBanners { get; set; }
	}
}