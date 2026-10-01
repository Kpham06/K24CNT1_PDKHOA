using System.ComponentModel.DataAnnotations;

namespace BTVN_PdkLab12.Models
{
	public class PdkCategory
	{
		[Key]
		public int PdkId { get; set; }

		[Required(ErrorMessage = "Tên danh mục không được để trống")]
		[StringLength(100, ErrorMessage = "Tên danh mục không vượt quá 100 ký tự")]
		[Display(Name = "Tên danh mục")]
		public string PdkName { get; set; } = string.Empty;

		[Display(Name = "Trạng thái")]
		public byte PdkStatus { get; set; } = 1;

		[Display(Name = "Ngày tạo")]
		public DateTime PdkCreatedDate { get; set; } = DateTime.Now;

		// Navigation Property
		public virtual ICollection<PdkProduct> PdkProducts { get; set; } = new List<PdkProduct>();
	}
}