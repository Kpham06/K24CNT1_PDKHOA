using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTVN_PdkLab12.Models
{
	public class PdkProduct
	{
		[Key]
		public int PdkId { get; set; }

		[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
		[StringLength(150, ErrorMessage = "Tên sản phẩm không vượt quá 150 ký tự")]
		[Display(Name = "Tên sản phẩm")]
		public string PdkName { get; set; } = string.Empty;

		[Display(Name = "Hình ảnh")]
		public string? PdkImage { get; set; }

		[Required(ErrorMessage = "Giá nhập không được để trống")]
		[Display(Name = "Giá nhập")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal PdkPrice { get; set; }

		[Required(ErrorMessage = "Giá bán không được để trống")]
		[Display(Name = "Giá bán")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal PdkSalePrice { get; set; }

		[Display(Name = "Trạng thái")]
		public byte PdkStatus { get; set; } = 1;

		[Display(Name = "Mô tả")]
		public string? PdkDescriptions { get; set; }

		[Display(Name = "Ngày tạo")]
		public DateTime PdkCreatedDate { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Vui lòng chọn danh mục")]
		[Display(Name = "Danh mục")]
		public int PdkCategoryId { get; set; }

		[ForeignKey("PdkCategoryId")]
		public virtual PdkCategory? PdkCategory { get; set; }
	}
}