using Library.Common;
using Library.IService;
using Library.Service.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Services
{
	public class UserService:IUserService
	{
		public async Task AddUserAsync(string phoneNum,string password)
		{
			using (var context = new LibContext())
			{
				if (await context.Users.AnyAsync(e=>e.PhoneNum==phoneNum))
				{
					throw new ArgumentException($"用户{phoneNum}已存在");
				}
				string passwordSalt = CommonHelper.CreateVerifyCode(5);
				string hashedPwd = CommonHelper.CalcMD5(passwordSalt + password);
				User user = new() 
				{
					PhoneNum= phoneNum,
					PasswordSalt= passwordSalt,
					PasswordHash= hashedPwd
				};
				await context.Users.AddAsync(user);
				await context.SaveChangesAsync();
			}
		}
		public async Task<bool> CheckPasswordAsync(string phoneNum,string password)
		{
			using(var context=new LibContext())
			{
				User? user = await context.Users
					.AsNoTracking()
					.SingleOrDefaultAsync(e => e.PhoneNum == phoneNum);
				if (user == null)
				{
					return false;
				}
				string hashedPwd= CommonHelper.CalcMD5(user.PasswordSalt+password);
				return hashedPwd == user.PasswordHash;
			}
		}
		public async Task<int?> GetUserIdByPhoneAsync(string phoneNum)
		{
			using(var context= new LibContext())
			{
				var user= await context.Users.SingleOrDefaultAsync(e => e.PhoneNum == phoneNum);
				return user?.Id;
			}
		}
		public async Task<bool> IsExistAsync(int userId)
		{
			using(var context=new LibContext())
			{
				return await context.Users.AnyAsync(e=>e.Id== userId);
			}
		}

	}
}
