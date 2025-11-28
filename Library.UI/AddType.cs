using Library.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UI
{
	public partial class AddType : Form
	{
		public AddType()
		{
			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			var typeName = textBox1.Text.Trim();
			var result = await HttpHelper.PostAsync<string, ApiResult>(ApiUrls.AddTypeUrl+$"/{typeName}", "");
			if (result == null || result.Status == "error")
			{
				MessageBox.Show("添加失败：" + result?.ErrorMsg);
				return;
			}
			if(result.Status == "ok")
			{
				MessageBox.Show("添加成功");
				textBox1.Clear();
				int typeId = Convert.ToInt32(result.Data);
				PublicData.BookType=new DTO.TypeDTO { Id = typeId ,Name=typeName};
				Close();
			}
			else
			{
				MessageBox.Show("添加失败：未知错误");
			}
		}
	}
}
