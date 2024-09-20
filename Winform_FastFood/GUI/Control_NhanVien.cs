using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class Control_NhanVien : UserControl
    {
        private readonly BLL_NhanVien _BLL_NhanVien;

        public Control_NhanVien()
        {
            InitializeComponent();
            _BLL_NhanVien = new BLL_NhanVien();
            GRV_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loaddata();
            

            bnt_ThemNV.Click += Bnt_ThemNV_Click;
            bnt_TaiLaiNV.Click += Bnt_TaiLaiNV_Click;
        }

       

        private void Bnt_TaiLaiNV_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void Bnt_ThemNV_Click(object sender, EventArgs e)
        {
            themnhanvien();
           
        }

        private void loaddata()
        {
            var danhsachnhanvien = _BLL_NhanVien.DanhSachNhanVien();
            GRV_NhanVien.DataSource = danhsachnhanvien;
        }

        private void themnhanvien()
        {
            var nv = new nhanvien();
            nv.TenNhanVien = txt_TenNhanVien.Text;
            nv.TenDangNhap = txt_TenDangNhapNV.Text;
            nv.MatKhau = txt_MatKhauNV.Text;
            nv.ChucVu = txt_ChucvuNV.Text;
            nv.Luong = int.Parse(txt_LuongNhanVien.Text);
            nv.Quyen = txt_PhanQuyenNV.Text;
            _BLL_NhanVien.them(nv);
            MessageBox.Show("Thêm thành công!");
            txt_TenNhanVien.Clear();
            txt_TenDangNhapNV.Clear();
            txt_MatKhauNV.Clear();
            txt_ChucvuNV.Clear();
            txt_LuongNhanVien.Clear();
            txt_PhanQuyenNV.Clear();
        }
    }
}
