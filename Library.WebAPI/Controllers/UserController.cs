using Library.Common;
using Library.IService;
using Library.Model;
using LibraryAPI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;
		public UserController(IUserService userService)
		{
			this.userService = userService;
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody]LoginModel model)
		{
			if (!ModelState.IsValid)
			{
				string errorMsg = ApiHelper.GetErrorMsg(ModelState);
				return Ok(new ApiResult { Status="error",ErrorMsg= errorMsg });
			}
			if (TempDataHelper.Get(HttpContext, "verifyCode") != model.VerifyCode)
			{
				return Ok(new ApiResult { Status = "error", ErrorMsg = "验证码错误" });
			}
			bool result=await userService.CheckPasswordAsync(model.PhoneNum, model.PasswordHash);
			if (!result)
			{
				return Ok(new ApiResult { Status = "error", ErrorMsg = "用户名或密码错误" });
			}
			int? userId = await userService.GetUserIdByPhoneAsync(model.PhoneNum);
			HttpContext.Session.SetInt32("userId",userId.Value);
			return Ok(new ApiResult { Status="ok",Data="登录成功"});
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody]RegisterModel model)
		{
			if (!ModelState.IsValid)
			{
				string errorMsg = ApiHelper.GetErrorMsg(ModelState);
				return Ok(new ApiResult { Status = "error", ErrorMsg = errorMsg });
			}
			if (TempDataHelper.Get(HttpContext, "verifyCode") != model.VerifyCode)
			{
				return Ok(new ApiResult { Status = "error", ErrorMsg = "验证码错误" });
			}
			if (TempDataHelper.Get(HttpContext, "smsCode") != model.SMSCode || TempDataHelper.Get(HttpContext, "phone") != model.PhoneNum)
			{
				return Ok(new ApiResult { Status = "error", ErrorMsg = "手机号或验证码错误" });
			}
			bool exist = await userService.GetUserIdByPhoneAsync(model.PhoneNum) != null;
			if (exist) return Ok(new ApiResult { Status = "error", ErrorMsg = "用户已存在" });
			await userService.AddUserAsync(model.PhoneNum, model.PasswordHash);
			return Ok(new ApiResult { Status="ok",Data="注册成功"});
		}
		[HttpGet("logout")]
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("userId");
			return Ok(new ApiResult { Status="ok",Data="注销成功"});
		}
		[HttpGet("verify-code")]
		public IActionResult CreateVerifyCode()
		{
			string verifyCode = CommonHelper.CreateVerifyCode(4);
			TempDataHelper.Set(HttpContext, "verifyCode", verifyCode);
			return Ok(new ApiResult { Status="ok",Data=verifyCode});
		}
		[HttpGet("send-sms/{phoneNum}")]
		public IActionResult SendSMSCode([FromRoute]string phoneNum)
		{
			string smsCode = CommonHelper.CreateVerifyCode(6);
			TempDataHelper.Set(HttpContext, "smsCode", smsCode);
			TempDataHelper.Set(HttpContext, "phone", phoneNum);
			//这里应该调用短信接口发送验证码，省略
			return Ok(new ApiResult { Status = "ok", Data = $"验证码发送成功:{smsCode}" });
		}
	}
}
