using System;
using System.ComponentModel.DataAnnotations;

namespace PdkLab08_Lession08.Models
{
	public class PdkProduct
	{
		[Display(Name = "Mã sản phẩm")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
		[Display(Name = "Tên sản phẩm")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Giá bán không được để trống")]
		[Display(Name = "Giá niêm yết")]
		public decimal Price { get; set; }

		[Display(Name = "Giá khuyến mãi")]
		public decimal SalePrice { get; set; }

		[Display(Name = "Trạng thái")]
		public bool Status { get; set; }

		[Display(Name = "Ngày tạo")]
		public DateTime CreatedDate { get; set; } = DateTime.Now;

		[Display(Name = "Hình ảnh")]
		public string Image { get; set; }

		[Display(Name = "Danh mục")]
		public int CategoryId { get; set; }

		[Display(Name = "Mô tả")]
		public string Description { get; set; }
	}
}