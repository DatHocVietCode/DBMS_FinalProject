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
    public partial class loc_khoang_gia : Form
    {
        private string start;
        private string end;

        public loc_khoang_gia(ref string start, ref string end)
        {
            InitializeComponent();
            this.start = start;
            this.end = end;
        }

        private void btn_xac_nhan_Click(object sender, EventArgs e)
        {
            this.start = txt_startingValue.Text;
            this.end = txt_endingValue.Text;
            this.Close();
        }

        private void btn_huy_bo_Click(object sender, EventArgs e)
        {
            this.start = null;
            this.end = null;
            this.Close();
        }
        public void GetValues(ref string start, ref string end)
        {
            // Cập nhật lại giá trị tham số khi form con đóng
            start = this.start;
            end = this.end;
        }
    }
}
