namespace Library.UI
{
	partial class VerifyForm
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
			textBox1 = new TextBox();
			pictureBox1 = new PictureBox();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(97, 119);
			label1.Name = "label1";
			label1.Size = new Size(118, 24);
			label1.TabIndex = 0;
			label1.Text = "请输入验证码";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(251, 119);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(150, 30);
			textBox1.TabIndex = 1;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(450, 104);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(150, 75);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			pictureBox1.Click += pictureBox1_Click;
			// 
			// button1
			// 
			button1.Location = new Point(279, 227);
			button1.Name = "button1";
			button1.Size = new Size(141, 71);
			button1.TabIndex = 3;
			button1.Text = "确定";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// VerifyForm
			// 
			AutoScaleDimensions = new SizeF(11F, 24F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(702, 358);
			Controls.Add(button1);
			Controls.Add(pictureBox1);
			Controls.Add(textBox1);
			Controls.Add(label1);
			Name = "VerifyForm";
			Text = "VerifyForm";
			Load += VerifyForm_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBox1;
		private PictureBox pictureBox1;
		private Button button1;
	}
}