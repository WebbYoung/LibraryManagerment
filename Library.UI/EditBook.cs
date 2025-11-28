using Library.Common;
using Library.DTO;
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
	public partial class EditBook : Form
	{
		public EditBook()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void EditBook_Load(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";
			var types = await HttpHelper.GetAsync<TypeDTO[]>(ApiUrls.BookTypesUrl);
			if (types != null)
			{
				comboBox1.DataSource = types;
				comboBox1.ValueMember = "Id";
				comboBox1.DisplayMember = "Name";
			}
			var book = PublicData.Book;
			if (book is null) throw new ArgumentException("图书为空");
			var detail = await HttpHelper.GetAsync<BookDetailsDTO>(ApiUrls.BookUrl + $"/{book.Id}/detail");
			var type = await HttpHelper.GetAsync<TypeDTO>(ApiUrls.BookTypesUrl + $"/{book.Id}");
			if (book != null)
			{
				label7.Text = book.Id.ToString();
				textBox1.Text = book.Name;
				textBox3.Text = book.Author;
				textBox4.Text = book.Publisher;
				dateTimePicker1.Value = book.PublisherDate;
				textBox6.Text = book.Price.ToString();
			}
			if (type != null)
			{
				foreach (var item in comboBox1.Items)
				{
					if (item is TypeDTO dto && dto.Id == type.Id)
					{
						comboBox1.SelectedItem = item;
						break;
					}
				}
			}
			if (detail != null)
			{
				textBox7.Text = detail.Description;
				byte[] base64Pic = Convert.FromBase64String(detail.PicBaseString ?? "");
				using Stream ms = new MemoryStream(base64Pic);
				pictureBox1.Image = Image.FromStream(ms);
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedValue == null)
			{
				MessageBox.Show("请选择一个分类");
				return;
			}
			string? bookBase64 = null;
			if (!string.IsNullOrEmpty(openFileDialog1.FileName))
			{
				byte[] bookBytes = await File.ReadAllBytesAsync(openFileDialog1.FileName);
				bookBase64 = Convert.ToBase64String(bookBytes);
			}
			var model = new BookEditModel()
			{
				Name = textBox1.Text,
				TypeId = Convert.ToInt32(comboBox1.SelectedValue),
				Author = textBox3.Text,
				Publisher = textBox4.Text,
				PublisherDate = dateTimePicker1.Value,
				Price = Convert.ToInt32(textBox6.Text),
				Picture = bookBase64,
				Description = textBox7.Text
			};
			var result = await HttpHelper.PostAsync<BookEditModel, ApiResult>(ApiUrls.BookUrl + $"/edit/{label7.Text}", model);
			if (result?.Status == "ok")
			{
				MessageBox.Show("修改成功");
				Close();
				return;
			}
			if (result?.Status == "error")
			{
				MessageBox.Show("修改失败:" + result.ErrorMsg);
			}
			else
			{
				MessageBox.Show("修改失败,未知错误");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";
			openFileDialog1.Filter = "IMG File(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
			openFileDialog1.ShowDialog();
			pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
		}
	}

}

