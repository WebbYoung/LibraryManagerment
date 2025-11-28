using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.IService
{
	public interface IBookService
	{
		Task<BookDTO> AddBookAsync(string name, string description, string author, string publisher, DateTime publisherDate, int price, string? picture, int typeId);
		Task<BookDTO?> GetByNameAsync(string name);
		Task<BookDTO[]> GetByTypeIdAsync(int typeId);
		Task<BookDTO[]> GetAllAsync();
		Task<BookDetailsDTO> GetDetialByIdAsync(int bookId);
		Task MarkedDelete(int id);
		Task UpdateBookAsync(int bookId, string name, string description, string author, string publisher, DateTime publisherDate, int price, string? picture, int typeId);
	}
}
