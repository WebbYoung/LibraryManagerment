using Library.Common;
using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UI
{
	public partial class AddBook : Form
	{
		public AddBook()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void AddBook_Load(object sender, EventArgs e)
		{
			var types = await HttpHelper.GetAsync<TypeDTO[]>(ApiUrls.BookTypesUrl);
			if (types != null)
			{
				comboBox1.DataSource = types;
				comboBox1.ValueMember = "Id";
				comboBox1.DisplayMember = "Name";
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";
			openFileDialog1.Filter = "IMG File(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
			openFileDialog1.ShowDialog();
			pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedValue == null)
			{
				MessageBox.Show("请选择一个分类");
				return;
			}
			if (string.IsNullOrEmpty(openFileDialog1.FileName))
			{
				MessageBox.Show("请选择封面图片");
				return;
			}
			byte[] bookBytes = await File.ReadAllBytesAsync(openFileDialog1.FileName);
			string bookBase64 = Convert.ToBase64String(bookBytes);
			var model = new BookAddModel()
			{
				Name = textBox1.Text,
				TypeId = Convert.ToInt32(comboBox1.SelectedValue),
				Author = textBox3.Text,
				Publisher = textBox4.Text,
				PublisherDate = dateTimePicker1.Value,
				Price = Convert.ToInt32(textBox6.Text),
				Picture = bookBase64,
				Description=textBox7.Text
			};
			var result = await HttpHelper.PostAsync<BookAddModel, ApiResult>(ApiUrls.BookUrl,model);
			if (result?.Status == "ok")
			{
				PublicData.Book = result.Data as BookDTO;
				PublicData.BookType = new TypeDTO
				{
					Id = Convert.ToInt32(comboBox1.SelectedValue),
					Name = comboBox1.SelectedText
				};
				MessageBox.Show("添加成功");
				Close();
				return;
			}
			if (result?.Status == "error")
			{
				MessageBox.Show("添加失败:" + result.ErrorMsg);
			}
			else
			{
				MessageBox.Show("添加失败,未知错误");
			}
		}
	}
}
