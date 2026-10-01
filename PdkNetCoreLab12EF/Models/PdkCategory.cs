using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdkNetCoreCRUD.Models
{
	[Table("PdkCategory")]
	public class PdkCategory
	{
		[Key]
		public int PdkId { get; set; }

		[Required(ErrorMessage = "Tên danh mục không được để trống")]
		[StringLength(100)]
		[Column(TypeName = "nvarchar(100)")]
		public string PdkName { get; set; } = string.Empty;

		[Column(TypeName = "tinyint")]
		public byte PdkStatus { get; set; }

		public DateTime PdkCreatedDate { get; set; }

		// Danh sách sản phẩm theo danh mục
		public ICollection<PdkProduct>? PdkProducts { get; set; }
	}
}