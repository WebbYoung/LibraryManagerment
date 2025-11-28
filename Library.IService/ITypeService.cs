using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.IService
{
	public interface ITypeService
	{
		Task AddBookToTypeAsync(int BookId, int typeId);
		Task<int> AddTypeAsync(string typeName);
		Task<TypeDTO[]> GetAllAsync();
		Task<TypeDTO?> GetByNameAsync(string typeName);
		Task<TypeDTO?> GetByIdAsync(int typeId);
		Task MarkDeleteAsync(int typeId);
		Task UpdateType(int typeId, string typeName);
	}
}
