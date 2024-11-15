using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class frm_TrangChu : Form
    {
        private nhanvien _nhanVien;
        public frm_TrangChu(nhanvien nhanVien)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _nhanVien = nhanVien;
            var trangchu  = new TrangChu();
            Panel_Body.Controls.Add(trangchu);
            settable();
            lb_tennv.Text = _nhanVien.TenNhanVien;
            bnt_Menu_NhanVien.Click += Bnt_Menu_NhanVien_Click;
            bnt_Menu_KhachHang.Click += Bnt_Menu_KhachHang_Click;
            bnt_Menu_ThucDon.Click += Bnt_Menu_ThucDon_Click;
            bnt_Menu_HoaDon.Click += Bnt_Menu_HoaDon_Click;
            bnt_Menu_ThucDon.Click += Bnt_Menu_ThucDon_Click1;
            bnt_Menu_TrangChu.Click += Bnt_Menu_TrangChu_Click;
            bnt_Menu_TrangChu.BackColor = Color.White;
            bnt_Menu_DoanhThu.Click += Bnt_Menu_DoanhThu_Click;
            bnt_Menu_DangXuat.Click += Bnt_Menu_DangXuat_Click;
            PhanQuyenTheoChucVu();
        }

        private void Bnt_Menu_DangXuat_Click(object sender, EventArgs e)
        {
            _nhanVien = null;  

            // Ẩn form trang chủ
            this.Hide();

            // Tạo và hiển thị lại form đăng nhập
            var loginForm = new frm_DangNhap();
            loginForm.Show();
        }

        private void PhanQuyenTheoChucVu()
        {
            if (_nhanVien.ChucVu == "Nhân viên") // Kiểm tra nếu là nhân viên
            {
                bnt_Menu_NhanVien.Enabled = false;
                bnt_Menu_DoanhThu.Enabled = false;
            }
            else if (_nhanVien.ChucVu == "Admin" || _nhanVien.ChucVu == "Quản lý") // Admin hoặc Quản lý
            {
                bnt_Menu_NhanVien.Enabled = true;
                bnt_Menu_DoanhThu.Enabled = true;
            }
        }
        private void Bnt_Menu_DoanhThu_Click(object sender, EventArgs e)
        {
            var doanhthu = new Doanhthu();
            Panel_Body.Controls.Clear();
            doanhthu.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(doanhthu);

            //************
            setcolor();
            bnt_Menu_DoanhThu.BackColor = Color.White;
        }

        private void Bnt_Menu_TrangChu_Click(object sender, EventArgs e)
        {
            var trangchu = new TrangChu();
            Panel_Body.Controls.Clear();
            trangchu.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(trangchu);

            //************
            setcolor();
            bnt_Menu_TrangChu.BackColor = Color.White;
        }

        private void Bnt_Menu_ThucDon_Click1(object sender, EventArgs e)
        {
            var control_thucdon = new Control_ThucDon();
            Panel_Body.Controls.Clear();
            control_thucdon.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(control_thucdon);

            //************
            setcolor();
            bnt_Menu_ThucDon.BackColor = Color.White;
        }

        private void Bnt_Menu_HoaDon_Click(object sender, EventArgs e)
        {
            var control_hoadon = new Contro_MonAnl(_nhanVien); 
            Panel_Body.Controls.Clear();
            control_hoadon.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(control_hoadon);

            //************
            setcolor();
            bnt_Menu_HoaDon.BackColor = Color.White;
        }

        private void settable() {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 1;

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150)); // 200px cho menu
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // Phần còn lại

           
            panel1.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(panel1, 0, 0); // Thêm vào cột 0

            // Tạo Panel_Body cho nội dung
            
            Panel_Body.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(Panel_Body, 1, 0); // Thêm vào cột 1

            // Thêm TableLayoutPanel vào Form
            this.Controls.Add(tableLayoutPanel);
        }
        private void Bnt_Menu_ThucDon_Click(object sender, EventArgs e)
        {
     
           
        }

        private void Bnt_Menu_KhachHang_Click(object sender, EventArgs e)
        {
            var control_khachhang = new Control_KhachHang();
            Panel_Body.Controls.Clear();
            control_khachhang.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(control_khachhang);
            //************
            setcolor();
            bnt_Menu_KhachHang.BackColor = Color.White;
            
        }
        private void Bnt_Menu_NhanVien_Click(object sender, EventArgs e)
        {
            var control_nhanvien = new Control_NhanVien();
            Panel_Body.Controls.Clear();
            control_nhanvien.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(control_nhanvien);
            //************
            setcolor();
            bnt_Menu_NhanVien.BackColor = Color.White;
        }
        private void setcolor() {
            bnt_Menu_TrangChu.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_DanhMuc.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_ThucDon.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_HoaDon.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_KhachHang.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_DangXuat.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_DoanhThu.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_NhanVien.BackColor = Color.FromArgb(255, 250, 200);
        }

        private void bnt_Menu_DanhMuc_Click(object sender, EventArgs e)
        {
            var control_Danhmuc = new Control_DanhMuc();
            Panel_Body.Controls.Clear();
            control_Danhmuc.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(control_Danhmuc);
            //************
            setcolor();
            bnt_Menu_DanhMuc.BackColor = Color.White;
        }

        private void bnt_Menu_ThucDon_Click_1(object sender, EventArgs e)
        {

        }
    }
}
