using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdkLab12Bai1234.Models;

namespace PdkLab12Bai1234.Controllers
{
	public class PdkBannerController : Controller
	{
		private readonly PdkDbContext _context;

		public PdkBannerController(PdkDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> PdkIndex()
		{
			var banners = await _context.PdkBanners.ToListAsync();
			return View(banners);
		}

		// --- 1. THÊM MỚI (PdkCreate) ---
		// GET: PdkBanner/PdkCreate
		public IActionResult PdkCreate()
		{
			return View();
		}

		// POST: PdkBanner/PdkCreate
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PdkCreate([Bind("PdkName,PdkDescription,PdkImage,PdkStatus")] PdkBanner pdkBanner)
		{
			if (ModelState.IsValid)
			{
				pdkBanner.PdkCreatedDate = DateTime.Now;
				_context.Add(pdkBanner);
				await _context.SaveChangesAsync();
				return RedirectToAction("PdkIndex", "PdkHome");
			}
			return View(pdkBanner);
		}

		// --- 2. CHỈNH SỬA (PdkEdit) ---
		public async Task<IActionResult> PdkEdit(int? id)
		{
			if (id == null) return NotFound();
			var pdkBanner = await _context.PdkBanners.FindAsync(id);
			if (pdkBanner == null) return NotFound();
			return View(pdkBanner);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PdkEdit(int id, [Bind("PdkId,PdkName,PdkDescription,PdkImage,PdkStatus,PdkCreatedDate")] PdkBanner pdkBanner)
		{
			if (id != pdkBanner.PdkId) return NotFound();

			if (ModelState.IsValid)
			{
				_context.Update(pdkBanner);
				await _context.SaveChangesAsync();
				return RedirectToAction("PdkIndex", "PdkHome");
			}
			return View(pdkBanner);
		}

		// --- 3. XÓA (PdkDelete) ---
		// GET: PdkBanner/PdkDelete/5
		public async Task<IActionResult> PdkDelete(int? id)
		{
			if (id == null) return NotFound();

			var pdkBanner = await _context.PdkBanners
				.FirstOrDefaultAsync(m => m.PdkId == id);
			if (pdkBanner == null) return NotFound();

			return View(pdkBanner);
		}

		// POST: PdkBanner/PdkDelete/5
		[HttpPost, ActionName("PdkDelete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PdkDeleteConfirmed(int id)
		{
			var pdkBanner = await _context.PdkBanners.FindAsync(id);
			if (pdkBanner != null)
			{
				_context.PdkBanners.Remove(pdkBanner);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction("PdkIndex", "PdkHome");
		}
	}
}