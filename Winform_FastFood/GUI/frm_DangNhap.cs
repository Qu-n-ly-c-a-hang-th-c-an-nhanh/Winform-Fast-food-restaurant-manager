using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace GUI
{
    public partial class frm_DangNhap : Form
    { 
        private readonly BLL_DangNhap _BLL_DangNhap;
    
        public frm_DangNhap()
        {
            InitializeComponent();
            _BLL_DangNhap = new BLL_DangNhap();

            this.StartPosition = FormStartPosition.CenterScreen;
            txtMatKhau.UseSystemPasswordChar = true;
            bnt_DangNhap.Click += Bnt_DangNhap_Click;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void Bnt_DangNhap_Click(object sender, EventArgs e)
        {
            string TenDangNhap = txtTenDangNhap.Text;
            string MatKhau = txtMatKhau.Text;

            if (_BLL_DangNhap.XacThucDangNhap(TenDangNhap, MatKhau))
            {               
                var mainform = new frm_TrangChu();
                mainform.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
