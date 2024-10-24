namespace DBMS_Final_Project.view.ChucNangBanHang
{
    partial class member_detail
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_ten = new System.Windows.Forms.Label();
            this.lbl_sdt = new System.Windows.Forms.Label();
            this.lbl_diem_tich_luy = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.txt_dtl = new System.Windows.Forms.TextBox();
            this.btn_xac_nhan = new System.Windows.Forms.Button();
            this.btn_huy_bo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(147, 24);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(33, 16);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Title";
            // 
            // lbl_ten
            // 
            this.lbl_ten.AutoSize = true;
            this.lbl_ten.Location = new System.Drawing.Point(26, 82);
            this.lbl_ten.Name = "lbl_ten";
            this.lbl_ten.Size = new System.Drawing.Size(103, 16);
            this.lbl_ten.TabIndex = 1;
            this.lbl_ten.Text = "Tên khách hàng";
            // 
            // lbl_sdt
            // 
            this.lbl_sdt.AutoSize = true;
            this.lbl_sdt.Location = new System.Drawing.Point(26, 159);
            this.lbl_sdt.Name = "lbl_sdt";
            this.lbl_sdt.Size = new System.Drawing.Size(85, 16);
            this.lbl_sdt.TabIndex = 2;
            this.lbl_sdt.Text = "Số điện thoại";
            // 
            // lbl_diem_tich_luy
            // 
            this.lbl_diem_tich_luy.AutoSize = true;
            this.lbl_diem_tich_luy.Location = new System.Drawing.Point(26, 238);
            this.lbl_diem_tich_luy.Name = "lbl_diem_tich_luy";
            this.lbl_diem_tich_luy.Size = new System.Drawing.Size(81, 16);
            this.lbl_diem_tich_luy.TabIndex = 3;
            this.lbl_diem_tich_luy.Text = "Điểm tích lũy";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(29, 101);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(382, 22);
            this.txt_name.TabIndex = 4;
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(29, 178);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(382, 22);
            this.txt_sdt.TabIndex = 5;
            // 
            // txt_dtl
            // 
            this.txt_dtl.Location = new System.Drawing.Point(29, 257);
            this.txt_dtl.Name = "txt_dtl";
            this.txt_dtl.Size = new System.Drawing.Size(382, 22);
            this.txt_dtl.TabIndex = 6;
            // 
            // btn_xac_nhan
            // 
            this.btn_xac_nhan.Location = new System.Drawing.Point(329, 334);
            this.btn_xac_nhan.Name = "btn_xac_nhan";
            this.btn_xac_nhan.Size = new System.Drawing.Size(82, 35);
            this.btn_xac_nhan.TabIndex = 7;
            this.btn_xac_nhan.Text = "Xác nhận";
            this.btn_xac_nhan.UseVisualStyleBackColor = true;
            this.btn_xac_nhan.Click += new System.EventHandler(this.btn_xac_nhan_Click);
            // 
            // btn_huy_bo
            // 
            this.btn_huy_bo.Location = new System.Drawing.Point(228, 334);
            this.btn_huy_bo.Name = "btn_huy_bo";
            this.btn_huy_bo.Size = new System.Drawing.Size(82, 35);
            this.btn_huy_bo.TabIndex = 8;
            this.btn_huy_bo.Text = "Hủy bỏ";
            this.btn_huy_bo.UseVisualStyleBackColor = true;
            this.btn_huy_bo.Click += new System.EventHandler(this.btn_huy_bo_Click);
            // 
            // member_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 388);
            this.Controls.Add(this.btn_huy_bo);
            this.Controls.Add(this.btn_xac_nhan);
            this.Controls.Add(this.txt_dtl);
            this.Controls.Add(this.txt_sdt);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_diem_tich_luy);
            this.Controls.Add(this.lbl_sdt);
            this.Controls.Add(this.lbl_ten);
            this.Controls.Add(this.lbl_title);
            this.Name = "member_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin khách hàng";
            this.Load += new System.EventHandler(this.member_detail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_ten;
        private System.Windows.Forms.Label lbl_sdt;
        private System.Windows.Forms.Label lbl_diem_tich_luy;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.TextBox txt_dtl;
        private System.Windows.Forms.Button btn_xac_nhan;
        private System.Windows.Forms.Button btn_huy_bo;
    }
}