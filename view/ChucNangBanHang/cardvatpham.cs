using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_Final_Project.view.ChucNangBanHang
{
    public partial class cardvatpham : UserControl
    {
        public EventHandler addHoaDon;
        public EventHandler chitietvatpham;
        private int id;
        private decimal giaUudai;
        private string ten;
        public int Id { get => id; set => id = value; }
        public decimal GiaUudai { get => giaUudai; set => giaUudai = value; }
        public string Ten { get => ten; set => ten = value; }

        public cardvatpham(int id, string name, decimal giagoc, decimal giauudai, string link)
        {
            InitializeComponent();
            this.Id = id;
            this.GiaUudai = giauudai;
            this.Ten = name;
            lbl_gia_goc.Text = giagoc.ToString("#,0") + "VND";
            lbl_gia_uu_dai.Text = giauudai.ToString("#,0") + "VND";
            lbl_ten.Text = name;
            lbl_gia_goc.AutoSize = false; 
            //lbl_gia_goc.Dock = DockStyle.Fill; 
            lbl_gia_goc.TextAlign = ContentAlignment.MiddleCenter;

            lbl_gia_uu_dai.AutoSize = false;
            //lbl_gia_uu_dai.Dock = DockStyle.Fill;
            lbl_gia_uu_dai.TextAlign = ContentAlignment.MiddleCenter;

            lbl_ten.AutoSize = false;
            //lbl_ten.Dock = DockStyle.Fill;
            lbl_ten.TextAlign = ContentAlignment.MiddleCenter;
            
            picture_spdv.ImageLocation = link;
            picture_spdv.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void cardvatpham_Load(object sender, EventArgs e)
        {

        }

        private void lbl_gia_uu_dai_Click(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (addHoaDon != null)
            {
                addHoaDon(this, e); 
            }
        }

        private void btn_chi_tiet_Click(object sender, EventArgs e)
        {
            if (chitietvatpham != null)
            {
                chitietvatpham(this, e);
            }
        }
    }
}
