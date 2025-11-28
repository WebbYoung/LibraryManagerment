namespace Library.UI
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			label2 = new Label();
			Phone = new TextBox();
			Password = new TextBox();
			label3 = new Label();
			button1 = new Button();
			label4 = new Label();
			textBox3 = new TextBox();
			VerifyCode = new PictureBox();
			button2 = new Button();
			((System.ComponentModel.ISupportInitialize)VerifyCode).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(121, 161);
			label1.Name = "label1";
			label1.Size = new Size(46, 24);
			label1.TabIndex = 0;
			label1.Text = "密码";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(121, 104);
			label2.Name = "label2";
			label2.Size = new Size(64, 24);
			label2.TabIndex = 1;
			label2.Text = "手机号";
			// 
			// Phone
			// 
			Phone.Location = new Point(208, 98);
			Phone.Name = "Phone";
			Phone.Size = new Size(297, 30);
			Phone.TabIndex = 2;
			// 
			// Password
			// 
			Password.Location = new Point(208, 155);
			Password.Name = "Password";
			Password.PasswordChar = '*';
			Password.Size = new Size(297, 30);
			Password.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(239, 48);
			label3.Name = "label3";
			label3.Size = new Size(82, 24);
			label3.TabIndex = 4;
			label3.Text = "用户登录";
			// 
			// button1
			// 
			button1.Location = new Point(153, 300);
			button1.Name = "button1";
			button1.Size = new Size(117, 55);
			button1.TabIndex = 5;
			button1.Text = "登录";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(122, 219);
			label4.Name = "label4";
			label4.Size = new Size(64, 24);
			label4.TabIndex = 6;
			label4.Text = "验证码";
			// 
			// textBox3
			// 
			textBox3.Location = new Point(208, 219);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(150, 30);
			textBox3.TabIndex = 7;
			// 
			// VerifyCode
			// 
			VerifyCode.Location = new Point(374, 219);
			VerifyCode.Name = "VerifyCode";
			VerifyCode.Size = new Size(131, 57);
			VerifyCode.TabIndex = 8;
			VerifyCode.TabStop = false;
			VerifyCode.Click += VerifyCode_Click;
			// 
			// button2
			// 
			button2.Location = new Point(322, 300);
			button2.Name = "button2";
			button2.Size = new Size(125, 55);
			button2.TabIndex = 9;
			button2.Text = "注册";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(11F, 24F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(630, 403);
			Controls.Add(button2);
			Controls.Add(VerifyCode);
			Controls.Add(textBox3);
			Controls.Add(label4);
			Controls.Add(button1);
			Controls.Add(label3);
			Controls.Add(Password);
			Controls.Add(Phone);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "LoginForm";
			Text = "图书管理系统";
			Load += LoginForm_Load;
			((System.ComponentModel.ISupportInitialize)VerifyCode).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private TextBox Phone;
		private TextBox Password;
		private Label label3;
		private Button button1;
		private Label label4;
		private TextBox textBox3;
		private PictureBox VerifyCode;
		private Button button2;
	}
}
