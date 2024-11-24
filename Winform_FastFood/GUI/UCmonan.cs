using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DTO;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.Data.NetCompatibility.Extensions;

namespace GUI
{
    public partial class UCmonan : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly FastFoodDataContext db;
        private nhanvien nhanVien;
        public UCmonan(nhanvien nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
            db = new FastFoodDataContext();
            LoadMenuItems();  // Gọi phương thức để load danh mục món ăn
            LoadAllMonAn();
            InitializeDataGridView();
            lb_ngayin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lb_gio.Text = DateTime.Now.ToString("HH:mm:ss");
            lb_tennv.Text = nhanVien.TenNhanVien;
        }
        private void LoadAllMonAn()
        {
            // Lấy tất cả các món ăn từ cơ sở dữ liệu
            var allMonAn = db.MonAns.ToList();

            // Hiển thị tất cả món ăn lên giao diện (có thể là FlowLayoutPanel hoặc Panel)
            LoadMonAn(allMonAn);
        }
        private void LoadMonAnTheoDanhMuc(DanhMucMonAn danhMuc)
        {
       
            var monAnList = db.MonAns.Where(m => m.MaDanhMuc == danhMuc.MaDanhMuc).ToList();


            // Gọi hàm LoadMonAn để hiển thị các món ăn lên giao diện
            LoadMonAn(monAnList);
        }
        

        private void LoadMonAn(List<MonAn> results)
        {
            Body.Controls.Clear();
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Width = Body.Width,
                Height = Body.Height,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,  // Cho phép bọc thẻ xuống dòng nếu hết không gian
                Padding = new Padding(10)
            };

            // Duyệt qua danh sách món ăn và hiển thị trên FlowLayoutPanel dưới dạng thẻ
            foreach (var monAn in results)
            {
                // Kiểm tra nguyên liệu của món ăn
                bool isOutOfStock = CheckMonAnOutOfStock(monAn.MaMonAn);
                 // Hàm kiểm tra nguyên liệu

                // Tạo panel đại diện cho một thẻ
                Panel cardPanel = new Panel
                {
                    Width = 150,
                    Height = 250,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    BackColor = isOutOfStock ? Color.LightGray : Color.White // Thay đổi màu nền nếu hết hàng
                };

                // Tạo PictureBox để hiển thị ảnh món ăn
                PictureBox pictureBox = new PictureBox
                {
                    Width = 120,
                    Height = 120,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 0, 0, 10) // Margin giữa ảnh và tên món ăn
                };

                // Gán hình ảnh cho PictureBox
                if (!string.IsNullOrEmpty(monAn.HinhAnh))
                {
                    string imagePath = monAn.HinhAnh; // Đường dẫn tương đối từ cơ sở dữ liệu
                    string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);

