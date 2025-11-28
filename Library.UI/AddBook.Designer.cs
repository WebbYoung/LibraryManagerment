namespace Library.UI
{
	partial class AddBook
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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			textBox1 = new TextBox();
			textBox3 = new TextBox();
			textBox4 = new TextBox();
			textBox6 = new TextBox();
			groupBox1 = new GroupBox();
			pictureBox1 = new PictureBox();
			groupBox2 = new GroupBox();
			textBox7 = new TextBox();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			openFileDialog1 = new OpenFileDialog();
			comboBox1 = new ComboBox();
			dateTimePicker1 = new DateTimePicker();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(66, 39);
			label1.Name = "label1";
			label1.Size = new Size(64, 24);
			label1.TabIndex = 0;
			label1.Text = "图书名";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(66, 98);
			label2.Name = "label2";
			label2.Size = new Size(82, 24);
			label2.TabIndex = 1;
			label2.Text = "图书类型";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(66, 157);
			label3.Name = "label3";
			label3.Size = new Size(46, 24);
			label3.TabIndex = 2;
			label3.Text = "作者";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(66, 216);
			label4.Name = "label4";
			label4.Size = new Size(64, 24);
			label4.TabIndex = 3;
			label4.Text = "出版社";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(66, 275);
			label5.Name = "label5";
			label5.Size = new Size(82, 24);
			label5.TabIndex = 4;
			label5.Text = "出版时间";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(66, 334);
			label6.Name = "label6";
			label6.Size = new Size(46, 24);
			label6.TabIndex = 5;
			label6.Text = "价格";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(185, 39);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(238, 30);
			textBox1.TabIndex = 6;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(185, 151);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(238, 30);
			textBox3.TabIndex = 8;
			// 
			// textBox4
			// 
			textBox4.Location = new Point(185, 216);
			textBox4.Name = "textBox4";
			textBox4.Size = new Size(238, 30);
			textBox4.TabIndex = 9;
			// 
			// textBox6
			// 
			textBox6.Location = new Point(185, 342);
			textBox6.Name = "textBox6";
			textBox6.Size = new Size(238, 30);
			textBox6.TabIndex = 11;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(pictureBox1);
			groupBox1.Location = new Point(467, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(259, 190);
			groupBox1.TabIndex = 12;
			groupBox1.TabStop = false;
			groupBox1.Text = "图片";
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(20, 41);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(210, 128);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(textBox7);
			groupBox2.Location = new Point(467, 247);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(259, 191);
			groupBox2.TabIndex = 13;
			groupBox2.TabStop = false;
			groupBox2.Text = "简介";
			// 
			// textBox7
			// 
			textBox7.Location = new Point(3, 26);
			textBox7.Multiline = true;
			textBox7.Name = "textBox7";
			textBox7.Size = new Size(250, 142);
			textBox7.TabIndex = 0;
			// 
			// button1
			// 
			button1.Location = new Point(113, 392);
			button1.Name = "button1";
			button1.Size = new Size(112, 34);
			button1.TabIndex = 14;
			button1.Text = "确定";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(280, 392);
			button2.Name = "button2";
			button2.Size = new Size(112, 34);
			button2.TabIndex = 15;
			button2.Text = "退出";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Location = new Point(537, 206);
			button3.Name = "button3";
			button3.RightToLeft = RightToLeft.No;
			button3.Size = new Size(112, 34);
			button3.TabIndex = 1;
			button3.Text = "浏览";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(185, 95);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(238, 32);
			comboBox1.TabIndex = 16;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(185, 275);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(238, 30);
			dateTimePicker1.TabIndex = 17;
			// 
			// AddBook
			// 
			AutoScaleDimensions = new SizeF(11F, 24F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(dateTimePicker1);
			Controls.Add(comboBox1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(textBox6);
			Controls.Add(textBox4);
			Controls.Add(textBox3);
			Controls.Add(textBox1);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "AddBook";
			Text = "AddBook";
			Load += AddBook_Load;
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private TextBox textBox1;
		private TextBox textBox3;
		private TextBox textBox4;
		private TextBox textBox6;
		private GroupBox groupBox1;
		private PictureBox pictureBox1;
		private GroupBox groupBox2;
		private TextBox textBox7;
		private Button button1;
		private Button button2;
		private Button button3;
		private OpenFileDialog openFileDialog1;
		private ComboBox comboBox1;
		private DateTimePicker dateTimePicker1;
	}
}