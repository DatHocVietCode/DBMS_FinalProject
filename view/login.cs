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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void lbl_petshop_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            //lbl_petshop.Font = new Font("Time new Roman", 24, FontStyle.Bold);
        }

        private void lbl_taikhoan_Click(object sender, EventArgs e)
        {

        }
        
        private void llbl_dangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup signup = new signup();
            signup.FormClosed += Signup_FormClosed;
            signup.Show();
            this.Hide();
        }

        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
