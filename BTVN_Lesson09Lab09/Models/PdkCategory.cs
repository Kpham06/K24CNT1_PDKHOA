using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTVN_Lesson09Lab09.Models
{
	public class PdkCategory
	{
		[DisplayName("Mã danh mục")]
		[Required(ErrorMessage = "Mã danh mục không được để trống")]
		public int Id { get; set; }

		[DisplayName("Tên danh mục")]
		[Required(ErrorMessage = "Tên danh mục không được để trống")]
		[StringLength(150, MinimumLength = 6, ErrorMessage = "Tên danh mục phải từ 6 đến 150 ký tự")]
		public string Name { get; set; }
	}
}