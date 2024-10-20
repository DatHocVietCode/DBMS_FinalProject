namespace DBMS_Final_Project.view
{
    partial class login
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
            this.lbl_petshop = new System.Windows.Forms.Label();
            this.lbl_taikhoan = new System.Windows.Forms.Label();
            this.lbl_matkhau = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_txt = new System.Windows.Forms.Label();
            this.llbl_dangky = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbl_petshop
            // 
            this.lbl_petshop.AutoSize = true;
            this.lbl_petshop.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_petshop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_petshop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_petshop.Location = new System.Drawing.Point(118, 47);
            this.lbl_petshop.Name = "lbl_petshop";
            this.lbl_petshop.Size = new System.Drawing.Size(165, 39);
            this.lbl_petshop.TabIndex = 0;
            this.lbl_petshop.Text = "Pet Shop";
            this.lbl_petshop.Click += new System.EventHandler(this.lbl_petshop_Click);
            // 
            // lbl_taikhoan
            // 
            this.lbl_taikhoan.AutoSize = true;
            this.lbl_taikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_taikhoan.Location = new System.Drawing.Point(16, 168);
            this.lbl_taikhoan.Name = "lbl_taikhoan";
            this.lbl_taikhoan.Size = new System.Drawing.Size(119, 29);
            this.lbl_taikhoan.TabIndex = 1;
            this.lbl_taikhoan.Text = "Tài khoản";
            this.lbl_taikhoan.Click += new System.EventHandler(this.lbl_taikhoan_Click);
            // 
            // lbl_matkhau
            // 
            this.lbl_matkhau.AutoSize = true;
            this.lbl_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_matkhau.Location = new System.Drawing.Point(16, 250);
            this.lbl_matkhau.Name = "lbl_matkhau";
            this.lbl_matkhau.Size = new System.Drawing.Size(109, 29);
            this.lbl_matkhau.TabIndex = 2;
            this.lbl_matkhau.Text = "Mật khẩu";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 295);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(338, 22);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Đăng nhập";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbl_txt
            // 
            this.lbl_txt.AutoSize = true;
            this.lbl_txt.Location = new System.Drawing.Point(84, 403);
            this.lbl_txt.Name = "lbl_txt";
            this.lbl_txt.Size = new System.Drawing.Size(120, 16);
            this.lbl_txt.TabIndex = 6;
            this.lbl_txt.Text = "Chưa có tài khoản?";
            // 
            // llbl_dangky
            // 
            this.llbl_dangky.AutoSize = true;
            this.llbl_dangky.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbl_dangky.Location = new System.Drawing.Point(210, 403);
            this.llbl_dangky.Name = "llbl_dangky";
            this.llbl_dangky.Size = new System.Drawing.Size(89, 16);
            this.llbl_dangky.TabIndex = 8;
            this.llbl_dangky.TabStop = true;
            this.llbl_dangky.Text = "Đăng ký ngay";
            this.llbl_dangky.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_dangky_LinkClicked);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 450);
            this.Controls.Add(this.llbl_dangky);
            this.Controls.Add(this.lbl_txt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_matkhau);
            this.Controls.Add(this.lbl_taikhoan);
            this.Controls.Add(this.lbl_petshop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_petshop;
        private System.Windows.Forms.Label lbl_taikhoan;
        private System.Windows.Forms.Label lbl_matkhau;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_txt;
        private System.Windows.Forms.LinkLabel llbl_dangky;
    }
}