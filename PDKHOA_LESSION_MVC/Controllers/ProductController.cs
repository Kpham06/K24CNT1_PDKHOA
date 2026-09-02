using Microsoft.AspNetCore.Mvc;
using PDKHOA_LESSION_MVC.Models;

namespace PDKHOA_LESSION_MVC.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			var products = new List<Product>
			{
				new Product { Id = 1, Name = "Product 1", Price = 500000, CreatedAt = new DateTime(2020, 12, 25), Image = "https://tse3.mm.bing.net/th/id/OIP.68UuyxXa70lRSNOTs_QAZgHaHa?r=0&rs=1&pid=ImgDetMain&o=7&rm=3" },
				new Product { Id = 2, Name = "Product 2", Price = 700000, CreatedAt = new DateTime(2020, 12, 25), Image = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/9f5645183045113.6538b6aa7d431.jpg" },
				new Product { Id = 3, Name = "Product 3", Price = 550000, CreatedAt = new DateTime(2020, 12, 25), Image = "https://mir-s3-cdn-cf.behance.net/project_modules/1400/bf19d5159401347.639d9d13389f8.jpg" },
				new Product { Id = 4, Name = "Product 4", Price = 550000, CreatedAt = new DateTime(2020, 12, 25), Image = "https://tse1.mm.bing.net/th/id/OIP.-XS-7IlXxaI6Xs2_Iu7b5gHaHa?r=0&w=736&h=736&rs=1&pid=ImgDetMain&o=7&rm=3" }
			};

			return View(products);
		}
	}
}