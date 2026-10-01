using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdkNetCoreCRUD.Models
{
	[Table("PdkProduct")]
	public class PdkProduct
	{
		[Key]
		public int PdkId { get; set; }

		[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
		[StringLength(150, ErrorMessage = "Tên sản phẩm giới hạn 150 ký tự")]
		[Column(TypeName = "nvarchar(150)")]
		public string PdkName { get; set; } = string.Empty;

		[Column(TypeName = "varchar(150)")]
		public string? PdkImage { get; set; }

		[Required(ErrorMessage = "Giá sản phẩm không được để trống")]
		public float PdkPrice { get; set; }

		public float PdkSalePrice { get; set; }

		public byte PdkStatus { get; set; }

		[StringLength(1000, ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
		[Column(TypeName = "ntext")]
		public string? PdkDescriptions { get; set; }

		[Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
		public int PdkCategoryId { get; set; }

		public DateTime PdkCreatedDate { get; set; }

		// Khóa ngoại tới bảng PdkCategory
		[ForeignKey("PdkCategoryId")]
		public PdkCategory? PdkCategory { get; set; }
	}
}