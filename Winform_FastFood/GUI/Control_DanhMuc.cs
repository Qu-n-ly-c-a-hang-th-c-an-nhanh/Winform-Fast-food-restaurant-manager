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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace GUI
{
    public partial class Control_DanhMuc : UserControl
    {
       // private readonly FastFoodDataContext db;
        public Control_DanhMuc()
        {
         
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (FastFoodDataContext db = new FastFoodDataContext())
            {
                var danhmuc = db.DanhMucMonAns.ToList();

                datagv_danhmuc.DataSource = danhmuc;
                datagv_danhmuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Thêm danh mục thành công!");
            }
        }
        private void datagv_danhmuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var SelectRow = datagv_danhmuc.Rows[e.RowIndex];
            string tendanhmuc = SelectRow.Cells["TenDanhmuc"].Value.ToString();

            textBox1.Text = tendanhmuc;
            string imageFileName = SelectRow.Cells["HinhAnh"].Value.ToString();

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageFileName);

            if (File.Exists(imagePath))
            {
                pictureBox1.Image = new Bitmap(imagePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh.");
                pictureBox1.Image = null;
            }
        }

        private string imagePath;

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);

                    imagePath = openFileDialog.FileName;
                }
            }
        }

        private void bnt_ThemNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Vui lòng chọn một ảnh trước khi lưu.");
                return;
            }

            using (var db = new FastFoodDataContext())
            {
                var danhMucMonAn = new DanhMucMonAn
                {
                    TenDanhMuc = textBox1.Text,
                    HinhAnh = imagePath
                };

                db.DanhMucMonAns.InsertOnSubmit(danhMucMonAn);
                db.SubmitChanges();

                MessageBox.Show("Đã lưu món ăn thành công!");

                LoadData();
            }
        }

        private void bnt_TaiLaiNV_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void bnt_Xoa_Click(object sender, EventArgs e)
        {
            if (datagv_danhmuc.SelectedRows.Count > 0)
            {
                var selectRow = datagv_danhmuc.SelectedRows[0];

                int id = Convert.ToInt32(selectRow.Cells["MaDanhMuc"].Value);
                string tenDanhMuc = selectRow.Cells["TenDanhMuc"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    string.Format("Bạn có chắc chắn muốn xóa danh mục món ăn '{0}' không?", tenDanhMuc),
                    "Xác nhận",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.OK)
                {
                    using (var db = new FastFoodDataContext())
                    {
                        var danhMucMonAn = db.DanhMucMonAns.FirstOrDefault(m => m.MaDanhMuc == id);
                        if (danhMucMonAn != null)
                        {
                            db.DanhMucMonAns.DeleteOnSubmit(danhMucMonAn);
                            db.SubmitChanges();

                            MessageBox.Show("Xóa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy danh mục món ăn cần xóa.");
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {

                }

                LoadData();
            }
        }

        private void bnt_Sua_Click(object sender, EventArgs e)
        {
            if (datagv_danhmuc.SelectedRows.Count > 0)
            {
                var SelectRow = datagv_danhmuc.SelectedRows[0];

                int id = Convert.ToInt32(SelectRow.Cells["MaDanhMuc"].Value);

                string tenDanhMuc = textBox1.Text;

                string imagePath = this.imagePath;

                if (string.IsNullOrEmpty(imagePath))
                {
                    imagePath = SelectRow.Cells["HinhAnh"].Value.ToString();
                }

                var danhMucMonAn = new DanhMucMonAn()
                {
                    MaDanhMuc = id,
                    TenDanhMuc = tenDanhMuc,
                    HinhAnh = imagePath,
                };

                using (var db = new FastFoodDataContext())
                {
                    var existingDanhMuc = db.DanhMucMonAns.FirstOrDefault(d => d.MaDanhMuc == id);

                    if (existingDanhMuc != null)
                    {
                        existingDanhMuc.TenDanhMuc = tenDanhMuc;
                        existingDanhMuc.HinhAnh = imagePath;

                        db.SubmitChanges();

                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy danh mục món ăn cần cập nhật.");
                    }
                }

                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một danh mục món ăn để sửa.");
            }
        }
    }
}
