using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DBMS_Final_Project.database
{
    public class Database
    {
        static public string connectionString = @"server=(localdb)\MSSQLLocalDB;Database=PetShop;Integrated Security=True;";
        private SqlConnection conn;
        public Database()
        {

        }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    command.Parameters.AddRange(parameter);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }
        public object getResultFromProc(string query, object[] parametervalue = null, string[] paramName = null, bool isExecReader = false)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Nếu có tham số, gán cho SqlCommand
                if (parametervalue != null && paramName != null)
                {
                    // Giả sử rằng tham số được truyền vào sẽ là các giá trị kiểu object.
                    for (int i = 0; i < parametervalue.Length; i++)
                    {
                        // Gán tham số vào SqlCommand
                        sqlCommand.Parameters.AddWithValue(paramName[i], parametervalue[i]);
                    }
                }
                if (isExecReader)
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            dt.Load(reader); // Tải dữ liệu từ SqlDataReader vào DataTable
                        }
                        return dt; // Trả về DataTable chứa kết quả
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        return null;
                    }

                }
                object result = sqlCommand.ExecuteScalar();
                return result;
            }
        }
    }
}
