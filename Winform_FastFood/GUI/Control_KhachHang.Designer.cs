namespace GUI
{
    partial class Control_KhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control_KhachHang));
            this.grb_TimKiem = new System.Windows.Forms.GroupBox();
            this.pic_TimKiem = new System.Windows.Forms.PictureBox();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.grb_Congcu = new System.Windows.Forms.GroupBox();
            this.bnt_TaiLaiNV = new System.Windows.Forms.Button();
            this.bnt_Sua = new System.Windows.Forms.Button();
            this.bnt_Xoa = new System.Windows.Forms.Button();
            this.bnt_ThemNV = new System.Windows.Forms.Button();
            this.bnt_Huy_Sua = new System.Windows.Forms.Button();
            this.bnt_XacNhan_Sua = new System.Windows.Forms.Button();
            this.bnt_Huy_Them = new System.Windows.Forms.Button();
            this.bnt_XacNhan_Them = new System.Windows.Forms.Button();
            this.txt_TenDangNhapNV = new System.Windows.Forms.TextBox();
            this.txt_MatKhauNV = new System.Windows.Forms.TextBox();
            this.txt_LuongNhanVien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TenNhanVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datagv_NhanVien = new System.Windows.Forms.DataGridView();
            this.grb_TimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_TimKiem)).BeginInit();
            this.grb_Congcu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagv_NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_TimKiem
            // 
            this.grb_TimKiem.Controls.Add(this.pic_TimKiem);
            this.grb_TimKiem.Controls.Add(this.txt_TimKiem);
            this.grb_TimKiem.Location = new System.Drawing.Point(86, 548);
            this.grb_TimKiem.Name = "grb_TimKiem";
            this.grb_TimKiem.Size = new System.Drawing.Size(368, 80);
            this.grb_TimKiem.TabIndex = 20;
            this.grb_TimKiem.TabStop = false;
            this.grb_TimKiem.Text = "Tìm kiếm theo tên người dùng";
            // 
            // pic_TimKiem
            // 
            this.pic_TimKiem.Image = ((System.Drawing.Image)(resources.GetObject("pic_TimKiem.Image")));
            this.pic_TimKiem.Location = new System.Drawing.Point(281, 29);
            this.pic_TimKiem.Name = "pic_TimKiem";
            this.pic_TimKiem.Size = new System.Drawing.Size(24, 24);
            this.pic_TimKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_TimKiem.TabIndex = 19;
            this.pic_TimKiem.TabStop = false;
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(8, 29);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(267, 20);
            this.txt_TimKiem.TabIndex = 18;
            // 
            // grb_Congcu
            // 
            this.grb_Congcu.Controls.Add(this.bnt_TaiLaiNV);
            this.grb_Congcu.Controls.Add(this.bnt_Sua);
            this.grb_Congcu.Controls.Add(this.bnt_Xoa);
            this.grb_Congcu.Controls.Add(this.bnt_ThemNV);
            this.grb_Congcu.Location = new System.Drawing.Point(482, 545);
            this.grb_Congcu.Name = "grb_Congcu";
            this.grb_Congcu.Size = new System.Drawing.Size(541, 80);
            this.grb_Congcu.TabIndex = 21;
            this.grb_Congcu.TabStop = false;
            this.grb_Congcu.Text = "Công cụ";
            // 
            // bnt_TaiLaiNV
            // 
            this.bnt_TaiLaiNV.Image = ((System.Drawing.Image)(resources.GetObject("bnt_TaiLaiNV.Image")));
            this.bnt_TaiLaiNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_TaiLaiNV.Location = new System.Drawing.Point(407, 26);
            this.bnt_TaiLaiNV.Name = "bnt_TaiLaiNV";
            this.bnt_TaiLaiNV.Size = new System.Drawing.Size(87, 34);
            this.bnt_TaiLaiNV.TabIndex = 15;
            this.bnt_TaiLaiNV.Text = "Tải lại";
            this.bnt_TaiLaiNV.UseVisualStyleBackColor = true;
            // 
            // bnt_Sua
            // 
            this.bnt_Sua.Image = ((System.Drawing.Image)(resources.GetObject("bnt_Sua.Image")));
            this.bnt_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_Sua.Location = new System.Drawing.Point(282, 26);
            this.bnt_Sua.Name = "bnt_Sua";
            this.bnt_Sua.Size = new System.Drawing.Size(92, 34);
            this.bnt_Sua.TabIndex = 14;
            this.bnt_Sua.Text = "Sửa";
            this.bnt_Sua.UseVisualStyleBackColor = true;
            // 
            // bnt_Xoa
            // 
            this.bnt_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("bnt_Xoa.Image")));
            this.bnt_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_Xoa.Location = new System.Drawing.Point(165, 26);
            this.bnt_Xoa.Name = "bnt_Xoa";
            this.bnt_Xoa.Size = new System.Drawing.Size(88, 34);
            this.bnt_Xoa.TabIndex = 13;
            this.bnt_Xoa.Text = "Xóa";
            this.bnt_Xoa.UseVisualStyleBackColor = true;
            // 
            // bnt_ThemNV
            // 
            this.bnt_ThemNV.Image = ((System.Drawing.Image)(resources.GetObject("bnt_ThemNV.Image")));
            this.bnt_ThemNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_ThemNV.Location = new System.Drawing.Point(40, 26);
            this.bnt_ThemNV.Name = "bnt_ThemNV";
            this.bnt_ThemNV.Size = new System.Drawing.Size(89, 34);
            this.bnt_ThemNV.TabIndex = 12;
            this.bnt_ThemNV.Text = "Thêm";
            this.bnt_ThemNV.UseVisualStyleBackColor = true;
            // 
            // bnt_Huy_Sua
            // 
            this.bnt_Huy_Sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bnt_Huy_Sua.Location = new System.Drawing.Point(490, 127);
            this.bnt_Huy_Sua.Name = "bnt_Huy_Sua";
            this.bnt_Huy_Sua.Size = new System.Drawing.Size(75, 23);
            this.bnt_Huy_Sua.TabIndex = 31;
            this.bnt_Huy_Sua.UseVisualStyleBackColor = false;
            // 
            // bnt_XacNhan_Sua
            // 
            this.bnt_XacNhan_Sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bnt_XacNhan_Sua.Location = new System.Drawing.Point(409, 127);
            this.bnt_XacNhan_Sua.Name = "bnt_XacNhan_Sua";
            this.bnt_XacNhan_Sua.Size = new System.Drawing.Size(75, 23);
            this.bnt_XacNhan_Sua.TabIndex = 30;
            this.bnt_XacNhan_Sua.UseVisualStyleBackColor = false;
            // 
            // bnt_Huy_Them
            // 
            this.bnt_Huy_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bnt_Huy_Them.Location = new System.Drawing.Point(490, 127);
            this.bnt_Huy_Them.Name = "bnt_Huy_Them";
            this.bnt_Huy_Them.Size = new System.Drawing.Size(75, 23);
            this.bnt_Huy_Them.TabIndex = 29;
            this.bnt_Huy_Them.UseVisualStyleBackColor = false;
            // 
            // bnt_XacNhan_Them
            // 
            this.bnt_XacNhan_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bnt_XacNhan_Them.Location = new System.Drawing.Point(409, 127);
            this.bnt_XacNhan_Them.Name = "bnt_XacNhan_Them";
            this.bnt_XacNhan_Them.Size = new System.Drawing.Size(75, 23);
            this.bnt_XacNhan_Them.TabIndex = 28;
            this.bnt_XacNhan_Them.UseVisualStyleBackColor = false;
            // 
            // txt_TenDangNhapNV
            // 
            this.txt_TenDangNhapNV.Location = new System.Drawing.Point(478, 32);
            this.txt_TenDangNhapNV.Name = "txt_TenDangNhapNV";
            this.txt_TenDangNhapNV.Size = new System.Drawing.Size(164, 20);
            this.txt_TenDangNhapNV.TabIndex = 27;
            // 
            // txt_MatKhauNV
            // 
            this.txt_MatKhauNV.Location = new System.Drawing.Point(728, 32);
            this.txt_MatKhauNV.Name = "txt_MatKhauNV";
            this.txt_MatKhauNV.Size = new System.Drawing.Size(164, 20);
            this.txt_MatKhauNV.TabIndex = 26;
            // 
            // txt_LuongNhanVien
            // 
            this.txt_LuongNhanVien.Location = new System.Drawing.Point(212, 69);
            this.txt_LuongNhanVien.Name = "txt_LuongNhanVien";
            this.txt_LuongNhanVien.Size = new System.Drawing.Size(164, 20);
            this.txt_LuongNhanVien.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Điện Thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Email";
            // 
            // txt_TenNhanVien
            // 
            this.txt_TenNhanVien.Location = new System.Drawing.Point(212, 32);
            this.txt_TenNhanVien.Name = "txt_TenNhanVien";
            this.txt_TenNhanVien.Size = new System.Drawing.Size(164, 20);
            this.txt_TenNhanVien.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên khách hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(670, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Mật khẩu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.bnt_Huy_Sua);
            this.groupBox1.Controls.Add(this.bnt_XacNhan_Sua);
            this.groupBox1.Controls.Add(this.bnt_Huy_Them);
            this.groupBox1.Controls.Add(this.bnt_XacNhan_Them);
            this.groupBox1.Controls.Add(this.txt_TenDangNhapNV);
            this.groupBox1.Controls.Add(this.txt_MatKhauNV);
            this.groupBox1.Controls.Add(this.txt_LuongNhanVien);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_TenNhanVien);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1022, 164);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(728, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 20);
            this.textBox2.TabIndex = 33;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(478, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tên đăng nhập";
            // 
            // datagv_NhanVien
            // 
            this.datagv_NhanVien.BackgroundColor = System.Drawing.Color.White;
            this.datagv_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagv_NhanVien.Location = new System.Drawing.Point(12, 173);
            this.datagv_NhanVien.Name = "datagv_NhanVien";
            this.datagv_NhanVien.Size = new System.Drawing.Size(1011, 369);
            this.datagv_NhanVien.TabIndex = 17;
            // 
            // Control_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grb_TimKiem);
            this.Controls.Add(this.grb_Congcu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.datagv_NhanVien);
            this.Name = "Control_KhachHang";
            this.Size = new System.Drawing.Size(1026, 628);
            this.grb_TimKiem.ResumeLayout(false);
            this.grb_TimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_TimKiem)).EndInit();
            this.grb_Congcu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagv_NhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_TimKiem;
        private System.Windows.Forms.PictureBox pic_TimKiem;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.GroupBox grb_Congcu;
        private System.Windows.Forms.Button bnt_TaiLaiNV;
        private System.Windows.Forms.Button bnt_Sua;
        private System.Windows.Forms.Button bnt_Xoa;
        private System.Windows.Forms.Button bnt_ThemNV;
        private System.Windows.Forms.Button bnt_Huy_Sua;
        private System.Windows.Forms.Button bnt_XacNhan_Sua;
        private System.Windows.Forms.Button bnt_Huy_Them;
        private System.Windows.Forms.Button bnt_XacNhan_Them;
        private System.Windows.Forms.TextBox txt_TenDangNhapNV;
        private System.Windows.Forms.TextBox txt_MatKhauNV;
        private System.Windows.Forms.TextBox txt_LuongNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_TenNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView datagv_NhanVien;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
