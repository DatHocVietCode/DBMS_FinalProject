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
            this.panel_tao_hoadon_moi = new System.Windows.Forms.Panel();
            this.lbl_tong_tien = new System.Windows.Forms.Label();
            this.lbl_title_tongtien = new System.Windows.Forms.Label();
            this.lbl_giam_gia = new System.Windows.Forms.Label();
            this.lbl_ten_khachhang = new System.Windows.Forms.Label();
            this.btn_xac_nhan_id_khachhang = new System.Windows.Forms.Button();
            this.lbl_title_giam_gia = new System.Windows.Forms.Label();
            this.lbl_title_hoten = new System.Windows.Forms.Label();
            this.txt_id_khachhang = new System.Windows.Forms.TextBox();
            this.lbl_id_khachhang = new System.Windows.Forms.Label();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_xac_nhan = new System.Windows.Forms.Button();
            this.btn_huy_bo = new System.Windows.Forms.Button();
            this.lv_hoa_don = new System.Windows.Forms.ListView();
            this.lbl_ending_value = new System.Windows.Forms.Label();
            this.lbl_starting_value = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_chon_khoang_gia = new System.Windows.Forms.Button();
            this.lbl_title_alphabet = new System.Windows.Forms.Label();
            this.lbl_title_sap_xep_gia = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_types = new System.Windows.Forms.TabControl();
            this.tp_thu_cung = new System.Windows.Forms.TabPage();
            this.flp_thu_cung = new System.Windows.Forms.FlowLayoutPanel();
            this.tp_vat_pham = new System.Windows.Forms.TabPage();
            this.flp_vatpham = new System.Windows.Forms.FlowLayoutPanel();
            this.tp_dich_vu = new System.Windows.Forms.TabPage();
            this.btn_tim_kiem = new System.Windows.Forms.Button();
            this.txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.cb_alphabet = new System.Windows.Forms.ComboBox();
            this.cb_gia = new System.Windows.Forms.ComboBox();
            this.tp_hoa_don = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.tc_hoa_don = new System.Windows.Forms.TabControl();
            this.tp_chua_thanh_toan = new System.Windows.Forms.TabPage();
            this.gv_hoadon_chuathanhtoan = new System.Windows.Forms.DataGridView();
            this.tp_da_thanh_toan = new System.Windows.Forms.TabPage();
            this.gv_hoadon_dathanhtoan = new System.Windows.Forms.DataGridView();
            this.tp_thanh_vien = new System.Windows.Forms.TabPage();
            this.gv_thanh_vien = new System.Windows.Forms.DataGridView();
            this.btn_tim_kiem_thanh_vien = new System.Windows.Forms.Button();
            this.txt_tim_kiem_thanh_vien = new System.Windows.Forms.TextBox();
            this.btn_them_thanh_vien = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.flp_dichvu = new System.Windows.Forms.FlowLayoutPanel();
            this.tc_ban_hang.SuspendLayout();
            this.tp_spdv.SuspendLayout();
            this.panel_tao_hoadon_moi.SuspendLayout();
            this.tb_types.SuspendLayout();
            this.tp_thu_cung.SuspendLayout();
            this.tp_vat_pham.SuspendLayout();
            this.tp_dich_vu.SuspendLayout();
            this.tp_hoa_don.SuspendLayout();
            this.tc_hoa_don.SuspendLayout();
            this.tp_chua_thanh_toan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_hoadon_chuathanhtoan)).BeginInit();
            this.tp_da_thanh_toan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_hoadon_dathanhtoan)).BeginInit();
            this.tp_thanh_vien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_thanh_vien)).BeginInit();
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
            this.tc_ban_hang.SelectedIndexChanged += new System.EventHandler(this.tc_ban_hang_SelectedIndexChanged);
            // 
            // tp_spdv
            // 
            this.tp_spdv.BackColor = System.Drawing.SystemColors.Window;
            this.tp_spdv.Controls.Add(this.panel_tao_hoadon_moi);
            this.tp_spdv.Controls.Add(this.lbl_ending_value);
            this.tp_spdv.Controls.Add(this.lbl_starting_value);
            this.tp_spdv.Controls.Add(this.label7);
            this.tp_spdv.Controls.Add(this.label6);
            this.tp_spdv.Controls.Add(this.btn_chon_khoang_gia);
            this.tp_spdv.Controls.Add(this.lbl_title_alphabet);
            this.tp_spdv.Controls.Add(this.lbl_title_sap_xep_gia);
            this.tp_spdv.Controls.Add(this.label5);
            this.tp_spdv.Controls.Add(this.label4);
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
            // panel_tao_hoadon_moi
            // 
            this.panel_tao_hoadon_moi.Controls.Add(this.lbl_tong_tien);
            this.panel_tao_hoadon_moi.Controls.Add(this.lbl_title_tongtien);
            this.panel_tao_hoadon_moi.Controls.Add(this.lbl_giam_gia);
            this.panel_tao_hoadon_moi.Controls.Add(this.lbl_ten_khachhang);
            this.panel_tao_hoadon_moi.Controls.Add(this.btn_xac_nhan_id_khachhang);
            this.panel_tao_hoadon_moi.Controls.Add(this.lbl_title_giam_gia);
            this.panel_tao_hoadon_moi.Controls.Add(this.lbl_title_hoten);
            this.panel_tao_hoadon_moi.Controls.Add(this.txt_id_khachhang);
            this.panel_tao_hoadon_moi.Controls.Add(this.lbl_id_khachhang);
            this.panel_tao_hoadon_moi.Controls.Add(this.btn_xoa);
            this.panel_tao_hoadon_moi.Controls.Add(this.btn_xac_nhan);
            this.panel_tao_hoadon_moi.Controls.Add(this.btn_huy_bo);
            this.panel_tao_hoadon_moi.Controls.Add(this.lv_hoa_don);
            this.panel_tao_hoadon_moi.Location = new System.Drawing.Point(724, 95);
            this.panel_tao_hoadon_moi.Name = "panel_tao_hoadon_moi";
            this.panel_tao_hoadon_moi.Size = new System.Drawing.Size(423, 462);
            this.panel_tao_hoadon_moi.TabIndex = 0;
            // 
            // lbl_tong_tien
            // 
            this.lbl_tong_tien.Location = new System.Drawing.Point(193, 351);
            this.lbl_tong_tien.Name = "lbl_tong_tien";
            this.lbl_tong_tien.Size = new System.Drawing.Size(203, 19);
            this.lbl_tong_tien.TabIndex = 33;
            this.lbl_tong_tien.Text = "000000000000";
            // 
            // lbl_title_tongtien
            // 
            this.lbl_title_tongtien.Location = new System.Drawing.Point(94, 351);
            this.lbl_title_tongtien.Name = "lbl_title_tongtien";
            this.lbl_title_tongtien.Size = new System.Drawing.Size(82, 19);
            this.lbl_title_tongtien.TabIndex = 32;
            this.lbl_title_tongtien.Text = "Tổng tiền:";
            // 
            // lbl_giam_gia
            // 
            this.lbl_giam_gia.Location = new System.Drawing.Point(193, 320);
            this.lbl_giam_gia.Name = "lbl_giam_gia";
            this.lbl_giam_gia.Size = new System.Drawing.Size(206, 19);
            this.lbl_giam_gia.TabIndex = 31;
            this.lbl_giam_gia.Text = "0";
            // 
            // lbl_ten_khachhang
            // 
            this.lbl_ten_khachhang.Location = new System.Drawing.Point(193, 288);
            this.lbl_ten_khachhang.Name = "lbl_ten_khachhang";
            this.lbl_ten_khachhang.Size = new System.Drawing.Size(206, 22);
            this.lbl_ten_khachhang.TabIndex = 30;
            this.lbl_ten_khachhang.Text = "vãng lai";
            // 
            // btn_xac_nhan_id_khachhang
            // 
            this.btn_xac_nhan_id_khachhang.Location = new System.Drawing.Point(287, 247);
            this.btn_xac_nhan_id_khachhang.Name = "btn_xac_nhan_id_khachhang";
            this.btn_xac_nhan_id_khachhang.Size = new System.Drawing.Size(96, 33);
            this.btn_xac_nhan_id_khachhang.TabIndex = 29;
            this.btn_xac_nhan_id_khachhang.Text = "Xác nhận";
            this.btn_xac_nhan_id_khachhang.UseVisualStyleBackColor = true;
            this.btn_xac_nhan_id_khachhang.Click += new System.EventHandler(this.btn_xac_nhan_id_khachhang_Click_1);
            // 
            // lbl_title_giam_gia
            // 
            this.lbl_title_giam_gia.Location = new System.Drawing.Point(80, 320);
            this.lbl_title_giam_gia.Name = "lbl_title_giam_gia";
            this.lbl_title_giam_gia.Size = new System.Drawing.Size(96, 19);
            this.lbl_title_giam_gia.TabIndex = 28;
            this.lbl_title_giam_gia.Text = "Điểm tích lũy:";
            // 
            // lbl_title_hoten
            // 
            this.lbl_title_hoten.Location = new System.Drawing.Point(56, 288);
            this.lbl_title_hoten.Name = "lbl_title_hoten";
            this.lbl_title_hoten.Size = new System.Drawing.Size(120, 22);
            this.lbl_title_hoten.TabIndex = 27;
            this.lbl_title_hoten.Text = "Tên khách hàng:";
            // 
            // txt_id_khachhang
            // 
            this.txt_id_khachhang.Location = new System.Drawing.Point(196, 253);
            this.txt_id_khachhang.Name = "txt_id_khachhang";
            this.txt_id_khachhang.Size = new System.Drawing.Size(65, 22);
            this.txt_id_khachhang.TabIndex = 26;
            this.txt_id_khachhang.Text = "0";
            // 
            // lbl_id_khachhang
            // 
            this.lbl_id_khachhang.AutoSize = true;
            this.lbl_id_khachhang.Location = new System.Drawing.Point(69, 259);
            this.lbl_id_khachhang.Name = "lbl_id_khachhang";
            this.lbl_id_khachhang.Size = new System.Drawing.Size(96, 16);
            this.lbl_id_khachhang.TabIndex = 25;
            this.lbl_id_khachhang.Text = "ID Khách hàng:";
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(51, 424);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(100, 33);
            this.btn_xoa.TabIndex = 24;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_xac_nhan
            // 
            this.btn_xac_nhan.Location = new System.Drawing.Point(287, 424);
            this.btn_xac_nhan.Name = "btn_xac_nhan";
            this.btn_xac_nhan.Size = new System.Drawing.Size(96, 33);
            this.btn_xac_nhan.TabIndex = 23;
            this.btn_xac_nhan.Text = "Xác nhận";
            this.btn_xac_nhan.UseVisualStyleBackColor = true;
            this.btn_xac_nhan.Click += new System.EventHandler(this.btn_xac_nhan_Click);
            // 
            // btn_huy_bo
            // 
            this.btn_huy_bo.Location = new System.Drawing.Point(170, 424);
            this.btn_huy_bo.Name = "btn_huy_bo";
            this.btn_huy_bo.Size = new System.Drawing.Size(100, 33);
            this.btn_huy_bo.TabIndex = 22;
            this.btn_huy_bo.Text = "Hủy bỏ";
            this.btn_huy_bo.UseVisualStyleBackColor = true;
            this.btn_huy_bo.Click += new System.EventHandler(this.btn_huy_bo_Click);
            // 
            // lv_hoa_don
            // 
            this.lv_hoa_don.FullRowSelect = true;
            this.lv_hoa_don.HideSelection = false;
            this.lv_hoa_don.Location = new System.Drawing.Point(4, 3);
            this.lv_hoa_don.Name = "lv_hoa_don";
            this.lv_hoa_don.Size = new System.Drawing.Size(398, 242);
            this.lv_hoa_don.TabIndex = 21;
            this.lv_hoa_don.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_ending_value
            // 
            this.lbl_ending_value.Location = new System.Drawing.Point(586, 40);
            this.lbl_ending_value.Name = "lbl_ending_value";
            this.lbl_ending_value.Size = new System.Drawing.Size(189, 21);
            this.lbl_ending_value.TabIndex = 27;
            // 
            // lbl_starting_value
            // 
            this.lbl_starting_value.Location = new System.Drawing.Point(586, 6);
            this.lbl_starting_value.Name = "lbl_starting_value";
            this.lbl_starting_value.Size = new System.Drawing.Size(189, 21);
            this.lbl_starting_value.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(535, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Đến";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(535, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Từ";
            // 
            // btn_chon_khoang_gia
            // 
            this.btn_chon_khoang_gia.Location = new System.Drawing.Point(382, 19);
            this.btn_chon_khoang_gia.Name = "btn_chon_khoang_gia";
            this.btn_chon_khoang_gia.Size = new System.Drawing.Size(134, 30);
            this.btn_chon_khoang_gia.TabIndex = 23;
            this.btn_chon_khoang_gia.Text = "Chọn khoảng giá";
            this.btn_chon_khoang_gia.UseVisualStyleBackColor = true;
            this.btn_chon_khoang_gia.Click += new System.EventHandler(this.btn_chon_khoang_gia_Click);
            // 
            // lbl_title_alphabet
            // 
            this.lbl_title_alphabet.Location = new System.Drawing.Point(8, 6);
            this.lbl_title_alphabet.Name = "lbl_title_alphabet";
            this.lbl_title_alphabet.Size = new System.Drawing.Size(187, 29);
            this.lbl_title_alphabet.TabIndex = 22;
            this.lbl_title_alphabet.Text = "Sắp xếp theo bảng chữ cái:";
            // 
            // lbl_title_sap_xep_gia
            // 
            this.lbl_title_sap_xep_gia.Location = new System.Drawing.Point(64, 40);
            this.lbl_title_sap_xep_gia.Name = "lbl_title_sap_xep_gia";
            this.lbl_title_sap_xep_gia.Size = new System.Drawing.Size(129, 23);
            this.lbl_title_sap_xep_gia.TabIndex = 21;
            this.lbl_title_sap_xep_gia.Text = "Sắp xếp theo giá:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(860, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tạo hóa đơn mới";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tb_types
            // 
            this.tb_types.Controls.Add(this.tp_thu_cung);
            this.tb_types.Controls.Add(this.tp_vat_pham);
            this.tb_types.Controls.Add(this.tp_dich_vu);
            this.tb_types.Location = new System.Drawing.Point(0, 70);
            this.tb_types.Name = "tb_types";
            this.tb_types.SelectedIndex = 0;
            this.tb_types.Size = new System.Drawing.Size(728, 484);
            this.tb_types.TabIndex = 5;
            // 
            // tp_thu_cung
            // 
            this.tp_thu_cung.Controls.Add(this.flp_thu_cung);
            this.tp_thu_cung.Location = new System.Drawing.Point(4, 25);
            this.tp_thu_cung.Name = "tp_thu_cung";
            this.tp_thu_cung.Padding = new System.Windows.Forms.Padding(3);
            this.tp_thu_cung.Size = new System.Drawing.Size(720, 455);
            this.tp_thu_cung.TabIndex = 0;
            this.tp_thu_cung.Text = "Thú cưng";
            this.tp_thu_cung.UseVisualStyleBackColor = true;
            // 
            // flp_thu_cung
            // 
            this.flp_thu_cung.AutoScroll = true;
            this.flp_thu_cung.Location = new System.Drawing.Point(0, 0);
            this.flp_thu_cung.Name = "flp_thu_cung";
            this.flp_thu_cung.Size = new System.Drawing.Size(714, 469);
            this.flp_thu_cung.TabIndex = 0;
            this.flp_thu_cung.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_thu_cung_Paint);
            // 
            // tp_vat_pham
            // 
            this.tp_vat_pham.Controls.Add(this.flp_vatpham);
            this.tp_vat_pham.Location = new System.Drawing.Point(4, 25);
            this.tp_vat_pham.Name = "tp_vat_pham";
            this.tp_vat_pham.Padding = new System.Windows.Forms.Padding(3);
            this.tp_vat_pham.Size = new System.Drawing.Size(720, 455);
            this.tp_vat_pham.TabIndex = 1;
            this.tp_vat_pham.Text = "Vật phẩm";
            this.tp_vat_pham.UseVisualStyleBackColor = true;
            // 
            // flp_vatpham
            // 
            this.flp_vatpham.AutoScroll = true;
            this.flp_vatpham.Location = new System.Drawing.Point(-1, 0);
            this.flp_vatpham.Name = "flp_vatpham";
            this.flp_vatpham.Size = new System.Drawing.Size(721, 459);
            this.flp_vatpham.TabIndex = 0;
            // 
            // tp_dich_vu
            // 
            this.tp_dich_vu.Controls.Add(this.flp_dichvu);
            this.tp_dich_vu.Location = new System.Drawing.Point(4, 25);
            this.tp_dich_vu.Name = "tp_dich_vu";
            this.tp_dich_vu.Size = new System.Drawing.Size(720, 455);
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
            "Tùy chọn",
            "A - Z",
            "Z - A"});
            this.cb_alphabet.Location = new System.Drawing.Point(199, 3);
            this.cb_alphabet.Name = "cb_alphabet";
            this.cb_alphabet.Size = new System.Drawing.Size(121, 24);
            this.cb_alphabet.TabIndex = 1;
            this.cb_alphabet.SelectedIndexChanged += new System.EventHandler(this.cb_alphabet_SelectedIndexChanged);
            // 
            // cb_gia
            // 
            this.cb_gia.FormattingEnabled = true;
            this.cb_gia.Items.AddRange(new object[] {
            "Tùy chọn",
            "Tăng dần",
            "Giảm dần"});
            this.cb_gia.Location = new System.Drawing.Point(199, 40);
            this.cb_gia.Name = "cb_gia";
            this.cb_gia.Size = new System.Drawing.Size(121, 24);
            this.cb_gia.TabIndex = 0;
            this.cb_gia.SelectedIndexChanged += new System.EventHandler(this.cb_gia_SelectedIndexChanged);
            // 
            // tp_hoa_don
            // 
            this.tp_hoa_don.Controls.Add(this.button1);
            this.tp_hoa_don.Controls.Add(this.label2);
            this.tp_hoa_don.Controls.Add(this.dtp);
            this.tp_hoa_don.Controls.Add(this.tc_hoa_don);
            this.tp_hoa_don.Location = new System.Drawing.Point(4, 25);
            this.tp_hoa_don.Name = "tp_hoa_don";
            this.tp_hoa_don.Padding = new System.Windows.Forms.Padding(3);
            this.tp_hoa_don.Size = new System.Drawing.Size(1135, 557);
            this.tp_hoa_don.TabIndex = 1;
            this.tp_hoa_don.Text = "Hóa đơn";
            this.tp_hoa_don.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1018, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Chỉnh sửa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chọn ngày xác định";
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(138, 22);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(271, 22);
            this.dtp.TabIndex = 3;
            // 
            // tc_hoa_don
            // 
            this.tc_hoa_don.Controls.Add(this.tp_chua_thanh_toan);
            this.tc_hoa_don.Controls.Add(this.tp_da_thanh_toan);
            this.tc_hoa_don.Location = new System.Drawing.Point(8, 66);
            this.tc_hoa_don.Name = "tc_hoa_don";
            this.tc_hoa_don.SelectedIndex = 0;
            this.tc_hoa_don.Size = new System.Drawing.Size(1124, 491);
            this.tc_hoa_don.TabIndex = 0;
            this.tc_hoa_don.SelectedIndexChanged += new System.EventHandler(this.tc_hoa_don_SelectedIndexChanged);
            // 
            // tp_chua_thanh_toan
            // 
            this.tp_chua_thanh_toan.Controls.Add(this.gv_hoadon_chuathanhtoan);
            this.tp_chua_thanh_toan.Location = new System.Drawing.Point(4, 25);
            this.tp_chua_thanh_toan.Name = "tp_chua_thanh_toan";
            this.tp_chua_thanh_toan.Padding = new System.Windows.Forms.Padding(3);
            this.tp_chua_thanh_toan.Size = new System.Drawing.Size(1116, 462);
            this.tp_chua_thanh_toan.TabIndex = 0;
            this.tp_chua_thanh_toan.Text = "Chưa thanh toán";
            this.tp_chua_thanh_toan.UseVisualStyleBackColor = true;
            // 
            // gv_hoadon_chuathanhtoan
            // 
            this.gv_hoadon_chuathanhtoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_hoadon_chuathanhtoan.Location = new System.Drawing.Point(0, 0);
            this.gv_hoadon_chuathanhtoan.Name = "gv_hoadon_chuathanhtoan";
            this.gv_hoadon_chuathanhtoan.RowHeadersWidth = 51;
            this.gv_hoadon_chuathanhtoan.RowTemplate.Height = 24;
            this.gv_hoadon_chuathanhtoan.Size = new System.Drawing.Size(1127, 470);
            this.gv_hoadon_chuathanhtoan.TabIndex = 0;
            // 
            // tp_da_thanh_toan
            // 
            this.tp_da_thanh_toan.Controls.Add(this.gv_hoadon_dathanhtoan);
            this.tp_da_thanh_toan.Location = new System.Drawing.Point(4, 25);
            this.tp_da_thanh_toan.Name = "tp_da_thanh_toan";
            this.tp_da_thanh_toan.Padding = new System.Windows.Forms.Padding(3);
            this.tp_da_thanh_toan.Size = new System.Drawing.Size(1116, 462);
            this.tp_da_thanh_toan.TabIndex = 1;
            this.tp_da_thanh_toan.Text = "Đã thanh toán";
            this.tp_da_thanh_toan.UseVisualStyleBackColor = true;
            // 
            // gv_hoadon_dathanhtoan
            // 
            this.gv_hoadon_dathanhtoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_hoadon_dathanhtoan.Location = new System.Drawing.Point(0, 0);
            this.gv_hoadon_dathanhtoan.Name = "gv_hoadon_dathanhtoan";
            this.gv_hoadon_dathanhtoan.RowHeadersWidth = 51;
            this.gv_hoadon_dathanhtoan.RowTemplate.Height = 24;
            this.gv_hoadon_dathanhtoan.Size = new System.Drawing.Size(1138, 470);
            this.gv_hoadon_dathanhtoan.TabIndex = 0;
            // 
            // tp_thanh_vien
            // 
            this.tp_thanh_vien.Controls.Add(this.gv_thanh_vien);
            this.tp_thanh_vien.Controls.Add(this.btn_tim_kiem_thanh_vien);
            this.tp_thanh_vien.Controls.Add(this.txt_tim_kiem_thanh_vien);
            this.tp_thanh_vien.Controls.Add(this.btn_them_thanh_vien);
            this.tp_thanh_vien.Location = new System.Drawing.Point(4, 25);
            this.tp_thanh_vien.Name = "tp_thanh_vien";
            this.tp_thanh_vien.Size = new System.Drawing.Size(1135, 557);
            this.tp_thanh_vien.TabIndex = 2;
            this.tp_thanh_vien.Text = "Thành viên";
            this.tp_thanh_vien.UseVisualStyleBackColor = true;
            // 
            // gv_thanh_vien
            // 
            this.gv_thanh_vien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_thanh_vien.Location = new System.Drawing.Point(3, 66);
            this.gv_thanh_vien.Name = "gv_thanh_vien";
            this.gv_thanh_vien.RowHeadersWidth = 51;
            this.gv_thanh_vien.RowTemplate.Height = 24;
            this.gv_thanh_vien.Size = new System.Drawing.Size(1132, 491);
            this.gv_thanh_vien.TabIndex = 7;
            // 
            // btn_tim_kiem_thanh_vien
            // 
            this.btn_tim_kiem_thanh_vien.Location = new System.Drawing.Point(749, 20);
            this.btn_tim_kiem_thanh_vien.Name = "btn_tim_kiem_thanh_vien";
            this.btn_tim_kiem_thanh_vien.Size = new System.Drawing.Size(29, 24);
            this.btn_tim_kiem_thanh_vien.TabIndex = 6;
            this.btn_tim_kiem_thanh_vien.UseVisualStyleBackColor = true;
            this.btn_tim_kiem_thanh_vien.Click += new System.EventHandler(this.btn_tim_kiem_thanh_vien_Click);
            // 
            // txt_tim_kiem_thanh_vien
            // 
            this.txt_tim_kiem_thanh_vien.Location = new System.Drawing.Point(784, 20);
            this.txt_tim_kiem_thanh_vien.Name = "txt_tim_kiem_thanh_vien";
            this.txt_tim_kiem_thanh_vien.Size = new System.Drawing.Size(273, 22);
            this.txt_tim_kiem_thanh_vien.TabIndex = 5;
            this.txt_tim_kiem_thanh_vien.Text = "Tìm kiếm";
            this.txt_tim_kiem_thanh_vien.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_tim_kiem_thanh_vien_MouseClick);
            this.txt_tim_kiem_thanh_vien.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_them_thanh_vien
            // 
            this.btn_them_thanh_vien.Location = new System.Drawing.Point(8, 14);
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
            // flp_dichvu
            // 
            this.flp_dichvu.AutoScroll = true;
            this.flp_dichvu.Location = new System.Drawing.Point(-1, 0);
            this.flp_dichvu.Name = "flp_dichvu";
            this.flp_dichvu.Size = new System.Drawing.Size(721, 457);
            this.flp_dichvu.TabIndex = 0;
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
            this.panel_tao_hoadon_moi.ResumeLayout(false);
            this.panel_tao_hoadon_moi.PerformLayout();
            this.tb_types.ResumeLayout(false);
            this.tp_thu_cung.ResumeLayout(false);
            this.tp_vat_pham.ResumeLayout(false);
            this.tp_dich_vu.ResumeLayout(false);
            this.tp_hoa_don.ResumeLayout(false);
            this.tp_hoa_don.PerformLayout();
            this.tc_hoa_don.ResumeLayout(false);
            this.tp_chua_thanh_toan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_hoadon_chuathanhtoan)).EndInit();
            this.tp_da_thanh_toan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_hoadon_dathanhtoan)).EndInit();
            this.tp_thanh_vien.ResumeLayout(false);
            this.tp_thanh_vien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_thanh_vien)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.TabControl tc_hoa_don;
        private System.Windows.Forms.TabPage tp_chua_thanh_toan;
        private System.Windows.Forms.TabPage tp_da_thanh_toan;
        private System.Windows.Forms.Button btn_them_thanh_vien;
        private System.Windows.Forms.Button btn_tim_kiem_thanh_vien;
        private System.Windows.Forms.TextBox txt_tim_kiem_thanh_vien;
        private System.Windows.Forms.DataGridView gv_thanh_vien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gv_hoadon_chuathanhtoan;
        private System.Windows.Forms.DataGridView gv_hoadon_dathanhtoan;
        private System.Windows.Forms.FlowLayoutPanel flp_thu_cung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_title_sap_xep_gia;
        private System.Windows.Forms.Label lbl_title_alphabet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_chon_khoang_gia;
        private System.Windows.Forms.Label lbl_ending_value;
        private System.Windows.Forms.Label lbl_starting_value;
        private System.Windows.Forms.Panel panel_tao_hoadon_moi;
        private System.Windows.Forms.Label lbl_tong_tien;
        private System.Windows.Forms.Label lbl_title_tongtien;
        private System.Windows.Forms.Label lbl_giam_gia;
        private System.Windows.Forms.Label lbl_ten_khachhang;
        private System.Windows.Forms.Button btn_xac_nhan_id_khachhang;
        private System.Windows.Forms.Label lbl_title_giam_gia;
        private System.Windows.Forms.Label lbl_title_hoten;
        private System.Windows.Forms.TextBox txt_id_khachhang;
        private System.Windows.Forms.Label lbl_id_khachhang;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_xac_nhan;
        private System.Windows.Forms.Button btn_huy_bo;
        private System.Windows.Forms.ListView lv_hoa_don;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flp_vatpham;
        private System.Windows.Forms.FlowLayoutPanel flp_dichvu;
    }
}