using Microsoft.AspNetCore.Mvc;
using PdkLesson04Lab.Models;

namespace PdkLesson04Lab.Controllers
{
    public class PdkAccountController : Controller
    {
        private readonly List<PdkAccount> pdkAccounts = new()
        {
            new PdkAccount()
            {
                Id = 1,
                Name = "Phạm Đăng Khoa",
                Email = "dangkhoa.pham@gmail.com",
                Phone = "0986456789",
                Address = "Số 123 Đường Cầu Giấy, Cầu Giấy, Hà Nội",
                Avatar = "/image/1.jpg",
                Gender = 1,
                Bio = "Lập trình viên ASP.NET Core, đam mê phát triển hệ thống và công nghệ mới.",
                Birthday = new DateTime(2003, 5, 10)
            },
            new PdkAccount()
            {
                Id = 2,
                Name = "Phạm Đăng Minh",
                Email = "dangminh.pham@gmail.com",
                Phone = "0987654321",
                Address = "Số 45 Đường Nguyễn Văn Linh, Quận Thanh Khê, Đà Nẵng",
                Avatar = "/image/2.jpg",
                Gender = 1,
                Bio = "Chuyên gia tư vấn giải pháp phần mềm và tối ưu hóa cơ sở dữ liệu.",
                Birthday = new DateTime(1998, 10, 20)
            },
            new PdkAccount()
            {
                Id = 3,
                Name = "Phạm Thúy Hằng",
                Email = "thuyhang.pham@gmail.com",
                Phone = "0912345678",
                Address = "Số 88 Đường Lê Lợi, Quận 1, TP. Hồ Chí Minh",
                Avatar = "/image/3.jpg",
                Gender = 0,
                Bio = "Thiết kế giao diện UI/UX với niềm đam mê tạo ra trải nghiệm người dùng tối ưu.",
                Birthday = new DateTime(2000, 3, 12)
            },
            new PdkAccount()
            {
                Id = 4,
                Name = "Phạm Đăng Tuấn",
                Email = "dangtuan.pham@gmail.com",
                Phone = "0934567890",
                Address = "Số 12 Đường Lạch Tray, Quận Ngô Quyền, Hải Phòng",
                Avatar = "/image/4.jpg",
                Gender = 1,
                Bio = "Kỹ sư Fullstack Web Developer, chuyên về ReactJS và .NET.",
                Birthday = new DateTime(1997, 11, 5)
            },
            new PdkAccount()
            {
                Id = 5,
                Name = "Phạm Phương Thảo",
                Email = "phuongthao.pham@gmail.com",
                Phone = "0978123456",
                Address = "Số 56 Đường 3 Tháng 2, Quận Ninh Kiều, Cần Thơ",
                Avatar = "/image/5.jpg",
                Gender = 0,
                Bio = "Chuyên viên phân tích dữ liệu (Data Analyst).",
                Birthday = new DateTime(2001, 8, 25)
            }
        };

        public IActionResult PdkIndex()
        {
            ViewBag.PdkAccounts = pdkAccounts;
            return View();
        }

        [Route("ho-so-cua-toi", Name = "PdkProfile")]
        public IActionResult PdkProfile(int? id)
        {
            PdkAccount pdkAccount = new PdkAccount
            {
                Id = 5,
                Name = "Phạm Đăng Khoa",
                Email = "dangkhoa.pham@gmail.com",
                Phone = "0986456789",
                Avatar = "/images/1.jpg",
                Address = "Số 123 Đường Cầu Giấy, Cầu Giấy, Hà Nội",
                Bio = "Lập trình viên ASP.NET Core, đam mê phát triển hệ thống và công nghệ mới.",
                Gender = 1,
                Birthday = new DateTime(2003, 5, 10)
            };

            if (id != null)
            {
                pdkAccount = pdkAccounts.FirstOrDefault(x => x.Id == id);
            }

            ViewBag.PdkAccount = pdkAccount;
            return View();
        }
    }
}