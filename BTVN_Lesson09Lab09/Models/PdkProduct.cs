using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using BTVN_Lesson09Lab09.Attributes;

namespace BTVN_Lesson09Lab09.Models
{
	public class PdkProduct
	{
		[DisplayName("Mã sản phẩm")]
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		public int Id { get; set; }

		[DisplayName("Tên sản phẩm")]
		[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
		[StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm từ 6 đến 150 ký tự")]
		public string Name { get; set; }

		[DisplayName("Hình ảnh")]
		public string Image { get; set; }

		[DisplayName("Chọn ảnh upload")]
		[NotMapped]
		public IFormFile ImageFile { get; set; }

		[DisplayName("Giá sản phẩm")]
		[Required(ErrorMessage = "Giá sản phẩm không được để trống")]
		[Range(100000, double.MaxValue, ErrorMessage = "Giá sản phẩm phải từ 100.000 VNĐ trở lên")]
		public float Price { get; set; }

		[DisplayName("Giá khuyến mãi")]
		[Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
		[Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được nhỏ hơn 0")]
		public float SalePrice { get; set; }

		[DisplayName("Mô tả")]
		[Required(ErrorMessage = "Mô tả không được để trống")]
		[StringLength(1500, ErrorMessage = "Mô tả tối đa 1500 ký tự")]
		[PdkProfanityCheck]
		public string Description { get; set; }

		[DisplayName("Danh mục")]
		[Required(ErrorMessage = "Vui lòng chọn danh mục")]
		public int CategoryId { get; set; }
	}
}