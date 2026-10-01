using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdkNetCoreCRUD.Data;
using PdkNetCoreCRUD.Models;

namespace PdkNetCoreCRUD.Controllers
{
	public class PdkCategoriesController : Controller
	{
		private readonly PdkAppDbContext _context;

		public PdkCategoriesController(PdkAppDbContext context)
		{
			_context = context;
		}

		// GET: PdkCategories
		public async Task<IActionResult> Index()
		{
			return _context.PdkCategories != null ?
						View(await _context.PdkCategories.ToListAsync()) :
						Problem("Entity set 'PdkAppDbContext.PdkCategories' is null.");
		}

		// GET: PdkCategories/Details/5
		public async Task<IActionResult> Details(int? pdkid)
		{
			if (pdkid == null || _context.PdkCategories == null)
			{
				return NotFound();
			}

			var pdkcategory = await _context.PdkCategories
				.FirstOrDefaultAsync(m => m.PdkId == pdkid);
			if (pdkcategory == null)
			{
				return NotFound();
			}

			return View(pdkcategory);
		}

		// GET: PdkCategories/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: PdkCategories/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PdkId,PdkName,PdkStatus,PdkCreatedDate")] PdkCategory pdkcategory)
		{
			if (ModelState.IsValid)
			{
				pdkcategory.PdkCreatedDate = DateTime.Now; // Gán ngày giờ hiện tại
				_context.Add(pdkcategory);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(pdkcategory);
		}

		// GET: PdkCategories/Edit/5
		public async Task<IActionResult> Edit(int? pdkid)
		{
			if (pdkid == null || _context.PdkCategories == null)
			{
				return NotFound();
			}

			var pdkcategory = await _context.PdkCategories.FindAsync(pdkid);
			if (pdkcategory == null)
			{
				return NotFound();
			}
			return View(pdkcategory);
		}

		// POST: PdkCategories/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int pdkid, [Bind("PdkId,PdkName,PdkStatus,PdkCreatedDate")] PdkCategory pdkcategory)
		{
			if (pdkid != pdkcategory.PdkId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					pdkcategory.PdkCreatedDate = DateTime.Now; // Cập nhật lại ngày giờ hiện tại
					_context.Update(pdkcategory);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PdkCategoryExists(pdkcategory.PdkId))
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
			return View(pdkcategory);
		}

		// GET: PdkCategories/Delete/5
		public async Task<IActionResult> Delete(int? pdkid)
		{
			if (pdkid == null || _context.PdkCategories == null)
			{
				return NotFound();
			}

			var pdkcategory = await _context.PdkCategories
				.FirstOrDefaultAsync(m => m.PdkId == pdkid);
			if (pdkcategory == null)
			{
				return NotFound();
			}

			return View(pdkcategory);
		}

		// POST: PdkCategories/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int pdkid)
		{
			if (_context.PdkCategories == null)
			{
				return Problem("Entity set 'PdkAppDbContext.PdkCategories' is null.");
			}

			var pdkcategory = await _context.PdkCategories.FindAsync(pdkid);
			if (pdkcategory != null)
			{
				_context.PdkCategories.Remove(pdkcategory);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PdkCategoryExists(int pdkid)
		{
			return (_context.PdkCategories?.Any(e => e.PdkId == pdkid)).GetValueOrDefault();
		}
	}
}