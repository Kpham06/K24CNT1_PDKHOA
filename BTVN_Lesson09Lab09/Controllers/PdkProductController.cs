using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BTVN_Lesson09Lab09.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BTVN_Lesson09Lab09.Controllers
{
	public class PdkProductController : Controller
	{
		private readonly IWebHostEnvironment _env;

		public static List<PdkCategory> Categories = new List<PdkCategory>
		{
			new PdkCategory { Id = 1, Name = "Điện thoại di động" },
			new PdkCategory { Id = 2, Name = "Máy tính xách tay" },
			new PdkCategory { Id = 3, Name = "Phụ kiện công nghệ" }
		};

		public static List<PdkProduct> Products = new List<PdkProduct>
		{
			new PdkProduct { Id = 1, Name = "Laptop Dell XPS 13", Image = "dell.jpg", Price = 25000000, SalePrice = 22000000, Description = "Laptop mỏng nhẹ cao cấp", CategoryId = 2 }
		};

		public PdkProductController(IWebHostEnvironment env)
		{
			_env = env;
		}

		// GET: PdkProduct
		public IActionResult Index()
		{
			ViewBag.Categories = Categories;
			return View(Products);
		}

		// GET: PdkProduct/Details/5
		public IActionResult Details(int id)
		{
			var product = Products.FirstOrDefault(p => p.Id == id);
			if (product == null) return NotFound();
			ViewBag.CategoryName = Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name;
			return View(product);
		}

		// GET: PdkProduct/Create
		public IActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(Categories, "Id", "Name");
			return View();
		}

		// POST: PdkProduct/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(PdkProduct product)
		{
			if (product.ImageFile == null || product.ImageFile.Length == 0)
			{
				ModelState.AddModelError("ImageFile", "Vui lòng chọn hình ảnh upload");
			}

			if (product.SalePrice >= product.Price * 0.9f)
			{
				ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn giá gốc ít nhất 10%");
			}

			if (ModelState.IsValid)
			{
				string uploadsFolder = Path.Combine(_env.WebRootPath, "products");
				if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

				string uniqueFileName = product.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					product.ImageFile.CopyTo(stream);
				}

				product.Image = uniqueFileName;
				Products.Add(product);
				return RedirectToAction(nameof(Index));
			}

			ViewBag.CategoryId = new SelectList(Categories, "Id", "Name", product.CategoryId);
			return View(product);
		}

		// GET: PdkProduct/Edit/5
		public IActionResult Edit(int id)
		{
			var product = Products.FirstOrDefault(p => p.Id == id);
			if (product == null) return NotFound();
			ViewBag.CategoryId = new SelectList(Categories, "Id", "Name", product.CategoryId);
			return View(product);
		}

		// POST: PdkProduct/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, PdkProduct product)
		{
			var existing = Products.FirstOrDefault(p => p.Id == id);
			if (existing == null) return NotFound();

			if (product.SalePrice >= product.Price * 0.9f)
			{
				ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn giá gốc ít nhất 10%");
			}

			if (ModelState.IsValid)
			{
				if (product.ImageFile != null && product.ImageFile.Length > 0)
				{
					string uploadsFolder = Path.Combine(_env.WebRootPath, "products");
					string uniqueFileName = product.ImageFile.FileName;
					string filePath = Path.Combine(uploadsFolder, uniqueFileName);
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						product.ImageFile.CopyTo(stream);
					}
					existing.Image = uniqueFileName;
				}

				existing.Name = product.Name;
				existing.Price = product.Price;
				existing.SalePrice = product.SalePrice;
				existing.Description = product.Description;
				existing.CategoryId = product.CategoryId;

				return RedirectToAction(nameof(Index));
			}

			ViewBag.CategoryId = new SelectList(Categories, "Id", "Name", product.CategoryId);
			return View(product);
		}

		// GET: PdkProduct/Delete/5
		public IActionResult Delete(int id)
		{
			var product = Products.FirstOrDefault(p => p.Id == id);
			if (product == null) return NotFound();
			ViewBag.CategoryName = Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name;
			return View(product);
		}

		// POST: PdkProduct/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var product = Products.FirstOrDefault(p => p.Id == id);
			if (product != null) Products.Remove(product);
			return RedirectToAction(nameof(Index));
		}
	}
}