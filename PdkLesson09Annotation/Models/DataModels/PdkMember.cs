namespace PdkLesson09Annotation.Models.DataModels
{
	public class PdkMember
	{
		public int PdkMemberId { get; set; }
		public string PdkUserName { get; set; }
		public string PdkPassword { get; set; }
		public string PdkEmail { get; set; }
		public string PdkPhoneNumber { get; set; }
		public string PdkFullName { get; set; }
		public DateTime PdkBirthday { get; set; }
	}
}