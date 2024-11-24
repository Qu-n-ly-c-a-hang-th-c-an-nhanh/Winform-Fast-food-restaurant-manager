using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class Home : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private readonly nhanvien _nhanVien;
        public Home(nhanvien nhanVien)
        {
            InitializeComponent();
            _nhanVien = nhanVien;
            // this.WindowState = FormWindowState.Maximized;
            var hoadon = new UCmonan(_nhanVien);
            tieude.Caption = "Tạo hóa đơn";
            container1.Controls.Clear();
            container1.Controls.Add(hoadon);
            PhanQuyenTheoChucVu();
           
        }
        private void PhanQuyenTheoChucVu()
        {
            if (_nhanVien.ChucVu == "Nhân viên") // Kiểm tra nếu là nhân viên
            {
                MNnhanvien.Enabled = false;
                Mnthucdon.Enabled = false;
                MNdanhmuc.Enabled = false;
                MNdoanhthu.Enabled = false;


            }
            else if (_nhanVien.ChucVu == "Admin" || _nhanVien.ChucVu == "Quản lý") // Admin hoặc Quản lý
            {
                
            }
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            

        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            var khachhang = new Control_KhachHang();
            container1.Controls.Clear();
            container1.Controls.Add(khachhang);
            khachhang.Dock = DockStyle.Fill;
            tieude.Caption = "Quản lý khách hàng";
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            var thucdon = new Control_ThucDon();
            container1.Controls.Clear();
            container1.Controls.Add(thucdon);
            tieude.Caption = "Quản lý thực đơn";
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            var hoadon = new UCmonan(_nhanVien);
            container1.Controls.Clear();
            container1.Controls.Add(hoadon);


            tieude.Caption = "Tạo hóa đơn";
        }

        private void accordionControlElement7_Click_1(object sender, EventArgs e)
        {
            var danhmuc = new Control_DanhMuc();
            container1.Controls.Clear();
            container1.Controls.Add(danhmuc);
            tieude.Caption = "Quản lý danh mục";
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            //_nhanVien = null;
            this.Hide();
            var loginForm = new frm_DangNhap();
            loginForm.Show();
        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            var doanhthu = new Doanhthu();
            container1.Controls.Clear();
            container1.Controls.Add(doanhthu);
            tieude.Caption = "Báo cáo doanh thu";
        }

        private void title_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void MNphieuxuat_Click(object sender, EventArgs e)
        {
            var phieunhap = new UCphieunhap(_nhanVien);
            container1.Controls.Clear();
            container1.Controls.Add(phieunhap);
            tieude.Caption = "Thông tin phiếu nhập";
        }

        private void MNtonkho_Click(object sender, EventArgs e)
        {
            var tonkho = new UCtonkho();
            container1.Controls.Clear();
            container1.Controls.Add(tonkho);
            tieude.Caption = "Thông tin tồn kho";
        }

        private void MNphieunhap_Click(object sender, EventArgs e)
        {
            var phieuxuat = new UCphieuxuat(_nhanVien);
            container1.Controls.Clear();
            container1.Controls.Add(phieuxuat);
            tieude.Caption = "Thông tin phiếu xuất";
        }

        private void accordionControlElement4_Click_1(object sender, EventArgs e)
        {
            var nhanvien = new Control_NhanVien();
            container1.Controls.Clear();
            container1.Controls.Add(nhanvien);
            tieude.Caption = "Quản lý nhân viên";
        }
    }
}
