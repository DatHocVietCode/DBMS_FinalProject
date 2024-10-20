using DBMS_Final_Project.control.converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace DBMS_Final_Project.view.ChucNangBanHang
{
    public partial class main_ban_hang : Form
    {
        public main_ban_hang()
        {
            InitializeComponent();
        }

        private void tp_spdv_Click(object sender, EventArgs e)
        {

        }

        private void main_ban_hang_Load(object sender, EventArgs e)
        {
            cb_gia.SelectedIndex = 0;
            cb_alphabet.SelectedIndex = 0;
            cb_ngay_tao.SelectedIndex = 0;
            cb_tong_tien.SelectedIndex = 0;
            string img_link = @"assets\images\chucnangbanhang\icon\Search_Icon.png";
            img_link = imageLinkConverter.Convert(img_link).ToString();
            btn_tim_kiem.ImageList = imageList;
            btn_tim_kiem.Image = imageList.Images[0];
            btn_tim_kiem_thanh_vien.ImageList = imageList;
            btn_tim_kiem_thanh_vien.Image = imageList.Images[0];

            lv_hoa_don.View = View.Details;
            // Thêm các cột vào ListView
            lv_hoa_don.Columns.Add("ID", 50); // Tên cột và độ rộng
            lv_hoa_don.Columns.Add("Tên sản phẩm", 150);
            lv_hoa_don.Columns.Add("Số lượng", 70);
            lv_hoa_don.Columns.Add("Đơn giá", 100);
            lv_hoa_don.Columns.Add("Thành tiền", 100);
            for (int i = 0; i < 10; i++)
            {
                string[] row = new string[] { i.ToString(), "dat", "10", "100", "1000" };
                ListViewItem lv = new ListViewItem(row);
                lv_hoa_don.Items.Add(lv);
            }
        }

        private void txt_tim_kiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_tim_kiem_MouseClick(object sender, MouseEventArgs e)
        {
            txt_tim_kiem.Clear();
        }

        private void lv_hoa_don_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (lv_hoa_don.SelectedItems == null)
                return;
            foreach (var item in lv_hoa_don.SelectedItems)
            {
                lv_hoa_don.Items.Remove((ListViewItem)item);
            }
        }

        private void cb_gia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_gia.SelectedIndex == 2)
            {
                decimal start = 0;
                decimal end = 0;
                loc_khoang_gia loc_Khoang_Gia = new loc_khoang_gia(ref start, ref end);
                loc_Khoang_Gia.ShowDialog();

            }
        }

        private void btn_xac_nhan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thanh toán ngay?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Người dùng nhấn nút Yes
                MessageBox.Show("Bạn đã chọn Yes, hóa đơn có trạng thái đã thanh toán","Notice");
            }
            else if (result == DialogResult.No)
            {
                // Người dùng nhấn nút No
                MessageBox.Show("Bạn đã chọn No, hóa đơn sẽ đưa vào danh sách chờ", "Notice");
            }
        }

        private void btn_huy_bo_Click(object sender, EventArgs e)
        {
            lv_hoa_don.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {

        }

        private void btn_them_thanh_vien_Click(object sender, EventArgs e)
        {
            modifyMember("Thêm");
        }

        private void btn_sua_thanh_vien_Click(object sender, EventArgs e)
        {
            modifyMember("Sửa");
        }
        private void modifyMember(string header)
        {
            string title = header + " thông tin thành viên";
            member_detail member_Detail = new member_detail(title);
            member_Detail.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_tim_kiem_thanh_vien_MouseClick(object sender, MouseEventArgs e)
        {
            txt_tim_kiem_thanh_vien.Clear();
        }
    }
}
