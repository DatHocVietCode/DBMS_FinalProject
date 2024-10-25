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

namespace DBMS_Final_Project.view.ChucNangXemDoanhThu
{
    public partial class UC_DoanhThu : UserControl
    {
        string conn = Database.connectionString;
        public UC_DoanhThu()
        {
            InitializeComponent();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("Proc_DoanhThu", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Lấy giá trị từ DateTimePicker
                    command.Parameters.AddWithValue("@NgayBatDau", dtpStartDate.Value);
                    command.Parameters.AddWithValue("@NgayKetThuc", dtpEndDate.Value);

                    SqlParameter doanhThuParam = new SqlParameter("@DoanhThu", SqlDbType.Decimal);
                    doanhThuParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(doanhThuParam);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        decimal totalAmount = (decimal)doanhThuParam.Value;

                        // Cập nhật tổng tiền lên label
                        lblTotalAmount.Text = $"Tổng Tiền: {totalAmount:F2} VNĐ";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
