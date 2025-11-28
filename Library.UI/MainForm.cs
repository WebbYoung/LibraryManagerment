using Library.Common;
using Library.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library.UI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			var allTypes = await HttpHelper.GetAsync<TypeDTO[]>(ApiUrls.BookTypesUrl);
			TreeNode root = new TreeNode("所有分类");
			root.Tag = new TypeDTO { Id = -1, Name = "所有分类" };
			
			foreach (var type in allTypes)
			{
				TreeNode child = new TreeNode(type.Name)
				{
					Tag = type
				};
				root.Nodes.Add(child);
			}
			treeView1.Nodes.Add(root);

			var allBooks = await HttpHelper.GetAsync<BookDTO[]>(ApiUrls.BookUrl);
			foreach (var book in allBooks)
			{
				dataGridView1.Rows.Add(book.Id.ToString(), book.Name, book.Author, book.Publisher, book.PublisherDate, book.Price.ToString());
			}
		}

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private async void 注销用户ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var response = MessageBox.Show("确定要注销当前用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (response == DialogResult.Yes)
			{
				var logout = await HttpHelper.GetAsync<ApiResult>(ApiUrls.LogoutUrl);
				if (logout != null && logout.Status == "ok")
				{
					MessageBox.Show("用户注销成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					DialogResult = DialogResult.Retry;
				}
				else
				{
					MessageBox.Show("用户注销失败！" + logout?.ErrorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void 添加图书ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddBook form = new AddBook();
			form.ShowDialog();
			var book = PublicData.Book;
			var bookType = PublicData.BookType;
			if (book is null || bookType is null) return;
			var selectNode = treeView1.SelectedNode.Tag as TypeDTO;
			if (selectNode == null) return;
			if (selectNode.Id == bookType.Id || selectNode.Id == -1)
			{
				dataGridView1.Rows.Add(book.Id.ToString(), book.Name, book.Author, book.Publisher, book.PublisherDate, book.Price.ToString());
			}
		}

		private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddType form = new AddType();
			form.ShowDialog();
			var newType = PublicData.BookType;
			if (newType == null) return;
			TreeNode node = new TreeNode(newType.Name)
			{
				Tag = newType
			};
			treeView1.Nodes[0].Nodes.Add(node);
		}

		private async void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode == null)
			{
				MessageBox.Show("请选中要删除的类型！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var selectType = treeView1.SelectedNode.Tag as TypeDTO;
			if (selectType.Id == -1)
			{
				MessageBox.Show("您不能删除所有类型！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			var resp = MessageBox.Show("删除类型会删除该类型下的所有图书，确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (resp == DialogResult.Yes)
			{
				var result = await HttpHelper.DeleteAsync<ApiResult>(ApiUrls.AddTypeUrl + $"/{selectType.Id}");
				if (result == null)
				{
					MessageBox.Show("请求未知异常");
					return;
				}
				if (result.Status == "ok")
				{
					treeView1.Nodes.Remove(treeView1.SelectedNode);
					MessageBox.Show("删除类型成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("删除类型失败！" + result.ErrorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode == null)
			{
				MessageBox.Show("请选中要修改的类型！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			PublicData.BookType = treeView1.SelectedNode.Tag as TypeDTO;
			EditType form = new EditType();
			form.ShowDialog();
			var res = PublicData.BookType;
			if (res is not null)
			{
				treeView1.SelectedNode.Tag = res;
				treeView1.SelectedNode.Text = res.Name;
			}
		}

		private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			var row = dataGridView1.Rows[e.RowIndex];
			if (row == null) return;
			int bookId = Convert.ToInt32(row.Cells[0].Value);
			var result = await HttpHelper.GetAsync<BookDetailsDTO>(ApiUrls.BookUrl + $"/{bookId}/detail");
			if (result == null) return;
			byte[] base64Pic = Convert.FromBase64String(result.PicBaseString ?? "");
			using Stream ms = new MemoryStream(base64Pic);
			pictureBox1.Image = Image.FromStream(ms);
			label1.Text = result.Description;
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private async void treeView1_AfterSelectAsync(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null) return;
			if (e.Node.Tag is TypeDTO dto)
			{
				dataGridView1.Rows.Clear();
				if (dto.Id == -1)
				{
					var allBooks = await HttpHelper.GetAsync<BookDTO[]>(ApiUrls.BookUrl);
					foreach (var book in allBooks)
					{
						dataGridView1.Rows.Add(book.Id.ToString(), book.Name, book.Name, book.Publisher, book.PublisherDate, book.Price.ToString());
					}
				}
				else
				{
					var books = await HttpHelper.GetAsync<BookDTO[]>(ApiUrls.BookTypesUrl + $"/{dto.Id}/book");
					foreach (var book in books)
					{
						dataGridView1.Rows.Add(book.Id.ToString(), book.Name, book.Name, book.Publisher, book.PublisherDate, book.Price.ToString());
					}
				}

			}
		}

		private async void 删除图书ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedBooks = dataGridView1.SelectedRows;
			if (selectedBooks.Count == 0)
			{
				MessageBox.Show("请先选择要删除那几行图书！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var res = MessageBox.Show("确定要删除选中的图书吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (res == DialogResult.Yes)
			{

				List<int> bookIds = new List<int>();
				foreach (DataGridViewRow row in selectedBooks)
				{
					bookIds.Add(Convert.ToInt32(row.Cells[0].Value));
				}
				var resp = await HttpHelper.PostAsync<int[], ApiResult>(ApiUrls.BookUrl + "/delete", bookIds.ToArray());
				if (resp == null)
				{
					MessageBox.Show("无响应");
					return;
				}
				if (resp.Status == "ok")
				{
					foreach (DataGridViewRow row in selectedBooks)
					{
						dataGridView1.Rows.Remove(row);
					}
					MessageBox.Show("删除图书成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("删除图书失败！" + resp.ErrorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private async void 修改图书ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedBooks = dataGridView1.SelectedRows;
			if (selectedBooks.Count != 1)
			{
				MessageBox.Show("请先选择要修改的图书！只能选一行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			PublicData.Book=new BookDTO
			{
				Id = Convert.ToInt32(selectedBooks[0].Cells[0].Value),
				Name = Convert.ToString(selectedBooks[0].Cells[1].Value),
				Author = Convert.ToString(selectedBooks[0].Cells[2].Value),
				Publisher = Convert.ToString(selectedBooks[0].Cells[3].Value),
				PublisherDate = Convert.ToDateTime(selectedBooks[0].Cells[4].Value),
				Price = Convert.ToInt32(selectedBooks[0].Cells[5].Value)
			};
			EditBook form = new EditBook();
			form.ShowDialog();
			TypeDTO? dto= treeView1.SelectedNode==null?null: treeView1.SelectedNode.Tag as TypeDTO;
			{
				dataGridView1.Rows.Clear();
				if (dto == null|| dto.Id == -1)
				{
					var allBooks = await HttpHelper.GetAsync<BookDTO[]>(ApiUrls.BookUrl);
					foreach (var book in allBooks)
					{
						dataGridView1.Rows.Add(book.Id.ToString(), book.Name, book.Name, book.Publisher, book.PublisherDate, book.Price.ToString());
					}
				}
				else
				{
					var books = await HttpHelper.GetAsync<BookDTO[]>(ApiUrls.BookTypesUrl + $"/{dto.Id}/book");
					foreach (var book in books)
					{
						dataGridView1.Rows.Add(book.Id.ToString(), book.Name, book.Name, book.Publisher, book.PublisherDate, book.Price.ToString());
					}
				}
			}
			pictureBox1.Image = null;
			label1.Text = "";
		}
	}
}