                    try
                    {
                        if (File.Exists(absolutePath))
                        {
                            pictureBox.Image = Image.FromFile(absolutePath); // Gán ảnh vào PictureBox
                        }
                        else
                        {
                            pictureBox.Image = null; // Nếu không tìm thấy ảnh, gán null
                        }
                    }
                    catch (Exception)
                    {
                        pictureBox.Image = null; // Gán ảnh mặc định nếu có lỗi
                    }
                }

                // Tạo Label để hiển thị tên món ăn
                Label nameLabel = new Label
                {
                    Text = monAn.TenMonAn,
                    Width = 120,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 40
                };

                // Tạo Label để hiển thị giá
                Label priceLabel = new Label
                {
                    Text = $"{monAn.Gia} VND",
                    Width = 120,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    Dock = DockStyle.Bottom,
                    Height = 30
                };

                // Nếu món ăn hết hàng, thêm một nhãn "Hết hàng"
                if (isOutOfStock)
                {
                    Label outOfStockLabel = new Label
                    {
                        Text = "Hết hàng",
                        Width = 120,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };
                    cardPanel.Controls.Add(outOfStockLabel); // Thêm nhãn "Hết hàng" vào cardPanel
                }

                // Thêm các control vào cardPanel
                cardPanel.Controls.Add(pictureBox);
                cardPanel.Controls.Add(nameLabel);
                cardPanel.Controls.Add(priceLabel);

                // Nếu món ăn hết hàng, vô hiệu hóa sự kiện click
                if (isOutOfStock)
                {
                    cardPanel.Enabled = false; // Vô hiệu hóa thẻ
                    pictureBox.Enabled = false; // Vô hiệu hóa ảnh
                }
                else
                {
                    // Thêm sự kiện khi nhấn vào thẻ món ăn
                    cardPanel.Click += (sender, e) => ShowMonAnDetails(monAn);
                    pictureBox.Click += (sender, e) => ShowMonAnDetails(monAn);
                }

                // Thêm cardPanel vào FlowLayoutPanel
                flowPanel.Controls.Add(cardPanel);
            }

            // Thêm FlowLayoutPanel vào panneldanhmuc
            Body.Controls.Add(flowPanel);
        }

        // Hàm kiểm tra món ăn có đủ nguyên liệu không
        private bool CheckMonAnOutOfStock(int maMonAn)
        {
           
                // Sử dụng LINQ để kiểm tra xem món ăn có đủ nguyên liệu hay không
                var result = (from m in db.MonAns
                              join ctm in db.CongThucMonAns on m.MaMonAn equals ctm.MaMonAn
                              join tk in db.TonKhos on ctm.MaNguyenLieu equals tk.MaNguyenLieu
                              where m.MaMonAn == maMonAn
                              && (tk.SoLuong < ctm.SoLuongSuDung || tk.SoLuong == null)
                              select m).Any(); // Kiểm tra xem có món ăn nào không đủ nguyên liệu

                return result; // Nếu có món ăn không đủ nguyên liệu, trả về true
            
        }
       
        
        private void LoadMenuItems()
        {
            // Lấy danh mục món ăn từ cơ sở dữ liệu
            var danhMucMonAn = db.DanhMucMonAns.ToList();

            // Kiểm tra xem BarManager đã được khởi tạo chưa
            if (barManager1 == null)
            {
                MessageBox.Show("BarManager chưa được khởi tạo.");
                return;
            }

            // Tạo thanh Bar mới nếu cần thiết
            Bar bar = new Bar(barManager1, "Main Bar");
            barManager1.Bars.Add(bar);

            // Đảm bảo Bar được dàn đều trên thanh Bar
            bar.DockStyle = BarDockStyle.Top;

            // Duyệt qua danh mục món ăn và tạo các mục menu
            foreach (var item in danhMucMonAn)
            {
                // Tạo một mục menu cho từng danh mục món ăn
                BarButtonItem menuItem = new BarButtonItem(barManager1, item.TenDanhMuc);

                // Thêm sự kiện khi nhấn vào danh mục
                menuItem.ItemClick += (sender, e) => LoadMonAnTheoDanhMuc(item);

               // menuItem.Appearance.ForeColor = Color.Blue;   // Màu chữ (ví dụ: màu xanh)
                menuItem.Appearance.Font = new Font("Arial", 11, FontStyle.Bold); // Cỡ chữ và kiểu chữ

                // Thêm mục menu vào thanh Bar
                bar.AddItem(menuItem);

                // Thêm BarStaticItem để tạo khoảng cách đều cho các mục
                BarStaticItem staticItem = new BarStaticItem();
                staticItem.Caption = ""; // Ký tự ngăn cách, có thể để trống
                staticItem.Width = 30;    // Chỉnh chiều rộng của khoảng cách giữa các mục
                bar.AddItem(staticItem);
            }

            // Đảm bảo các mục sẽ dàn đều trên thanh Bar
            barManager1.Form = this.ParentForm; // Đảm bảo BarManager được liên kết với form
        }
        private void InitializeDataGridView()
        {
            // Kiểm tra nếu DataGridView chưa có cột, thêm cột vào
            if (dataGridViewHoaDon.Columns.Count == 0)
            {
                // Thêm các cột thông thường
                dataGridViewHoaDon.Columns.Add("TenMonAn", "Tên Món Ăn");
                dataGridViewHoaDon.Columns.Add("SoLuong", "Số Lượng");
                dataGridViewHoaDon.Columns.Add("Gia", "Giá");
                dataGridViewHoaDon.Columns.Add("TongTien", "Tổng Tiền");

                // Thiết lập cột "Số lượng" và "Giá" là kiểu số
                dataGridViewHoaDon.Columns["SoLuong"].ValueType = typeof(int);
                dataGridViewHoaDon.Columns["Gia"].ValueType = typeof(decimal);
                dataGridViewHoaDon.Columns["TongTien"].ValueType = typeof(decimal);

                // Không cho phép sửa các cột ngoài "Số Lượng"
                dataGridViewHoaDon.Columns["TenMonAn"].ReadOnly = true;
                dataGridViewHoaDon.Columns["Gia"].ReadOnly = true;
                dataGridViewHoaDon.Columns["TongTien"].ReadOnly = true;
            }
        }
        private void ShowMonAnDetails(MonAn monAn)
        {
           
            int rowIndex = dataGridViewHoaDon.Rows.Add(); // Thêm một dòng mới vào DataGridView

                // Lấy giá của món ăn
                decimal giaMonAn = monAn.Gia.GetValueOrDefault();

                // Điền dữ liệu vào các cột
                dataGridViewHoaDon.Rows[rowIndex].Cells["TenMonAn"].Value = monAn.TenMonAn;
                dataGridViewHoaDon.Rows[rowIndex].Cells["SoLuong"].Value = 1; // Mặc định là 1
                dataGridViewHoaDon.Rows[rowIndex].Cells["Gia"].Value = giaMonAn;
                dataGridViewHoaDon.Rows[rowIndex].Cells["TongTien"].Value = giaMonAn; // Tổng tiền = giá món * số lượng

                // Cập nhật tổng tiền của hóa đơn
                CapNhatTongTienHoaDon();
        }
        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = searchControl1.Text.Trim();  // Lấy từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(keyword))
            {
                // Tìm kiếm món ăn theo từ khóa
                SearchMonAn(keyword);
            }
            else
            {
                // Nếu không có từ khóa, hiển thị tất cả món ăn
                LoadAllMonAn();
            }
        }
        private void searchControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = searchControl1.Text.Trim(); // Lấy từ khóa tìm kiếm
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Thực hiện tìm kiếm khi nhấn Enter
                    SearchMonAn(keyword);
                }
                else
                {
                    // Nếu không có từ khóa, có thể hiển thị tất cả món ăn
                    LoadAllMonAn();
                }
            }
        }
        private void InitializeSearchControl()
        {
            searchControl1.KeyDown += searchControl1_KeyDown;
        }
        private void SearchMonAn(string keyword)
        {
            // Lọc danh sách món ăn theo từ khóa
            var results = db.MonAns
                            .Where(mon => mon.TenMonAn.Contains(keyword) || mon.MoTa.Contains(keyword))
                            .ToList();

            // Hiển thị kết quả tìm kiếm
            LoadMonAn(results);
        }
        private void dataGridViewHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng thay đổi giá trị trong cột "Số Lượng"
            if (e.ColumnIndex == dataGridViewHoaDon.Columns["SoLuong"].Index && e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dataGridViewHoaDon.Rows[e.RowIndex];

                // Lấy giá trị của cột "Số Lượng" và "Giá"
                int quantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal price = Convert.ToDecimal(row.Cells["Gia"].Value);

                if (quantity == 0)
                {
                    dataGridViewHoaDon.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    // Tính lại tổng tiền của món ăn
                    decimal total = quantity * price;
                    row.Cells["TongTien"].Value = total;

                    // Cập nhật tổng tiền của hóa đơn
                    CapNhatTongTienHoaDon();
                }

                // Cập nhật tổng tiền của hóa đơn
                CapNhatTongTienHoaDon();
            }
        }
        private void SaveHoaDon()
        {
            // Lấy thông tin từ giao diện người dùng
            string tenNhanVien = lb_tennv.Text;  // Tên nhân viên
            string ngayHoaDon = lb_ngayin.Text;    // Ngày hóa đơn
            string gioHoaDon = lb_gio.Text;      // Giờ hóa đơn
            decimal tongTien = CapNhatTongTienHoaDon();  // Cập nhật tổng tiền từ hàm tính toán tổng tiền trong hóa đơn

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
                NgayHoaDon = DateTime.Parse(ngayHoaDon),  // Ngày hóa đơn
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

            // Lưu doanh thu
            SaveDoanhThu(maHoaDon, tongTien);

            // Thông báo thành công
            //MessageBox.Show("Hóa đơn đã được lưu thành công.");
        }
        private void SaveChiTietHoaDon(int maHoaDon)
        {
            // Lặp qua các món ăn trong DataGridView (dataGridViewHoaDon)
            foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
            {
                if (row.IsNewRow) continue;  // Bỏ qua dòng mới (chưa có dữ liệu)

                var tenMonAn = row.Cells["TenMonAn"].Value.ToString();  // Lấy tên món ăn
                var gia = Convert.ToDecimal(row.Cells["Gia"].Value);  // Lấy giá
                var soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);  // Lấy số lượng
                var thanhTien = Convert.ToDecimal(row.Cells["TongTien"].Value);  // Tính tổng tiền

                // Lấy mã món ăn từ cơ sở dữ liệu
                var monAn = db.MonAns.SingleOrDefault(m => m.TenMonAn == tenMonAn);

                if (monAn != null)
                {
                    // Tạo đối tượng chi tiết hóa đơn
                    var chiTietHoaDon = new ChiTietHoaDon
                    {
                        MaHoaDon = maHoaDon,       // Mã hóa đơn
                        MaMonAn = monAn.MaMonAn,   // Mã món ăn
                        SoLuong = soLuong,         // Số lượng món ăn
                        Gia = gia,                 // Giá mỗi món ăn
                        ThanhTien = thanhTien      // Tổng tiền món ăn
                    };

                    // Thêm chi tiết hóa đơn vào cơ sở dữ liệu
                    db.ChiTietHoaDons.InsertOnSubmit(chiTietHoaDon);
                }
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }
        private void SaveDoanhThu(int maHoaDon, decimal tongTien)
        {
            // Tạo đối tượng DoanhThu
            var doanhThu = new DoanhThu
            {
                MaHoaDon = maHoaDon,        // Mã hóa đơn đã lưu
                NgayGhiNhan = DateTime.Now, // Ngày ghi nhận (ngày hiện tại)
                TongTien = tongTien,        // Tổng tiền từ hóa đơn
            };

            // Thêm doanh thu vào cơ sở dữ liệu
            db.DoanhThus.InsertOnSubmit(doanhThu);
            db.SubmitChanges(); // Lưu thay đổi vào database
        }
        private decimal CapNhatTongTienHoaDon()
        {
            decimal tongTien = 0;

            // Duyệt qua các dòng của DataGridView và tính tổng tiền
            foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
            {
                if (row.Cells["TongTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["TongTien"].Value);
                }
            }

            // Cập nhật Label hiển thị tổng tiền
            lbl_tongtien.Text = $"{tongTien} VNĐ";

            return tongTien;
        }
        //private void luu_Click(object sender, EventArgs e)
        //{
        //    SaveHoaDon();
        //    // Lặp qua các dòng trong dataGridViewHoaDon
        //    foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
        //    {
        //        if (row.IsNewRow) continue;  // Bỏ qua dòng mới (không có dữ liệu)

        //        var tenMonAn = row.Cells["TenMonAn"].Value?.ToString();  // Lấy tên món ăn
        //        var soLuongMonAn = Convert.ToInt32(row.Cells["SoLuong"].Value);  // Lấy số lượng món ăn

        //        // Thêm kiểm tra để xem giá trị lấy từ DataGridView
        //        Console.WriteLine($"Tên món ăn: {tenMonAn}, Số lượng: {soLuongMonAn}");

        //        if (string.IsNullOrEmpty(tenMonAn)) continue;  // Nếu tên món ăn là null hoặc rỗng thì bỏ qua

        //        // Lấy mã món ăn từ cơ sở dữ liệu
        //        var monAn = db.MonAns.SingleOrDefault(m => m.TenMonAn == tenMonAn);

        //        if (monAn != null)
        //        {
        //            // Lưu thông tin vào bảng XuatKho
        //            SaveXuatKho(monAn.MaMonAn, soLuongMonAn);

        //            // Sau khi lưu XuatKho, lấy mã xuất kho mới nhất
        //            var xuatKho = db.XuatKhos.OrderByDescending(xk => xk.NgayXuat).FirstOrDefault();
        //            if (xuatKho != null)
        //            {
        //                // Lưu chi tiết phiếu xuất
        //                SaveChiTietPhieuXuat(xuatKho.MaXuatKho, monAn.MaMonAn, soLuongMonAn);
        //            }
        //        }
        //        else
        //        {
        //            // Xử lý khi không tìm thấy món ăn trong cơ sở dữ liệu
        //            Console.WriteLine($"Không tìm thấy món ăn: {tenMonAn}");
        //        }
        //    }

        //    // Xóa dữ liệu trong dataGridViewHoaDon sau khi lưu
        //    dataGridViewHoaDon.Rows.Clear();
        //    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}




        //private void SaveXuatKho(int maMonAn, decimal soLuongMonAn)
        //{
        //    // Kiểm tra nếu số lượng món ăn <= 0, không cần xuất kho
        //    if (soLuongMonAn <= 0)
        //    {
        //        MessageBox.Show("Số lượng món ăn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // Kiểm tra công thức món ăn
        //    var congThucMonAn = db.CongThucMonAns.Where(ct => ct.MaMonAn == maMonAn).ToList();

        //    if (!congThucMonAn.Any())
        //    {
        //        MessageBox.Show($"Không tìm thấy công thức món ăn với mã {maMonAn}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // Tiến hành tính toán tổng tiền
        //    decimal tongTien = 0;
        //    foreach (var ct in congThucMonAn)
        //    {
        //        var nguyenLieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu == ct.MaNguyenLieu);
        //        if (nguyenLieu != null)
        //        {
        //            decimal donGia = nguyenLieu.GiaNhap.GetValueOrDefault();
        //            decimal soLuongSuDung = (decimal)(ct.SoLuongSuDung ?? 0) * soLuongMonAn;
        //            tongTien += soLuongSuDung * donGia;
        //        }
        //    }

        //    // Tạo đối tượng XuatKho
        //    var xuatKho = new XuatKho
        //    {
        //        MaNhanVien = 1,  // Mã nhân viên giả định
        //        NgayXuat = DateTime.Now,
        //        TongTien = tongTien
        //    };

        //    try
        //    {
        //        db.XuatKhos.InsertOnSubmit(xuatKho);
        //        db.SubmitChanges();
        //        // MessageBox.Show("Lưu phiếu xuất kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        // MessageBox.Show($"Lỗi khi lưu phiếu xuất kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        //private void SaveChiTietPhieuXuat(int maXuatKho, int maMonAn, decimal soLuongMonAn)
        //{
        //    // Kiểm tra nếu số lượng món ăn <= 0, không cần lưu chi tiết
        //    if (soLuongMonAn <= 0)
        //    {
        //        Console.WriteLine($"Số lượng món ăn không hợp lệ: {soLuongMonAn}");
        //        return;
        //    }

        //    // Lấy thông tin công thức món ăn từ cơ sở dữ liệu
        //    var congThucMonAn = db.CongThucMonAns.Where(ct => ct.MaMonAn == maMonAn).ToList();

        //    // Nếu không tìm thấy công thức món ăn, không thực hiện gì
        //    if (!congThucMonAn.Any())
        //    {
        //        Console.WriteLine($"Không tìm thấy công thức món ăn với mã {maMonAn}.");
        //        return;
        //    }

        //    // Lặp qua từng nguyên liệu trong công thức món ăn
        //    foreach (var ct in congThucMonAn)
        //    {
        //        // Lấy thông tin nguyên liệu từ cơ sở dữ liệu
        //        var nguyenLieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu == ct.MaNguyenLieu);

        //        if (nguyenLieu == null)
        //        {
        //            Console.WriteLine($"Không tìm thấy nguyên liệu có mã {ct.MaNguyenLieu}.");
        //            continue;
        //        }

        //        // Lấy giá nhập của nguyên liệu (GiaNhap là kiểu decimal? nullable)
        //        decimal donGia = nguyenLieu.GiaNhap.GetValueOrDefault();  // GiaNhap có thể null, trả về 0 nếu null

        //        // Tính số lượng nguyên liệu cần xuất kho
        //        decimal soLuongSuDung = (decimal)(ct.SoLuongSuDung ?? 0) * soLuongMonAn;  // Giữ nguyên kiểu decimal

        //        // Tính thành tiền
        //        decimal thanhTien = soLuongSuDung * donGia;

        //        // Tạo đối tượng ChiTietPhieuXuat
        //        var chiTietPhieuXuat = new ChiTietPhieuXuat
        //        {
        //            MaXuatKho = maXuatKho,  // Gán mã xuất kho từ bảng XuatKho
        //            MaNguyenLieu = ct.MaNguyenLieu,
        //            SoLuongXuat = soLuongSuDung,  // Lưu số lượng xuất kho dưới dạng decimal
        //            LydoXuat = "Bán món ăn",  // Lý do xuất kho, có thể thay đổi theo yêu cầu
        //            DonGia = donGia,
        //            ThanhTien = thanhTien
        //        };

        //        try
        //        {
        //            // Thêm vào cơ sở dữ liệu và lưu thông tin vào bảng ChiTietPhieuXuat
        //            db.ChiTietPhieuXuats.InsertOnSubmit(chiTietPhieuXuat);
        //            db.SubmitChanges();
        //            //Console.WriteLine("Lưu thành công chi tiết phiếu xuất.");
        //        }
        //        catch (Exception ex)
        //        {
        //            //Console.WriteLine($"Lỗi khi lưu chi tiết phiếu xuất: {ex.Message}");
        //        }
        //    }
        //}

        private void luu_Click(object sender, EventArgs e)
        {
            SaveHoaDon();

            decimal tongTien = 0;

            foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
            {
                if (row.IsNewRow) continue;  // Bỏ qua dòng mới (không có dữ liệu)

                var tenMonAn = row.Cells["TenMonAn"].Value?.ToString();
                var soLuongMonAn = Convert.ToInt32(row.Cells["SoLuong"].Value);

                if (string.IsNullOrEmpty(tenMonAn)) continue;

                var monAn = db.MonAns.SingleOrDefault(m => m.TenMonAn == tenMonAn);
                if (monAn != null)
                {
                    var congThucMonAn = db.CongThucMonAns.Where(ct => ct.MaMonAn == monAn.MaMonAn).ToList();
                    foreach (var ct in congThucMonAn)
                    {
                        var nguyenLieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu == ct.MaNguyenLieu);
                        if (nguyenLieu != null)
                        {
                            decimal donGia = nguyenLieu.GiaNhap.GetValueOrDefault();
                            decimal soLuongSuDung = (decimal)(ct.SoLuongSuDung ?? 0) * soLuongMonAn;
                            tongTien += soLuongSuDung * donGia;
                        }
                    }
                }
            }
            int maNhanVien = nhanVien.MaNhanVien;
            var xuatKho = new XuatKho
            {
                MaNhanVien = maNhanVien,  // Giả định mã nhân viên
                NgayXuat = DateTime.Now,
                TongTien = tongTien
            };

            try
            {
                db.XuatKhos.InsertOnSubmit(xuatKho);
                db.SubmitChanges();

                // Lấy MaXuatKho của phiếu xuất kho mới tạo
                int maXuatKho = xuatKho.MaXuatKho;  // MaXuatKho sẽ được tự động gán sau khi Insert

                foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
                {
                    if (row.IsNewRow) continue;

                    var tenMonAn = row.Cells["TenMonAn"].Value?.ToString();
                    var soLuongMonAn = Convert.ToInt32(row.Cells["SoLuong"].Value);

                    if (string.IsNullOrEmpty(tenMonAn)) continue;

                    var monAn = db.MonAns.SingleOrDefault(m => m.TenMonAn == tenMonAn);
                    if (monAn != null)
                    {
                        // Lưu chi tiết phiếu xuất cho món ăn vào phiếu xuất kho
                        SaveChiTietPhieuXuat(maXuatKho, monAn.MaMonAn, soLuongMonAn);
                    }
                }
                UpdateTonKho(maXuatKho);

                // Xóa dữ liệu trong dataGridViewHoaDon sau khi lưu
                dataGridViewHoaDon.Rows.Clear();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu xuất kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveChiTietPhieuXuat(int maXuatKho, int maMonAn, decimal soLuongMonAn)
        {
            if (soLuongMonAn <= 0)
            {
                Console.WriteLine($"Số lượng món ăn không hợp lệ: {soLuongMonAn}");
                return;
            }

            var congThucMonAn = db.CongThucMonAns.Where(ct => ct.MaMonAn == maMonAn).ToList();
            if (!congThucMonAn.Any())
            {
                Console.WriteLine($"Không tìm thấy công thức món ăn với mã {maMonAn}.");
                return;
            }

            foreach (var ct in congThucMonAn)
            {
                var nguyenLieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu == ct.MaNguyenLieu);

                if (nguyenLieu == null)
                {
                    Console.WriteLine($"Không tìm thấy nguyên liệu có mã {ct.MaNguyenLieu}.");
                    continue;
                }

                decimal donGia = nguyenLieu.GiaNhap.GetValueOrDefault();
                decimal soLuongSuDung = (decimal)(ct.SoLuongSuDung ?? 0) * soLuongMonAn;
                decimal thanhTien = soLuongSuDung * donGia;

                var chiTietPhieuXuat = new ChiTietPhieuXuat
                {
                    MaXuatKho = maXuatKho,
                    MaNguyenLieu = ct.MaNguyenLieu,
                    SoLuongXuat = soLuongSuDung,
                    LydoXuat = "Bán món ăn",
                    DonGia = donGia,
                    ThanhTien = thanhTien
                };

                try
                {
                    db.ChiTietPhieuXuats.InsertOnSubmit(chiTietPhieuXuat);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu chi tiết phiếu xuất: {ex.Message}");
                }
            }
        }
        private void UpdateTonKho(int maXuatKho)
        {
            // Lấy danh sách chi tiết phiếu xuất đã được lưu
            var chiTietXuat = db.ChiTietPhieuXuats.Where(ct => ct.MaXuatKho == maXuatKho).ToList();

            foreach (var chiTiet in chiTietXuat)
            {
                var tonKho = db.TonKhos.SingleOrDefault(tk => tk.MaNguyenLieu == chiTiet.MaNguyenLieu);
                if (tonKho != null)
                {
                    // Kiểm tra tồn kho hiện tại có đủ để xuất không
                    if (tonKho.SoLuong >= chiTiet.SoLuongXuat)
                    {
                        // Nếu có đủ tồn kho, trừ đi số lượng đã xuất
                        tonKho.SoLuong -= (int?)Math.Round((decimal)(chiTiet.SoLuongXuat ?? 0));
                    }
                    else
                    {
                        // Nếu không đủ tồn kho, đặt tồn kho về 0
                        tonKho.SoLuong = 0;
                    }
                    // Cập nhật lại số lượng tồn kho
                    db.SubmitChanges();
                }
                else
                {
                    // Nếu không tồn tại bản ghi tồn kho cho nguyên liệu, có thể thông báo lỗi hoặc bỏ qua
                    Console.WriteLine($"Không tìm thấy thông tin tồn kho cho nguyên liệu có mã {chiTiet.MaNguyenLieu}.");
                }
            }
        }

    }
}
