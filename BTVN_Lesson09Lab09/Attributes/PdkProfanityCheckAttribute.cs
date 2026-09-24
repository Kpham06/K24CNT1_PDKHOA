using System.ComponentModel.DataAnnotations;

namespace BTVN_Lesson09Lab09.Attributes
{
	public class PdkProfanityCheckAttribute : ValidationAttribute
	{
		private readonly string[] _badWords = new[] { "die", "admin", "fack", "fuck" };

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				string input = value.ToString().ToLower();
				foreach (var word in _badWords)
				{
					if (input.Contains(word))
					{
						return new ValidationResult($"Mô tả chứa từ ngữ nhạy cảm không cho phép ('{word}')");
					}
				}
			}
			return ValidationResult.Success;
		}
	}
}