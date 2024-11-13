namespace GUI
{
    partial class Control_ThucDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control_ThucDon));
            this.grb_Congcu = new System.Windows.Forms.GroupBox();
            this.bnt_TaiLaiNV = new System.Windows.Forms.Button();
            this.bnt_Sua = new System.Windows.Forms.Button();
            this.bnt_Xoa = new System.Windows.Forms.Button();
            this.bnt_ThemNV = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grb_Congcu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_Congcu
            // 
            this.grb_Congcu.Controls.Add(this.bnt_TaiLaiNV);
            this.grb_Congcu.Controls.Add(this.bnt_Sua);
            this.grb_Congcu.Controls.Add(this.bnt_Xoa);
            this.grb_Congcu.Controls.Add(this.bnt_ThemNV);
            this.grb_Congcu.Location = new System.Drawing.Point(11, 37);
            this.grb_Congcu.Name = "grb_Congcu";
            this.grb_Congcu.Size = new System.Drawing.Size(506, 70);
            this.grb_Congcu.TabIndex = 29;
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
            this.bnt_Sua.Click += new System.EventHandler(this.bnt_Sua_Click);
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
            this.bnt_Xoa.Click += new System.EventHandler(this.bnt_Xoa_Click);
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
            this.bnt_ThemNV.Click += new System.EventHandler(this.bnt_ThemNV_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(523, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 533);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin món ăn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(213, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Quản lý món ăn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(506, 464);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên món ăn";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 107);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(178, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mô tả";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 150);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(178, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ảnh";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(168, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Chọn ảnh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tên danh mục";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 333);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // Control_ThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grb_Congcu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Control_ThucDon";
            this.Size = new System.Drawing.Size(886, 586);
            this.grb_Congcu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
    }
}
