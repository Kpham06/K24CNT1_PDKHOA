using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PdkLesson09Annotation.Models.DataViewModels
{
	/// <summary>
	/// Data Annotation - Validation
	/// </summary>
	public class PdkMemberRegister
	{
		[DisplayName("Mã thành viên")]
		public int PdkMemberId { get; set; }

		[DisplayName("Tên đăng nhập")]
		[Required(ErrorMessage = "Tên đăng nhập không được để trống")]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Tên đăng nhập có độ dài trong khoảng 2 - 20 ký tự")]
		public string PdkUserName { get; set; }

		[DisplayName("Mật khẩu")]
		[Required(ErrorMessage = "Mật khẩu không được để trống")]
		[DataType(DataType.Password)]
		public string PdkPassword { get; set; }

		[DisplayName("Email")]
		[Required(ErrorMessage = "Email không được để trống")]
		[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
		public string PdkEmail { get; set; }

		[DisplayName("Số điện thoại")]
		[Required(ErrorMessage = "Số điện thoại không được để trống")]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải bao gồm 10 chữ số và bắt đầu bằng số 0")]
		public string PdkPhoneNumber { get; set; }

		[DisplayName("Họ và tên")]
		[Required(ErrorMessage = "Họ tên không được để trống")]
		public string PdkFullName { get; set; }

		[DisplayName("Ngày sinh")]
		[Required(ErrorMessage = "Ngày sinh không được để trống")]
		[DataType(DataType.Date)]
		public DateTime PdkBirthday { get; set; }
	}
}