using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdkLab12Bai1234.Models
{
	public class PdkProduct
	{
		[Key]
		public int PdkId { get; set; }

		[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
		[StringLength(150)]
		public string PdkName { get; set; }

		public string PdkImage { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal PdkPrice { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal PdkSalePrice { get; set; }

		public byte PdkStatus { get; set; }

		public string PdkDescriptions { get; set; }

		public DateTime PdkCreatedDate { get; set; } = DateTime.Now;

		public int PdkCategoryId { get; set; }

		[ForeignKey("PdkCategoryId")]
		public virtual PdkCategory PdkCategory { get; set; }
	}
}