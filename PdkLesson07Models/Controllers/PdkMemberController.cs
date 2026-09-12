using Microsoft.AspNetCore.Mvc;
using PdkLesson07Models.Models.DataModels;

namespace PdkLesson07Models.Controllers
{
	public class PdkMemberController : Controller
	{
		protected static List<PdkMember> _members = new List<PdkMember>
		{
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "pdkuser01",
				PdkPassword = "password123",
				PdkFullName = "Phạm Đăng Khoa",
				PdkEmail = "dangkhoa01@gmail.com"
			},
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "pdkuser02",
				PdkPassword = "password123",
				PdkFullName = "Nguyễn Văn A",
				PdkEmail = "nguyenvana@gmail.com"
			},
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "pdkuser03",
				PdkPassword = "password123",
				PdkFullName = "Trần Thị B",
				PdkEmail = "tranthib@gmail.com"
			},
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "pdkuser04",
				PdkPassword = "password123",
				PdkFullName = "Lê Văn C",
				PdkEmail = "levanc@gmail.com"
			},
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "pdkuser05",
				PdkPassword = "password123",
				PdkFullName = "Hoàng Thị D",
				PdkEmail = "hoangthid@gmail.com"
			}
		};

		public IActionResult Index()
		{
			return View(_members);
		}

		public IActionResult GetMember()
		{
			var member = new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "pdkuser",
				PdkPassword = "password123",
				PdkFullName = "Phạm Đăng Khoa",
				PdkEmail = "pdk@gmail.com"
			};
			//ViewBag.Member = member;
			return View(member);
		}

		// Đưa dữ liệu dạng List ra View
		public IActionResult GetMembers()
		{
			// Lấy từ mock data
			ViewBag.Members = _members;
			return View();
		}
		// GET: Create member
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Create member
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(PdkMember member)
		{
			if (ModelState.IsValid)
			{
				member.PdkMemberId = Guid.NewGuid().ToString();
				_members.Add(member);
				return RedirectToAction(nameof(Index));
			}
			return View(member);
		}
	}
}