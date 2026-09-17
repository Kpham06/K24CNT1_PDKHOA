using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PdkLesson08Models.Models;

namespace PdkLesson08Models.Controllers
{
	public class PdkHomeController : Controller
	{
		private readonly ILogger<PdkHomeController> _logger;

		public PdkHomeController(ILogger<PdkHomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult PdkIndex()
		{
			return View();
		}

		public IActionResult PdkPrivacy()
		{
			return View();
		}

		public IActionResult PdkAbout()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}