using DBMS_Final_Project.control.converter;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DBMS_Final_Project.view.ChucNangBanHang
{
    public partial class main_ban_hang : Form
    {
        Database instace = new Database();
        DataTable dt_thucung = new DataTable();
        DataTable dt_vatpham = new DataTable();
        DataTable dt_dichvu = new DataTable();
        int IDHoaDonHienTai = -1;
        decimal tongtien = 0;
        int idkhachhang = 0;
        decimal giamgia = 0;
        string startingValue = null;
        string endingValue = null;
        public main_ban_hang()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Lấy giá trị hiện tại cộng cho một lượng input, sau đó thiết lập lên label
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
            cb_ngay_tao.SelectedIndex = 0;
            cb_tong_tien.SelectedIndex = 0;
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

        private void vat_pham_load()
        {
            //throw new NotImplementedException();
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
                //dt_thucung = instace.ExecuteQuery("select * from ThuCung");
            }
            else
            {
                dt_thucung = thucung;
            }
            flp_thu_cung.Controls.Clear();
            foreach (DataRow row in dt_thucung.Rows)
            {
                /* int id = Convert.ToInt32(row["Ma_Thu_Cung"]);
                 string command = string.Format("Select Ten, Gia_Ban_Goc, Gia_Khuyen_Mai from SanPhamVaDichVu where Ma_SPDV = {0}", id);
                 DataTable dataTable = instace.ExecuteQuery(command);
                 string name = dataTable.Rows[0]["Ten"].ToString();
                 decimal giagoc = Convert.ToDecimal(dataTable.Rows[0]["Gia_Ban_Goc"]);
                 decimal giauudai = Convert.ToDecimal(dataTable.Rows[0]["Gia_Khuyen_Mai"]);

                 command = string.Format("Select * from HinhAnh where Ma_SPDV = {0}", id);
                 dataTable = instace.ExecuteQuery(command);
                 string link = dataTable.Rows[0]["Duong_Dan"].ToString();
                 link = imageLinkConverter.Convert(link).ToString();

                 cardvatpham cardvatpham = new cardvatpham(id, name, giagoc, giauudai, link);
                 cardvatpham.addHoaDon += AddHoaDon;

                 flp_thu_cung.Controls.Add(cardvatpham);*/
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

        private void dich_vu_Load()
        {
            //throw new NotImplementedException();
        }

        private void main_ban_hang_Load(object sender, EventArgs e)
        {
            tao_hoa_don_Load();
            san_pham_va_dich_vu_Load();
            hoa_don_Load();
            khach_hang_Load();
            //DataTable sanphamdichvu = instace.ExecuteQuery("select * from SanPhamVaDichVu");
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
           
            // Thêm vào chi tiết hóa đơn
            object[] parameterValues = { IDHoaDonHienTai, item.Id, item.Ten ,item.GiaUudai };
            string[] parameterNames = { "@id_hoadon", "@id_vatpham", "@ten", "@dongia" };
            string SQLcmd = "proc_ThemChiTietHoaDon";
            decimal thanhtien = Convert.ToDecimal(instace.getResultFromProc(SQLcmd, parameterValues, parameterNames));

            // Hiển thị lên list view
            // Bước lấy dữ liệu
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
            string[] row = new string[] { item.Id.ToString(), item.Ten, (thanhtien / item.GiaUudai).ToString("#,0"), item.GiaUudai.ToString("#,0"), tongtien.ToString("#,0") };

            // Bước hiển thị
            bool isExist = false;
            ListViewItem currentItem = null;
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

            // cập nhật tổng tiền
            setTongTien(tongtien);
       
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
                setTongTien(Convert.ToDecimal(item.SubItems[4].Text) * -1);
               /* tongtien -= Convert.ToDecimal(item.SubItems[4].Text);
                lbl_tong_tien.Text = tongtien.ToString("#,0") + "VND";*/
                // Xóa item khỏi ListView
                lv_hoa_don.Items.Remove((ListViewItem)item);
            }
        }

        private void cb_gia_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (cb_gia.SelectedIndex == 0)
                btn_timkiem_Click(sender, null);*/
            
       /*     if (cb_gia.SelectedIndex == 3)
            {
                loc_khoang_gia loc_Khoang_Gia = new loc_khoang_gia(ref startingValue, ref endingValue);
                loc_Khoang_Gia.ShowDialog();
                loc_Khoang_Gia.GetValues(ref startingValue, ref endingValue);   
                string sortOrderGiaTien = getValueCBGiaTien();
                //MessageBox.Show(startingValue + " " + endingValue);
                string sortOrderTen = getValueCBTen();
                TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            }*/
        /*    if (cb_gia.SelectedIndex == 1 || cb_gia.SelectedIndex == 2)
            {*/
                string sortOrderGiaTien = getValueCBGiaTien();
                string sortOrderTen = getValueCBTen();
                //SetNullStartingEndingValues();
                TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);                          
            /*}*/
           
           /* string cmd = "proc_TimKiemSanPhamVaDichVu";
            object[] paramValues = { "DanhSachThuCung", "Ten_San_Pham" };
            string[] paramNames = { "@tenview", "@tencot", "@tukhoa", "@SortColumnGiaTien", "@SortOrderGiaTien", "@SortColumnTen", "@SortOrderTen" };
            dt_thucung = (DataTable)instace.getResultFromProc(cmd, paramValues, paramNames, true);*/
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
            }
            else if (result == DialogResult.No)
            {
                // Người dùng nhấn nút No
                MessageBox.Show("Bạn đã chọn No, hóa đơn sẽ đưa vào danh sách chờ", "Notice");
            }
        }

        private void btn_huy_bo_Click(object sender, EventArgs e)
        {
            string sqlcmd = "proc_XoaHoaDon";
            object[] paramValues = { IDHoaDonHienTai.ToString()};
            string[] paramNames = { "@id_hoadon" };
            instace.getResultFromProc(sqlcmd, paramValues, paramNames);
            lv_hoa_don.Items.Clear();
            IDHoaDonHienTai = -1;
            setTongTien(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// input vào tên view và tên cột để tìm kiếm các bản ghi trùng khớp vs txt trong thanh tìm kiếm 
        /// </summary>
        /// <param name="tenView"></param>
        private void TimKiem(string tenView, string tenCot, string orderColumnGiaTien = null, string orderColumnTen = null)
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
           /* if (startingValue != null && endingValue != null)
            {
                string cmd = "proc_TimKiemSanPhamVaDichVuTrongKhoang";
                object[] paramValues = { tenView, tenCot, tukhoa, "Gia_Khuyen_Mai",  "Ten_San_Pham", orderColumnTen, startingValue, endingValue };
                string[] paramNames = { "@tenview", "@tencot", "@tukhoa", "@SortColumnGiaTien",  "@SortColumnTen", "@SortOrderTen" , "@ValueA", "@ValueB" };
                DataTable dt = (DataTable)instace.getResultFromProc(cmd, paramValues, paramNames, true);
                thu_cung_load(dt);
            }*/
            //else
            
                string cmd = "proc_TimKiemSanPhamVaDichVu";
                object[] paramValues = { tenView, tenCot, tukhoa, startingValue, endingValue, 
                    "Gia_Khuyen_Mai", orderColumnGiaTien, "Ten_San_Pham", orderColumnTen };
                string[] paramNames = { "@tenview", "@tencot", "@tukhoa", "@ValueA", "@ValueB", 
                    "@SortColumnGiaTien", "@SortOrderGiaTien", "@SortColumnTen", "@SortOrderTen" };
                DataTable dt = (DataTable)instace.getResultFromProc(cmd, paramValues, paramNames, true);
                thu_cung_load(dt);     
            
           
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
                TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            }
            else if (tb_types.SelectedIndex == 1)
                TimKiem("","");
            else if (tb_types.SelectedIndex == 2)
                TimKiem("","");
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
            if (tc_ban_hang.SelectedIndex == 0)
                san_pham_va_dich_vu_Load();
            else if (tc_ban_hang.SelectedIndex == 1)
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

        private void btn_xac_nhan_id_khachhang_Click(object sender, EventArgs e)
        {

        }

        private void cb_alphabet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortOrderGiaTien = getValueCBGiaTien();
            string sortOrderTen = getValueCBTen();
            TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
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
            TimKiem("DanhSachThuCung", "Ten_San_Pham", orderColumnGiaTien: sortOrderGiaTien, orderColumnTen: sortOrderTen);
            update_KhoangGia();
        }
    }
}
