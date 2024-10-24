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
        string name = "";
        string sdt = "";
        string dtl = "";
        public member_detail(string title)
        {
            InitializeComponent();
            lbl_title.Text = title;
        }

        private void member_detail_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_xac_nhan_Click(object sender, EventArgs e)
        {
            this.name = txt_name.Text;
            this.txt_dtl.Text = txt_dtl.Text;
            this.sdt = txt_sdt.Text;
            this.Close();
        }

        private void btn_huy_bo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void getValue(ref string name, ref string sdt, ref string dtl) 
        {
            name = txt_name.Text;
            sdt = txt_sdt.Text;
            dtl = txt_dtl.Text;
        }
    }
}
