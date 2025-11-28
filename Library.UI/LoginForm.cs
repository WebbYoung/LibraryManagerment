using CaptchaGen.NetCore;
using Library.Common;
using Library.Model;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UI
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			string? phoneNum = Phone.Text.Trim();
			string? password = Password.Text.Trim();
			string? verifyCode = textBox3.Text.Trim();
			if (string.IsNullOrEmpty(phoneNum) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("手机号密码不能为空");
				return;
			}
			if (string.IsNullOrEmpty(verifyCode))
			{
				MessageBox.Show("请输入验证码");
				return;
			}
			string hashedPwd = CommonHelper.CalcMD5(password);
			LoginModel model = new LoginModel()
			{
				PhoneNum = phoneNum,
				PasswordHash = hashedPwd,
				VerifyCode = verifyCode,
			};
			ApiResult? result = await HttpHelper.PostAsync<LoginModel, ApiResult>(ApiUrls.LoginUrl, model);
			if (result == null)
			{
				MessageBox.Show("登录失败，请稍后重试");
				LoginForm_Load(new object(), EventArgs.Empty);
				return;
			}
			if (result.Status == "error")
			{
				MessageBox.Show("登录失败：" + result.ErrorMsg);
				LoginForm_Load(new object(), EventArgs.Empty);
				return;
			}
			if (result.Status == "ok")
			{
				this.Hide();
				MainForm mainForm = new MainForm();
				mainForm.ShowDialog();
				switch (mainForm.DialogResult)
				{

					case DialogResult.Cancel:
						mainForm.Close();
						Close();
						break;
					case DialogResult.Retry:
						mainForm.Close();
						Show();
						LoginForm_Load(new object(), EventArgs.Empty);
						break;
					default:
						Show();
						break;

				}
			}
			else
			{
				MessageBox.Show("登录失败，未知错误");
			}
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			RegisterForm form = new RegisterForm();
			form.ShowDialog();
		}

		private async void LoginForm_Load(object sender, EventArgs e)
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
				VerifyCode.Image = Image.FromStream(stream);
			}
		}

		private async void VerifyCode_Click(object sender, EventArgs e)
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
				VerifyCode.Image = Image.FromStream(stream);
			}
		}
	}
}
