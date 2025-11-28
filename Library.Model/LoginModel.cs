using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
	public class LoginModel
	{
		[Required]
		[Phone]
		public string PhoneNum { get; set; }
		[Required]
		[StringLength(32,MinimumLength =5)]
		public string PasswordHash { get; set; }
		[Required]
		public string VerifyCode { get; set; }
	}
}
