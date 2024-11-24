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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datagv_danhmuc = new System.Windows.Forms.DataGridView();
            this.grb_Congcu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagv_danhmuc)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_Congcu
            // 
            this.grb_Congcu.Controls.Add(this.bnt_TaiLaiNV);
            this.grb_Congcu.Controls.Add(this.bnt_Sua);
            this.grb_Congcu.Controls.Add(this.bnt_Xoa);
            this.grb_Congcu.Controls.Add(this.bnt_ThemNV);
            this.grb_Congcu.Location = new System.Drawing.Point(3, 37);
            this.grb_Congcu.Name = "grb_Congcu";
            this.grb_Congcu.Size = new System.Drawing.Size(662, 70);
            this.grb_Congcu.TabIndex = 25;
            this.grb_Congcu.TabStop = false;
            this.grb_Congcu.Text = "Công cụ";
            // 
            // bnt_TaiLaiNV
            // 
            this.bnt_TaiLaiNV.Image = ((System.Drawing.Image)(resources.GetObject("bnt_TaiLaiNV.Image")));
            this.bnt_TaiLaiNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_TaiLaiNV.Location = new System.Drawing.Point(460, 19);
            this.bnt_TaiLaiNV.Name = "bnt_TaiLaiNV";
            this.bnt_TaiLaiNV.Size = new System.Drawing.Size(87, 34);
            this.bnt_TaiLaiNV.TabIndex = 15;
            this.bnt_TaiLaiNV.Text = "Tải lại";
            this.bnt_TaiLaiNV.UseVisualStyleBackColor = true;
            this.bnt_TaiLaiNV.Click += new System.EventHandler(this.bnt_TaiLaiNV_Click);
            // 
            // bnt_Sua
            // 
            this.bnt_Sua.Image = ((System.Drawing.Image)(resources.GetObject("bnt_Sua.Image")));
            this.bnt_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_Sua.Location = new System.Drawing.Point(335, 19);
            this.bnt_Sua.Name = "bnt_Sua";
            this.bnt_Sua.Size = new System.Drawing.Size(92, 34);
            this.bnt_Sua.TabIndex = 14;
            this.bnt_Sua.Text = "Sửa";
            this.bnt_Sua.UseVisualStyleBackColor = true;
            this.bnt_Sua.Click += new System.EventHandler(this.bnt_Sua_Click);
            // 
            // bnt_Xoa
            // 
            this.bnt_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("bnt_Xoa.Image")));
            this.bnt_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_Xoa.Location = new System.Drawing.Point(218, 19);
            this.bnt_Xoa.Name = "bnt_Xoa";
            this.bnt_Xoa.Size = new System.Drawing.Size(88, 34);
            this.bnt_Xoa.TabIndex = 13;
            this.bnt_Xoa.Text = "Xóa";
            this.bnt_Xoa.UseVisualStyleBackColor = true;
            this.bnt_Xoa.Click += new System.EventHandler(this.bnt_Xoa_Click);
            // 
            // bnt_ThemNV
            // 
            this.bnt_ThemNV.Image = ((System.Drawing.Image)(resources.GetObject("bnt_ThemNV.Image")));
            this.bnt_ThemNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_ThemNV.Location = new System.Drawing.Point(93, 19);
            this.bnt_ThemNV.Name = "bnt_ThemNV";
            this.bnt_ThemNV.Size = new System.Drawing.Size(89, 34);
            this.bnt_ThemNV.TabIndex = 12;
            this.bnt_ThemNV.Text = "Thêm";
            this.bnt_ThemNV.UseVisualStyleBackColor = true;
            this.bnt_ThemNV.Click += new System.EventHandler(this.bnt_ThemNV_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(671, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 588);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin danh mục";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Chọn ảnh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(92, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ảnh";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên danh mục";
            // 
            // datagv_danhmuc
            // 
            this.datagv_danhmuc.BackgroundColor = System.Drawing.Color.White;
            this.datagv_danhmuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagv_danhmuc.Location = new System.Drawing.Point(3, 113);
            this.datagv_danhmuc.Name = "datagv_danhmuc";
            this.datagv_danhmuc.Size = new System.Drawing.Size(662, 512);
            this.datagv_danhmuc.TabIndex = 22;
            this.datagv_danhmuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagv_danhmuc_CellClick);
            // 
            // Control_DanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grb_Congcu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.datagv_danhmuc);
            this.Name = "Control_DanhMuc";
            this.Size = new System.Drawing.Size(1026, 628);
            this.grb_Congcu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagv_danhmuc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_Congcu;
        private System.Windows.Forms.Button bnt_TaiLaiNV;
        private System.Windows.Forms.Button bnt_Sua;
        private System.Windows.Forms.Button bnt_Xoa;
        private System.Windows.Forms.Button bnt_ThemNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView datagv_danhmuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
