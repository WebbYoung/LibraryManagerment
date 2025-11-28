using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
	public class BookAddModel
	{
		[Required]
		public required string Name { get; set; }
		[Required]
		public required int TypeId { get; set; }
		[Required]
		public required string Description { get; set; }
		[Required]
		public required string Author { get; set; }
		[Required]
		public required string Publisher { get; set; }
		[Required]
		public DateTime PublisherDate { get; set; }
		[Required]
		public int Price { get; set; }
		[Required]
		public string? Picture { get; set; }
	}
}
