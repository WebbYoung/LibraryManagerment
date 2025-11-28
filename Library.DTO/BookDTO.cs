using System.ComponentModel.DataAnnotations;

namespace Library.DTO
{
	public class BookDTO
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Author { get; set; }
		public string? Publisher { get; set; }
		public DateTime PublisherDate { get; set; }
		public int Price { get; set; }
	}
}
