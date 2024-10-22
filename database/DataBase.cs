using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DBMS_Final_Project
{
    public class Database
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetShop;Integrated Security=True";
        private SqlConnection conn;
        public Database()
        {
       
        }
        /// <summary>
        /// Input là một câu quey (string) và một mảng các tham số, output là datatable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                return data;
            }
        }
        /// <summary>
        /// Trả về một đối tượng (object) sau khi thực hiện một thủ tục (stored procedure) trong SQL Server.
        /// Dữ liệu input gồm Command, param values và names theo thứ tự.
        /// </summary>
        /// <param name="query">Tên của stored procedure cần thực hiện.</param>
        /// <param name="parameter">Mảng các tham số (nếu có) để truyền vào stored procedure. Mặc định là null.</param>
        /// <param name="paramName">Mảng chứa tên các tham số. Mặc định là null</param>
        /// <returns>Đối tượng đại diện cho giá trị trả về từ stored procedure. 
        /// Nếu không có giá trị nào được trả về, phương thức sẽ trả về null.</returns>
        public object getSingleResultFromProc(string query, object[] parametervalue = null, string[] paramName = null)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Nếu có tham số, gán cho SqlCommand
                if (parametervalue != null && paramName!=null)
                {
                    // Giả sử rằng tham số được truyền vào sẽ là các giá trị kiểu object.
                    for (int i = 0; i < parametervalue.Length; i++)
                    {
                        // Gán tham số vào SqlCommand
                        sqlCommand.Parameters.AddWithValue(paramName[i], parametervalue[i]);
                    }
                }
                object result = sqlCommand.ExecuteScalar();
                return result;
            }
        }

    }
}
