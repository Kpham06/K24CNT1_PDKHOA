using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTVN_PdkLab12.Data;
using BTVN_PdkLab12.Models;

namespace BTVN_PdkLab12.Controllers
{
	public class PdkProductsController : Controller
	{
		private readonly PdkDbContext _context;
		private readonly IWebHostEnvironment _env;

		public PdkProductsController(PdkDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		// 1. DSHS / INDEX
		public async Task<IActionResult> Index()
		{
			var pdkDbContext = _context.PdkProducts.Include(p => p.PdkCategory);
			return View(await pdkDbContext.ToListAsync());
		}

		// 2. CHI TIẾT / DETAILS
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pdkProduct = await _context.PdkProducts
				.Include(p => p.PdkCategory)
				.FirstOrDefaultAsync(m => m.PdkId == id);

			if (pdkProduct == null)
			{
				return NotFound();
			}

			return View(pdkProduct);
		}

		// 3. THÊM MỚI / CREATE (GET)
		public IActionResult Create()
		{
			ViewData["PdkCategoryId"] = new SelectList(_context.PdkCategories, "PdkId", "PdkName");
			return View();
		}

		// 3. THÊM MỚI / CREATE (POST)
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(PdkProduct pdkProduct, IFormFile? files)
		{
			if (ModelState.IsValid)
			{
				if (files != null && files.Length > 0)
				{
					string folderPath = Path.Combine(_env.WebRootPath, "Product");
					if (!Directory.Exists(folderPath))
					{
						Directory.CreateDirectory(folderPath);
					}

					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
					string filePath = Path.Combine(folderPath, fileName);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await files.CopyToAsync(stream);
					}

					pdkProduct.PdkImage = fileName;
				}

				pdkProduct.PdkCreatedDate = DateTime.Now;
				_context.Add(pdkProduct);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewData["PdkCategoryId"] = new SelectList(_context.PdkCategories, "PdkId", "PdkName", pdkProduct.PdkCategoryId);
			return View(pdkProduct);
		}

		// 4. CHỈNH SỬA / EDIT (GET)
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pdkProduct = await _context.PdkProducts.FindAsync(id);
			if (pdkProduct == null)
			{
				return NotFound();
			}

			ViewData["PdkCategoryId"] = new SelectList(_context.PdkCategories, "PdkId", "PdkName", pdkProduct.PdkCategoryId);
			return View(pdkProduct);
		}

		// 4. CHỈNH SỬA / EDIT (POST)
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, PdkProduct pdkProduct, IFormFile? files)
		{
			if (id != pdkProduct.PdkId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					if (files != null && files.Length > 0)
					{
						string folderPath = Path.Combine(_env.WebRootPath, "Product");
						if (!Directory.Exists(folderPath))
						{
							Directory.CreateDirectory(folderPath);
						}

						string fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
						string filePath = Path.Combine(folderPath, fileName);

						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await files.CopyToAsync(stream);
						}

						pdkProduct.PdkImage = fileName;
					}

					_context.Update(pdkProduct);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PdkProductExists(pdkProduct.PdkId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}

			ViewData["PdkCategoryId"] = new SelectList(_context.PdkCategories, "PdkId", "PdkName", pdkProduct.PdkCategoryId);
			return View(pdkProduct);
		}

		// 5. XÓA / DELETE (GET)
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pdkProduct = await _context.PdkProducts
				.Include(p => p.PdkCategory)
				.FirstOrDefaultAsync(m => m.PdkId == id);

			if (pdkProduct == null)
			{
				return NotFound();
			}

			return View(pdkProduct);
		}

		// 5. XÓA / DELETE (POST)
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var pdkProduct = await _context.PdkProducts.FindAsync(id);
			if (pdkProduct != null)
			{
				_context.PdkProducts.Remove(pdkProduct);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}

		// 6. THAY ĐỔI TRẠNG THÁI / CHANGE STATUS
		public async Task<IActionResult> ChangeStatus(int id)
		{
			var pdkProduct = await _context.PdkProducts.FindAsync(id);
			if (pdkProduct == null)
			{
				return NotFound();
			}

			pdkProduct.PdkStatus = (byte)(pdkProduct.PdkStatus == 1 ? 0 : 1);
			_context.Update(pdkProduct);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		private bool PdkProductExists(int id)
		{
			return _context.PdkProducts.Any(e => e.PdkId == id);
		}
	}
}