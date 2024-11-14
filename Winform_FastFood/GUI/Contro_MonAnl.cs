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
using System.Data.Linq;
using System.IO;

namespace GUI
{
    public partial class Contro_MonAnl : UserControl
    {
        private readonly FastFoodDataContext db;
        private decimal totalAmount = 0;

        public Contro_MonAnl(nhanvien nhanVien)
        {
            db = new FastFoodDataContext();
            InitializeComponent();
            panel1.AutoScroll = true;
            loadmenu();
            lb_ngayin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lb_gio.Text = DateTime.Now.ToString("HH:mm:ss");
            SetTenNV(nhanVien);

            luu.Click += Luu_Click;
        }

        private void Luu_Click(object sender, EventArgs e)
        {
           SaveHoaDon();
         
        }

        public void SetTenNV(nhanvien nhanVien)
        {
            lb_tennv.Text = nhanVien.TenNhanVien;
        }
        private void loadmenu()
        {
            FastFoodDataContext db = new FastFoodDataContext();
            var danhmuc = db.DanhMucMonAns.ToList();

            Panel panneldanhmuc = new Panel();
            panneldanhmuc.AutoScroll = true;
            panneldanhmuc.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(panneldanhmuc, 0, 0);
            int buttonHeight = 80;
            int buttonWidth = 100;
            int spacing = 0;

            for (int i = 0; i < danhmuc.Count; i++)
            {
                Button b1 = new Button();
                b1.Text = danhmuc[i].TenDanhMuc;
                b1.Width = buttonWidth;
                b1.Font = new Font("Arial", 12, FontStyle.Italic);
                b1.ForeColor = Color.White;
         
                b1.Height = buttonHeight;
                b1.Location = new Point(1, i * (buttonHeight + spacing));

                string imagePath = danhmuc[i].HinhAnh; // Lấy đường dẫn hình ảnh từ danh mục
                if (!string.IsNullOrEmpty(imagePath))
                {
                    // Chuyển đổi đường dẫn tương đối thành đường dẫn tuyệt đối
                    string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);

                    try
                    {
                        // Kiểm tra xem file có tồn tại không
                        if (File.Exists(absolutePath))
                        {
                         

                            Image originalImage = Image.FromFile(absolutePath);
                            b1.Image = ResizeImage(originalImage, buttonWidth , buttonHeight );
                        }
                        else
                        {
                            // Gán hình ảnh mặc định nếu không tìm thấy
                            b1.Image = null; // Thay đổi tên hình ảnh mặc định cho phù hợp
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
                        b1.Image = null; // Gán hình ảnh mặc định
                    }
                }

                int index = i;
                b1.Click += (sender, e) => Button_Click(sender, e, danhmuc[index]);
                panneldanhmuc.Controls.Add(b1);
                LoadAllMonAn();

            }
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            // Thay đổi kích thước hình ảnh
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Cải thiện chất lượng hình ảnh
                g.DrawImage(img, 0, 0, width, height);
            }

            // Giảm độ sáng của hình ảnh
            b = (Bitmap)DarkenImage(b, 0.8f); // Chuyển đổi rõ ràng về Bitmap

