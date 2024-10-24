using DBMS_Final_Project.view.ChucNangBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_Final_Project.view
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnPhanCa_Click(object sender, EventArgs e)
        {
            UC_Schedule uC_Schedule = new UC_Schedule();
            flpScreen.Controls.Clear();
            flpScreen.Controls.Add(uC_Schedule);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            main_ban_hang main_Ban_Hang = new main_ban_hang();

            flpScreen.Controls.Clear();
            flpScreen.Controls.Add(main_Ban_Hang);
        }
    }
}
