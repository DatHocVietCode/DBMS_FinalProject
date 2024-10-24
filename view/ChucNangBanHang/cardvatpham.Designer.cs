namespace DBMS_Final_Project.view.ChucNangBanHang
{
    partial class cardvatpham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cardvatpham));
            this.picture_spdv = new System.Windows.Forms.PictureBox();
            this.lbl_ten = new System.Windows.Forms.Label();
            this.lbl_gia_goc = new System.Windows.Forms.Label();
            this.lbl_gia_uu_dai = new System.Windows.Forms.Label();
            this.btn_chi_tiet = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture_spdv)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_spdv
            // 
            this.picture_spdv.Image = ((System.Drawing.Image)(resources.GetObject("picture_spdv.Image")));
            this.picture_spdv.Location = new System.Drawing.Point(3, -1);
            this.picture_spdv.Name = "picture_spdv";
            this.picture_spdv.Size = new System.Drawing.Size(214, 169);
            this.picture_spdv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_spdv.TabIndex = 0;
            this.picture_spdv.TabStop = false;
            // 
            // lbl_ten
            // 
            this.lbl_ten.AutoEllipsis = true;
            this.lbl_ten.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ten.Location = new System.Drawing.Point(6, 184);
            this.lbl_ten.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_ten.Name = "lbl_ten";
            this.lbl_ten.Size = new System.Drawing.Size(211, 29);
            this.lbl_ten.TabIndex = 2;
            this.lbl_ten.Text = "label1";
            // 
            // lbl_gia_goc
            // 
            this.lbl_gia_goc.AutoEllipsis = true;
            this.lbl_gia_goc.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gia_goc.Location = new System.Drawing.Point(3, 237);
            this.lbl_gia_goc.Name = "lbl_gia_goc";
            this.lbl_gia_goc.Size = new System.Drawing.Size(210, 57);
            this.lbl_gia_goc.TabIndex = 3;
            this.lbl_gia_goc.Text = "label1";
            // 
            // lbl_gia_uu_dai
            // 
            this.lbl_gia_uu_dai.AutoEllipsis = true;
            this.lbl_gia_uu_dai.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gia_uu_dai.Location = new System.Drawing.Point(6, 294);
            this.lbl_gia_uu_dai.Name = "lbl_gia_uu_dai";
            this.lbl_gia_uu_dai.Size = new System.Drawing.Size(210, 68);
            this.lbl_gia_uu_dai.TabIndex = 4;
            this.lbl_gia_uu_dai.Text = "label1";
            this.lbl_gia_uu_dai.Click += new System.EventHandler(this.lbl_gia_uu_dai_Click);
            // 
            // btn_chi_tiet
            // 
            this.btn_chi_tiet.Location = new System.Drawing.Point(105, 384);
            this.btn_chi_tiet.Name = "btn_chi_tiet";
            this.btn_chi_tiet.Size = new System.Drawing.Size(89, 37);
            this.btn_chi_tiet.TabIndex = 5;
            this.btn_chi_tiet.Text = "Chi Tiết";
            this.btn_chi_tiet.UseVisualStyleBackColor = true;
            this.btn_chi_tiet.Click += new System.EventHandler(this.btn_chi_tiet_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(10, 384);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(89, 37);
            this.btn_them.TabIndex = 6;
            this.btn_them.Text = "Thêm ";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // cardvatpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_chi_tiet);
            this.Controls.Add(this.lbl_gia_uu_dai);
            this.Controls.Add(this.lbl_gia_goc);
            this.Controls.Add(this.lbl_ten);
            this.Controls.Add(this.picture_spdv);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "cardvatpham";
            this.Size = new System.Drawing.Size(217, 433);
            this.Load += new System.EventHandler(this.cardvatpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture_spdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picture_spdv;
        private System.Windows.Forms.Label lbl_ten;
        private System.Windows.Forms.Label lbl_gia_goc;
        private System.Windows.Forms.Label lbl_gia_uu_dai;
        private System.Windows.Forms.Button btn_chi_tiet;
        private System.Windows.Forms.Button btn_them;
    }
}
