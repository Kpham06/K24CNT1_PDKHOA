using Microsoft.AspNetCore.Mvc;

namespace PdkNetCoreLA7_LAB14DEMO.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}