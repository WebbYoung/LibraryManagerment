using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
	public static class HttpHelper
	{
		private static HttpClient Client { get; set; }=new HttpClient();
		public static async Task<TRespone?> PostAsync<TRequest,TRespone>(string url,TRequest data)
		{
			var request = JsonConvert.SerializeObject(data);
			HttpContent content=new StringContent(request, Encoding.UTF8, "application/json");
			var result=await Client.PostAsync(url, content);
			var responseStr= await result.Content.ReadAsStringAsync();
			var response=JsonConvert.DeserializeObject<TRespone>(responseStr);
			return response;
		}
		public static async Task<TRespone?> GetAsync<TRespone>(string url)
		{
			var result= await Client.GetAsync(url);
			var responseStr = await result.Content.ReadAsStringAsync();
			var response = JsonConvert.DeserializeObject<TRespone>(responseStr);
			return response;
		}
		public static async Task<TRespone?> DeleteAsync<TRespone>(string url)
		{
			var result = await Client.DeleteAsync(url);
			var responseStr = await result.Content.ReadAsStringAsync();
			var response = JsonConvert.DeserializeObject<TRespone>(responseStr);
			return response;
		}
	}
}
