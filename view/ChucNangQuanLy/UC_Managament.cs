using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DBMS_Final_Project.control.converter;
using DBMS_Final_Project.database;

namespace DBMS_Final_Project.view
{
    public partial class UC_Management : UserControl
    {
        private ContextMenuStrip contextMenuStrip;
        static int ma;
        public UC_Management()
        {
            InitializeComponent();
            // Khởi tạo ContextMenuStrip
            contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuItemXoa = new ToolStripMenuItem("Xóa Ảnh");
            menuItemXoa.Click += MenuItemXoa_Click; // Gán sự kiện cho menu item
            contextMenuStrip.Items.Add(menuItemXoa);
        }
        Database db = new Database();
        private void Fmanager_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgvNhanVien.DataSource = db.ExecuteQuery("Select * from view_DanhSachNhanVien");
            dgv_ThuCung.DataSource = db.ExecuteQuery("Select * from view_DanhSachThuCung");
            dgv_VatPham.DataSource = db.ExecuteQuery("Select * from view_DanhSachVatPham");
            dgv_DichVu.DataSource = db.ExecuteQuery("select * from view_DichVu");
            dgv_KhachHang.DataSource = db.ExecuteQuery("select * from view_DanhSachKhachHang");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvNhanVien.Rows[e.RowIndex].IsNewRow)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Đổ dữ liệu vào các TextBox
                txb_MaNV.Text = row.Cells["Ma_Nhan_Vien"].Value.ToString();
                txb_TenNV.Text = row.Cells["Ho_Ten"].Value.ToString();
                txb_sdtNV.Text = row.Cells["SDT"].Value.ToString();
                txb_DiaChiNV.Text = row.Cells["Dia_Chi"].Value.ToString();
                dtp_NgaySinhNV.Value = Convert.ToDateTime(row.Cells["Ngay_Sinh"].Value);
                cb_GioiTinh.Text = row.Cells["Gioi_Tinh"].Value.ToString();
                txb_CongViec.Text = row.Cells["Cong_Viec"].Value.ToString();
                txb_LuongNV.Text = row.Cells["Luong"].Value.ToString();
                txb_MaQL.Text = row.Cells["Ma_NQL"].Value.ToString();
            }
        }

        private void btn_SuaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                int maNhanVien = Convert.ToInt32(txb_MaNV.Text);
                string hoTen = txb_TenNV.Text.Trim();
                DateTime ngaySinh = dtp_NgaySinhNV.Value;
                string gioiTinh = cb_GioiTinh.Text.Trim();
                string diaChi = txb_DiaChiNV.Text.Trim();
                string sdt = txb_sdtNV.Text.Trim();
                decimal luong = decimal.Parse(txb_LuongNV.Text);
                string congViec = txb_CongViec.Text.Trim();
                int maNQL = Convert.ToInt32(txb_MaQL.Text.Trim());

                // Nếu tất cả các kiểm tra đều hợp lệ, tiến hành gọi Stored Procedure
                string[] paramNames = { "@Ma_Nhan_Vien", "@Ho_Ten", "@Ngay_Sinh", "@Gioi_Tinh", "@Dia_Chi", "@SDT", "@Luong", "@Cong_Viec", "@Ma_NQL" };
                object[] paramValues = { maNhanVien, hoTen, ngaySinh, gioiTinh, diaChi, sdt, luong, congViec, maNQL };

                // Gọi hàm để thực thi Stored Procedure
                object result = db.getResultFromProc("sp_UpdateNhanVien", paramValues, paramNames);

                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm nhân viên.");
                }
            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {


                string hoTen = txb_TenNV.Text;
                DateTime ngaySinh = dtp_NgaySinhNV.Value;
                string gioiTinh = cb_GioiTinh.SelectedItem.ToString();
                string diaChi = txb_DiaChiNV.Text;
                string sdt = txb_sdtNV.Text.Trim();
                decimal luong = decimal.Parse(txb_LuongNV.Text);
                string congViec = txb_CongViec.Text;
                int maNQL = Convert.ToInt32(txb_MaQL.Text.Trim());

                // Tham số cho stored procedure
                string storedProcedure = "sp_ThemNhanVien"; // Tên stored procedure
                string[] paramNames = new string[] { "@Ho_Ten", "@Ngay_Sinh", "@Gioi_Tinh", "@Dia_Chi", "@SDT", "@Luong", "@Cong_Viec", "@Ma_NQL" };
                object[] paramValues = new object[] { hoTen, ngaySinh, gioiTinh, diaChi, sdt, luong, congViec, maNQL };

                // Gọi hàm thực thi stored procedure
                object result = db.getResultFromProc(storedProcedure, paramValues, paramNames);

                // Xử lý kết quả trả về
                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm nhân viên.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dgv_ThuCung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgv_ThuCung.Rows[e.RowIndex].IsNewRow)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dgv_ThuCung.Rows[e.RowIndex];

                // Đổ dữ liệu vào các TextBox
                txb_MaTC.Text = row.Cells["Mã Thú Cưng"].Value.ToString();
                txb_TenTC.Text = row.Cells["Tên Thú Cưng"].Value.ToString();
                txb_Loai.Text = row.Cells["Loài"].Value.ToString();
                txb_GiongTC.Text = row.Cells["Giống"].Value.ToString();
                dtp_NgaySinhTC.Value = Convert.ToDateTime(row.Cells["Ngày Sinh"].Value);
                txb_MauSacTC.Text = row.Cells["Màu Sắc"].Value.ToString();
                txb_CanNangTC.Text = row.Cells["Cân Nặng (kg)"].Value.ToString();
                txb_SucKhoeTC.Text = row.Cells["Tình Trạng Sức Khỏe"].Value.ToString();
                txb_TrangThaiTC.Text = row.Cells["Trạng Thái"].Value.ToString();
                txb_SoMuiTiemTC.Text = row.Cells["Số Lần Tiêm"].Value.ToString();
                cb_GioiTinhTC.Text = row.Cells["Giới Tính"].Value.ToString();
                txb_GiaGocTC.Text = row.Cells["Giá Bán Gốc"].Value.ToString();
                txb_GiaKMTC.Text = row.Cells["Giá Khuyến Mại"].Value.ToString();
                flp_HinhAnhTC.Controls.Clear();
                btn_ThemAnhTC.Tag = txb_MaTC.Text;
                ma = Convert.ToInt32(txb_MaTC.Text);
                Load_Hinh_Anh("thucung");
            }
        }
        private void Load_Hinh_Anh(string loai)
        {
            string query = "SELECT * FROM HinhAnh WHERE Ma_SPDV = @Ma_SPDV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Ma_SPDV", SqlDbType.Int) { Value = ma }
            };

            DataTable table = db.ExecuteQuery(query, parameters);

            // Gọi hàm thực thi query với tham số
            foreach (DataRow rowHA in table.Rows)
            {
                // Lấy đường dẫn hình ảnh từ cột "Duong_Dan" của bảng
                string link = rowHA["Duong_Dan"].ToString();

                // Chuyển đổi đường dẫn 
                link = imageLinkConverter.Convert(link).ToString();

                // Tạo một PictureBox mới cho mỗi hình ảnh
                PictureBox pictureBox = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = link
                };
                pictureBox.Tag = ma;
                pictureBox.MouseDown += PictureBox_MouseDown;
                // Thêm PictureBox vào FlowLayoutPanel
                if (loai == "thucung")
                {
                    flp_HinhAnhTC.Controls.Add(pictureBox);
                }
                else if (loai == "vatpham")
                {
                    flp_HinhAnhVP.Controls.Add(pictureBox);
                }
                else if (loai == "dichvu")
                {
                    flp_HinhAnhDV.Controls.Add(pictureBox);
                }
            }
        }
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox pictureBox = sender as PictureBox;

                if (pictureBox != null)
                {
                    // Lưu đường dẫn ảnh vào Tag của menu item
                    contextMenuStrip.Tag = pictureBox.ImageLocation;
                    MessageBox.Show(pictureBox.ImageLocation);
                    // Hiển thị menu ngữ cảnh
                    contextMenuStrip.Show(pictureBox, e.Location);
                }
            }
        }
        private void MenuItemXoa_Click(object sender, EventArgs e)
        {
            string imageLocation = contextMenuStrip.Tag as string;
            string filePath = imageLocation.Replace("file:///", "");

            filePath = filePath.Replace("/", "\\");

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Không tìm thấy hình ảnh để xóa.");
                return;
            }


            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hình ảnh này?", "Xóa Ảnh", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File không tồn tại: " + filePath);
                    return;
                }
                // Xóa hình ảnh khỏi hệ thống tệp
                try
                {
                    File.Delete(filePath);
                    MessageBox.Show("Hình ảnh đã được xóa thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hình ảnh: {ex.Message}");
                    return;
                }
                filePath = filePath.Replace("D:/HK1_Nam3/DBMS/DBMS_FinalProject/", "");
                // Gọi procedure để xóa thông tin hình ảnh khỏi cơ sở dữ liệu
                string[] paramNames = { "@Ma_SPDV", "@Duong_Dan" };
                object[] paramValues = { ma, filePath };

                object result = db.getResultFromProc("sp_XoaHinhAnh", paramValues, paramNames);

                if (result != null)
                {
                    MessageBox.Show(result.ToString()); // Hiển thị thông báo từ stored procedure
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa hình ảnh khỏi cơ sở dữ liệu.");
                }
            }
        }
        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Lấy Mã Thú Cưng từ Tag của nút
            if (clickedButton?.Tag == null)
            {
                MessageBox.Show("Mã sản phẩm và dịch vụ không hợp lệ.");
                return;
            }

            int maSPDV = Convert.ToInt32(clickedButton.Tag);

            // Tiến hành xử lý thêm ảnh
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn Hình Ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    // Đường dẫn lưu hình ảnh
                    string imagePath = $"D:\\HK1_Nam3\\DBMS\\DBMS_FinalProject\\assets\\images\\{maSPDV}\\" + Path.GetFileName(selectedImagePath);

                    // Tạo thư mục nếu chưa tồn tại
                    string directoryPath = $"D:\\HK1_Nam3\\DBMS\\DBMS_FinalProject\\assets\\images\\{maSPDV}";
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Sao chép hình ảnh vào thư mục
                    try
                    {
                        File.Copy(selectedImagePath, imagePath, true);
                        // Gọi procedure để lưu thông tin hình ảnh vào cơ sở dữ liệu
                        string[] paramNames = { "@Ma_SPDV", "@Duong_Dan" };
                        object[] paramValues = { maSPDV, imagePath };

                        object result = db.getResultFromProc("sp_ThemHinhAnh", paramValues, paramNames, false);

                        if (result != null)
                        {
                            MessageBox.Show(result.ToString()); // Hiển thị thông báo từ stored procedure // Tải lại hình ảnh để cập nhật giao diện
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi khi thêm hình ảnh.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi sao chép hình ảnh: {ex.Message}");
                        return; // Kết thúc hàm nếu sao chép không thành công
                    }
                }
            }
        }

        private void btn_SuaThuCung_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox và các điều khiển khác
                int maThuCung = Convert.ToInt32(txb_MaTC.Text);
                string loai = txb_Loai.Text.Trim();
                string giong = txb_GiongTC.Text.Trim();
                DateTime ngaySinh = dtp_NgaySinhTC.Value;
                string gioiTinh = cb_GioiTinhTC.Text; // Giả sử cb_GioiTinhTC là ComboBox
                string mauSac = txb_MauSacTC.Text.Trim();
                decimal canNang = decimal.Parse(txb_CanNangTC.Text.Trim());
                string sucKhoe = txb_SucKhoeTC.Text.Trim();
                string trangThai = txb_TrangThaiTC.Text.Trim();
                int soLanTiem = Convert.ToInt32(txb_SoMuiTiemTC.Text.Trim());

                // Thông tin sản phẩm/dịch vụ
                string tenSPDV = txb_TenTC.Text.Trim();
                string moTaSPDV = txb_SucKhoeTC.Text.Trim(); // Dùng tình trạng sức khỏe làm mô tả
                decimal giaBanGoc = decimal.Parse(txb_GiaGocTC.Text.Trim());
                decimal giaKhuyenMai = decimal.Parse(txb_GiaKMTC.Text.Trim());

                // Tạo mảng chứa tên các tham số và các giá trị của chúng
                string[] paramNames = { "@Ma_Thu_Cung", "@Loai", "@Giong", "@Ngay_Sinh", "@Gioi_Tinh", "@Mau_Sac", "@Can_Nang",
                                "@Tinh_Trang_Suc_Khoe", "@Trang_Thai", "@So_Lan_Tiem", "@Ten_SPDV", "@Mo_Ta_SPDV",
                                "@Gia_Ban_Goc", "@Gia_Khuyen_Mai" };

                object[] paramValues = { maThuCung, loai, giong, ngaySinh, gioiTinh, mauSac, canNang, sucKhoe, trangThai,
                                 soLanTiem, tenSPDV, moTaSPDV, giaBanGoc, giaKhuyenMai };

                // Gọi hàm để thực thi Stored Procedure
                object result = db.getResultFromProc("sp_UpdateThuCung", paramValues, paramNames);

                // Kiểm tra kết quả trả về và hiển thị thông báo
                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật thú cưng.");
                }

                // Tải lại dữ liệu sau khi cập nhật

            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }

        }

        private void btn_ThemThuCung_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox và ComboBox
                string loai = txb_Loai.Text.Trim();
                string giong = txb_GiongTC.Text.Trim();
                DateTime ngaySinh = dtp_NgaySinhTC.Value; // Ngày sinh từ DateTimePicker
                string gioiTinh = cb_GioiTinhTC.Text.Trim(); // Giả sử bạn sử dụng ComboBox
                string mauSac = txb_MauSacTC.Text.Trim();
                decimal canNang = decimal.Parse(txb_CanNangTC.Text); // Đảm bảo bạn đã kiểm tra tính hợp lệ
                string tinhTrangSucKhoe = txb_SucKhoeTC.Text.Trim();
                string trangThai = txb_TrangThaiTC.Text.Trim();
                int soLanTiem = Convert.ToInt32(txb_SoMuiTiemTC.Text); // Đảm bảo giá trị hợp lệ
                string tenSPDV = txb_TenTC.Text.Trim(); // Tên sản phẩm/dịch vụ
                string moTaSPDV = txb_MoTaTC.Text.Trim(); // Mô tả sản phẩm/dịch vụ
                decimal giaBanGoc = decimal.Parse(txb_GiaGocTC.Text); // Giá bán gốc
                decimal giaKhuyenMai = decimal.Parse(txb_GiaKMTC.Text); // Giá khuyến mại

                // Tham số cho stored procedure
                string storedProcedure = "sp_ThemThuCung"; // Tên stored procedure
                string[] paramNames = new string[] { "@Loai", "@Giong", "@Ngay_Sinh", "@Gioi_Tinh", "@Mau_Sac", "@Can_Nang", "@Tinh_Trang_Suc_Khoe", "@Trang_Thai", "@So_Lan_Tiem", "@Ten_SPDV", "@Mo_Ta_SPDV", "@Gia_Ban_Goc", "@Gia_Khuyen_Mai" };
                object[] paramValues = new object[] { loai, giong, ngaySinh, gioiTinh, mauSac, canNang, tinhTrangSucKhoe, trangThai, soLanTiem, tenSPDV, moTaSPDV, giaBanGoc, giaKhuyenMai };

                // Gọi hàm thực thi stored procedure
                object result = db.getResultFromProc(storedProcedure, paramValues, paramNames);

                // Xử lý kết quả trả về
                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm thú cưng.");
                }
            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dgv_VatPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && !dgv_VatPham.Rows[e.RowIndex].IsNewRow)
                {
                    // Lấy dòng hiện tại
                    DataGridViewRow row = dgv_VatPham.Rows[e.RowIndex];

                    // Đổ dữ liệu vào các TextBox
                    txb_MaVP.Text = row.Cells["Ma_Vat_Pham"].Value.ToString();
                    txb_TenVP.Text = row.Cells["Ten_San_Pham"].Value.ToString();
                    txb_ThuongHieuVP.Text = row.Cells["Thuong_Hieu"].Value.ToString();
                    dtp_HSDVP.Value = Convert.ToDateTime(row.Cells["Han_Su_Dung"].Value);
                    txb_SoLuongVP.Text = row.Cells["So_Luong_Ton_Kho"].Value.ToString();
                    txb_GiaGocVP.Text = row.Cells["Gia_Ban_Goc"].Value.ToString();
                    txb_GiaKMVP.Text = row.Cells["Gia_Khuyen_Mai"].Value.ToString();
                    txb_MoTaVP.Text = row.Cells["Mo_Ta_San_Pham"].Value.ToString();
                    flp_HinhAnhVP.Controls.Clear();
                    btn_ThemAnhVP.Tag = txb_MaVP.Text;
                    ma = Convert.ToInt32(txb_MaVP.Text);
                    Load_Hinh_Anh("vatpham");
                }
            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btn_SuaVP_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBo
                int maVatPham = Convert.ToInt32(txb_MaVP.Text); // Mã vật phẩm
                string ten = txb_TenVP.Text.Trim(); // Tên vật phẩm
                string moTa = txb_MoTaVP.Text.Trim(); // Mô tả vật phẩm
                decimal giaBanGoc = decimal.Parse(txb_GiaGocVP.Text); // Giá bán gốc
                decimal giaKhuyenMai = decimal.Parse(txb_GiaKMVP.Text); // Giá khuyến mãi
                string thuongHieu = txb_ThuongHieuVP.Text.Trim(); // Thương hiệu
                DateTime hanSuDung = dtp_HSDVP.Value; // Hạn sử dụng
                int soLuongTonKho = Convert.ToInt32(txb_SoLuongVP.Text); // Số lượng tồn kho

                // Nếu tất cả các kiểm tra đều hợp lệ, tiến hành gọi Stored Procedure
                string[] paramNames = { "@Ma_Vat_Pham", "@Ten", "@Mo_Ta", "@Gia_Ban_Goc", "@Gia_Khuyen_Mai", "@Thuong_Hieu", "@Han_Su_Dung", "@So_Luong_Ton_Kho" };
                object[] paramValues = { maVatPham, ten, moTa, giaBanGoc, giaKhuyenMai, thuongHieu, hanSuDung, soLuongTonKho };

                // Gọi hàm để thực thi Stored Procedure
                object result = db.getResultFromProc("sp_UpdateVatPham", paramValues, paramNames);

                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật vật phẩm.");
                }
            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btn_ThemVP_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                string ten = txb_TenVP.Text.Trim();
                string moTa = txb_MoTaVP.Text.Trim();
                decimal giaBanGoc = decimal.Parse(txb_GiaGocVP.Text);
                decimal giaKhuyenMai = decimal.Parse(txb_GiaKMVP.Text);
                string thuongHieu = txb_ThuongHieuVP.Text.Trim();
                DateTime hanSuDung = dtp_HSDVP.Value;
                int soLuongTonKho = Convert.ToInt32(txb_SoLuongVP.Text);

                // Nếu tất cả các kiểm tra đều hợp lệ, tiến hành gọi Stored Procedure
                string[] paramNames = { "@Ten", "@Mo_Ta", "@Gia_Ban_Goc", "@Gia_Khuyen_Mai", "@Thuong_Hieu", "@Han_Su_Dung", "@So_Luong_Ton_Kho" };
                object[] paramValues = { ten, moTa, giaBanGoc, giaKhuyenMai, thuongHieu, hanSuDung, soLuongTonKho };

                // Gọi hàm để thực thi Stored Procedure
                object result = db.getResultFromProc("sp_InsertVatPham", paramValues, paramNames);

                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm vật phẩm.");
                }
            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dgv_DichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgv_DichVu.Rows[e.RowIndex].IsNewRow)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dgv_DichVu.Rows[e.RowIndex];

                // Đổ dữ liệu vào các TextBox
                txb_MaDV.Text = row.Cells["Ma_Dich_Vu"].Value.ToString();
                txb_TenDV.Text = row.Cells["Ten_Dich_Vu"].Value.ToString();
                txb_GiaGocDV.Text = row.Cells["Gia_Ban_Goc"].Value.ToString();
                txb_GiaKMDV.Text = row.Cells["Gia_Khuyen_Mai"].Value.ToString();
                txb_TGTH.Text = row.Cells["Thoi_Gian_Thuc_Hien"].Value.ToString();
                txb_MoTaDV.Text = row.Cells["Mo_Ta_Dich_Vu"].Value.ToString();
                txb_SoPhong.Text = row.Cells["So_Luong_Phong_Trong"].Value.ToString();
                flp_HinhAnhDV.Controls.Clear();
                btn_ThemAnhDV.Tag = txb_MaDV.Text;
                ma = Convert.ToInt32(txb_MaDV.Text);
                Load_Hinh_Anh("dichvu");
            }
        }

        private void btn_SuaDV_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                int maDichVu = Convert.ToInt32(txb_MaDV.Text);
                string tenDichVu = txb_TenDV.Text.Trim();
                decimal giaBanGoc = decimal.Parse(txb_GiaGocDV.Text);
                decimal giaKhuyenMai = decimal.Parse(txb_GiaKMDV.Text);
                int thoiGianThucHien = int.Parse(txb_TGTH.Text);
                string moTaDichVu = txb_MoTaDV.Text.Trim();

                // Giả sử có một cách để lấy số lượng phòng trống, nếu không có, hãy đặt một giá trị mặc định
                int soLuongPhongTrong = 0; // Bạn có thể thay đổi theo yêu cầu

                // Nếu tất cả các kiểm tra đều hợp lệ, tiến hành gọi Stored Procedure
                string[] paramNames = { "@Ma_Dich_Vu", "@Ten", "@Mo_Ta", "@Gia_Ban_Goc", "@Gia_Khuyen_Mai", "@Thoi_Gian_Thuc_Hien", "@So_Luong_Phong_Trong" };
                object[] paramValues = { maDichVu, tenDichVu, moTaDichVu, giaBanGoc, giaKhuyenMai, thoiGianThucHien, soLuongPhongTrong };

                // Gọi hàm để thực thi Stored Procedure
                object result = db.getResultFromProc("sp_UpdateDichVu", paramValues, paramNames);

                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật dịch vụ.");
                }

            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btn_ThemDV_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                string tenDV = txb_TenDV.Text.Trim();
                string moTa = txb_MoTaDV.Text.Trim();
                decimal giaBanGoc = decimal.Parse(txb_GiaGocDV.Text);
                decimal giaKhuyenMai = decimal.Parse(txb_GiaKMDV.Text);
                int thoiGianThucHien = int.Parse(txb_TGTH.Text);
                int soLuongPhongTrong = int.Parse(txb_SoPhong.Text); // Giả sử bạn có một TextBox cho số lượng phòng trống

                // Định nghĩa tên tham số cho stored procedure
                string[] paramNames = { "@Ten_SPDV", "@Mo_Ta", "@Gia_Ban_Goc", "@Gia_Khuyen_Mai", "@Thoi_Gian_Thuc_Hien", "@So_Luong_Phong_Trong" };
                object[] paramValues = { tenDV, moTa, giaBanGoc, giaKhuyenMai, thoiGianThucHien, soLuongPhongTrong };

                // Gọi hàm để thực thi stored procedure
                object result = db.getResultFromProc("sp_InsertDichVu", paramValues, paramNames);

                if (result != null)
                {
                    string message = result.ToString(); // Kết quả là thông báo từ stored procedure
                    MessageBox.Show(message);
                    LoadData(); // Cập nhật lại dữ liệu hiển thị nếu cần
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm dịch vụ.");
                }
            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dgv_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgv_KhachHang.Rows[e.RowIndex].IsNewRow)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dgv_KhachHang.Rows[e.RowIndex];

                // Đổ dữ liệu vào các TextBox
                txb_MaKH.Text = row.Cells["Ma_Khach_Hang"].Value.ToString();
                txb_TenKH.Text = row.Cells["Ten"].Value.ToString();
                txb_SDTKH.Text = row.Cells["SDT"].Value.ToString();
                txb_DiemTichLuy.Text = row.Cells["Diem_Tich_Luy"].Value.ToString();
            }
        }

        private void btn_ThemAnhTC_Click(object sender, EventArgs e)
        {
            btnThemAnh_Click(sender, e);
        }

        private void btn_ThemAnhVP_Click(object sender, EventArgs e)
        {
            btnThemAnh_Click(sender, e);
        }

        private void btn_ThemAnhDV_Click(object sender, EventArgs e)
        {
            btnThemAnh_Click(sender, e);
        }


        private void btn_XoaNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void btn_SuaKH_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                int maKhachHang = Convert.ToInt32(txb_MaKH.Text);
                string tenKH = txb_TenKH.Text;
                string sdtKH = txb_SDTKH.Text;
                int diemTichLuy = Convert.ToInt32(txb_DiemTichLuy.Text);

                // Tạo mảng tham số cho stored procedure
                string[] paramNames = { "@Ma_Khach_Hang", "@Ten", "@SDT", "@Diem_Tich_Luy" };
                object[] paramValues = { maKhachHang, tenKH, sdtKH, diemTichLuy };

                // Gọi stored procedure để cập nhật thông tin khách hàng
                object result = db.getResultFromProc("sp_SuaKhachHang", paramValues, paramNames, false);

                // Hiển thị thông báo kết quả
                if (result != null)
                {
                    MessageBox.Show(result.ToString()); // Hiển thị thông báo từ stored procedure
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin khách hàng.");
                }
            }
            catch (FormatException ex)
            {
                // Bắt lỗi định dạng dữ liệu (ví dụ: số điện thoại không hợp lệ)
                MessageBox.Show("Lỗi định dạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
