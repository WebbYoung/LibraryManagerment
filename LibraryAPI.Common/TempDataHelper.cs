using Microsoft.AspNetCore.Http;
using System.Text;

namespace LibraryAPI.Common
{
	public class TempDataHelper
	{
		public static void Set(HttpContext context,string key,string value)
		{
			byte[] bytes=Encoding.UTF8.GetBytes(value);
			context.Session.Set(key,bytes);
		}
		public static string? Get(HttpContext context,string key)
		{
			byte[] bytes=context.Session.Get(key);
			if(bytes==null||bytes?.Length==0)
			{
				return null;
			}
			string? res=Encoding.UTF8.GetString(bytes);
			if(string.IsNullOrEmpty(res))
			{
				return null;
			}
			context.Session.Remove(key);
			return res;
		}
	}
}
