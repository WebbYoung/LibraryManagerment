namespace Library.UI
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			treeView1 = new TreeView();
			dataGridView1 = new DataGridView();
			Id = new DataGridViewTextBoxColumn();
			BookName = new DataGridViewTextBoxColumn();
			Author = new DataGridViewTextBoxColumn();
			Publisher = new DataGridViewTextBoxColumn();
			PublisherDate = new DataGridViewTextBoxColumn();
			Price = new DataGridViewTextBoxColumn();
			groupBox1 = new GroupBox();
			pictureBox1 = new PictureBox();
			groupBox2 = new GroupBox();
			label1 = new Label();
			menuStrip1 = new MenuStrip();
			管理员ToolStripMenuItem = new ToolStripMenuItem();
			注销用户ToolStripMenuItem = new ToolStripMenuItem();
			添加图书ToolStripMenuItem = new ToolStripMenuItem();
			删除图书ToolStripMenuItem = new ToolStripMenuItem();
			修改图书ToolStripMenuItem = new ToolStripMenuItem();
			类型管理ToolStripMenuItem = new ToolStripMenuItem();
			新增ToolStripMenuItem = new ToolStripMenuItem();
			删除ToolStripMenuItem = new ToolStripMenuItem();
			修改ToolStripMenuItem = new ToolStripMenuItem();
			联系作者ToolStripMenuItem = new ToolStripMenuItem();
			退出ToolStripMenuItem = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox2.SuspendLayout();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// treeView1
			// 
			treeView1.Location = new Point(12, 49);
			treeView1.Name = "treeView1";
			treeView1.Size = new Size(200, 715);
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += treeView1_AfterSelectAsync;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, BookName, Author, Publisher, PublisherDate, Price });
			dataGridView1.Location = new Point(243, 49);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 62;
			dataGridView1.Size = new Size(974, 523);
			dataGridView1.TabIndex = 1;
			dataGridView1.CellClick += dataGridView1_CellClick;
			dataGridView1.CellContentClick += dataGridView1_CellContentClick;
			// 
			// Id
			// 
			Id.HeaderText = "编号";
			Id.MinimumWidth = 8;
			Id.Name = "Id";
			Id.Width = 150;
			// 
			// BookName
			// 
			BookName.HeaderText = "图书名";
			BookName.MinimumWidth = 8;
			BookName.Name = "BookName";
			BookName.Width = 150;
			// 
			// Author
			// 
			Author.HeaderText = "作者";
			Author.MinimumWidth = 8;
			Author.Name = "Author";
			Author.Width = 150;
			// 
			// Publisher
			// 
			Publisher.HeaderText = "出版社";
			Publisher.MinimumWidth = 8;
			Publisher.Name = "Publisher";
			Publisher.Width = 150;
			// 
			// PublisherDate
			// 
			PublisherDate.HeaderText = "出版时间";
			PublisherDate.MinimumWidth = 8;
			PublisherDate.Name = "PublisherDate";
			PublisherDate.Width = 150;
			// 
			// Price
			// 
			Price.HeaderText = "价格";
			Price.MinimumWidth = 8;
			Price.Name = "Price";
			Price.Width = 150;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(pictureBox1);
			groupBox1.Location = new Point(243, 587);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(202, 177);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "图书封面";
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(6, 29);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(190, 148);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(label1);
			groupBox2.Location = new Point(451, 587);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(766, 177);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "图书简绍";
			// 
			// label1
			// 
			label1.Location = new Point(3, 26);
			label1.Name = "label1";
			label1.Size = new Size(763, 148);
			label1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(24, 24);
			menuStrip1.Items.AddRange(new ToolStripItem[] { 管理员ToolStripMenuItem, 类型管理ToolStripMenuItem, 联系作者ToolStripMenuItem, 退出ToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1253, 32);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			// 
			// 管理员ToolStripMenuItem
			// 
			管理员ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 注销用户ToolStripMenuItem, 添加图书ToolStripMenuItem, 删除图书ToolStripMenuItem, 修改图书ToolStripMenuItem });
			管理员ToolStripMenuItem.Name = "管理员ToolStripMenuItem";
			管理员ToolStripMenuItem.Size = new Size(80, 28);
			管理员ToolStripMenuItem.Text = "管理员";
			// 
			// 注销用户ToolStripMenuItem
			// 
			注销用户ToolStripMenuItem.Name = "注销用户ToolStripMenuItem";
			注销用户ToolStripMenuItem.Size = new Size(270, 34);
			注销用户ToolStripMenuItem.Text = "注销用户";
			注销用户ToolStripMenuItem.Click += 注销用户ToolStripMenuItem_Click;
			// 
			// 添加图书ToolStripMenuItem
			// 
			添加图书ToolStripMenuItem.Name = "添加图书ToolStripMenuItem";
			添加图书ToolStripMenuItem.Size = new Size(270, 34);
			添加图书ToolStripMenuItem.Text = "添加图书";
			添加图书ToolStripMenuItem.Click += 添加图书ToolStripMenuItem_Click;
			// 
			// 删除图书ToolStripMenuItem
			// 
			删除图书ToolStripMenuItem.Name = "删除图书ToolStripMenuItem";
			删除图书ToolStripMenuItem.Size = new Size(270, 34);
			删除图书ToolStripMenuItem.Text = "删除图书";
			删除图书ToolStripMenuItem.Click += 删除图书ToolStripMenuItem_Click;
			// 
			// 修改图书ToolStripMenuItem
			// 
			修改图书ToolStripMenuItem.Name = "修改图书ToolStripMenuItem";
			修改图书ToolStripMenuItem.Size = new Size(270, 34);
			修改图书ToolStripMenuItem.Text = "修改图书";
			修改图书ToolStripMenuItem.Click += 修改图书ToolStripMenuItem_Click;
			// 
			// 类型管理ToolStripMenuItem
			// 
			类型管理ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 新增ToolStripMenuItem, 删除ToolStripMenuItem, 修改ToolStripMenuItem });
			类型管理ToolStripMenuItem.Name = "类型管理ToolStripMenuItem";
			类型管理ToolStripMenuItem.Size = new Size(98, 28);
			类型管理ToolStripMenuItem.Text = "类型管理";
			// 
			// 新增ToolStripMenuItem
			// 
			新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
			新增ToolStripMenuItem.Size = new Size(270, 34);
			新增ToolStripMenuItem.Text = "新增";
			新增ToolStripMenuItem.Click += 新增ToolStripMenuItem_Click;
			// 
			// 删除ToolStripMenuItem
			// 
			删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			删除ToolStripMenuItem.Size = new Size(270, 34);
			删除ToolStripMenuItem.Text = "删除";
			删除ToolStripMenuItem.Click += 删除ToolStripMenuItem_Click;
			// 
			// 修改ToolStripMenuItem
			// 
			修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
			修改ToolStripMenuItem.Size = new Size(270, 34);
			修改ToolStripMenuItem.Text = "修改";
			修改ToolStripMenuItem.Click += 修改ToolStripMenuItem_Click;
			// 
			// 联系作者ToolStripMenuItem
			// 
			联系作者ToolStripMenuItem.Name = "联系作者ToolStripMenuItem";
			联系作者ToolStripMenuItem.Size = new Size(98, 28);
			联系作者ToolStripMenuItem.Text = "联系作者";
			// 
			// 退出ToolStripMenuItem
			// 
			退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			退出ToolStripMenuItem.Size = new Size(62, 28);
			退出ToolStripMenuItem.Text = "退出";
			退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(11F, 24F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1253, 789);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(dataGridView1);
			Controls.Add(treeView1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "MainForm";
			Text = "MainForm";
			Load += MainForm_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox2.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TreeView treeView1;
		private DataGridView dataGridView1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private PictureBox pictureBox1;
		private Label label1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem 管理员ToolStripMenuItem;
		private ToolStripMenuItem 注销用户ToolStripMenuItem;
		private ToolStripMenuItem 添加图书ToolStripMenuItem;
		private ToolStripMenuItem 删除图书ToolStripMenuItem;
		private ToolStripMenuItem 修改图书ToolStripMenuItem;
		private ToolStripMenuItem 类型管理ToolStripMenuItem;
		private ToolStripMenuItem 新增ToolStripMenuItem;
		private ToolStripMenuItem 删除ToolStripMenuItem;
		private ToolStripMenuItem 修改ToolStripMenuItem;
		private ToolStripMenuItem 联系作者ToolStripMenuItem;
		private ToolStripMenuItem 退出ToolStripMenuItem;
		private DataGridViewTextBoxColumn Id;
		private DataGridViewTextBoxColumn BookName;
		private DataGridViewTextBoxColumn Author;
		private DataGridViewTextBoxColumn Publisher;
		private DataGridViewTextBoxColumn PublisherDate;
		private DataGridViewTextBoxColumn Price;
	}
}