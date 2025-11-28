using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Entities
{
	public class BookType:Entity
	{
		[Required]
		public required string Name { get; set; }
		public List<Book> Books { get; set; } = new List<Book>();
	}
}
