using Microsoft.AspNetCore.Mvc;
using PDK_Lession02demo.Models;
using System.Security.Cryptography.X509Certificates;

namespace PDK_Lession02demo.Controllers
{
	public class PdkProductController1 : Controller
	{
		public IActionResult Index()
		{
			//Đưa dữ liệu ra view
			ViewBag.name = "Khoa Phạm";
			ViewData["address"] = "fit NTU";
			TempData["UNI"] = "Trường Đại Học Nguyễn Trãi";

			return View();
		}

		//Chi tiết sản phẩm
		public IActionResult GetProduct()
		{
			//Mock data
			PdkProduct product = new PdkProduct()
			{
				ProductId = "P001",
				ProductName = "Laptop Dell Vostro",
				YearRelease = 2024,
				Price = 12000000,
			};

			ViewData["productVD"] = product;
			ViewBag.ProductVB = product;

			return View();
		}
	}
}