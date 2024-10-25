using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_Final_Project;
using DBMS_Final_Project.control.converter;
using static System.Windows.Forms.LinkLabel;
using DBMS_Final_Project.database;
namespace DBMS_Final_Project.view.ChucNangBanHang
{
    public partial class chitietvatphamthucung : Form
    {
        
        int id_spdv;
        Database instance = new Database();
        public chitietvatphamthucung(int id_spdv, bool isPet = true)
        {
            InitializeComponent();
            this.id_spdv = id_spdv; 
            if (isPet )
            {
              
                string query = "SELECT * FROM dbo.XemChiTietThuCung(" + id_spdv.ToString() + ")";
                DataTable dt = instance.ExecuteQuery(query);
                query = "SELECT * FROM dbo.LayHinhAnh(" + id_spdv.ToString() + ")";
                DataTable hinhanh = instance.ExecuteQuery(query);

                load_giao_dien_thu_cung(dt, hinhanh);
            }
            else
            {
              
                string query = "SELECT * FROM dbo.XemChiTietVatPham(" + id_spdv.ToString() + ")";
                DataTable dt = instance.ExecuteQuery(query);
                query = "SELECT * FROM dbo.LayHinhAnh(" + id_spdv.ToString() + ")";
                DataTable hinhanh = instance.ExecuteQuery(query);

                load_giao_dien_vat_pham(dt, hinhanh);
            }
        }

        private void load_giao_dien_vat_pham(DataTable dt, DataTable hinhanh)
        {
            panel_thu_cung.Visible = false;
            panel_vatpham.Visible = true;
            foreach (DataRow row in dt.Rows)
            {
                lbl_ten_spdv.Text = row["Ten"].ToString();
                lbl_mo_ta.Text = row["Mo_Ta"].ToString();
                lbl_gia_ban_goc.Text = Convert.ToDecimal(row["Gia_Ban_Goc"]).ToString("#,0") + "VND";
                lbl_gia_khuyen_mai.Text = Convert.ToDecimal(row["Gia_Khuyen_Mai"]).ToString("#,0") + "VND";
                lbl_thuonghieu.Text = row["Thuong_Hieu"].ToString();
                lbl_hsd.Text = Convert.ToDateTime(row["Han_Su_Dung"]).ToString("dd/MM/yyyy");
                lbl_tonkho.Text = row["So_Luong_Ton_Kho"].ToString();
            }
            ObservableCollection<string> listImg = new ObservableCollection<string>();
            foreach (DataRow item in hinhanh.Rows)
            {
                string link = item["Duong_Dan"].ToString();
                link = imageLinkConverter.Convert(link).ToString();
                listImg.Add(link);

            }
            pb_main.ImageLocation = listImg[0];
            pb_main.SizeMode = PictureBoxSizeMode.StretchImage;
            foreach (string item in listImg)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = item;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Click += PictureBox_Click;
                flp_hinhanh.Controls.Add(pictureBox);
            }
        }

        private void load_thu_cung()
        {

        }
        private void chitietvatphamthucung_Load(object sender, EventArgs e)
        {
            
        }

        private void load_giao_dien_thu_cung(DataTable dt, DataTable hinhanh)
        {
            panel_thu_cung.Visible = true;
            panel_vatpham.Visible = false;
            foreach (DataRow row in dt.Rows)
            {
                lbl_ten_spdv.Text = row["Ten"].ToString();
                lbl_mo_ta.Text = row["Mo_Ta"].ToString();
                lbl_gia_ban_goc.Text = Convert.ToDecimal(row["Gia_Ban_Goc"]).ToString("#,0") + "VND";
                lbl_gia_khuyen_mai.Text = Convert.ToDecimal(row["Gia_Khuyen_Mai"]).ToString("#,0") + "VND";
                lbl_loai.Text = row["Loai"].ToString();
                lbl_giong.Text = row["Giong"].ToString() ;
                lbl_gioi_tinh.Text = row["Gioi_Tinh"].ToString();
                lbl_mau_sac.Text = row["Mau_Sac"].ToString();
                lbl_can_nang.Text = row["Can_Nang"].ToString() + " kg";
                lbl_so_lan_tiem.Text = row["So_Lan_Tiem"].ToString();
                lbl_ttsk.Text = row["Tinh_Trang_Suc_Khoe"].ToString().ToLower();
                lbl_trang_thai.Text = row["Trang_Thai"].ToString();
                string ngaysinh = Convert.ToDateTime(row["Ngay_Sinh"]).ToString("dd/MM/yyyy");
                lbl_ngay_sinh.Text = ngaysinh;
            }
            ObservableCollection<string> listImg = new ObservableCollection<string>();
            foreach (DataRow item in hinhanh.Rows)
            {
                string link = item["Duong_Dan"].ToString();
                link = imageLinkConverter.Convert(link).ToString();
                listImg.Add(link);
               
            }
            pb_main.ImageLocation = listImg[0];
            pb_main.SizeMode = PictureBoxSizeMode.StretchImage;
            foreach (string item in listImg)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = item;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Click += PictureBox_Click;
                flp_hinhanh.Controls.Add(pictureBox);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            pb_main.ImageLocation = picture.ImageLocation;
        }

        private void lbl_gia_khuyen_mai_Click(object sender, EventArgs e)
        {

        }

        private void panel_vatpham_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
