using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI
{
	public static class PublicData
	{
		public static string? VerifyCode { get; set; }
		private static TypeDTO? bookType;
		public static TypeDTO? BookType 
		{
			get
			{
				TypeDTO? type= bookType;
				bookType = null;
				return type;
			}
			set
			{
				bookType = value;
			}
		}
		private static BookDTO? book;
		public static BookDTO? Book
		{
			get
			{
				BookDTO? newbook = book;
				book = null;
				return newbook;
			}
			set
			{
				book = value;
			}
		}
		public static int BookId { get; set; }
	}
}
