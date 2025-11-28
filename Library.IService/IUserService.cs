namespace Library.IService
{
	public interface IUserService
	{
		Task AddUserAsync(string phoneNum, string password);
		Task<bool> CheckPasswordAsync(string phoneNum, string password);
		Task<int?> GetUserIdByPhoneAsync(string phoneNum);
		Task<bool> IsExistAsync(int userId);
	}
}
