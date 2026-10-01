using Microsoft.EntityFrameworkCore;
using PdkNetCoreCRUD.Models;

namespace PdkNetCoreCRUD.Data
{
	public class PdkAppDbContext : DbContext
	{
		public PdkAppDbContext(DbContextOptions<PdkAppDbContext> options) : base(options) { }

		public DbSet<PdkCategory> PdkCategories { get; set; }
		public DbSet<PdkProduct> PdkProducts { get; set; }
	}
}