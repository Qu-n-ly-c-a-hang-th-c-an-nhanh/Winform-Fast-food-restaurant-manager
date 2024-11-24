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
            this.Dock = DockStyle.Fill;
            this.AutoSize = false;
            Setup();
           

            bnt_ThemNV.Click += Bnt_ThemNV_Click;
            bnt_XacNhan_Them.Click += Bnt_XacNhan_Them_Click;
            bnt_Huy_Them.Click += Bnt_Huy_Them_Click;

            bnt_Xoa.Click += Bnt_Xoa_Click;

            bnt_Sua.Click += Bnt_Sua_Click;
            bnt_XacNhan_Sua.Click += Bnt_XacNhan_Sua_Click;
            bnt_Huy_Sua.Click += Bnt_Huy_Sua_Click;

            pic_TimKiem.Click += Pic_TimKiem_Click;

            bnt_TaiLaiNV.Click += Bnt_TaiLaiNV_Click;

            datagv_NhanVien.CellClick += GRV_NhanVien_CellClick;                                  
        }

        private void Pic_TimKiem_Click(object sender, EventArgs e)
        {
            timkiem();
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

        private void Bnt_XacNhan_Sua_Click(object sender, EventArgs e)
        {
            suanhanvien();
            grb_TimKiem.Enabled = true;
            grb_Congcu.Enabled = true;
            datagv_NhanVien.Enabled = true;
            Setup();
        }

        private void Bnt_Xoa_Click(object sender, EventArgs e)
        {
            xoanhanvien();
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

        private void Bnt_XacNhan_Them_Click(object sender, EventArgs e)
        {
            themnhanvien();
            grb_TimKiem.Enabled = true;
            grb_Congcu.Enabled = true;
            datagv_NhanVien.Enabled = true;
            Setup();
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

        private void GRV_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                var SelectRow = datagv_NhanVien.Rows[e.RowIndex];               
                string tennhanvien = SelectRow.Cells["TenNhanVien"].Value.ToString();
                string tendangnhap = SelectRow.Cells["TenDangNhap"].Value.ToString();
                string matkhau = SelectRow.Cells["MatKhau"].Value.ToString();
                int luong = Convert.ToInt32(SelectRow.Cells["Luong"].Value);
                string chucvu = SelectRow.Cells["ChucVu"].Value.ToString();
                string phanquyen = SelectRow.Cells["Quyen"].Value.ToString();

                txt_TenNhanVien.Text = tennhanvien;
                txt_TenDangNhapNV.Text = tendangnhap;
                txt_MatKhauNV.Text = matkhau;
                txt_LuongNhanVien.Text = luong.ToString();             
                comboBox1.Text = phanquyen;
                comboBox2.Text = chucvu;
            }
        }

        private void Bnt_TaiLaiNV_Click(object sender, EventArgs e)
        {
            loaddata();
            XoaTxt();
            txt_TimKiem.Text = "";
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

        private void timkiem() {
            string tentimkiem = txt_TimKiem.Text.Trim();
            datagv_NhanVien.DataSource = _BLL_NhanVien.DanhSachTimKiem(tentimkiem);
        }
        private void loaddata()
        {
            var danhsachnhanvien = _BLL_NhanVien.DanhSachNhanVien();
            datagv_NhanVien.DataSource = danhsachnhanvien;
        }
        private void loadcomboboxChucvu()
        {
            var danhsachchucvu = _BLL_NhanVien.Danhsachchucvu();
            comboBox2.DataSource = danhsachchucvu;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void loadcomboboxQuyen()
        {
            var danhsachquyen = _BLL_NhanVien.DanhsachQuyen();
            comboBox1.DataSource = danhsachquyen;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void themnhanvien()
        {
            var nv = new nhanvien();
            nv.TenNhanVien = txt_TenNhanVien.Text;
            nv.TenDangNhap = txt_TenDangNhapNV.Text;
            nv.MatKhau = txt_MatKhauNV.Text;
            nv.ChucVu = comboBox2.SelectedItem.ToString();
            nv.Luong = int.Parse(txt_LuongNhanVien.Text);
            nv.Quyen = comboBox1.SelectedItem.ToString();
            _BLL_NhanVien.them(nv);
            MessageBox.Show("Thêm thành công!");
            loaddata();
        }
        private void xoanhanvien() {
            if (datagv_NhanVien.SelectedRows.Count > 0)
            {
                var SelectRow = datagv_NhanVien.SelectedRows[0];
                int id = Convert.ToInt32(SelectRow.Cells["MaNhanVien"].Value);
                string tennhanvien = SelectRow.Cells["TenNhanVien"].Value.ToString(); 
                
                DialogResult result = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa {0} không?",tennhanvien),"Xác nhận",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
               );
                if (result == DialogResult.OK)
                {
                    _BLL_NhanVien.xoa(id);
                    MessageBox.Show("Xóa thành công");
                }
                else if (result == DialogResult.Cancel)
                {
                }
                loaddata();
            }
          
        }
        private void suanhanvien() {
            if (datagv_NhanVien.SelectedRows.Count>0)
            {
                var SelectRow = datagv_NhanVien.SelectedRows[0];
                int id = Convert.ToInt32(SelectRow.Cells["MaNhanVien"].Value);

                var nv = new nhanvien();
                nv.MaNhanVien = id;
                nv.TenNhanVien = txt_TenNhanVien.Text;
                nv.TenDangNhap = txt_TenDangNhapNV.Text;
                nv.MatKhau = txt_MatKhauNV.Text;
                nv.ChucVu = comboBox2.SelectedItem.ToString();
                nv.Luong = int.Parse(txt_LuongNhanVien.Text);
                nv.Quyen = comboBox1.SelectedItem.ToString();
                _BLL_NhanVien.sua(nv);
                loaddata();
                MessageBox.Show("Cập nhật thành công!");
                
            }
           
        }
        private void AnTxt()
        {
            txt_TenNhanVien.ReadOnly = true;
            txt_TenDangNhapNV.ReadOnly = true;
            txt_MatKhauNV.ReadOnly = true;
            txt_LuongNhanVien.ReadOnly = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }
        private void HienTxt()
        {
            txt_TenNhanVien.ReadOnly = false;
            txt_TenDangNhapNV.ReadOnly = false;
            txt_MatKhauNV.ReadOnly = false;
            txt_LuongNhanVien.ReadOnly = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
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
            loadcomboboxChucvu();
            loadcomboboxQuyen();
            bnt_XacNhan_Them.Hide();
            bnt_Huy_Them.Hide();
            bnt_XacNhan_Sua.Hide();
            bnt_Huy_Sua.Hide();
        
        }

        private void Control_NhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
