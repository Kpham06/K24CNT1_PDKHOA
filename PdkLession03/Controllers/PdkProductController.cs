using Microsoft.AspNetCore.Mvc;
using PdkLession03.Models;

namespace PdkLession03.Controllers
{
	public class PdkProductController : Controller
	{
		// Tạo mock data
		private readonly List<PdkProduct> _products = new()
		{
		new PdkProduct
			{
				PdkProductId = "PROD-001",
				PdkProductName = "CPU Intel Core i9-14900K",
				PdkYearRelease = "2023",
				PdkPrice = 589.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-002",
				PdkProductName = "CPU AMD Ryzen 7 7800X3D",
				PdkYearRelease = "2023",
				PdkPrice = 449.00m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-003",
				PdkProductName = "VGA NVIDIA GeForce RTX 4090 24GB",
				PdkYearRelease = "2022",
				PdkPrice = 1599.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-004",
				PdkProductName = "VGA ASUS ROG Strix RTX 4080 Super",
				PdkYearRelease = "2024",
				PdkPrice = 999.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-005",
				PdkProductName = "RAM Corsair Vengeance DDR5 32GB (2x16GB) 6000MHz",
				PdkYearRelease = "2023",
				PdkPrice = 139.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-006",
				PdkProductName = "SSD Samsung 990 PRO 2TB NVMe PCIe 4.0",
				PdkYearRelease = "2022",
				PdkPrice = 179.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-007",
				PdkProductName = "Mainboard ASUS ROG Maximus Z790 HERO",
				PdkYearRelease = "2023",
				PdkPrice = 629.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-008",
				PdkProductName = "Mainboard MSI MAG B650 TOMAHAWK WIFI",
				PdkYearRelease = "2022",
				PdkPrice = 219.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-009",
				PdkProductName = "Nguồn Corsair RM1000x 1000W 80 Plus Gold",
				PdkYearRelease = "2021",
				PdkPrice = 189.99m
			},
			new PdkProduct
			{
				PdkProductId = "PROD-010",
				PdkProductName = "Tản nhiệt AIO NZXT Kraken Elite 360 RGB",
				PdkYearRelease = "2023",
				PdkPrice = 279.99m
			}
		};
		public IActionResult Index()
		{
			return Json(_products);
		}
		// GET: danh sách sản phẩm
		public IActionResult PdkGetAllProduct()
		{
			ViewData["products"] = _products;
			return View();
		}
		public IActionResult PdkGetListProduct()
		{
			return View(_products);
		}
	}
}
