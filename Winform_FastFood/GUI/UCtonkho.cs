using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DTO;
namespace GUI
{
    public partial class UCtonkho : DevExpress.XtraEditors.XtraUserControl
    {
         readonly private FastFoodDataContext db;
        public UCtonkho()
        {
            db = new FastFoodDataContext();
            InitializeComponent();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadCT();
            LoadCT10();
            LoadCT7day();
            searchControl1.TextChanged += SearchControl1_TextChanged;
        }

        private void SearchControl1_TextChanged(object sender, EventArgs e)
        {
            LoadCT(searchControl1.Text);
        }

        private void LoadCT(string searchText = "")
        {
            // Lọc dữ liệu theo tên nguyên liệu khi có giá trị tìm kiếm
            var query = from tk in db.TonKhos
                        join nl in db.NguyenLieus on tk.MaNguyenLieu equals nl.MaNguyenLieu
                        where nl.TenNguyenLieu.Contains(searchText)  // Lọc theo tên nguyên liệu
                        select new
                        {
                            TenNguyenLieu = nl.TenNguyenLieu,
                            tk.SoLuong,
                            tk.NgayNhap
                        };

            // Cập nhật dữ liệu vào DataGridView
            dataGridView2.DataSource = query.ToList();

            // Cập nhật tiêu đề cột
            dataGridView2.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dataGridView2.Columns["SoLuong"].HeaderText = "Số Lượng";
            dataGridView2.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
        }
        private void LoadCT7day()
        {
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Truy vấn dữ liệu tồn kho từ bảng TonKho và kết hợp với bảng NguyenLieu để lấy tên nguyên liệu
            var query = from tk in db.TonKhos
                        join nl in db.NguyenLieus on tk.MaNguyenLieu equals nl.MaNguyenLieu
                        where tk.NgayNhap <= currentDate.AddDays(-7)  // Lọc các phiếu nhập từ hơn 7 ngày trước
                        && tk.SoLuong > 0  // Thêm điều kiện để chỉ lấy các nguyên liệu có số lượng > 0
                        select new
                        {
                            TenNguyenLieu = nl.TenNguyenLieu,  // Lấy tên nguyên liệu
                            tk.SoLuong,                        // Lấy số lượng tồn kho
                            tk.NgayNhap                        // Lấy ngày nhập
                        };

            // Đưa dữ liệu vào DataGridView
            dataGridView1.DataSource = query.ToList();

            // Tùy chọn: Cấu hình các cột nếu muốn
            dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";
            dataGridView1.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
        }

        private void LoadCT10()
        {
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Truy vấn dữ liệu tồn kho từ bảng TonKho và kết hợp với bảng NguyenLieu để lấy tên nguyên liệu
            var query = from tk in db.TonKhos
                        join nl in db.NguyenLieus on tk.MaNguyenLieu equals nl.MaNguyenLieu
                        where  tk.SoLuong < 10                           // Lọc những món có số lượng dưới 10
                        select new
                        {
                            TenNguyenLieu = nl.TenNguyenLieu,  // Lấy tên nguyên liệu
                            tk.SoLuong,                        // Lấy số lượng tồn kho
                            tk.NgayNhap                        // Lấy ngày nhập
                        };

            // Đưa dữ liệu vào DataGridView
            dataGridView3.DataSource = query.ToList();

            // Tùy chọn: Cấu hình các cột nếu muốn
            dataGridView3.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dataGridView3.Columns["SoLuong"].HeaderText = "Số Lượng";
            dataGridView3.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
        }


    }
}
