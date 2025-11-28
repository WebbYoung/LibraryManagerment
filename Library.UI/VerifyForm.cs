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
using CaptchaGen.NetCore;
namespace Library.UI
{
	public partial class VerifyForm : Form
	{
		public VerifyForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string verifyCode = textBox1.Text;
			if (string.IsNullOrEmpty(verifyCode))
			{
				MessageBox.Show("请输入图形验证码");
				return;
			}
			PublicData.VerifyCode = verifyCode;
			Close();
		}

		private async void VerifyForm_Load(object sender, EventArgs e)
		{
			var result = await HttpHelper.GetAsync<ApiResult>(ApiUrls.VerifyCodeUrl);
			if (result == null)
			{
				MessageBox.Show("获取验证码失败");
			}
			else if (result.Status == "error")
			{
				MessageBox.Show("错误;" + result.ErrorMsg);
				return;
			}
			if (result.Status == "ok")
			{
				using var stream = ImageFactory.BuildImage((string)result.Data, 60, 100, 20, 6);
				pictureBox1.Image = Image.FromStream(stream);
			}
		}

		private async void pictureBox1_Click(object sender, EventArgs e)
		{
			var result = await HttpHelper.GetAsync<ApiResult>(ApiUrls.VerifyCodeUrl);
			if (result == null)
			{
				MessageBox.Show("获取验证码失败");
			}
			else if (result.Status == "error")
			{
				MessageBox.Show("错误;" + result.ErrorMsg);
				return;
			}
			if (result.Status == "ok")
			{
				using var stream = ImageFactory.BuildImage((string)result.Data, 60, 100, 20, 6);
				pictureBox1.Image = Image.FromStream(stream);
			}
		}
	}
}
