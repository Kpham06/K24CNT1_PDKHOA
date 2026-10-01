using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTVN_PdkLab12.Data;

namespace BTVN_PdkLab12.Controllers
{
	public class HomeController : Controller
	{
		private readonly PdkDbContext _context;

		public HomeController(PdkDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			// Lấy danh sách Banner có trạng thái hiển thị (PdkStatus == 1) cho Bài 4
			var banners = await _context.PdkBanners.Where(b => b.PdkStatus == 1).ToListAsync();
			return View(banners);
		}

		// BÀI 2: Action Product
		public async Task<IActionResult> Product()
		{
			var products = await _context.PdkProducts.Where(p => p.PdkStatus == 1).ToListAsync();
			return View(products);
		}
	}
}