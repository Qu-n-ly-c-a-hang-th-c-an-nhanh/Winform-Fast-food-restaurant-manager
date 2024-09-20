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
          
        }

        private void Bnt_Menu_NhanVien_Click(object sender, EventArgs e)
        {
            var control_nhanvien = new Control_NhanVien();
            Panel_Body.Controls.Clear();
            Panel_Body.Controls.Add(control_nhanvien);
            bnt_Menu_NhanVien.BackColor = Color.White;
        }
    }
}
