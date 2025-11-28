using Library.Common;
using Library.DTO;
using Library.IService;
using Library.Model;
using Library.WebAPI.Uow;
using LibraryAPI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class BookController : ControllerBase
	{
		private readonly IBookService bookService;
		private readonly ITypeService typeService;
		public BookController(IBookService bookService, ITypeService typeService)
		{
			this.bookService = bookService;
			this.typeService = typeService;
		}
		[Authorized]
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var books = await bookService.GetAllAsync();
			return Ok(books);
		}
		[Authorized]
		[HttpGet("{id}/detail")]
		public async Task<IActionResult> GetDeail([FromRoute]int id)
		{
			var detail = await bookService.GetDetialByIdAsync(id);
			return Ok(detail);
		}
		[Authorized]
		[HttpPost]
		public async Task<IActionResult> AddBook([FromBody]BookAddModel model)
		{
			if (!ModelState.IsValid)
			{
				string errorMsg = ApiHelper.GetErrorMsg(ModelState);
				return Ok(new ApiResult { Status = "error", ErrorMsg = errorMsg });
			}
			var book=await bookService.GetByNameAsync(model.Name);
			if (book != null)return Ok(new ApiResult { Status="error",ErrorMsg="书籍已存在" });
			bool exist = await typeService.GetByIdAsync(model.TypeId) != null;
			if (!exist) return Ok(new ApiResult { Status = "error", ErrorMsg = "类型不存在" });
			BookDTO newBook=await bookService.AddBookAsync(model.Name,model.Description,model.Author,model.Publisher,model.PublisherDate,model.Price,model.Picture,model.TypeId);
			return Ok(new ApiResult { Status="ok",Data=newBook});
		}
		[Authorized]
		[HttpPost("delete")]
		public async Task<IActionResult> MarkDelete([FromBody]int[] bookIds)
		{
			foreach(int id in bookIds)
			{
				await bookService.MarkedDelete(id);
			}
			return Ok(new ApiResult { Status = "ok", Data = "删除成功" });
		}
		[Authorized]
		[HttpPost("edit/{id}")]
		public async Task<IActionResult> UpdateBook([FromRoute]int id,[FromBody] BookEditModel model)
		{
			if (!ModelState.IsValid)
			{
				string errorMsg = ApiHelper.GetErrorMsg(ModelState);
				return Ok(new ApiResult { Status = "error", ErrorMsg = errorMsg });
			}
			await bookService.UpdateBookAsync(id, model.Name, model.Description, model.Author, model.Publisher, model.PublisherDate, model.Price, model.Picture, model.TypeId);
			return Ok(new ApiResult { Status = "ok", Data = "更新成功" });
		}
	}
}
