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

namespace DBMS_Final_Project.view.ChucNangTinhLuong
{
    public partial class UC_TinhLuong : UserControl
    {
        string conn = Database.connectionString;
        public UC_TinhLuong()
        {
            InitializeComponent();
        }
        private void btnCalculateSalary_Click(object sender, EventArgs e)
        {
            // Lấy mốc thời gian từ các TextBox (hoặc DateTimePicker)
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            // Gọi phương thức để lấy lương nhân viên
            DataTable salaryTable = GetEmployeeSalaries(startDate, endDate);

            // Gán DataTable cho DataGridView
            dataGridView1.DataSource = salaryTable;
        }

        private DataTable GetEmployeeSalaries(DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("Proc_TinhLuongNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số cho stored procedure
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    try
                    {
                        // Mở kết nối và điền dữ liệu vào DataTable
                        connection.Open();
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }
    }
}
