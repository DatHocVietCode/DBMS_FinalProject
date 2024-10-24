namespace DBMS_Final_Project.view
{
    partial class AddNewSession
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
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.cbBuoiLam = new System.Windows.Forms.ComboBox();
            this.dpNgayLamViec = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbMaNV
            // 
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(146, 17);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(200, 24);
            this.cbMaNV.TabIndex = 0;
            // 
            // cbBuoiLam
            // 
            this.cbBuoiLam.FormattingEnabled = true;
            this.cbBuoiLam.Items.AddRange(new object[] {
            "Sáng",
            "Chiều",
            "Tối"});
            this.cbBuoiLam.Location = new System.Drawing.Point(146, 69);
            this.cbBuoiLam.Name = "cbBuoiLam";
            this.cbBuoiLam.Size = new System.Drawing.Size(200, 24);
            this.cbBuoiLam.TabIndex = 1;
            // 
            // dpNgayLamViec
            // 
            this.dpNgayLamViec.Location = new System.Drawing.Point(146, 122);
            this.dpNgayLamViec.Name = "dpNgayLamViec";
            this.dpNgayLamViec.Size = new System.Drawing.Size(200, 22);
            this.dpNgayLamViec.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buổi làm: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày làm việc:";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(15, 171);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(331, 41);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // AddNewSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 231);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpNgayLamViec);
            this.Controls.Add(this.cbBuoiLam);
            this.Controls.Add(this.cbMaNV);
            this.Name = "AddNewSession";
            this.Text = "AddNewSession";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.ComboBox cbBuoiLam;
        private System.Windows.Forms.DateTimePicker dpNgayLamViec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_OK;
    }
}