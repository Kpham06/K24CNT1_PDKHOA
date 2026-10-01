using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdkLab12Bai1234.Models;

namespace PdkLab12Bai1234.Controllers
{
	public class PdkHomeController : Controller
	{
		private readonly PdkDbContext _pdkContext;

		public PdkHomeController(PdkDbContext pdkContext)
		{
			_pdkContext = pdkContext;
		}

		public async Task<IActionResult> PdkIndex()
		{
			// Lấy toàn bộ danh sách Banner (hoặc lọc theo trạng thái nếu cần)
			var pdkBanners = await _pdkContext.PdkBanners.ToListAsync();
			return View(pdkBanners);
		}
	}
}