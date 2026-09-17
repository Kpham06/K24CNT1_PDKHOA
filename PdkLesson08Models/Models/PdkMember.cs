using System.ComponentModel;

namespace PdkLesson08Models.Models
{
	public class PdkMember
	{
		public string PdkMemberId { get; set; }
		public string PdkUserName { get; set; }
		public string PdkPassword { get; set; }

		[DisplayName("Họ và tên")]
		public string PdkFullName { get; set; }
		public string PdkEmail { get; set; }
	}
}