using System;
using System.ComponentModel.DataAnnotations;

namespace PdkLab12Bai1234.Models
{
	public class PdkBanner
	{
		[Key]
		public int PdkId { get; set; }

		[Required(ErrorMessage = "Tên banner không được để trống")]
		[StringLength(150)]
		public string PdkName { get; set; }

		public string PdkImage { get; set; }

		public string PdkDescription { get; set; }

		public DateTime PdkCreatedDate { get; set; } = DateTime.Now;

		public byte PdkStatus { get; set; }
	}
}