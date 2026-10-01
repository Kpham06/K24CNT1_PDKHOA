using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Đảm bảo có dòng này
using Microsoft.EntityFrameworkCore;
using PdkLab12Bai1234.Models;

namespace PdkLab12Bai1234.Controllers
{
	public class PdkProductController : Controller
	{
		private readonly PdkDbContext _context;

		public PdkProductController(PdkDbContext context)
		{
			_context = context;
		}

		// 1. DANH SÁCH (INDEX)
		public async Task<IActionResult> PdkIndex()
		{
			var products = await _context.PdkProducts.Include(p => p.PdkCategory).ToListAsync();
			return View(products);
		}

		// 2. CHI TIẾT (DETAILS)
		public async Task<IActionResult> PdkDetails(int? id)
		{
			if (id == null) return NotFound();

			var pdkProduct = await _context.PdkProducts
				.Include(p => p.PdkCategory)
				.FirstOrDefaultAsync(m => m.PdkId == id);

			if (pdkProduct == null) return NotFound();

			return View(pdkProduct);
		}

		// 3. THÊM MỚI (CREATE) - GET
		public IActionResult PdkCreate()
		{
			// Truyền danh sách Category vào ViewBag (Value: PdkId, Text: PdkName)
			ViewBag.PdkCategoryId = new SelectList(_context.PdkCategories, "PdkId", "PdkName");
			return View();
		}

		// 3. THÊM MỚI (CREATE) - POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PdkCreate(PdkProduct pdkProduct)
		{
			ModelState.Remove("PdkCategory"); // Bỏ qua kiểm tra navigation property

			if (ModelState.IsValid)
			{
				pdkProduct.PdkCreatedDate = DateTime.Now;
				_context.Add(pdkProduct);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(PdkIndex));
			}

			// Nếu dữ liệu không hợp lệ, load lại danh sách danh mục
			ViewBag.PdkCategoryId = new SelectList(_context.PdkCategories, "PdkId", "PdkName", pdkProduct.PdkCategoryId);
			return View(pdkProduct);
		}

		// 4. CHỈNH SỬA (EDIT) - GET
		public async Task<IActionResult> PdkEdit(int? id)
		{
			if (id == null) return NotFound();

			var pdkProduct = await _context.PdkProducts.FindAsync(id);
			if (pdkProduct == null) return NotFound();

			ViewBag.PdkCategoryId = new SelectList(_context.PdkCategories, "PdkId", "PdkName", pdkProduct.PdkCategoryId);
			return View(pdkProduct);
		}

		// 4. CHỈNH SỬA (EDIT) - POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PdkEdit(int id, PdkProduct pdkProduct)
		{
			if (id != pdkProduct.PdkId) return NotFound();

			ModelState.Remove("PdkCategory");

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(pdkProduct);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(PdkIndex));
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_context.PdkProducts.Any(e => e.PdkId == pdkProduct.PdkId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}
			ViewBag.PdkCategoryId = new SelectList(_context.PdkCategories, "PdkId", "PdkName", pdkProduct.PdkCategoryId);
			return View(pdkProduct);
		}

		// 5. XÓA (DELETE) - GET
		public async Task<IActionResult> PdkDelete(int? id)
		{
			if (id == null) return NotFound();

			var pdkProduct = await _context.PdkProducts
				.Include(p => p.PdkCategory)
				.FirstOrDefaultAsync(m => m.PdkId == id);

			if (pdkProduct == null) return NotFound();

			return View(pdkProduct);
		}

		// 5. XÓA (DELETE) - POST
		[HttpPost, ActionName("PdkDelete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PdkDeleteConfirmed(int id)
		{
			var pdkProduct = await _context.PdkProducts.FindAsync(id);
			if (pdkProduct != null)
			{
				_context.PdkProducts.Remove(pdkProduct);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(PdkIndex));
		}
	}
}