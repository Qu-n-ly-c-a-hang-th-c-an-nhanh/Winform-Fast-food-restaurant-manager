namespace GUI
{
    partial class Control_DanhMuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control_DanhMuc));
            this.grb_Congcu = new System.Windows.Forms.GroupBox();
            this.bnt_TaiLaiNV = new System.Windows.Forms.Button();
            this.bnt_Sua = new System.Windows.Forms.Button();
            this.bnt_Xoa = new System.Windows.Forms.Button();
            this.bnt_ThemNV = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datagv_danhmuc = new System.Windows.Forms.DataGridView();
            this.grb_Congcu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagv_danhmuc)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_Congcu
            // 
            this.grb_Congcu.Controls.Add(this.bnt_TaiLaiNV);
            this.grb_Congcu.Controls.Add(this.bnt_Sua);
            this.grb_Congcu.Controls.Add(this.bnt_Xoa);
            this.grb_Congcu.Controls.Add(this.bnt_ThemNV);
            this.grb_Congcu.Location = new System.Drawing.Point(3, 42);
            this.grb_Congcu.Name = "grb_Congcu";
            this.grb_Congcu.Size = new System.Drawing.Size(506, 70);
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
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(515, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 530);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(270, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Quản lý thông tin nhân viên";
            // 
            // datagv_danhmuc
            // 
            this.datagv_danhmuc.BackgroundColor = System.Drawing.Color.White;
            this.datagv_danhmuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagv_danhmuc.Location = new System.Drawing.Point(3, 118);
            this.datagv_danhmuc.Name = "datagv_danhmuc";
            this.datagv_danhmuc.Size = new System.Drawing.Size(506, 465);
            this.datagv_danhmuc.TabIndex = 17;
            // 
            // Control_DanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grb_Congcu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagv_danhmuc);
            this.Name = "Control_DanhMuc";
            this.Size = new System.Drawing.Size(873, 586);
            this.grb_Congcu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagv_danhmuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grb_Congcu;
        private System.Windows.Forms.Button bnt_TaiLaiNV;
        private System.Windows.Forms.Button bnt_Sua;
        private System.Windows.Forms.Button bnt_Xoa;
        private System.Windows.Forms.Button bnt_ThemNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datagv_danhmuc;
    }
}
