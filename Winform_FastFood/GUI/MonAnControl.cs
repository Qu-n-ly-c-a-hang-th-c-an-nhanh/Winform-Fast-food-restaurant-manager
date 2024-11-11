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
using System.IO;



namespace GUI
{

    public partial class MonAnControl : UserControl
    {
        public event EventHandler MonAnClicked;
        public MonAn MonAn { get; private set; }
        public MonAnControl(MonAn monAn)
        {
             FastFoodDataContext db = new FastFoodDataContext();
            InitializeComponent();
        
            MonAn = monAn;
            nameLabel.Text = monAn.TenMonAn;
            priceLabel.Text = monAn.Gia.ToString();

            // Chuyển đổi đường dẫn tương đối thành đường dẫn tuyệt đối
            string imagePath = monAn.HinhAnh; // Lấy đường dẫn tương đối từ monAn
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);

            // Kiểm tra xem file có tồn tại không
            if (File.Exists(absolutePath))
            {
                // Đọc file ảnh và gán vào PictureBox
                pictureBox1.Image = Image.FromFile(absolutePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Đặt chế độ hiển thị hình ảnh
            }
            else
            {
               
                // Có thể gán hình ảnh mặc định
                pictureBox1.Image = null; // Hoặc hình ảnh mặc định
            }

            pictureBox1.Click += PictureBox1_Click;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            MonAnClicked?.Invoke(this, EventArgs.Empty);
        }

      

    }
}
