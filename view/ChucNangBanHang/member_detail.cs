using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_Final_Project.view.ChucNangBanHang
{
    public partial class member_detail : Form
    {
        public member_detail(string title)
        {
            InitializeComponent();
            lbl_title.Text = title;
        }

        private void member_detail_Load(object sender, EventArgs e)
        {
           
        }
    }
}
