namespace DBMS_Final_Project.view
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnQuanLy = new System.Windows.Forms.Button();
            this.btnPhanCa = new System.Windows.Forms.Button();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            this.flpScreen = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel4.Controls.Add(this.panel1);
            this.flowLayoutPanel4.Controls.Add(this.btnBanHang);
            this.flowLayoutPanel4.Controls.Add(this.btnQuanLy);
            this.flowLayoutPanel4.Controls.Add(this.btnPhanCa);
            this.flowLayoutPanel4.Controls.Add(this.btnDoanhThu);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(182, 807);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnBanHang
            // 
            this.btnBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanHang.Location = new System.Drawing.Point(0, 100);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(0);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(182, 50);
            this.btnBanHang.TabIndex = 0;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.UseVisualStyleBackColor = true;
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLy.Location = new System.Drawing.Point(0, 150);
            this.btnQuanLy.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.Size = new System.Drawing.Size(182, 50);
            this.btnQuanLy.TabIndex = 1;
            this.btnQuanLy.Text = "Quản lý";
            this.btnQuanLy.UseVisualStyleBackColor = true;
            // 
            // btnPhanCa
            // 
            this.btnPhanCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanCa.Location = new System.Drawing.Point(0, 200);
            this.btnPhanCa.Margin = new System.Windows.Forms.Padding(0);
            this.btnPhanCa.Name = "btnPhanCa";
            this.btnPhanCa.Size = new System.Drawing.Size(182, 50);
            this.btnPhanCa.TabIndex = 2;
            this.btnPhanCa.Text = "Phân Ca";
            this.btnPhanCa.UseVisualStyleBackColor = true;
            this.btnPhanCa.Click += new System.EventHandler(this.btnPhanCa_Click);
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.Location = new System.Drawing.Point(0, 250);
            this.btnDoanhThu.Margin = new System.Windows.Forms.Padding(0);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(182, 50);
            this.btnDoanhThu.TabIndex = 3;
            this.btnDoanhThu.Text = "Doanh Thu";
            this.btnDoanhThu.UseVisualStyleBackColor = true;
            // 
            // flpScreen
            // 
            this.flpScreen.Location = new System.Drawing.Point(203, 0);
            this.flpScreen.Margin = new System.Windows.Forms.Padding(0);
            this.flpScreen.Name = "flpScreen";
            this.flpScreen.Size = new System.Drawing.Size(1501, 807);
            this.flpScreen.TabIndex = 0;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1713, 829);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.flpScreen);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnQuanLy;
        private System.Windows.Forms.Button btnPhanCa;
        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.FlowLayoutPanel flpScreen;
    }
}