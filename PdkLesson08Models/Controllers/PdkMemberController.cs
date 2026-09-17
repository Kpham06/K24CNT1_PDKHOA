using Microsoft.AspNetCore.Mvc;
using PdkLesson08Models.Models;

namespace PdkLesson08Models.Controllers
{
	public class PdkMemberController : Controller
	{
		// Mock data - PdkMember
		private static List<PdkMember> _members = new List<PdkMember>()
		{
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "PDKVLOGER",
				PdkPassword = "Password123!",
				PdkFullName = "Phạm Đăng Khoa",
				PdkEmail = "Khoapham206.vn@gmail.com"
			},
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "tranthib",
				PdkPassword = "SecurePass456#",
				PdkFullName = "Trần Thị B",
				PdkEmail = "tranthib@outlook.com"
			},
			new PdkMember
			{
				PdkMemberId = Guid.NewGuid().ToString(),
				PdkUserName = "levanc",
				PdkPassword = "MyPassword789$",
				PdkFullName = "Lê Văn C",
				PdkEmail = "levanc@company.com"
			}
		};

		// GET: Danh sách thành viên
		public IActionResult Index()
		{
			return View(_members);
		}

		// GET: Thêm mới thành viên
		[HttpGet]
		public IActionResult PdkCreate()
		{
			var member = new PdkMember();
			return View(member);
		}

		// POST: Thêm mới thành viên
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult PdkCreate(PdkMember pdkMember)
		{
			if (ModelState.IsValid)
			{
				pdkMember.PdkMemberId = Guid.NewGuid().ToString();
				_members.Add(pdkMember);
				return RedirectToAction(nameof(Index));
			}
			return View(pdkMember);
		}

		// GET: Chỉnh sửa thông tin
		[HttpGet]
		public IActionResult PdkEdit(string id)
		{
			var member = _members.FirstOrDefault(x => x.PdkMemberId == id);
			if (member == null)
			{
				return NotFound();
			}
			return View(member);
		}

		// POST: Chỉnh sửa thông tin
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult PdkEdit(string id, PdkMember pdkMember)
		{
			var existingMember = _members.FirstOrDefault(x => x.PdkMemberId == id);
			if (existingMember != null)
			{
				existingMember.PdkUserName = pdkMember.PdkUserName;
				existingMember.PdkPassword = pdkMember.PdkPassword;
				existingMember.PdkFullName = pdkMember.PdkFullName;
				existingMember.PdkEmail = pdkMember.PdkEmail;

				return RedirectToAction(nameof(Index));
			}
			return View(pdkMember);
		}

		// GET: Xem chi tiết
		[HttpGet]
		public IActionResult PdkDetails(string id)
		{
			var member = _members.FirstOrDefault(x => x.PdkMemberId == id);
			if (member == null)
			{
				return NotFound();
			}
			return View(member);
		}

		// GET: Xác nhận xóa
		[HttpGet]
		public IActionResult PdkDelete(string id)
		{
			var member = _members.FirstOrDefault(x => x.PdkMemberId == id);
			if (member == null)
			{
				return NotFound();
			}
			return View(member);
		}

		// POST: Thực hiện xóa
		[HttpPost, ActionName("PdkDelete")]
		[ValidateAntiForgeryToken]
		public IActionResult PdkDeleteConfirmed(string id)
		{
			var member = _members.FirstOrDefault(x => x.PdkMemberId == id);
			if (member != null)
			{
				_members.Remove(member);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}