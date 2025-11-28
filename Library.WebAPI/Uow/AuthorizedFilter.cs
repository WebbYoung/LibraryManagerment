using Library.Common;
using Library.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Library.WebAPI.Uow
{
	public class AuthorizedFilter : IAsyncAuthorizationFilter
	{
		private readonly IUserService userService;
		public AuthorizedFilter(IUserService userService)
		{
			this.userService = userService;
		}

		public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			var Desc = context.ActionDescriptor as ControllerActionDescriptor;
			if (Desc == null) return;
			var attribute = Desc.MethodInfo.GetCustomAttribute<AuthorizedAttribute>();
			if (attribute == null) return;
			int? userId=context.HttpContext.Session.GetInt32("userId");
			if (userId == null)
			{
				context.Result = new OkObjectResult(new ApiResult {Status="error",ErrorMsg="未登录" });
				return;
			}
			if(!await userService.IsExistAsync(userId.Value))
			{
				context.Result = new OkObjectResult(new ApiResult { Status = "error", ErrorMsg = "已注销的账号" });
			}
		}
	}
}
