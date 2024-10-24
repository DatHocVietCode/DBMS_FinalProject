using DBMS_Final_Project;
using DBMS_Final_Project.objs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_Final_Project.view
{
    public partial class UC_Schedule : UserControl
    {
        string conn = Database.connectionString;
        DateTime startDate = DateTime.Now.Date;
        public UC_Schedule()
        {
            InitializeComponent();
            Load();
        }

        private Dictionary<DateTime, string> DaysOfWeek(DateTime startDate)
        {
            Dictionary<DateTime, string> daysOfWeek = new Dictionary<DateTime, string>();

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDay = startDate.AddDays(i);
                daysOfWeek[currentDay] = i.ToString();
            }

            return daysOfWeek;
        }

        public void Load()
        {
            startDate = startDate.AddDays(-((int)startDate.DayOfWeek));
            Run();
        }
        public void Run()
        {
            lbl_Thang.Text = startDate.Month.ToString() + "/" + startDate.Year.ToString();
            for (int i = 0; i < 7; i++)
            {
                Label lbl = (Label) this.Controls.Find("lbl" + i.ToString(), true).First();
                lbl.Text = (startDate.AddDays(i)).DayOfWeek.ToString() + " - "+ (startDate.AddDays(i)).Day.ToString();
            }
            List<CaLam> caLamList = new List<CaLam>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("Proc_XemPhanCaTheoTuan", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số cho thủ tục
                    command.Parameters.Add(new SqlParameter("@StartDate", startDate));

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Đọc dữ liệu từ kết quả truy vấn
                                int maNhanVien = reader.GetInt32(0); // Mã nhân viên
                                string hoTen = reader.GetString(1);   // Họ tên
                                string buoi = reader.GetString(2);    // Buổi
                                DateTime ngayLamViec = reader.GetDateTime(3); // Ngày làm việc

                                CaLam caLam = new CaLam(maNhanVien, hoTen, buoi, ngayLamViec);
                                caLamList.Add(caLam);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi: {ex.Message}");
                    }
                }

                Dictionary<DateTime, string> daysOfWeek = DaysOfWeek(startDate);
                Dictionary<string, string> sessionDictionary = new Dictionary<string, string>
                {
                    { "Sáng", "0" },
                    { "Chiều", "1" },
                    { "Tối", "2" }
                };

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        string strFlp = "flp" + i.ToString() + j.ToString();
                        FlowLayoutPanel flp = (FlowLayoutPanel)this.Controls.Find(strFlp, true).First();
                        flp.Controls.Clear();
                    }
                }


                for (int i = 0; i < caLamList.Count; i++)
                {
                    string strFlp = "flp" + sessionDictionary[caLamList[i].Buoi] + daysOfWeek[caLamList[i].Ngay_lam_viec];
                    FlowLayoutPanel flp = (FlowLayoutPanel)this.Controls.Find(strFlp, true).First();
                    flp.Controls.Add(new Label() { Text = caLamList[i].Ho_ten, ContextMenuStrip = ctm_xoaCaLam, Tag = caLamList[i] });
                }
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSession addNewSession = new AddNewSession();
            addNewSession.ShowDialog();
            Load();
        }

        public void XoaCaLamChoNhanVien(string buoi, DateTime ngayLamViec, int maNhanVien)
        {
            try
            {
                // Mở kết nối đến SQL Server
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Proc_XoaCaLamChoNhanVien", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Buoi", buoi);
                        cmd.Parameters.AddWithValue("@Ngay_Lam_Viec", ngayLamViec);
                        cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", maNhanVien);

                        // Thực hiện thủ tục
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Hiển thị thông báo sau khi thực hiện
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ca làm đã được xóa thành công.");
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
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Label lbl = ctm_xoaCaLam.SourceControl as Label;   
            if (lbl != null) // Kiểm tra xem có label nào được chọn không
            {
                // Lấy thông tin cần thiết từ tag hoặc tên label
                CaLam calam = (CaLam) lbl.Tag; // Hoặc sử dụng selectedLabel.Text nếu cần

                // Gọi hàm xóa ca làm cho nhân viên
                XoaCaLamChoNhanVien(calam.Buoi, calam.Ngay_lam_viec, calam.Ma_nv); // Giả sử tag chứa thông tin cần thiết để xóa
                Load();

            }
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            startDate = startDate.AddDays(-7);
            Run();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            startDate = startDate.AddDays(7);
            Run();
        }
    }
}
