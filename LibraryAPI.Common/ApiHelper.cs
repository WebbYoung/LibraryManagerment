using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LibraryAPI.Common
{
	public class ApiHelper
	{
		public static string GetErrorMsg(ModelStateDictionary modelState)
		{
			if(modelState==null||modelState.IsValid) return string.Empty;
			StringBuilder sb = new StringBuilder();
			foreach (var item in modelState.Values)
			{
				foreach (var error in item.Errors)
				{
					if (!string.IsNullOrEmpty(error.ErrorMessage))
					{
						sb.AppendLine(error.ErrorMessage);
					}
				}
			}
			return sb.ToString();
		}
	}
}
