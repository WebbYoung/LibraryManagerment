using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Entities
{
	public class User:Entity
	{
		[Required]
		public required string PhoneNum { get; set; }
		[Required]
		public required string PasswordSalt { get; set; }
		[Required]
		public required string PasswordHash { get; set; }
	}
}
