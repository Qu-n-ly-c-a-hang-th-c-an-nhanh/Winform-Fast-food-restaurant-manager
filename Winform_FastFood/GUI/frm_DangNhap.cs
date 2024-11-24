using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Linq;  // Đảm bảo bạn đã có thư viện này để sử dụng LINQ to SQL
using DTO; // Nếu bạn đang sử dụng lớp DTO cho nhân viên

namespace GUI
{
    public partial class frm_DangNhap : Form
    {
        
        public frm_DangNhap()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtMatKhau.UseSystemPasswordChar = true;
            bnt_DangNhap.Click += Bnt_DangNhap_Click;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
        }
        
        // Kiểm tra nếu người dùng muốn hiện thị mật khẩu hay không
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

        // Xử lý đăng nhập khi người dùng bấm nút Đăng Nhập
        private void Bnt_DangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;

            // Thực hiện đăng nhập thông qua LINQ to SQL trực tiếp
            using (var dbContext = new FastFoodDataContext()) // Tạo một instance của DataContext
            {
                // Tìm nhân viên trong cơ sở dữ liệu
                var nhanVien = dbContext.nhanviens
                                        .FirstOrDefault(nv => nv.TenDangNhap == tenDangNhap && nv.MatKhau == matKhau);

                // Kiểm tra nếu tìm thấy nhân viên
                if (nhanVien != null)
                {
                    // Nếu đăng nhập thành công, hiển thị tên nhân viên lên form trang chủ
                    MessageBox.Show($"Chào mừng {nhanVien.TenNhanVien} đã đăng nhập thành công!");

                    // Mở form trang chủ và chuyển qua màn hình chính, truyền thông tin nhân viên
                    var mainForm = new Home(nhanVien); // Truyền nhân viên vào form TrangChủ
                    mainForm.Show();
                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    // Nếu không tìm thấy nhân viên, thông báo lỗi
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }
        }

        // Sự kiện đóng form
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
