using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
	public class RegisterModel
	{
		[Required]
		[Phone]
		public string? PhoneNum { get; set; }
		[Required]
		[StringLength(32, MinimumLength = 5)]
		public string? PasswordHash { get; set; }
		[Required]
		[StringLength (4, MinimumLength = 4)]
		public string? VerifyCode { get; set; }
		[Required]
		public string? SMSCode { get; set; }
	}
}
