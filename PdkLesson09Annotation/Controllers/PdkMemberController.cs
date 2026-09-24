using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdkLesson09Annotation.Models.DataModels;
using PdkLesson09Annotation.Models.DataViewModels;

namespace PdkLesson09Annotation.Controllers
{
	public class PdkMemberController : Controller
	{
		private static List<PdkMember> pdkMembers = new List<PdkMember>();

		// GET: PdkMemberController
		public ActionResult Index()
		{
			// Truyền danh sách pdkMembers sang View Index
			return View(pdkMembers);
		}

		// GET: PdkMemberController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PdkMemberController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PdkMemberController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(PdkMemberRegister pdkMember)
		{
			try
			{
				// Kiểm tra dữ liệu Validation từ Model
				if (!ModelState.IsValid)
				{
					return View(pdkMember);
				}

				// Nếu hợp lệ, tiến hành thêm mới vào danh sách
				var newMember = new PdkMember
				{
					PdkMemberId = pdkMember.PdkMemberId,
					PdkUserName = pdkMember.PdkUserName,
					PdkPassword = pdkMember.PdkPassword,
					PdkEmail = pdkMember.PdkEmail,
					PdkPhoneNumber = pdkMember.PdkPhoneNumber,
					PdkFullName = pdkMember.PdkFullName,
					PdkBirthday = pdkMember.PdkBirthday
				};

				pdkMembers.Add(newMember);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(pdkMember);
			}
		}

		// GET: PdkMemberController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PdkMemberController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PdkMemberController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PdkMemberController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}