namespace DBMS_Final_Project.view.ChucNangBanHang
{
    partial class main_ban_hang
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_ban_hang));
            this.lbl_title = new System.Windows.Forms.Label();
            this.tc_ban_hang = new System.Windows.Forms.TabControl();
            this.tp_spdv = new System.Windows.Forms.TabPage();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_xac_nhan = new System.Windows.Forms.Button();
            this.btn_huy_bo = new System.Windows.Forms.Button();
            this.lv_hoa_don = new System.Windows.Forms.ListView();
            this.tb_types = new System.Windows.Forms.TabControl();
            this.tp_thu_cung = new System.Windows.Forms.TabPage();
            this.tp_vat_pham = new System.Windows.Forms.TabPage();
            this.tp_dich_vu = new System.Windows.Forms.TabPage();
            this.btn_tim_kiem = new System.Windows.Forms.Button();
            this.txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.cb_alphabet = new System.Windows.Forms.ComboBox();
            this.cb_gia = new System.Windows.Forms.ComboBox();
            this.tp_hoa_don = new System.Windows.Forms.TabPage();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.cb_tong_tien = new System.Windows.Forms.ComboBox();
            this.cb_ngay_tao = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_chua_thanh_toan = new System.Windows.Forms.TabPage();
            this.tp_da_thanh_toan = new System.Windows.Forms.TabPage();
            this.tp_thanh_vien = new System.Windows.Forms.TabPage();
            this.btn_tim_kiem_thanh_vien = new System.Windows.Forms.Button();
            this.txt_tim_kiem_thanh_vien = new System.Windows.Forms.TextBox();
            this.btn_sua_thanh_vien = new System.Windows.Forms.Button();
            this.btn_xoa_thanh_vien = new System.Windows.Forms.Button();
            this.btn_them_thanh_vien = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tc_ban_hang.SuspendLayout();
            this.tp_spdv.SuspendLayout();
            this.tb_types.SuspendLayout();
            this.tp_hoa_don.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp_thanh_vien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(511, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(137, 31);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Bán hàng";
            // 
            // tc_ban_hang
            // 
            this.tc_ban_hang.Controls.Add(this.tp_spdv);
            this.tc_ban_hang.Controls.Add(this.tp_hoa_don);
            this.tc_ban_hang.Controls.Add(this.tp_thanh_vien);
            this.tc_ban_hang.Location = new System.Drawing.Point(0, 43);
            this.tc_ban_hang.Name = "tc_ban_hang";
            this.tc_ban_hang.SelectedIndex = 0;
            this.tc_ban_hang.Size = new System.Drawing.Size(1143, 586);
            this.tc_ban_hang.TabIndex = 1;
            // 
            // tp_spdv
            // 
            this.tp_spdv.BackColor = System.Drawing.SystemColors.Window;
            this.tp_spdv.Controls.Add(this.label4);
            this.tp_spdv.Controls.Add(this.btn_xoa);
            this.tp_spdv.Controls.Add(this.btn_xac_nhan);
            this.tp_spdv.Controls.Add(this.btn_huy_bo);
            this.tp_spdv.Controls.Add(this.lv_hoa_don);
            this.tp_spdv.Controls.Add(this.tb_types);
            this.tp_spdv.Controls.Add(this.btn_tim_kiem);
            this.tp_spdv.Controls.Add(this.txt_tim_kiem);
            this.tp_spdv.Controls.Add(this.cb_alphabet);
            this.tp_spdv.Controls.Add(this.cb_gia);
            this.tp_spdv.Location = new System.Drawing.Point(4, 25);
            this.tp_spdv.Name = "tp_spdv";
            this.tp_spdv.Padding = new System.Windows.Forms.Padding(3);
            this.tp_spdv.Size = new System.Drawing.Size(1135, 557);
            this.tp_spdv.TabIndex = 0;
            this.tp_spdv.Text = "Sản phẩm và dịch vụ";
            this.tp_spdv.Click += new System.EventHandler(this.tp_spdv_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(781, 516);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(100, 33);
            this.btn_xoa.TabIndex = 9;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_xac_nhan
            // 
            this.btn_xac_nhan.Location = new System.Drawing.Point(1017, 516);
            this.btn_xac_nhan.Name = "btn_xac_nhan";
            this.btn_xac_nhan.Size = new System.Drawing.Size(96, 33);
            this.btn_xac_nhan.TabIndex = 8;
            this.btn_xac_nhan.Text = "Xác nhận";
            this.btn_xac_nhan.UseVisualStyleBackColor = true;
            this.btn_xac_nhan.Click += new System.EventHandler(this.btn_xac_nhan_Click);
            // 
            // btn_huy_bo
            // 
            this.btn_huy_bo.Location = new System.Drawing.Point(900, 516);
            this.btn_huy_bo.Name = "btn_huy_bo";
            this.btn_huy_bo.Size = new System.Drawing.Size(100, 33);
            this.btn_huy_bo.TabIndex = 7;
            this.btn_huy_bo.Text = "Hủy bỏ";
            this.btn_huy_bo.UseVisualStyleBackColor = true;
            this.btn_huy_bo.Click += new System.EventHandler(this.btn_huy_bo_Click);
            // 
            // lv_hoa_don
            // 
            this.lv_hoa_don.FullRowSelect = true;
            this.lv_hoa_don.HideSelection = false;
            this.lv_hoa_don.Location = new System.Drawing.Point(734, 82);
            this.lv_hoa_don.Name = "lv_hoa_don";
            this.lv_hoa_don.Size = new System.Drawing.Size(398, 428);
            this.lv_hoa_don.TabIndex = 6;
            this.lv_hoa_don.UseCompatibleStateImageBehavior = false;
            this.lv_hoa_don.SelectedIndexChanged += new System.EventHandler(this.lv_hoa_don_SelectedIndexChanged);
            // 
            // tb_types
            // 
            this.tb_types.Controls.Add(this.tp_thu_cung);
            this.tb_types.Controls.Add(this.tp_vat_pham);
            this.tb_types.Controls.Add(this.tp_dich_vu);
            this.tb_types.Location = new System.Drawing.Point(0, 57);
            this.tb_types.Name = "tb_types";
            this.tb_types.SelectedIndex = 0;
            this.tb_types.Size = new System.Drawing.Size(728, 497);
            this.tb_types.TabIndex = 5;
            // 
            // tp_thu_cung
            // 
            this.tp_thu_cung.Location = new System.Drawing.Point(4, 25);
            this.tp_thu_cung.Name = "tp_thu_cung";
            this.tp_thu_cung.Padding = new System.Windows.Forms.Padding(3);
            this.tp_thu_cung.Size = new System.Drawing.Size(720, 468);
            this.tp_thu_cung.TabIndex = 0;
            this.tp_thu_cung.Text = "Thú cưng";
            this.tp_thu_cung.UseVisualStyleBackColor = true;
            // 
            // tp_vat_pham
            // 
            this.tp_vat_pham.Location = new System.Drawing.Point(4, 25);
            this.tp_vat_pham.Name = "tp_vat_pham";
            this.tp_vat_pham.Padding = new System.Windows.Forms.Padding(3);
            this.tp_vat_pham.Size = new System.Drawing.Size(720, 468);
            this.tp_vat_pham.TabIndex = 1;
            this.tp_vat_pham.Text = "Vật phẩm";
            this.tp_vat_pham.UseVisualStyleBackColor = true;
            // 
            // tp_dich_vu
            // 
            this.tp_dich_vu.Location = new System.Drawing.Point(4, 25);
            this.tp_dich_vu.Name = "tp_dich_vu";
            this.tp_dich_vu.Size = new System.Drawing.Size(720, 468);
            this.tp_dich_vu.TabIndex = 2;
            this.tp_dich_vu.Text = "Dịch vụ";
            this.tp_dich_vu.UseVisualStyleBackColor = true;
            // 
            // btn_tim_kiem
            // 
            this.btn_tim_kiem.Location = new System.Drawing.Point(781, 19);
            this.btn_tim_kiem.Name = "btn_tim_kiem";
            this.btn_tim_kiem.Size = new System.Drawing.Size(29, 24);
            this.btn_tim_kiem.TabIndex = 4;
            this.btn_tim_kiem.UseVisualStyleBackColor = true;
            this.btn_tim_kiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // txt_tim_kiem
            // 
            this.txt_tim_kiem.Location = new System.Drawing.Point(816, 19);
            this.txt_tim_kiem.Name = "txt_tim_kiem";
            this.txt_tim_kiem.Size = new System.Drawing.Size(273, 22);
            this.txt_tim_kiem.TabIndex = 3;
            this.txt_tim_kiem.Text = "Tìm kiếm";
            this.txt_tim_kiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_tim_kiem_MouseClick);
            this.txt_tim_kiem.TextChanged += new System.EventHandler(this.txt_tim_kiem_TextChanged);
            // 
            // cb_alphabet
            // 
            this.cb_alphabet.FormattingEnabled = true;
            this.cb_alphabet.Items.AddRange(new object[] {
            "A - Z",
            "Z - A"});
            this.cb_alphabet.Location = new System.Drawing.Point(204, 16);
            this.cb_alphabet.Name = "cb_alphabet";
            this.cb_alphabet.Size = new System.Drawing.Size(121, 24);
            this.cb_alphabet.TabIndex = 1;
            // 
            // cb_gia
            // 
            this.cb_gia.FormattingEnabled = true;
            this.cb_gia.Items.AddRange(new object[] {
            "Tăng dần",
            "Giảm dần",
            "Tùy chỉnh"});
            this.cb_gia.Location = new System.Drawing.Point(24, 17);
            this.cb_gia.Name = "cb_gia";
            this.cb_gia.Size = new System.Drawing.Size(121, 24);
            this.cb_gia.TabIndex = 0;
            this.cb_gia.SelectedIndexChanged += new System.EventHandler(this.cb_gia_SelectedIndexChanged);
            // 
            // tp_hoa_don
            // 
            this.tp_hoa_don.Controls.Add(this.label2);
            this.tp_hoa_don.Controls.Add(this.label3);
            this.tp_hoa_don.Controls.Add(this.label1);
            this.tp_hoa_don.Controls.Add(this.dtp);
            this.tp_hoa_don.Controls.Add(this.cb_tong_tien);
            this.tp_hoa_don.Controls.Add(this.cb_ngay_tao);
            this.tp_hoa_don.Controls.Add(this.tabControl1);
            this.tp_hoa_don.Location = new System.Drawing.Point(4, 25);
            this.tp_hoa_don.Name = "tp_hoa_don";
            this.tp_hoa_don.Padding = new System.Windows.Forms.Padding(3);
            this.tp_hoa_don.Size = new System.Drawing.Size(1135, 557);
            this.tp_hoa_don.TabIndex = 1;
            this.tp_hoa_don.Text = "Hóa đơn";
            this.tp_hoa_don.UseVisualStyleBackColor = true;
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(857, 27);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(271, 22);
            this.dtp.TabIndex = 3;
            // 
            // cb_tong_tien
            // 
            this.cb_tong_tien.FormattingEnabled = true;
            this.cb_tong_tien.Items.AddRange(new object[] {
            "Tăng dần",
            "Giảm dần"});
            this.cb_tong_tien.Location = new System.Drawing.Point(523, 25);
            this.cb_tong_tien.Name = "cb_tong_tien";
            this.cb_tong_tien.Size = new System.Drawing.Size(121, 24);
            this.cb_tong_tien.TabIndex = 2;
            // 
            // cb_ngay_tao
            // 
            this.cb_ngay_tao.FormattingEnabled = true;
            this.cb_ngay_tao.Items.AddRange(new object[] {
            "Mới nhất",
            "Cũ nhất"});
            this.cb_ngay_tao.Location = new System.Drawing.Point(201, 25);
            this.cb_ngay_tao.Name = "cb_ngay_tao";
            this.cb_ngay_tao.Size = new System.Drawing.Size(121, 24);
            this.cb_ngay_tao.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_chua_thanh_toan);
            this.tabControl1.Controls.Add(this.tp_da_thanh_toan);
            this.tabControl1.Location = new System.Drawing.Point(8, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1124, 491);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_chua_thanh_toan
            // 
            this.tp_chua_thanh_toan.Location = new System.Drawing.Point(4, 25);
            this.tp_chua_thanh_toan.Name = "tp_chua_thanh_toan";
            this.tp_chua_thanh_toan.Padding = new System.Windows.Forms.Padding(3);
            this.tp_chua_thanh_toan.Size = new System.Drawing.Size(1116, 462);
            this.tp_chua_thanh_toan.TabIndex = 0;
            this.tp_chua_thanh_toan.Text = "Chưa thanh toán";
            this.tp_chua_thanh_toan.UseVisualStyleBackColor = true;
            // 
            // tp_da_thanh_toan
            // 
            this.tp_da_thanh_toan.Location = new System.Drawing.Point(4, 25);
            this.tp_da_thanh_toan.Name = "tp_da_thanh_toan";
            this.tp_da_thanh_toan.Padding = new System.Windows.Forms.Padding(3);
            this.tp_da_thanh_toan.Size = new System.Drawing.Size(1116, 462);
            this.tp_da_thanh_toan.TabIndex = 1;
            this.tp_da_thanh_toan.Text = "Đã thanh toán";
            this.tp_da_thanh_toan.UseVisualStyleBackColor = true;
            // 
            // tp_thanh_vien
            // 
            this.tp_thanh_vien.Controls.Add(this.dataGridView1);
            this.tp_thanh_vien.Controls.Add(this.btn_tim_kiem_thanh_vien);
            this.tp_thanh_vien.Controls.Add(this.txt_tim_kiem_thanh_vien);
            this.tp_thanh_vien.Controls.Add(this.btn_sua_thanh_vien);
            this.tp_thanh_vien.Controls.Add(this.btn_xoa_thanh_vien);
            this.tp_thanh_vien.Controls.Add(this.btn_them_thanh_vien);
            this.tp_thanh_vien.Location = new System.Drawing.Point(4, 25);
            this.tp_thanh_vien.Name = "tp_thanh_vien";
            this.tp_thanh_vien.Size = new System.Drawing.Size(1135, 557);
            this.tp_thanh_vien.TabIndex = 2;
            this.tp_thanh_vien.Text = "Thành viên";
            this.tp_thanh_vien.UseVisualStyleBackColor = true;
            // 
            // btn_tim_kiem_thanh_vien
            // 
            this.btn_tim_kiem_thanh_vien.Location = new System.Drawing.Point(747, 36);
            this.btn_tim_kiem_thanh_vien.Name = "btn_tim_kiem_thanh_vien";
            this.btn_tim_kiem_thanh_vien.Size = new System.Drawing.Size(29, 24);
            this.btn_tim_kiem_thanh_vien.TabIndex = 6;
            this.btn_tim_kiem_thanh_vien.UseVisualStyleBackColor = true;
            // 
            // txt_tim_kiem_thanh_vien
            // 
            this.txt_tim_kiem_thanh_vien.Location = new System.Drawing.Point(782, 36);
            this.txt_tim_kiem_thanh_vien.Name = "txt_tim_kiem_thanh_vien";
            this.txt_tim_kiem_thanh_vien.Size = new System.Drawing.Size(273, 22);
            this.txt_tim_kiem_thanh_vien.TabIndex = 5;
            this.txt_tim_kiem_thanh_vien.Text = "Tìm kiếm";
            this.txt_tim_kiem_thanh_vien.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_tim_kiem_thanh_vien_MouseClick);
            this.txt_tim_kiem_thanh_vien.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_sua_thanh_vien
            // 
            this.btn_sua_thanh_vien.Location = new System.Drawing.Point(260, 23);
            this.btn_sua_thanh_vien.Name = "btn_sua_thanh_vien";
            this.btn_sua_thanh_vien.Size = new System.Drawing.Size(90, 35);
            this.btn_sua_thanh_vien.TabIndex = 2;
            this.btn_sua_thanh_vien.Text = "Sửa";
            this.btn_sua_thanh_vien.UseVisualStyleBackColor = true;
            this.btn_sua_thanh_vien.Click += new System.EventHandler(this.btn_sua_thanh_vien_Click);
            // 
            // btn_xoa_thanh_vien
            // 
            this.btn_xoa_thanh_vien.Location = new System.Drawing.Point(140, 23);
            this.btn_xoa_thanh_vien.Name = "btn_xoa_thanh_vien";
            this.btn_xoa_thanh_vien.Size = new System.Drawing.Size(90, 35);
            this.btn_xoa_thanh_vien.TabIndex = 1;
            this.btn_xoa_thanh_vien.Text = "Xóa";
            this.btn_xoa_thanh_vien.UseVisualStyleBackColor = true;
            // 
            // btn_them_thanh_vien
            // 
            this.btn_them_thanh_vien.Location = new System.Drawing.Point(20, 23);
            this.btn_them_thanh_vien.Name = "btn_them_thanh_vien";
            this.btn_them_thanh_vien.Size = new System.Drawing.Size(90, 35);
            this.btn_them_thanh_vien.TabIndex = 0;
            this.btn_them_thanh_vien.Text = "Thêm";
            this.btn_them_thanh_vien.UseVisualStyleBackColor = true;
            this.btn_them_thanh_vien.Click += new System.EventHandler(this.btn_them_thanh_vien_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Search_Icon.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1132, 491);
            this.dataGridView1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sắp xếp theo ngày tạo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sắp xếp theo giá trị";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(686, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "hoặc chọn ngày xác định";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(864, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tạo hóa đơn mới";
            // 
            // main_ban_hang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 629);
            this.Controls.Add(this.tc_ban_hang);
            this.Controls.Add(this.lbl_title);
            this.Name = "main_ban_hang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main_ban_hang";
            this.Load += new System.EventHandler(this.main_ban_hang_Load);
            this.tc_ban_hang.ResumeLayout(false);
            this.tp_spdv.ResumeLayout(false);
            this.tp_spdv.PerformLayout();
            this.tb_types.ResumeLayout(false);
            this.tp_hoa_don.ResumeLayout(false);
            this.tp_hoa_don.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tp_thanh_vien.ResumeLayout(false);
            this.tp_thanh_vien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.TabControl tc_ban_hang;
        private System.Windows.Forms.TabPage tp_spdv;
        private System.Windows.Forms.TabPage tp_hoa_don;
        private System.Windows.Forms.TabPage tp_thanh_vien;
        private System.Windows.Forms.ComboBox cb_gia;
        private System.Windows.Forms.ComboBox cb_alphabet;
        private System.Windows.Forms.Button btn_tim_kiem;
        private System.Windows.Forms.TextBox txt_tim_kiem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabControl tb_types;
        private System.Windows.Forms.TabPage tp_thu_cung;
        private System.Windows.Forms.TabPage tp_vat_pham;
        private System.Windows.Forms.TabPage tp_dich_vu;
        private System.Windows.Forms.ListView lv_hoa_don;
        private System.Windows.Forms.Button btn_xac_nhan;
        private System.Windows.Forms.Button btn_huy_bo;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.ComboBox cb_tong_tien;
        private System.Windows.Forms.ComboBox cb_ngay_tao;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_chua_thanh_toan;
        private System.Windows.Forms.TabPage tp_da_thanh_toan;
        private System.Windows.Forms.Button btn_them_thanh_vien;
        private System.Windows.Forms.Button btn_sua_thanh_vien;
        private System.Windows.Forms.Button btn_xoa_thanh_vien;
        private System.Windows.Forms.Button btn_tim_kiem_thanh_vien;
        private System.Windows.Forms.TextBox txt_tim_kiem_thanh_vien;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}