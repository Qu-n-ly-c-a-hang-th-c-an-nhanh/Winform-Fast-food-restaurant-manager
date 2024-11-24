namespace GUI
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.container1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.QuanLy = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNkhachhang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Mnthucdon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNdanhmuc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Kho = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNphieunhap = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNphieuxuat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNtonkho = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNtaohoadon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNdoanhthu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MNdangxuat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.lb_tennv = new DevExpress.XtraBars.BarHeaderItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.title = new DevExpress.XtraBars.BarStaticItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.MNnhanvien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tieude = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // container1
            // 
            this.container1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container1.Location = new System.Drawing.Point(260, 36);
            this.container1.Name = "container1";
            this.container1.Size = new System.Drawing.Size(1038, 669);
            this.container1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.QuanLy,
            this.Kho,
            this.accordionControlElement3});
            this.accordionControl1.Location = new System.Drawing.Point(0, 36);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 669);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // QuanLy
            // 
            this.QuanLy.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.MNnhanvien,
            this.MNkhachhang,
            this.Mnthucdon,
            this.MNdanhmuc});
            this.QuanLy.Expanded = true;
            this.QuanLy.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Left),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.QuanLy.Name = "QuanLy";
            this.QuanLy.Text = "Quản lý";
            this.QuanLy.Click += new System.EventHandler(this.accordionControlElement1_Click);
            // 
            // MNkhachhang
            // 
            this.MNkhachhang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNkhachhang.ImageOptions.Image")));
            this.MNkhachhang.Name = "MNkhachhang";
            this.MNkhachhang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNkhachhang.Text = "Khách hàng";
            this.MNkhachhang.Click += new System.EventHandler(this.accordionControlElement5_Click);
            // 
            // Mnthucdon
            // 
            this.Mnthucdon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Mnthucdon.ImageOptions.Image")));
            this.Mnthucdon.Name = "Mnthucdon";
            this.Mnthucdon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Mnthucdon.Text = "Thực đơn";
            this.Mnthucdon.Click += new System.EventHandler(this.accordionControlElement6_Click);
            // 
            // MNdanhmuc
            // 
            this.MNdanhmuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNdanhmuc.ImageOptions.Image")));
            this.MNdanhmuc.Name = "MNdanhmuc";
            this.MNdanhmuc.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNdanhmuc.Text = "Danh mục";
            this.MNdanhmuc.Click += new System.EventHandler(this.accordionControlElement7_Click_1);
            // 
            // Kho
            // 
            this.Kho.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.MNphieunhap,
            this.MNphieuxuat,
            this.MNtonkho});
            this.Kho.Expanded = true;
            this.Kho.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.Kho.Name = "Kho";
            this.Kho.Text = "Kho ";
            // 
            // MNphieunhap
            // 
            this.MNphieunhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNphieunhap.ImageOptions.Image")));
            this.MNphieunhap.Name = "MNphieunhap";
            this.MNphieunhap.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNphieunhap.Text = "Phiếu xuất";
            this.MNphieunhap.Click += new System.EventHandler(this.MNphieunhap_Click);
            // 
            // MNphieuxuat
            // 
            this.MNphieuxuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNphieuxuat.ImageOptions.Image")));
            this.MNphieuxuat.Name = "MNphieuxuat";
            this.MNphieuxuat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNphieuxuat.Text = "Phiếu nhập";
            this.MNphieuxuat.Click += new System.EventHandler(this.MNphieuxuat_Click);
            // 
            // MNtonkho
            // 
            this.MNtonkho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNtonkho.ImageOptions.Image")));
            this.MNtonkho.Name = "MNtonkho";
            this.MNtonkho.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNtonkho.Text = "Tồn kho";
            this.MNtonkho.Click += new System.EventHandler(this.MNtonkho_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.MNtaohoadon,
            this.MNdoanhthu,
            this.MNdangxuat});
            this.accordionControlElement3.Expanded = true;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Hệ thống";
            // 
            // MNtaohoadon
            // 
            this.MNtaohoadon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNtaohoadon.ImageOptions.Image")));
            this.MNtaohoadon.Name = "MNtaohoadon";
            this.MNtaohoadon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNtaohoadon.Text = "Tạo hóa đơn";
            this.MNtaohoadon.Click += new System.EventHandler(this.accordionControlElement11_Click);
            // 
            // MNdoanhthu
            // 
            this.MNdoanhthu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNdoanhthu.ImageOptions.Image")));
            this.MNdoanhthu.Name = "MNdoanhthu";
            this.MNdoanhthu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNdoanhthu.Text = "Doanh thu";
            this.MNdoanhthu.Click += new System.EventHandler(this.accordionControlElement12_Click);
            // 
            // MNdangxuat
            // 
            this.MNdangxuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MNdangxuat.ImageOptions.Image")));
            this.MNdangxuat.Name = "MNdangxuat";
            this.MNdangxuat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNdangxuat.Text = "Đăng xuất";
            this.MNdangxuat.Click += new System.EventHandler(this.accordionControlElement13_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lb_tennv,
            this.barButtonItem1,
            this.title,
            this.tieude});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1298, 36);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.tieude);
            // 
            // lb_tennv
            // 
            this.lb_tennv.Id = 0;
            this.lb_tennv.Name = "lb_tennv";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // title
            // 
            this.title.Caption = "Home";
            this.title.Id = 2;
            this.title.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.title.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Blue;
            this.title.ItemAppearance.Normal.Options.UseFont = true;
            this.title.ItemAppearance.Normal.Options.UseForeColor = true;
            this.title.Name = "title";
            this.title.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.title_ItemClick);
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lb_tennv,
            this.barButtonItem1,
            this.title,
            this.tieude});
            this.fluentFormDefaultManager1.MaxItemId = 4;
            // 
            // MNnhanvien
            // 
            this.MNnhanvien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement4.ImageOptions.Image")));
            this.MNnhanvien.Name = "MNnhanvien";
            this.MNnhanvien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MNnhanvien.Text = "Nhân viên";
            this.MNnhanvien.Click += new System.EventHandler(this.accordionControlElement4_Click_1);
            // 
            // tieude
            // 
            this.tieude.Caption = "COMMAND";
            this.tieude.Id = 3;
            this.tieude.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tieude.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Blue;
            this.tieude.ItemAppearance.Disabled.Options.UseFont = true;
            this.tieude.ItemAppearance.Disabled.Options.UseForeColor = true;
            this.tieude.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tieude.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Blue;
            this.tieude.ItemAppearance.Normal.Options.UseFont = true;
            this.tieude.ItemAppearance.Normal.Options.UseForeColor = true;
            this.tieude.Name = "tieude";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 705);
            this.ControlContainer = this.container1;
            this.Controls.Add(this.container1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "Home";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FastFood Manager";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer container1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement QuanLy;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNkhachhang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Mnthucdon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Kho;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNphieunhap;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNphieuxuat;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNtonkho;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNtaohoadon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNdoanhthu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNdanhmuc;
        private DevExpress.XtraBars.BarHeaderItem lb_tennv;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNdangxuat;
        private DevExpress.XtraBars.BarStaticItem title;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MNnhanvien;
        private DevExpress.XtraBars.BarStaticItem tieude;
    }
}