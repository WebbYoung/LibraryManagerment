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
	public partial class RegisterForm : Form
	{
		public RegisterForm()
		{
			InitializeComponent();
		}

		private async void button2_Click(object sender, EventArgs e)
		{
			string phoneNum = Phone.Text;
			string password = Password.Text;
			string smsCode = SMSCode.Text;
			if (string.IsNullOrEmpty(phoneNum) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("请输入手机号和密码");
				return;
			}
			if (string.IsNullOrEmpty(smsCode))
			{
				MessageBox.Show("请输入手机验证码");
				return;
			}
			VerifyForm form = new VerifyForm();
			form.ShowDialog();
			string hashedPwd = CommonHelper.CalcMD5(password);
			RegisterModel model = new RegisterModel()
			{
				PhoneNum = phoneNum,
				PasswordHash = hashedPwd,
				SMSCode = smsCode,
				VerifyCode = PublicData.VerifyCode
			};
			ApiResult? result = await HttpHelper.PostAsync<RegisterModel, ApiResult>(ApiUrls.RegisterUrl, model);
			if (result == null)
			{
				MessageBox.Show("请求异常");
			}
			else if (result.Status == "ok")
			{
				MessageBox.Show("注册成功");
				Close();
			}
			else
			{
				MessageBox.Show("注册失败:" + result.ErrorMsg);
			}
		}

		private async void button3_Click(object sender, EventArgs e)
		{
			button3.Enabled = false;
			var result = await HttpHelper.GetAsync<ApiResult>(ApiUrls.SMSUrl + $"/{Phone.Text}");
			if (result == null || result.Status == "error")
			{
				MessageBox.Show("验证码发送失败");
				button3.Enabled = true;
				return;
			}
			if (result.Status == "ok")
			{
				await CountDown(60);
			}
		}
		private async Task CountDown(int count)
		{
			if (count <= 0)
			{
				button3.Text = "发送验证码";
				button3.Enabled = true;
				return;
			}
			button3.Text = $"{count}s后重试";
			await Task.Delay(1000);
			await CountDown(count - 1);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
