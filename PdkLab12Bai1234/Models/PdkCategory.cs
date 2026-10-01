using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PdkLab12Bai1234.Models
{
	public class PdkCategory
	{
		[Key]
		public int PdkId { get; set; }

		[Required(ErrorMessage = "Tên danh mục không được để trống")]
		[StringLength(100)]
		public string PdkName { get; set; }

		public virtual ICollection<PdkProduct> PdkProducts { get; set; }
	}
}