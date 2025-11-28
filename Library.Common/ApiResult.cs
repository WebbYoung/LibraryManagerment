namespace Library.Common
{
	public class ApiResult
	{
		public required string Status { get; set; }
		public string? ErrorMsg { get; set; }
		public object? Data { get; set; }
	}
}
