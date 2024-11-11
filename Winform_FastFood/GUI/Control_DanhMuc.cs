using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class Control_DanhMuc : UserControl
    {
        private readonly FastFoodDataContext db;
        public Control_DanhMuc()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (FastFoodDataContext db = new FastFoodDataContext())
            {
                // Lấy danh sách danh mục món ăn từ cơ sở dữ liệu
                var danhmuc = db.DanhMucMonAns.ToList();

                // Gán danh sách vào DataGridView
                datagv_danhmuc.DataSource = danhmuc;
            }
        }
        private void AddCategory(string tenDanhMuc)
        {
            using (FastFoodDataContext db = new FastFoodDataContext())
            {
                var newCategory = new DanhMucMonAn
                {
                    TenDanhMuc = tenDanhMuc
                };

                db.DanhMucMonAns.InsertOnSubmit(newCategory);
                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                LoadData(); // Tải lại dữ liệu
                MessageBox.Show("Thêm danh mục thành công!");
            }
        }

    }
}
