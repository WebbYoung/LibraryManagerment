using Library.Common;
using Library.Model;
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
	public partial class EditType : Form
	{
		public EditType()
		{
			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			string? typeName = textBox1.Text;
			if (string.IsNullOrEmpty(typeName))
			{
				MessageBox.Show("分类名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var selectedType = PublicData.BookType;
			TypeEditModel model = new() { Id=selectedType.Id,Name=typeName };
			var resp = await HttpHelper.PostAsync<TypeEditModel,ApiResult>(ApiUrls.AddTypeUrl, model);
			if (resp == null)
			{
				MessageBox.Show("网络异常，修改分类失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (resp.Status != "ok")
			{
				MessageBox.Show($"修改分类失败：{resp.ErrorMsg}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("修改分类成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			PublicData.BookType=new DTO.TypeDTO { Id=selectedType.Id, Name=typeName };
			Close();
		}
	}
}
