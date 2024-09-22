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
using System.Data.Linq;

namespace GUI
{
    public partial class Control_KhachHang : UserControl
    {
        private readonly BLL_KhachHang _BLL_KhachHang;

        public Control_KhachHang()
        {
            InitializeComponent();
            _BLL_KhachHang = new BLL_KhachHang();
            Setup();

            bnt_ThemNV.Click += Bnt_ThemNV_Click;
            bnt_Huy_Them.Click += Bnt_Huy_Them_Click;
            bnt_XacNhan_Them.Click += Bnt_XacNhan_Them_Click;

            bnt_Xoa.Click += Bnt_Xoa_Click;

            bnt_Sua.Click += Bnt_Sua_Click;
            bnt_Huy_Sua.Click += Bnt_Huy_Sua_Click;
            bnt_XacNhan_Sua.Click += Bnt_XacNhan_Sua_Click;

            bnt_TaiLaiNV.Click += Bnt_TaiLaiNV_Click;

            pic_TimKiem.Click += Pic_TimKiem_Click;

            datagv_NhanVien.CellClick += Datagv_NhanVien_CellClick;


        }

        private void Pic_TimKiem_Click(object sender, EventArgs e)
        {
            timkiem();
        }

        private void Bnt_TaiLaiNV_Click(object sender, EventArgs e)
        {
            loaddata();
            XoaTxt();
            txt_TimKiem.Text = "";
        }

        private void Bnt_XacNhan_Sua_Click(object sender, EventArgs e)
        {
            suakhachhang();
            grb_TimKiem.Enabled = true;
            grb_Congcu.Enabled = true;
            datagv_NhanVien.Enabled = true;
            Setup();
        }

