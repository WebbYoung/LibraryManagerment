namespace Library.UI
{
	partial class RegisterForm
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
			button2 = new Button();
			SMSCode = new TextBox();
			label4 = new Label();
			label3 = new Label();
			Password = new TextBox();
			Phone = new TextBox();
			label2 = new Label();
			label1 = new Label();
			button3 = new Button();
			button1 = new Button();
			SuspendLayout();
			// 
			// button2
			// 
			button2.Location = new Point(209, 314);
			button2.Name = "button2";
			button2.Size = new Size(125, 55);
			button2.TabIndex = 19;
			button2.Text = "注册";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// SMSCode
			// 
			SMSCode.Location = new Point(295, 243);
			SMSCode.Name = "SMSCode";
			SMSCode.Size = new Size(150, 30);
			SMSCode.TabIndex = 17;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(209, 243);
			label4.Name = "label4";
			label4.Size = new Size(64, 24);
			label4.TabIndex = 16;
			label4.Text = "验证码";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(326, 72);
			label3.Name = "label3";
			label3.Size = new Size(82, 24);
			label3.TabIndex = 14;
			label3.Text = "用户注册";
			// 
			// Password
			// 
			Password.Location = new Point(295, 179);
			Password.Name = "Password";
			Password.PasswordChar = '*';
			Password.Size = new Size(297, 30);
			Password.TabIndex = 13;
			// 
			// Phone
			// 
			Phone.Location = new Point(295, 122);
			Phone.Name = "Phone";
			Phone.Size = new Size(297, 30);
			Phone.TabIndex = 12;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(208, 128);
			label2.Name = "label2";
			label2.Size = new Size(64, 24);
			label2.TabIndex = 11;
			label2.Text = "手机号";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(208, 185);
			label1.Name = "label1";
			label1.Size = new Size(46, 24);
			label1.TabIndex = 10;
			label1.Text = "密码";
			// 
			// button3
			// 
			button3.Location = new Point(467, 233);
			button3.Name = "button3";
			button3.Size = new Size(125, 53);
			button3.TabIndex = 20;
			button3.Text = "发送验证码";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// button1
			// 
			button1.Location = new Point(423, 314);
			button1.Name = "button1";
			button1.Size = new Size(120, 55);
			button1.TabIndex = 21;
			button1.Text = "返回登录";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// RegisterForm
			// 
			AutoScaleDimensions = new SizeF(11F, 24F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(button1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(SMSCode);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(Password);
			Controls.Add(Phone);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "RegisterForm";
			Text = "RegisterForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button2;
		private TextBox SMSCode;
		private Label label4;
		private Label label3;
		private TextBox Password;
		private TextBox Phone;
		private Label label2;
		private Label label1;
		private Button button3;
		private Button button1;
	}
}