            // Thêm lớp phủ màu tối
            using (Graphics g = Graphics.FromImage(b))
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(0, Color.White))) // Lớp phủ 50% trong suốt
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, b.Width, b.Height));
                }
            }

            return b;
        }
        private Image DarkenImage(Image img, float factor)
        {
            Bitmap darkened = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color originalColor = ((Bitmap)img).GetPixel(x, y);
                    int r = (int)(originalColor.R * factor);
                    int g = (int)(originalColor.G * factor);
                    int b = (int)(originalColor.B * factor);
                    darkened.SetPixel(x, y, Color.FromArgb(originalColor.A, r, g, b));
                }
            }
            return darkened;
        }
        private void LoadAllMonAn(string searchTerm = "")
        {
            // Xóa các điều khiển cũ trong cột 1
            for (int i = tableLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                if (tableLayoutPanel1.GetColumn(tableLayoutPanel1.Controls[i]) == 1)
                {
                    tableLayoutPanel1.Controls.RemoveAt(i);
                }
            }

            // Tạo TableLayoutPanel cho món ăn
            TableLayoutPanel monAnTable = new TableLayoutPanel();
            monAnTable.Dock = DockStyle.Fill; // Đặt dock để chiếm hết không gian
            monAnTable.RowCount = 2; // 2 hàng
            monAnTable.ColumnCount = 1; // 1 cột

            // Thêm hàng tìm kiếm vào hàng đầu
            CreateSearchBar(monAnTable);

            // Thêm một hàng trống để tạo khoảng cách
            monAnTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Hàng trống 30 pixel
            monAnTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Hàng cho món ăn

            // Lấy danh sách tất cả món ăn, có thể lọc theo searchTerm
            var monAnList = string.IsNullOrEmpty(searchTerm)
                ? db.MonAns.ToList()
                : db.MonAns.Where(m => m.TenMonAn.Contains(searchTerm)).ToList();

            int controlHeight = 100;
            int controlWidth = 120;

            // Tạo một panel để chứa các món ăn với cuộn
            Panel scrollPanel = new Panel();
            scrollPanel.AutoScroll = true; // Bật cuộn
            scrollPanel.Dock = DockStyle.Fill; // Chiếm hết không gian hàng

            // Tạo FlowLayoutPanel để chứa món ăn
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Top; // Đặt dock để chiếm hết không gian hàng
            flowPanel.AutoSize = true; // Cho phép tự động điều chỉnh kích thước

            // Thêm tất cả món ăn vào flowPanel
            foreach (var monAn in monAnList)
            {
                MonAnControl monAnControl = new MonAnControl(monAn);
                monAnControl.Size = new Size(controlWidth, controlHeight);

                // Đăng ký sự kiện khi nhấn vào món ăn
                monAnControl.MonAnClicked += (s, eventArgs) => MonAnControl_Click(s, eventArgs);
                flowPanel.Controls.Add(monAnControl); // Thêm món ăn vào flowPanel
            }

            // Thêm flowPanel vào scrollPanel
            scrollPanel.Controls.Add(flowPanel);

            // Thêm scrollPanel vào hàng thứ hai của monAnTable
            monAnTable.Controls.Add(scrollPanel, 0, 1); // Đặt vào hàng thứ hai (index 1)

            // Thêm monAnTable vào cột giữa của tableLayoutPanel1
            tableLayoutPanel1.Controls.Add(monAnTable, 1, 0); // Đặt vào hàng đầu tiên
        } 
        private void CreateSearchBar(TableLayoutPanel tableLayoutPanel)
        {
            // Tạo một panel cho thanh tìm kiếm
            Panel searchPanel = new Panel();
            searchPanel.Dock = DockStyle.Fill; // Đặt dock để chiếm hết không gian

            // Tạo TextBox cho tìm kiếm
            TextBox searchTextBox = new TextBox();
            searchTextBox.Dock = DockStyle.Fill; // Đặt dock để chiếm hết không gian


            // Tạo nút tìm kiếm
            Button searchButton = new Button();
            searchButton.Text = "Tìm kiếm";
            searchButton.Size = new Size(100, 30); // Kích thước nút
            searchButton.Dock = DockStyle.Right; // Đặt dock bên phải

            // Đăng ký sự kiện cho nút tìm kiếm
            searchButton.Click += (s, e) =>
            {
                string searchText = searchTextBox.Text;
                LoadAllMonAn(searchText); // Tìm kiếm theo từ khóa và tải lại danh sách
            };

            // Thêm TextBox và Button vào searchPanel
            searchPanel.Controls.Add(searchTextBox);
            searchPanel.Controls.Add(searchButton);

            // Thêm searchPanel vào hàng đầu của monAnTable
            tableLayoutPanel.Controls.Add(searchPanel, 0, 0); // Đặt vào hàng đầu tiên (index 0)
        }
        private void Button_Click(object sender, EventArgs e, DanhMucMonAn danhMuc)
        {
            // Xóa các điều khiển cũ trong cột 1
            for (int i = tableLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                if (tableLayoutPanel1.GetColumn(tableLayoutPanel1.Controls[i]) == 1)
                {
                    tableLayoutPanel1.Controls.RemoveAt(i);
                }
            }

            // Tạo TableLayoutPanel cho món ăn
            TableLayoutPanel monAnTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };

            // Thêm hàng tìm kiếm vào hàng đầu
            CreateSearchBar(monAnTable);

            // Thêm một hàng trống để tạo khoảng cách
            monAnTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Hàng trống 30 pixel
            monAnTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Hàng cho món ăn

            // Tạo Panel có khả năng cuộn
            Panel scrollPanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill // Chiếm hết không gian hàng
            };

            // Tạo FlowLayoutPanel để chứa món ăn
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top, // Đặt dock để chiếm hết không gian hàng
                AutoSize = true // Cho phép tự động điều chỉnh kích thước
            };

            // Lấy danh sách món ăn theo danh mục
            var monAnList = db.MonAns.Where(ma => ma.MaDanhMuc == danhMuc.MaDanhMuc).ToList();

            int controlHeight = 100;
            int controlWidth = 120;
            //int spacing = 10;

            // Thêm tất cả món ăn vào flowPanel
            foreach (var monAn in monAnList)
            {
                MonAnControl monAnControl = new MonAnControl(monAn)
                {
                    Size = new Size(controlWidth, controlHeight)
                };

                // Đăng ký sự kiện khi nhấn vào món ăn
                monAnControl.MonAnClicked += (s, eventArgs) => MonAnControl_Click(s, eventArgs);
                flowPanel.Controls.Add(monAnControl); // Thêm món ăn vào flowPanel
            }

            // Thêm flowPanel vào scrollPanel
            scrollPanel.Controls.Add(flowPanel);

            // Thêm scrollPanel vào hàng thứ hai của monAnTable
            monAnTable.Controls.Add(scrollPanel, 0, 1); // Đặt vào hàng thứ hai (index 1)

            // Thêm monAnTable vào cột giữa của tableLayoutPanel1
            tableLayoutPanel1.Controls.Add(monAnTable, 1, 0); // Đặt vào hàng đầu tiên
        }
        private void MonAnControl_Click(object sender, EventArgs eventArgs)
        {
            MonAnControl clickedControl = sender as MonAnControl;
            if (clickedControl != null)
            {
                var monAnData = clickedControl.MonAn;

                // Tạo TableLayoutPanel để chứa thông tin món ăn
                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Top,
                    ColumnCount = 4,
                    RowCount = 1,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                };

                // Đặt kiểu cho các cột
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130)); // Tên món
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));  // Số lượng
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70)); // Giá
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70)); // Tổng

                // Tạo các điều khiển cho món ăn
                Label nameLabel = new Label
                {
                    Text = monAnData.TenMonAn,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                };

                TextBox quantityTextBox = new TextBox
                {
                    Text = "1",
                    TextAlign = HorizontalAlignment.Center,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                };

                decimal price = monAnData.Gia.GetValueOrDefault();
                Label priceLabel = new Label
                {
                    Text = $"{price} VNĐ",
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleRight,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                };

                Label totalLabel = new Label
                {
                    Text = $"{price} VNĐ",
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleRight,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                };

                // Cập nhật tổng khi số lượng thay đổi
                quantityTextBox.TextChanged += (s, args) => UpdateTotal(quantityTextBox, price, totalLabel, tableLayoutPanel);

                // Thêm các điều khiển vào TableLayoutPanel
                tableLayoutPanel.Controls.Add(nameLabel, 0, 0); // Cột 1
                tableLayoutPanel.Controls.Add(quantityTextBox, 1, 0); // Cột 2
                tableLayoutPanel.Controls.Add(priceLabel, 2, 0); // Cột 3
                tableLayoutPanel.Controls.Add(totalLabel, 3, 0); // Cột 4

                // Tạo đường kẻ dưới mỗi hàng
                Panel separator = new Panel
                {
                    Height = 1,
                    Dock = DockStyle.Bottom,
                    BackColor = Color.Black
                };

                tableLayoutPanel.Controls.Add(separator, 0, 1);
                tableLayoutPanel.SetColumnSpan(separator, 4);

                // Thêm TableLayoutPanel vào panel chính
                panel1.Controls.Add(tableLayoutPanel);

                // Cập nhật tổng tiền ngay sau khi thêm món ăn
                UpdateOverallTotal();
            }
        }
        private void UpdateTotal(TextBox quantityTextBox, decimal price, Label totalLabel, TableLayoutPanel tableLayoutPanel)
        {
            if (int.TryParse(quantityTextBox.Text, out int quantity) && quantity >= 0)
            {
                decimal total = quantity * price;
                totalLabel.Text = $"{total} VNĐ"; // Cập nhật tổng cho món ăn
                UpdateOverallTotal(); // Cập nhật tổng tiền
                // Nếu số lượng bằng 0, xóa món ăn khỏi panel
                if (quantity == 0)
                {
                    panel1.Controls.Remove(tableLayoutPanel);
                   
                }
            }
            else
            {
                totalLabel.Text = "0 VNĐ"; // Nếu không hợp lệ, hiển thị 0
            }
        }
        private void UpdateOverallTotal()
        {
             totalAmount = 0; // Đặt lại tổng tiền

            foreach (Control control in panel1.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    var quantityTextBox = (TextBox)tableLayoutPanel.Controls[1]; // Số lượng
                    var priceLabel = (Label)tableLayoutPanel.Controls[2]; // Giá

                    if (decimal.TryParse(priceLabel.Text.Replace(" VNĐ", ""), out decimal price) &&
                        int.TryParse(quantityTextBox.Text, out int quantity))
                    {
                        totalAmount += quantity * price; // Cộng dồn vào tổng
                    }
                }
            }

            tongtien.Text = $" {totalAmount} VNĐ"; // Cập nhật label tổng tiền
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SaveHoaDon()
        {
            // Lấy thông tin từ giao diện người dùng
            string tenNhanVien = lb_tennv.Text;  // Tên nhân viên
            string ngayHoaDon = lb_ngayin.Text;    // Ngày hóa đơn
            string gioHoaDon = lb_gio.Text;      // Giờ hóa đơn
            decimal tongTien = totalAmount;      // Tổng tiền lấy từ biến totalAmount

            // Lấy Mã Nhân Viên từ tên nhân viên (giả sử đã có danh sách nhân viên trong cơ sở dữ liệu)
            var nhanVien = db.nhanviens.SingleOrDefault(nv => nv.TenNhanVien == tenNhanVien);

            if (nhanVien == null)
            {
                MessageBox.Show("Nhân viên không tồn tại.");
                return; // Nếu không tìm thấy nhân viên, thoát khỏi hàm
            }

            // Tạo đối tượng Hóa Đơn
            var hoaDon = new HoaDon
            {
                MaNhanVien = nhanVien.MaNhanVien,  // Mã nhân viên lấy từ cơ sở dữ liệu
                NgayHoaDon = DateTime.Parse(ngayHoaDon),  // Ngày hóa đơn (có thể chuyển từ string sang DateTime nếu cần)
                TongTien = tongTien,   // Tổng tiền hóa đơn
                TenNhanVien = tenNhanVien,  // Tên nhân viên
                ThoiGian = DateTime.Parse(gioHoaDon)  // Giờ hóa đơn
            };

            // Thêm hóa đơn vào cơ sở dữ liệu
            db.HoaDons.InsertOnSubmit(hoaDon);
            db.SubmitChanges(); // Lưu thay đổi vào database

            // Lấy mã hóa đơn đã lưu
            int maHoaDon = hoaDon.MaHoaDon;

            // Lưu chi tiết hóa đơn
            SaveChiTietHoaDon(maHoaDon);

            // Thông báo thành công
            MessageBox.Show("Hóa đơn đã được lưu thành công.");
        }

        private void SaveChiTietHoaDon(int maHoaDon)
        {
            // Lặp qua các món ăn trong panel1 (hoặc nơi bạn lưu các món ăn đã chọn)
            foreach (Control control in panel1.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    var quantityTextBox = (TextBox)tableLayoutPanel.Controls[1]; // Số lượng
                    var priceLabel = (Label)tableLayoutPanel.Controls[2]; // Giá
                    var nameLabel = (Label)tableLayoutPanel.Controls[0]; // Tên món ăn

                    if (decimal.TryParse(priceLabel.Text.Replace(" VNĐ", ""), out decimal price) &&
                        int.TryParse(quantityTextBox.Text, out int quantity))
                    {
                        // Tính tổng tiền cho món ăn
                        decimal thanhTien = quantity * price;

                        // Lấy mã món ăn từ tên món ăn (giả sử bạn đã có cơ sở dữ liệu các món ăn)
                        var monAn = db.MonAns.SingleOrDefault(m => m.TenMonAn == nameLabel.Text);

                        if (monAn != null)
                        {
                            // Tạo đối tượng chi tiết hóa đơn
                            var chiTietHoaDon = new ChiTietHoaDon
                            {
                                MaHoaDon = maHoaDon,       // Mã hóa đơn
                                MaMonAn = monAn.MaMonAn,   // Mã món ăn
                                SoLuong = quantity,        // Số lượng món ăn
                                Gia = price,               // Giá mỗi món ăn
                                ThanhTien = thanhTien      // Tổng tiền món ăn
                            };

                            // Thêm chi tiết hóa đơn vào cơ sở dữ liệu
                            db.ChiTietHoaDons.InsertOnSubmit(chiTietHoaDon);
                        }
                    }
                }
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }




    }
}
