using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PdkLab08_Lession08.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PdkLab08_Lession08.Controllers
{
	public class PdkProductController : Controller
	{
		// Mock data danh mục
		private static List<Category> _categories = new List<Category>()
		{
			new Category { Id = 1, Name = "Điện thoại" },
			new Category { Id = 2, Name = "Laptop" },
			new Category { Id = 3, Name = "Phụ kiện" }
		};

		// Mock data sản phẩm
		private static List<PdkProduct> _products = new List<PdkProduct>()
		{
			new PdkProduct
			{
				Id = 1,
				Name = "iPhone 15 Pro",
				Price = 28000000,
				SalePrice = 25500000,
				Status = true,
				CreatedDate = DateTime.Now,
				Image = "iphone15.jpg",
				CategoryId = 1,
				Description = "Sản phẩm chính hãng Apple"
			},
			new PdkProduct
			{
				Id = 2,
				Name = "MacBook Air M2",
				Price = 30000000,
				SalePrice = 27000000,
				Status = true,
				CreatedDate = DateTime.Now,
				Image = "macbook.jpg",
				CategoryId = 2,
				Description = "Laptop mỏng nhẹ, hiệu năng cao"
			}
		};

		// Helper nạp ComboBox danh mục
		private void LoadCategories()
		{
			ViewBag.CategoryId = new SelectList(_categories, "Id", "Name");
		}

		// GET: Danh sách sản phẩm
		public IActionResult Index()
		{
			ViewBag.Categories = _categories;
			return View(_products);
		}

		// GET: Xem chi tiết
		[HttpGet]
		public IActionResult PdkDetails(int id)
		{
			var product = _products.FirstOrDefault(x => x.Id == id);
			ViewBag.CategoryName = _categories.FirstOrDefault(c => c.Id == product?.CategoryId)?.Name;
			return View(product);
		}

		// GET: Thêm mới
		[HttpGet]
		public IActionResult PdkCreate()
		{
			LoadCategories();
			return View(new PdkProduct());
		}

		// POST: Thêm mới
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult PdkCreate(PdkProduct product)
		{
			if (ModelState.IsValid)
			{
				product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
				product.CreatedDate = DateTime.Now;
				_products.Add(product);
				return RedirectToAction(nameof(Index));
			}
			LoadCategories();
			return View(product);
		}

		// GET: Chỉnh sửa
		[HttpGet]
		public IActionResult PdkEdit(int id)
		{
			var product = _products.FirstOrDefault(x => x.Id == id);
			LoadCategories();
			return View(product);
		}

		// POST: Chỉnh sửa
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult PdkEdit(int id, PdkProduct product)
		{
			var item = _products.FirstOrDefault(x => x.Id == id);
			if (item != null && ModelState.IsValid)
			{
				item.Name = product.Name;
				item.Price = product.Price;
				item.SalePrice = product.SalePrice;
				item.Status = product.Status;
				item.Image = product.Image;
				item.CategoryId = product.CategoryId;
				item.Description = product.Description;

				return RedirectToAction(nameof(Index));
			}
			LoadCategories();
			return View(product);
		}

		// GET: Xác nhận xóa
		[HttpGet]
		public IActionResult PdkDelete(int id)
		{
			var product = _products.FirstOrDefault(x => x.Id == id);
			ViewBag.CategoryName = _categories.FirstOrDefault(c => c.Id == product?.CategoryId)?.Name;
			return View(product);
		}

		// POST: Thực hiện xóa
		[HttpPost, ActionName("PdkDelete")]
		[ValidateAntiForgeryToken]
		public IActionResult PdkDeleteConfirmed(int id)
		{
			var product = _products.FirstOrDefault(x => x.Id == id);
			if (product != null)
			{
				_products.Remove(product);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}