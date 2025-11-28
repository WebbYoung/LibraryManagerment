using Library.DTO;
using Library.IService;
using Library.Service.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Services
{
	public class TypeService : ITypeService
	{
		public async Task AddBookToTypeAsync(int BookId, int typeId)
		{
			using var context=new LibContext();
			var book= await context.Books.FindAsync(BookId);
			if(book is null)throw new Exception($"找不到书籍{BookId}");
			if(book.TypeId==typeId) return;
			var type= await context.Types.Include(e=>e.Books)
				.SingleOrDefaultAsync(t=>t.Id==typeId);
			if(type is null) throw new Exception($"找不到书籍类型{typeId}");
			type?.Books.Add(book);
			await context.SaveChangesAsync();
		}
		public async Task UpdateType(int typeId,string typeName)
		{
			using var context=new LibContext();
			var type = await context.Types.FindAsync(typeId);
			if(type is null)throw new Exception($"找不到类型{typeId}");
			type.Name = typeName;
			await context.SaveChangesAsync();
		}

		public async Task<int> AddTypeAsync(string typeName)
		{
			using var context = new LibContext();
			if(await context.Types.AnyAsync(e=>e.Name==typeName))
				throw new Exception($"已存在类型{typeName}");
			var type = new BookType { Name = typeName };
			await context.Types.AddAsync(type);
			await context.SaveChangesAsync();
			return type.Id;
		}
		public async Task<TypeDTO?> GetByNameAsync(string typeName)
		{
			using var context=new LibContext();
			var type = await context.Types
				.Include(e => e.Books)
				.SingleOrDefaultAsync(e => e.Name == typeName);
			return type == null ? null : ToDTO(type);
		}
		public async Task<TypeDTO[]> GetAllAsync()
		{
			using var context=new LibContext();
			var types=await context.Types
				.Select(e=>ToDTO(e)).ToArrayAsync();
			return types;
		}
		public static TypeDTO ToDTO(BookType type)
		{
			return new TypeDTO
			{
				Id = type.Id,
				Name = type.Name
			};
		}

		public async Task<TypeDTO?> GetByIdAsync(int typeId)
		{
			using var context = new LibContext();
			var type = await context.Types.FindAsync(typeId);
			return type == null ? null : ToDTO(type);
		}
		public async Task MarkDeleteAsync(int typeId)
		{
			using var context=new LibContext();
			var type = await context.Types.FindAsync(typeId);
			if(type==null)throw new Exception($"找不到类型{typeId}");
			type.IsDeleted = true;
			await context.SaveChangesAsync();
		}
		public async Task<TypeDTO> GetByBookIdAsync(int bookId)
		{
			using var context=new LibContext();
			var book = await context.Books
				.Include(e => e.Type)
				.AsNoTracking()
				.SingleOrDefaultAsync(e => e.Id == bookId);
			if (book == null || book.Type == null)
				throw new ValidationException($"找不到书籍{bookId}或其类型");
			return ToDTO(book.Type);
		}
	}
}
