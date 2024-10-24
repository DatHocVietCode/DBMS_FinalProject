using DBMS_Final_Project.control.converter;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DBMS_Final_Project.view.ChucNangBanHang
{
    public partial class main_ban_hang : UserControl
    {
        Database instace = new Database();
        DataTable dt_thucung = new DataTable();
        DataTable dt_vatpham = new DataTable();
        DataTable dt_dichvu = new DataTable();
        int IDHoaDonHienTai = -1;
        decimal tongtien = 0;
        string idkhachhang = "0";
        decimal giamgia = 0;
        string startingValue = null;
        string endingValue = null;
        public main_ban_hang()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cập nhật, set tổng tiền = value input
        /// </summary>
        /// <param name="value"></param>
        private void setTongTien(decimal value)
        {
            tongtien = value;
            lbl_tong_tien.Text = tongtien.ToString("#,0") + "VND";
        }
        private void tp_spdv_Click(object sender, EventArgs e)
        {

        }
        private void khach_hang_Load()
        {
            btn_tim_kiem_thanh_vien.ImageList = imageList;
            btn_tim_kiem_thanh_vien.Image = imageList.Images[0];
            gv_thanh_vien.DataSource = instace.ExecuteQuery("select * from KhachHang");
        }
        private void hoa_don_Load()
        {
            /*cb_ngay_tao.SelectedIndex = 0;
            cb_tong_tien.SelectedIndex = 0;*/
            gv_hoadon_dathanhtoan.DataSource = instace.ExecuteQuery("select * from HoaDon where Trang_Thai = N'Đã thanh toán'");
            gv_hoadon_chuathanhtoan.DataSource = instace.ExecuteQuery("select * from HoaDon where Trang_Thai = N'Chưa thanh toán'");
        }
        private void san_pham_va_dich_vu_Load()
        {
            if (startingValue != null && endingValue!=null)
            {
                lbl_starting_value.Text = startingValue.ToString();
                lbl_ending_value.Text = endingValue.ToString();
            }
           
            cb_gia.SelectedIndex = 0;
            cb_alphabet.SelectedIndex = 0;
            string img_link = @"assets\images\chucnangbanhang\icon\Search_Icon.png";
            img_link = imageLinkConverter.Convert(img_link).ToString();
            btn_tim_kiem.ImageList = imageList;
            btn_tim_kiem.Image = imageList.Images[0];
            lv_hoa_don.View = View.Details;
            // Thêm các cột vào ListView
            thu_cung_load();
            vat_pham_load();
            dich_vu_Load();
        }

        private void vat_pham_load(DataTable vatpham = null)
        {
            if (vatpham == null)
            {
                dt_vatpham = instace.ExecuteQuery("SELECT * FROM DanhSachVatPham");
            }
            else
            {
                dt_vatpham = vatpham;
            }
            flp_vatpham.Controls.Clear();
            foreach (DataRow row in dt_vatpham.Rows)
            {
                int id = Convert.ToInt32(row["Ma_Vat_Pham"]);
                string name = row["Ten_San_Pham"].ToString();
                decimal giagoc = Convert.ToDecimal(row["Gia_Ban_Goc"]);
                decimal giauudai = Convert.ToDecimal(row["Gia_Khuyen_Mai"]);
                string link = row["Hinh_Anh"].ToString();
                link = imageLinkConverter.Convert(link).ToString();

                cardvatpham cardvatpham = new cardvatpham(id, name, giagoc, giauudai, link);
                cardvatpham.addHoaDon += AddHoaDon;

                flp_vatpham.Controls.Add(cardvatpham);
            }
        }
        /// <summary>
        /// Nhập vào 1 datatable để hiển thị nó lên giao diện, nếu không nhập, mặc định lấy tất cả thú cưng từ CSDL
        /// </summary>
        /// <param name="thucung"></param>
        private void thu_cung_load(DataTable thucung = null)
        {
            if (thucung == null)
            {
                dt_thucung = instace.ExecuteQuery("SELECT * FROM DanhSachThuCung");
            }
            else
            {
                dt_thucung = thucung;
            }
            flp_thu_cung.Controls.Clear();
            foreach (DataRow row in dt_thucung.Rows)
            {
                int id = Convert.ToInt32(row["Ma_Thu_Cung"]);
                string name = row["Ten_San_Pham"].ToString();
                decimal giagoc = Convert.ToDecimal(row["Gia_Ban_Goc"]);
                decimal giauudai = Convert.ToDecimal(row["Gia_Khuyen_Mai"]);
                string link = row["Hinh_Anh"].ToString();
                link = imageLinkConverter.Convert(link).ToString();

                cardvatpham cardvatpham = new cardvatpham(id, name, giagoc, giauudai, link);
                cardvatpham.addHoaDon += AddHoaDon;

                flp_thu_cung.Controls.Add(cardvatpham);
            }
        }

        private void dich_vu_Load(DataTable dichvu = null)
        {
            if (dichvu == null)
            {
                dt_dichvu = instace.ExecuteQuery("SELECT * FROM DanhSachDichVu");
            }
            else
            {
                dt_dichvu = dichvu;
            }
            flp_dichvu.Controls.Clear();
            foreach (DataRow row in dt_dichvu.Rows)
            {
                int id = Convert.ToInt32(row["Ma_Dich_Vu"]);
                string name = row["Ten_San_Pham"].ToString();
                decimal giagoc = Convert.ToDecimal(row["Gia_Ban_Goc"]);
                decimal giauudai = Convert.ToDecimal(row["Gia_Khuyen_Mai"]);
                string link = row["Hinh_Anh"].ToString();
                link = imageLinkConverter.Convert(link).ToString();

                cardvatpham cardvatpham = new cardvatpham(id, name, giagoc, giauudai, link);
                cardvatpham.addHoaDon += AddHoaDon;

                flp_dichvu.Controls.Add(cardvatpham);
            }
        }

        private void main_ban_hang_Load(object sender, EventArgs e)
        {
            tao_hoa_don_Load();
            san_pham_va_dich_vu_Load();
            hoa_don_Load();
            khach_hang_Load();
        }

        private void tao_hoa_don_Load()
        {
            lv_hoa_don.Columns.Add("ID", 50); // Tên cột và độ rộng
            lv_hoa_don.Columns.Add("Tên sản phẩm", 150);
            lv_hoa_don.Columns.Add("Số lượng", 70);
            lv_hoa_don.Columns.Add("Đơn giá", 100);
            lv_hoa_don.Columns.Add("Thành tiền", 100);
        }

        private void AddHoaDon(object sender, EventArgs e)
        {
            cardvatpham item = (cardvatpham)sender;
            if (IDHoaDonHienTai == -1)
            {
                // Tạo hóa đơn mới
                string cmd = "proc_TaoHoaDonMoi";
                IDHoaDonHienTai = Convert.ToInt16(instace.getResultFromProc(cmd));
            }

            // Tránh trường hợp khi nhập id khách hàng vào trước khi thêm hóa đơn thì không lấy được mã giảm giá
            btn_xac_nhan_id_khachhang_Click_1(sender, e);


            // Thêm vào chi tiết hóa đơn
            object[] parameterValues = { IDHoaDonHienTai, item.Id, item.Ten ,item.GiaUudai };
            string[] parameterNames = { "@id_hoadon", "@id_vatpham", "@ten", "@dongia" };
            string SQLcmd = "proc_ThemChiTietHoaDon";
            decimal thanhtien = Convert.ToDecimal(instace.getResultFromProc(SQLcmd, parameterValues, parameterNames));

            // cập nhật tổng tiền
            tongtien = LayTongTienHoaDonHienTai();
            setTongTien(tongtien);
            
            
            // Bước hiển thị
            bool isExist = false;
            ListViewItem currentItem = null;
            string[] row = new string[] { item.Id.ToString(), item.Ten, (thanhtien / item.GiaUudai).ToString("#,0"), item.GiaUudai.ToString("#,0"), thanhtien.ToString("#,0") };
            foreach (ListViewItem record in lv_hoa_don.Items)
            {
                if (record.SubItems[0].Text == item.Id.ToString())
                    { isExist = true; currentItem = record; break;  }
            }
            if (isExist)
            {
                lv_hoa_don.Items.Remove(currentItem);
                currentItem = new ListViewItem(row);
                lv_hoa_don.Items.Add(currentItem);
            }
            else
            {
                currentItem = new ListViewItem(row);
                lv_hoa_don.Items.Add(currentItem);
            }    
        }
        /// <summary>
        /// Dựa vào biến toàn cục IDHoaDonHienTai, gọi đến CSDL để lấy ra tổng tiền trong hóa đơn và trả về một giá trị decimal
        /// </summary>
        /// <returns></returns>
        private decimal LayTongTienHoaDonHienTai()
        {
            string sqlcmd = "select Tong_Tien from HoaDon where Ma_Hoa_Don = " + IDHoaDonHienTai;
            DataTable result = instace.ExecuteQuery(sqlcmd);

            decimal tongtien = 0;
            if (result.Rows.Count > 0) // Kiểm tra nếu có kết quả
            {
                var value = result.Rows[0]["Tong_Tien"];

                // Kiểm tra nếu giá trị là DBNull trước khi chuyển đổi
                if (value != DBNull.Value)
                {
                    tongtien = Convert.ToDecimal(value); // Lấy tổng tiền từ hàng đầu tiên
                }
            }
            return tongtien;
        }
        private void txt_tim_kiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_tim_kiem_MouseClick(object sender, MouseEventArgs e)
        {
            txt_tim_kiem.Clear();
        }

        private void lv_hoa_don_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (lv_hoa_don.SelectedItems == null)
                return;
            foreach (ListViewItem item in lv_hoa_don.SelectedItems)
            {
                string idVatPham = item.SubItems[0].Text;
                string sqlcmd = "delete from ChiTietHoaDon where Ma_Hoa_Don = " + IDHoaDonHienTai + " and Ma_SPDV = " + idVatPham;
                instace.ExecuteQuery(sqlcmd);
                lv_hoa_don.Items.Remove((ListViewItem)item);
                
            }
            setTongTien(LayTongTienHoaDonHienTai());
        }
        private void cb_gia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortOrderGiaTien = getValueCBGiaTien();
            string sortOrderTen = getValueCBTen();
            //SetNullStartingEndingValues();
            dt_thucung = TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            thu_cung_load(dt_thucung);
            dt_vatpham = TimKiem("DanhSachVatPham", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            vat_pham_load(dt_vatpham);
            //TimKiem("DanhSachVatPham", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            dt_dichvu = TimKiem("DanhSachDichVu", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            dich_vu_Load(dt_dichvu);
        }
        private void SetNullStartingEndingValues()
        {
            startingValue = null;
            endingValue = null;
        }
        private void btn_xac_nhan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thanh toán ngay?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Người dùng nhấn nút Yes
                MessageBox.Show("Bạn đã chọn Yes, hóa đơn có trạng thái đã thanh toán","Notice");
                string sqlcmd = "update HoaDon set Trang_thai = N'Đã thanh toán' where Ma_Hoa_Don = " + IDHoaDonHienTai;
                instace.ExecuteQuery(sqlcmd);
            }
            else if (result == DialogResult.No)
            {
                // Người dùng nhấn nút No
                MessageBox.Show("Bạn đã chọn No, hóa đơn sẽ đưa vào danh sách chờ", "Notice");
            }
            XoaGiaoDichHienTai();
        }
        private void XoaGiaoDichHienTai()
        {
            lv_hoa_don.Items.Clear();
            IDHoaDonHienTai = -1;
            txt_id_khachhang.Text = "0";
            lbl_giam_gia.Text = "0";
            lbl_ten_khachhang.Text = "";
            setTongTien(0);
        }
        private void btn_huy_bo_Click(object sender, EventArgs e)
        {
            string sqlcmd = "proc_XoaHoaDonDangLap";
            object[] paramValues = { IDHoaDonHienTai.ToString()};
            string[] paramNames = { "@id_hoadon" };
            instace.getResultFromProc(sqlcmd, paramValues, paramNames);
            lv_hoa_don.Items.Clear();
            IDHoaDonHienTai = -1;
            XoaGiaoDichHienTai();
            setTongTien(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// input vào tên view và tên cột để tìm kiếm các bản ghi trùng khớp vs txt trong thanh tìm kiếm, trả về một datatable
        /// </summary>
        /// <param name="tenView"></param>
        private DataTable TimKiem(string tenView, string tenCot, string orderColumnGiaTien = null, string orderColumnTen = null)
        {
            string tukhoa = "";
            if (txt_tim_kiem.Text.Length == 0 || txt_tim_kiem.Text.Equals("Tìm kiếm"))
            {
                tukhoa = ""; 
            }
            else
            {
                tukhoa = txt_tim_kiem.Text;
            }
            string cmd = "proc_TimKiemSanPhamVaDichVu";
            object[] paramValues = { tenView, tenCot, tukhoa, startingValue, endingValue, 
                "Gia_Khuyen_Mai", orderColumnGiaTien, "Ten_San_Pham", orderColumnTen };
            string[] paramNames = { "@tenview", "@tencot", "@tukhoa", "@ValueA", "@ValueB", 
                "@SortColumnGiaTien", "@SortOrderGiaTien", "@SortColumnTen", "@SortOrderTen" };
            DataTable dt = (DataTable)instace.getResultFromProc(cmd, paramValues, paramNames, true);
           
            return dt;
            
        }
        private string getValueCBGiaTien()
        {
            switch (cb_gia.SelectedIndex)
            {
                case 0:
                    return null;
                case 1:
                    return "ASC";
                case 2:
                    return "DESC";
                default:
                    return null;
            }
        }
        private string getValueCBTen()
        {
            switch (cb_alphabet.SelectedIndex)
            {
                case 0:
                    return null;
                case 1:
                    return "ASC";
                case 2:
                    return "DESC";
                default:
                    return null;
            }
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string sortOrderGiaTien = getValueCBGiaTien();
            string sortOrderTen = getValueCBTen();
            if (tb_types.SelectedIndex == 0)
            {
                DataTable dt_thucung =  TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
                thu_cung_load(dt_thucung);
            }
            else if (tb_types.SelectedIndex == 1)
            {
                DataTable dt_vatpham = TimKiem("DanhSachVatPham", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
                vat_pham_load(dt_vatpham);
            }
            else if (tb_types.SelectedIndex == 2)
            {
                dt_dichvu = TimKiem("DanhSachDichVu", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
                dich_vu_Load(dt_dichvu);
            }
        }
      
        private void btn_them_thanh_vien_Click(object sender, EventArgs e)
        {
            modifyMember("Thêm");
        }

        private void btn_sua_thanh_vien_Click(object sender, EventArgs e)
        {
            modifyMember("Sửa");
        }
        private void modifyMember(string header)
        {
            string title = header + " thông tin thành viên";
            member_detail member_Detail = new member_detail(title);
            member_Detail.ShowDialog();
            string name = "";
            string sdt = "";
            string dtl = "";
            member_Detail.getValue(ref name, ref sdt, ref dtl);
            string sqlcmd = "Insert into KhachHang(Ten, SDT, Diem_Tich_Luy) values ('" + name + "','" + sdt + "'," + dtl + ")";
            instace.ExecuteQuery(sqlcmd);
            khach_hang_Load();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_tim_kiem_thanh_vien_MouseClick(object sender, MouseEventArgs e)
        {
            txt_tim_kiem_thanh_vien.Clear();
        }

        private void flp_thu_cung_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbl_id_khachhang_Click(object sender, EventArgs e)
        {

        }

        private void tc_ban_hang_SelectedIndexChanged(object sender, EventArgs e)
        {
         /*   if (tc_ban_hang.SelectedIndex == 0)
                san_pham_va_dich_vu_Load();
            else */if (tc_ban_hang.SelectedIndex == 1)
                hoa_don_Load();
            else 
                khach_hang_Load();
        }

        private void tc_hoa_don_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoa_don_Load();
        }

        private void btn_tim_kiem_thanh_vien_Click(object sender, EventArgs e)
        {
            
        }

        private void cb_alphabet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortOrderGiaTien = getValueCBGiaTien();
            string sortOrderTen = getValueCBTen();

            dt_thucung = TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            thu_cung_load(dt_thucung);

            dt_vatpham = TimKiem("DanhSachVatPham", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            vat_pham_load(dt_vatpham);

            dt_dichvu = TimKiem("DanhSachDichVu", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            dich_vu_Load(dt_dichvu);
            //TimKiem("DanhSachVatPham", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
        }
        private void update_KhoangGia()
        {
            if (startingValue!=null && endingValue!=null)
            {
                lbl_starting_value.Text = startingValue;
                lbl_ending_value.Text = endingValue;

            }
            else
            {
                SetNullStartingEndingValues();
                lbl_ending_value.Text = "";
                lbl_ending_value.Text = "";
            }
        }
        private void btn_chon_khoang_gia_Click(object sender, EventArgs e)
        {
            loc_khoang_gia loc_Khoang_Gia = new loc_khoang_gia(ref startingValue, ref endingValue);
            loc_Khoang_Gia.ShowDialog();
            loc_Khoang_Gia.GetValues(ref startingValue, ref endingValue);
            string sortOrderGiaTien = getValueCBGiaTien();
            //MessageBox.Show(startingValue + " " + endingValue);
            string sortOrderTen = getValueCBTen();
            DataTable dt_thucung = TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            thu_cung_load(dt_thucung);
            DataTable dt_vatpham = TimKiem("DanhSachVatPham", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            vat_pham_load(dt_vatpham);
            dt_dichvu = TimKiem("DanhSachDichVu", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            dich_vu_Load(dt_dichvu);
            update_KhoangGia();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_xac_nhan_id_khachhang_Click_1(object sender, EventArgs e)
        {
            // Buoc cap nhat CSDL
            idkhachhang = "0";
            if (txt_id_khachhang.Text != "0")
            {
                idkhachhang = txt_id_khachhang.Text;
            }
            string sqlcmd = "Update HoaDon Set Ma_Khach_Hang = " + idkhachhang + " where Ma_Hoa_Don = " + IDHoaDonHienTai; 
            instace.ExecuteQuery(sqlcmd);
            if (idkhachhang != null)
            {
                DataTable dt_vw_khach_hang = instace.ExecuteQuery("select * from KhachHang where Ma_Khach_Hang = " + idkhachhang);
                foreach (DataRow row in dt_vw_khach_hang.Rows)
                {
                    lbl_ten_khachhang.Text = row["Ten"].ToString();
                    lbl_giam_gia.Text = row["Diem_Tich_Luy"].ToString();
                }
            }
            setTongTien(LayTongTienHoaDonHienTai());
        }

        private void btn_chinh_sua_hoadon_Click(object sender, EventArgs e)
        {
            if (tc_hoa_don.SelectedIndex == 1)
                return;
            DataGridViewRow hoadonhientai = gv_hoadon_chuathanhtoan.CurrentRow;
            if (hoadonhientai != null)
            {
                IDHoaDonHienTai = Convert.ToInt32(hoadonhientai.Cells[0].Value);


                string query = "SELECT * FROM dbo.XemChiTietHoaDon("+IDHoaDonHienTai.ToString()+")";
             
                DataTable chitiethoadon = (DataTable)instace.ExecuteQuery(query);
                CapNhatGiaoDienHoaDonCanChinhSua(chitiethoadon);
            }
        }
        /// <summary>
        /// Input datatable của hóa đơn cần chỉnh sửa để update lên giao diện
        /// </summary>
        /// <param name="dt"></param>
        private void CapNhatGiaoDienHoaDonCanChinhSua(DataTable dt)
        {
            lv_hoa_don.Items.Clear();
            foreach (DataRow row  in dt.Rows)
            {
                string idVatpham = row["Ma_SPDV"].ToString();
                string ten = row["Ten"].ToString();
                string soluong = row["So_Luong"].ToString();
                string dongia = Convert.ToDecimal(row["Gia_Khuyen_Mai"]).ToString("#,0");
                string thanhtien = Convert.ToDecimal(row["Thanh_Tien"]).ToString("#,0");
                string[] lvItem = {idVatpham, ten, soluong, dongia, thanhtien};
                lv_hoa_don.Items.Add(new ListViewItem(lvItem));
            }
            txt_id_khachhang.Text = dt.Rows[0]["Ma_Khach_Hang"].ToString();
            if (txt_id_khachhang.Text.Length == 0)
                txt_id_khachhang.Text = "0";
            btn_xac_nhan_id_khachhang_Click_1(null, null);  
            tc_ban_hang.SelectedIndex = 0;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tp_hoa_don_Click(object sender, EventArgs e)
        {

        }
    }
}
