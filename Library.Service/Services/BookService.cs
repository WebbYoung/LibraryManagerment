using Library.DTO;
using Library.IService;
using Library.Service.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Services
{
	public class BookService:IBookService
	{
		private readonly ITypeService typeService;
		public BookService(ITypeService typeService)
		{
			this.typeService = typeService;
		}

		public async Task<BookDTO> AddBookAsync(string name,string description,string author,string publisher,DateTime publisherDate,int price,string? picture,int typeId)
		{
			using var context = new LibContext();
			if(await context.Books.AnyAsync(b=>b.Name==name&&b.Author==author))
			{
				throw new Exception("该书籍已存在");
			}
			byte[]picBytes=Convert.FromBase64String(picture??"");
			string directoryPath=Path.Combine(Directory.GetCurrentDirectory(),"images");
			if(!Directory.Exists(directoryPath))Directory.CreateDirectory(directoryPath);
			string filePath = Path.Combine(directoryPath, Guid.NewGuid().ToString("N") + ".png");
			await File.WriteAllBytesAsync(filePath,picBytes);
			Book book = new Book()
			{
				Name = name,
				Description = description,
				Author = author,
				Publisher = publisher,
				PublisherDate = publisherDate,
				Price = price,
				PicUrl = filePath,
				TypeId = typeId
			};
			await context.AddAsync(book);
			await context.SaveChangesAsync();
			return ToDTO(book);
		}
		public async Task UpdateBookAsync(int bookId,string name, string description, string author, string publisher, DateTime publisherDate, int price, string? picture, int typeId)
		{
			using var context= new LibContext();
			Book? book=await context.Books.Include(e => e.Type).SingleOrDefaultAsync(e => e.Id == bookId);
			if(book==null)throw new ArgumentException($"书籍{bookId}不存在");
			book.Name = name;
			book.Description = description;
			book.Author = author;
			book.Publisher = publisher;
			book.PublisherDate = publisherDate;
			book.Price = price;
			book.TypeId = typeId;
			if(picture!=null)
			{
				if (File.Exists(book.PicUrl))
				{
					File.Delete(book.PicUrl);
				}
				byte[] picBytes = Convert.FromBase64String(picture);
				string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
				if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
				string filePath = Path.Combine(directoryPath, Guid.NewGuid().ToString("N") + ".png");
				await File.WriteAllBytesAsync(filePath, picBytes);
				book.PicUrl = filePath;
			}
			await context.SaveChangesAsync();
		}
		public async Task<BookDTO?> GetByNameAsync(string name)
		{
			var context= new LibContext();
			var book=await context.Books.Include(b=>b.Type).SingleOrDefaultAsync(b=>b.Name==name);
			return book==null?null:ToDTO(book);
		}
		public async Task<BookDTO[]> GetAllAsync()
		{
			var context = new LibContext();
			var books = await context.Books
				.AsNoTracking()
				.Select(e => ToDTO(e))
				.ToArrayAsync();
			return books;
		}
		public async Task<BookDTO[]> GetByTypeIdAsync(int typeId)
		{
			using var context=new LibContext();
			var type =await context.Types.AsNoTracking().Include(e => e.Books).SingleOrDefaultAsync(e => e.Id == typeId);
			if (type == null) throw new ArgumentException($"类型{typeId}不存在");
			var books = type.Books.Select(e=>ToDTO(e)).ToArray();
			return books;
		}
		public async Task<BookDetailsDTO> GetDetialByIdAsync(int bookId)
		{
			using var context = new LibContext();
			var book = await context.Books.FindAsync(bookId);
			if (book == null) throw new ArgumentException($"书籍{bookId}不存在");
			string? path = book.PicUrl ?? "";
			byte[] pic =await File.ReadAllBytesAsync(path);
			string base64 = Convert.ToBase64String(pic);
			BookDetailsDTO dto = new BookDetailsDTO()
			{
				Description = book.Description,
				PicBaseString = base64
			};
			return dto;
		}
		public static BookDTO ToDTO(Book book)
		{
			BookDTO dto = new()
			{
				Name = book.Name,
				Author = book.Author,
				Id = book.Id,
				Price = book.Price,
				Publisher = book.Publisher,
				PublisherDate = book.PublisherDate,
			};
			return dto;
		}
		public async Task MarkedDelete(int id)
		{
			using var context = new LibContext();
			Book? book = await context.Books.FindAsync(id);
			if (book == null) throw new ArgumentException($"找不到图书{id}");
			book.IsDeleted = true;
			await context.SaveChangesAsync();
		}
	}
}
