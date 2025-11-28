using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Library.UI
{
	public static class ApiUrls
	{
		public static string VerifyCodeUrl { get; set; }= "https://localhost:7220/api/User/verify-code";
		public static string RegisterUrl { get; set; } = "https://localhost:7220/api/User/register";
		public static string LoginUrl { get; set; } = "https://localhost:7220/api/User/login";
		public static string LogoutUrl { get; set; } = "https://localhost:7220/api/User/logout";
		public static string SMSUrl { get; set; }="https://localhost:7220/api/User/send-sms";
		public static string BookTypesUrl { get; set; } = "https://localhost:7220/api/Type";
		public static string AddTypeUrl { get; set; } = "https://localhost:7220/api/Type";
		public static string BookUrl { get; set; }= "https://localhost:7220/api/Book";

	}
}
