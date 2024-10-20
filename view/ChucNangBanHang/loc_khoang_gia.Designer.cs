namespace DBMS_Final_Project.view.ChucNangBanHang
{
    partial class loc_khoang_gia
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
            this.lbl_bat_dau = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_ket_thuc = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_xac_nhan = new System.Windows.Forms.Button();
            this.btn_huy_bo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_bat_dau
            // 
            this.lbl_bat_dau.AutoSize = true;
            this.lbl_bat_dau.Location = new System.Drawing.Point(13, 13);
            this.lbl_bat_dau.Name = "lbl_bat_dau";
            this.lbl_bat_dau.Size = new System.Drawing.Size(23, 16);
            this.lbl_bat_dau.TabIndex = 0;
            this.lbl_bat_dau.Text = "Từ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(412, 22);
            this.textBox1.TabIndex = 1;
            // 
            // lbl_ket_thuc
            // 
            this.lbl_ket_thuc.AutoSize = true;
            this.lbl_ket_thuc.Location = new System.Drawing.Point(13, 67);
            this.lbl_ket_thuc.Name = "lbl_ket_thuc";
            this.lbl_ket_thuc.Size = new System.Drawing.Size(31, 16);
            this.lbl_ket_thuc.TabIndex = 2;
            this.lbl_ket_thuc.Text = "Đến";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(412, 22);
            this.textBox2.TabIndex = 3;
            // 
            // btn_xac_nhan
            // 
            this.btn_xac_nhan.Location = new System.Drawing.Point(344, 124);
            this.btn_xac_nhan.Name = "btn_xac_nhan";
            this.btn_xac_nhan.Size = new System.Drawing.Size(92, 31);
            this.btn_xac_nhan.TabIndex = 4;
            this.btn_xac_nhan.Text = "Xác nhận";
            this.btn_xac_nhan.UseVisualStyleBackColor = true;
            // 
            // btn_huy_bo
            // 
            this.btn_huy_bo.Location = new System.Drawing.Point(248, 124);
            this.btn_huy_bo.Name = "btn_huy_bo";
            this.btn_huy_bo.Size = new System.Drawing.Size(87, 31);
            this.btn_huy_bo.TabIndex = 5;
            this.btn_huy_bo.Text = "Hủy bỏ";
            this.btn_huy_bo.UseVisualStyleBackColor = true;
            // 
            // loc_khoang_gia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 163);
            this.Controls.Add(this.btn_huy_bo);
            this.Controls.Add(this.btn_xac_nhan);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbl_ket_thuc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_bat_dau);
            this.Name = "loc_khoang_gia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn khoảng giá";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_bat_dau;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_ket_thuc;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_xac_nhan;
        private System.Windows.Forms.Button btn_huy_bo;
    }
}