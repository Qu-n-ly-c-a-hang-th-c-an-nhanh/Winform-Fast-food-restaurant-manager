using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Control_ThucDon : UserControl
    {
        public Control_ThucDon()
        {
            InitializeComponent();
            LoadData();
            LoadComBoBox();
        }

        private void LoadComBoBox()
        {
            using (FastFoodDataContext db = new FastFoodDataContext())
            {
                var danhMucList = db.DanhMucMonAns
                                    .Select(d => new
                                    {
                                        MaDanhMuc = d.MaDanhMuc,
                                        TenDanhMuc = d.TenDanhMuc
                                    })
                                    .ToList();

                comboBox1.DataSource = danhMucList;
                comboBox1.DisplayMember = "TenDanhMuc";
                comboBox1.ValueMember = "MaDanhMuc";
            }
        }

        private void LoadData()
        {
            using (var db = new FastFoodDataContext())
            {
                var thucdon = from monAn in db.MonAns
                              join danhMuc in db.DanhMucMonAns
                              on monAn.MaDanhMuc equals danhMuc.MaDanhMuc
                              select new
                              {
                                  monAn.MaMonAn,
                                  monAn.TenMonAn,
                                  monAn.MoTa,
                                  monAn.Gia,
                                  TenDanhMuc = danhMuc.TenDanhMuc,
                                  monAn.HinhAnh
                              };

                dataGridView1.DataSource = thucdon.ToList();
            }
        }

        private void datagv_thucdon_Scroll(object sender, ScrollEventArgs e)
        {
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var SelectRow = dataGridView1.Rows[e.RowIndex];
            string tenmonan = SelectRow.Cells["TenMonAn"].Value.ToString();
            string mota = SelectRow.Cells["MoTa"].Value.ToString();
            string gia = SelectRow.Cells["Gia"].Value.ToString();
            string madanhmuc = SelectRow.Cells["TenDanhmuc"].Value.ToString();

            textBox1.Text = tenmonan;
            textBox2.Text = mota;
            textBox3.Text = gia;
            string imageFileName = SelectRow.Cells["HinhAnh"].Value.ToString();
 
            // Tạo đường dẫn đầy đủ từ thư mục gốc và tên ảnh
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageFileName);
            

            // Kiểm tra xem ảnh có tồn tại không
            if (File.Exists(imagePath))
            {
                try
                {
                   
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                    pictureBox1.Image = null;
                }
            }
            else
            {                 
                    pictureBox1.Image = null;                              
            }

            comboBox1.Text = madanhmuc;
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
                var monAn = new MonAn
                {
                    TenMonAn = textBox1.Text,
                    MoTa = textBox2.Text,
                    Gia = decimal.Parse(textBox3.Text),
                    MaDanhMuc = (int)comboBox1.SelectedValue,
                    HinhAnh = imagePath
                };

                db.MonAns.InsertOnSubmit(monAn);
                db.SubmitChanges();

                MessageBox.Show("Đã lưu món ăn thành công!");

                LoadData();
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

        private void bnt_Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectRow.Cells["MaMonAn"].Value);
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
                        var monAn = db.MonAns.FirstOrDefault(m => m.MaMonAn == id);
                        if (monAn != null)
                        {
                            db.MonAns.DeleteOnSubmit(monAn);
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var SelectRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(SelectRow.Cells["MaMonAn"].Value);

                string tenMonAn = textBox1.Text;
                string moTa = textBox2.Text;
                decimal gia;
                if (!decimal.TryParse(textBox3.Text, out gia))
                {
                    MessageBox.Show("Giá phải là số hợp lệ.");
                    return;
                }
                int maDanhMuc = (int)comboBox1.SelectedValue;
                string imagePath = this.imagePath;

                // Nếu không có ảnh mới, giữ ảnh cũ
                if (string.IsNullOrEmpty(imagePath))
                {
                    imagePath = SelectRow.Cells["HinhAnh"].Value.ToString();
                }

                using (var db = new FastFoodDataContext())
                {
                    var existingMonAn = db.MonAns.FirstOrDefault(m => m.MaMonAn == id);

                    if (existingMonAn != null)
                    {
                        existingMonAn.TenMonAn = tenMonAn;
                        existingMonAn.MoTa = moTa;
                        existingMonAn.Gia = gia;
                        existingMonAn.MaDanhMuc = maDanhMuc;
                        existingMonAn.HinhAnh = imagePath;

                        db.SubmitChanges();

                        MessageBox.Show("Cập nhật món ăn thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy món ăn cần cập nhật.");
                    }
                }

                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món ăn để sửa.");
            }
        }
    }
}
