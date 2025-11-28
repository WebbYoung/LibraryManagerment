using Library.Common;
using Library.IService;
using Library.Model;
using Library.WebAPI.Uow;
using LibraryAPI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class TypeController : ControllerBase
	{
		public readonly IBookService bookService;
		private readonly ITypeService typeService;
		public TypeController(ITypeService typeService, IBookService bookService)
		{
			this.typeService = typeService;
			this.bookService = bookService;
		}
		[Authorized]
		[HttpPost("{typeName}")]
		public async Task<IActionResult> AddOne([FromRoute]string typeName)
		{
			var type=await typeService.GetByNameAsync(typeName);
			if (type is not null)
				return Ok(new ApiResult { Status = "error", ErrorMsg = "该条分类已存在" });
			int typeId=await typeService.AddTypeAsync(typeName);
			return Ok(new ApiResult { Status="ok",Data=typeId});
		}
		[Authorized]
		[HttpGet]
		public async Task<IActionResult> GetBookType()
		{
			var types = await typeService.GetAllAsync();
			return Ok(types);
		}
		[Authorized]
		[HttpGet("{id}/book")]
		public async Task<IActionResult> GetBook(int id)
		{
			var books = await bookService.GetByTypeIdAsync(id);
			return Ok(books);
		}
		[Authorized]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await typeService.MarkDeleteAsync(id);
			return Ok(new ApiResult { Status="ok",Data="类型删除成功" });
		}
		[Authorized]
		[HttpPost]
		public async Task<IActionResult> EditType([FromBody]TypeEditModel model)
		{
			if (!ModelState.IsValid)
			{
				string errorMsg = ApiHelper.GetErrorMsg(ModelState);
				return Ok(new ApiResult { Status = "error", ErrorMsg = errorMsg });
			}
			var type = await typeService.GetByIdAsync(model.Id);
			if (type is null)
				return Ok(new ApiResult { Status = "error", ErrorMsg = "该分类不存在" });
			await typeService.UpdateType(model.Id, model.Name);
			return Ok(new ApiResult { Status = "ok", Data = "分类修改成功" });
		}
		[Authorized]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByBookId([FromRoute] int id)
		{
			var type = await typeService.GetByIdAsync(id);
			if (type is null)
				return Ok(new ApiResult { Status = "error", ErrorMsg = "该分类不存在" });
			return Ok(new ApiResult { Status = "ok", Data = type });
		}
	}
}
