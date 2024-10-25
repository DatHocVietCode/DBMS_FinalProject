using DBMS_Final_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_Final_Project.database;

namespace DBMS_Final_Project.view
{
    public partial class AddNewSession : Form
    {
        string conn = Database.connectionString;
        public AddNewSession()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT Ma_Nhan_Vien FROM NhanVien", connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbMaNV.Items.Add(reader["Ma_Nhan_Vien"].ToString());
                            }
                        }
                    }
                }
                cbBuoiLam.SelectedIndex = 0;
                cbMaNV.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            
        }
        public void ThemCaLamChoNhanVien(string buoi, DateTime ngayLamViec, int maNhanVien)
        {
            try
            {
                // Mở kết nối đến SQL Server
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    // Tạo SqlCommand để gọi thủ tục Proc_ThemCaLamChoNhanVien
                    using (SqlCommand cmd = new SqlCommand("Proc_ThemCaLamChoNhanVien", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số cho thủ tục
                        cmd.Parameters.AddWithValue("@Buoi", buoi);
                        cmd.Parameters.AddWithValue("@Ngay_Lam_Viec", ngayLamViec);
                        cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", maNhanVien);

                        // Thực hiện thủ tục
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Hiển thị thông báo sau khi thực hiện
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ca làm đã được thêm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không có thay đổi nào được thực hiện.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các điều khiển trên form
                string buoi = cbBuoiLam.SelectedItem.ToString(); // Giả sử bạn có ComboBox chọn buổi
                DateTime ngayLamViec = dpNgayLamViec.Value;   // Giả sử bạn có DateTimePicker để chọn ngày làm việc
                int maNhanVien = int.Parse(cbMaNV.SelectedItem.ToString()); // Lấy mã nhân viên từ ComboBox

                // Gọi hàm để thêm ca làm cho nhân viên
                ThemCaLamChoNhanVien(buoi, ngayLamViec, maNhanVien);

                this.Close();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
