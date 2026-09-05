using Microsoft.AspNetCore.Mvc;

namespace BTVN_PdkLesson05MvcLab05.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}
	}
}