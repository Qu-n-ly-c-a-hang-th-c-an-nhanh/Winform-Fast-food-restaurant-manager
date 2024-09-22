using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_TrangChu : Form
    {
        public frm_TrangChu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            bnt_Menu_NhanVien.Click += Bnt_Menu_NhanVien_Click;
            bnt_Menu_KhachHang.Click += Bnt_Menu_KhachHang_Click;
          
        }

        private void Bnt_Menu_KhachHang_Click(object sender, EventArgs e)
        {
            var control_khachhang = new Control_KhachHang();
            Panel_Body.Controls.Clear();
            Panel_Body.Controls.Add(control_khachhang);
            setcolor();
            bnt_Menu_KhachHang.BackColor = Color.White;
            
        }

        private void Bnt_Menu_NhanVien_Click(object sender, EventArgs e)
        {
            var control_nhanvien = new Control_NhanVien();
            Panel_Body.Controls.Clear();
            Panel_Body.Controls.Add(control_nhanvien);
            setcolor();
            bnt_Menu_NhanVien.BackColor = Color.White;
        }
        private void setcolor() {
            bnt_Menu_TrangChu.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_DanhMuc.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_ThucDon.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_HoaDon.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_KhachHang.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_TaiKhoan.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_DoanhThu.BackColor = Color.FromArgb(255, 250, 200);
            bnt_Menu_NhanVien.BackColor = Color.FromArgb(255, 250, 200);
        }
    }
}
