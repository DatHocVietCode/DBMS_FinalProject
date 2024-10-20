namespace DBMS_Final_Project.view
{
    partial class signup
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_matkhau = new System.Windows.Forms.Label();
            this.lbl_taikhoan = new System.Windows.Forms.Label();
            this.lbl_petshop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.llbl_dangky = new System.Windows.Forms.LinkLabel();
            this.lbl_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "Đăng ký";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 268);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(338, 22);
            this.textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 173);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 22);
            this.textBox1.TabIndex = 9;
            // 
            // lbl_matkhau
            // 
            this.lbl_matkhau.AutoSize = true;
            this.lbl_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_matkhau.Location = new System.Drawing.Point(7, 223);
            this.lbl_matkhau.Name = "lbl_matkhau";
            this.lbl_matkhau.Size = new System.Drawing.Size(109, 29);
            this.lbl_matkhau.TabIndex = 8;
            this.lbl_matkhau.Text = "Mật khẩu";
            // 
            // lbl_taikhoan
            // 
            this.lbl_taikhoan.AutoSize = true;
            this.lbl_taikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_taikhoan.Location = new System.Drawing.Point(7, 141);
            this.lbl_taikhoan.Name = "lbl_taikhoan";
            this.lbl_taikhoan.Size = new System.Drawing.Size(119, 29);
            this.lbl_taikhoan.TabIndex = 7;
            this.lbl_taikhoan.Text = "Tài khoản";
            // 
            // lbl_petshop
            // 
            this.lbl_petshop.AutoSize = true;
            this.lbl_petshop.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_petshop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_petshop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_petshop.Location = new System.Drawing.Point(109, 20);
            this.lbl_petshop.Name = "lbl_petshop";
            this.lbl_petshop.Size = new System.Drawing.Size(165, 39);
            this.lbl_petshop.TabIndex = 6;
            this.lbl_petshop.Text = "Pet Shop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Đăng ký tài khoản";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 367);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(338, 22);
            this.textBox3.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Xác nhận mật khẩu";
            // 
            // llbl_dangky
            // 
            this.llbl_dangky.AutoSize = true;
            this.llbl_dangky.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbl_dangky.Location = new System.Drawing.Point(197, 484);
            this.llbl_dangky.Name = "llbl_dangky";
            this.llbl_dangky.Size = new System.Drawing.Size(72, 16);
            this.llbl_dangky.TabIndex = 16;
            this.llbl_dangky.TabStop = true;
            this.llbl_dangky.Text = "Đăng nhập";
            this.llbl_dangky.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_dangky_LinkClicked);
            // 
            // lbl_txt
            // 
            this.lbl_txt.AutoSize = true;
            this.lbl_txt.Location = new System.Drawing.Point(85, 484);
            this.lbl_txt.Name = "lbl_txt";
            this.lbl_txt.Size = new System.Drawing.Size(106, 16);
            this.lbl_txt.TabIndex = 15;
            this.lbl_txt.Text = "Đã có tài khoản?";
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 534);
            this.Controls.Add(this.llbl_dangky);
            this.Controls.Add(this.lbl_txt);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_matkhau);
            this.Controls.Add(this.lbl_taikhoan);
            this.Controls.Add(this.lbl_petshop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_matkhau;
        private System.Windows.Forms.Label lbl_taikhoan;
        private System.Windows.Forms.Label lbl_petshop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llbl_dangky;
        private System.Windows.Forms.Label lbl_txt;
    }
}