        private void Bnt_Huy_Sua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn hủy không?",
            "Xác nhận",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
        );
            if (result == DialogResult.OK)
            {
                Setup();
                grb_TimKiem.Enabled = true;
                grb_Congcu.Enabled = true;
                datagv_NhanVien.Enabled = true;
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void Bnt_Sua_Click(object sender, EventArgs e)
        {
            HienTxt();
            grb_TimKiem.Enabled = false;
            grb_Congcu.Enabled = false;
            datagv_NhanVien.Enabled = false;
            bnt_XacNhan_Sua.Show();
            bnt_Huy_Sua.Show();
            bnt_Huy_Sua.Text = "Hủy";
            bnt_XacNhan_Sua.Text = "Xác nhận";
        }

        private void Bnt_Xoa_Click(object sender, EventArgs e)
        {
            xoakhachhang();
        }

        private void Datagv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var SelectRow = datagv_NhanVien.Rows[e.RowIndex];
                string tenkhachhang = SelectRow.Cells["TenKhachHang"].Value.ToString();
                string tendangnhap = SelectRow.Cells["TenDangNhap"].Value.ToString();
                string matkhau = SelectRow.Cells["MatKhau"].Value.ToString();
                string diachi = SelectRow.Cells["DiaChi"].Value.ToString();
                string dienthoai = SelectRow.Cells["DienThoai"].Value.ToString();
                string email = SelectRow.Cells["Email"].Value.ToString();

                txt_TenNhanVien.Text = tenkhachhang;
                txt_TenDangNhapNV.Text = tendangnhap;
                txt_MatKhauNV.Text = matkhau;
                textBox2.Text = diachi;
                txt_LuongNhanVien.Text = email;
                textBox1.Text = dienthoai;
            }
        }

        private void Bnt_XacNhan_Them_Click(object sender, EventArgs e)
        {
            themkhachhang();
            grb_TimKiem.Enabled = true;
            grb_Congcu.Enabled = true;
            datagv_NhanVien.Enabled = true;
            Setup();
        }

        private void Bnt_Huy_Them_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Bạn có chắc chắn muốn hủy không?",
           "Xác nhận",
           MessageBoxButtons.OKCancel,
           MessageBoxIcon.Question
       );
            if (result == DialogResult.OK)
            {
                Setup();
                grb_TimKiem.Enabled = true;
                grb_Congcu.Enabled = true;
                datagv_NhanVien.Enabled = true;
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }
        private void Bnt_ThemNV_Click(object sender, EventArgs e)
        {
            HienTxt();
            XoaTxt();
            grb_TimKiem.Enabled = false;
            grb_Congcu.Enabled = false;
            datagv_NhanVien.Enabled = false;
            bnt_XacNhan_Them.Show();
            bnt_Huy_Them.Show();
            bnt_Huy_Them.Text = "Hủy";
            bnt_XacNhan_Them.Text = "Xác nhận";
        }

        private void loaddata()
        {         
            var danhsachkhachhang = _BLL_KhachHang.DanhSachKhachHang();
            datagv_NhanVien.DataSource = danhsachkhachhang;
        }
        private void themkhachhang()
        {
            var kh = new KhachHang();
            kh.TenKhachHang = txt_TenNhanVien.Text;
            kh.TenDangNhap = txt_TenDangNhapNV.Text;
            kh.MatKhau = txt_MatKhauNV.Text;
            kh.DienThoai = textBox1.Text;
            kh.Email = txt_LuongNhanVien.Text;
            kh.DiaChi = textBox2.Text;
            _BLL_KhachHang.them(kh);
            MessageBox.Show("Thêm thành công!");
            loaddata();
        }
        private void xoakhachhang()
        {
            if (datagv_NhanVien.SelectedRows.Count > 0)
            {
                var SelectRow = datagv_NhanVien.SelectedRows[0];
                int id = Convert.ToInt32(SelectRow.Cells["MaKhachHang"].Value);
                string tenkhachhang = SelectRow.Cells["TenKhachHang"].Value.ToString();

                DialogResult result = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa {0} không?", tenkhachhang), "Xác nhận",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
               );
                if (result == DialogResult.OK)
                {
                    _BLL_KhachHang.xoa(id);
                    MessageBox.Show("Xóa thành công");
                }
                else if (result == DialogResult.Cancel)
                {
                }
                loaddata();
            }

        }
        private void suakhachhang()
        {
            if (datagv_NhanVien.SelectedRows.Count > 0)
            {
                var SelectRow = datagv_NhanVien.SelectedRows[0];
                int id = Convert.ToInt32(SelectRow.Cells["MaKhachHang"].Value);

                var kh = new KhachHang();
                kh.MaKhachHang = id;
                kh.TenKhachHang = txt_TenNhanVien.Text;
                kh.TenDangNhap = txt_TenDangNhapNV.Text;
                kh.MatKhau = txt_MatKhauNV.Text;
                kh.DienThoai = textBox1.Text;
                kh.Email = txt_LuongNhanVien.Text;
                kh.DiaChi = textBox2.Text;
                _BLL_KhachHang.sua(kh);
                loaddata();
                MessageBox.Show("Cập nhật thành công!");

            }


        }
        private void timkiem()
        {
            string tentimkiem = txt_TimKiem.Text.Trim();
            datagv_NhanVien.DataSource = _BLL_KhachHang.DanhSachTimKiem(tentimkiem);
        }
        private void AnTxt()
        {
            txt_TenNhanVien.ReadOnly = true;
            txt_TenDangNhapNV.ReadOnly = true;
            txt_MatKhauNV.ReadOnly = true;
            txt_LuongNhanVien.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
   
        }
        private void HienTxt()
        {
            txt_TenNhanVien.ReadOnly = false;
            txt_TenDangNhapNV.ReadOnly = false;
            txt_MatKhauNV.ReadOnly = false;
            txt_LuongNhanVien.ReadOnly = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
          
        }
        private void XoaTxt()
        {
            txt_TenNhanVien.Focus();
            txt_TenNhanVien.Text = "";
            txt_TenDangNhapNV.Text = "";
            txt_MatKhauNV.Text = "";
            txt_LuongNhanVien.Text = "";

        }
        private void Setup()
        {
            datagv_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AnTxt();
            loaddata();
          
            bnt_XacNhan_Them.Hide();
            bnt_Huy_Them.Hide();
            bnt_XacNhan_Sua.Hide();
            bnt_Huy_Sua.Hide();

        }

    }
}
