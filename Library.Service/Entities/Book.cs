using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Entities
{
	public class Book:Entity
	{
		[Required]
		public required string Name { get; set; }
		public BookType? Type { get; set; }
		public int TypeId { get; set; }

		[Required]
		public required string Description { get; set; }
		[Required]
		public required string Author { get; set; }
		[Required]
		public required string Publisher { get; set; }
		public DateTime PublisherDate { get; set; }
		public int Price { get; set; }
		public string? PicUrl { get; set; }
	}
}
