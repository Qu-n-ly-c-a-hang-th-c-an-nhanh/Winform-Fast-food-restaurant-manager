using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using DTO;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Drawing.Chart;

namespace GUI
{
    public partial class Doanhthu : UserControl
    {
        private readonly FastFoodDataContext db;

        public Doanhthu()
        {
            InitializeComponent();
            db = new FastFoodDataContext();
            LoadHoaDonData();
            hoadon.CellClick += Hoadon_CellClick;
            LoadYearData();
            LoadMonthData();
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb2.DropDownStyle = ComboBoxStyle.DropDownList;
            cb2.SelectedIndexChanged += Cb2_SelectedIndexChanged;
            button1.Click += Button1_Click;
            Tongdoanhthu();
            Tongsohoadon();
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        
        private void Button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void ExportToExcel()
        {
            try
            {
                // Lấy năm và tháng từ ComboBox cb1 và cb2
                int? selectedYear = cb1.SelectedItem as int?;
                int? selectedMonth = cb2.SelectedItem as int?;

                if (!selectedYear.HasValue || !selectedMonth.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn năm và tháng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lọc doanh thu theo năm và tháng đã chọn
                var doanhThuList = db.DoanhThus
                                     .Join(db.HoaDons, dt => dt.MaHoaDon, hd => hd.MaHoaDon, (dt, hd) => new { dt, hd })
                                     .Join(db.nhanviens, temp => temp.hd.MaNhanVien, nv => nv.MaNhanVien, (temp, nv) => new
                                     {
                                         ThoiGian = temp.dt.NgayGhiNhan,    // Thời gian ghi nhận
                                 TenNhanVien = nv.TenNhanVien,       // Tên nhân viên
                                 MaHoaDon = temp.dt.MaHoaDon,        // Mã hóa đơn
                                 TongTien = temp.dt.TongTien         // Tổng tiền
                             })
                                     .Where(x => x.ThoiGian.Value.Year == selectedYear.Value && x.ThoiGian.Value.Month == selectedMonth.Value) // Lọc theo năm và tháng
                                     .OrderBy(x => x.ThoiGian)           // Sắp xếp theo thời gian
                                     .ToList();

                decimal totalRevenue = doanhThuList.Sum(x => x.TongTien ?? 0);

                // Mở hộp thoại để chọn nơi lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string templateFilePath = @"D:\Winform-Fast-food-restaurant-manager\Winform_FastFood\GUI\bin\Debug\template.xlsx";

                    if (!File.Exists(templateFilePath))
                    {
                        MessageBox.Show("File template không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Mở file template mẫu
                    FileInfo templateFile = new FileInfo(templateFilePath);

                    // Tạo một file Excel mới từ template
                    using (var package = new ExcelPackage(templateFile))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        string existingText = worksheet.Cells["A1"].Text;

                        string newText = existingText + selectedMonth.Value.ToString("00") + "/" + selectedYear.Value.ToString();
                        worksheet.Cells["A1"].Value = newText;
                        int STT = 1;
                        int row = 6;

                        foreach (var item in doanhThuList)
                        {
                            // Cột STT
                            worksheet.Cells[row, 1].Value = STT++;

                            // Cột Thời gian (định dạng ngày giờ)
                            worksheet.Cells[row, 2].Value = item.ThoiGian?.ToString("dd/MM/yyyy HH:mm");

                            // Cột Tên Nhân Viên
                            worksheet.Cells[row, 3].Value = item.TenNhanVien;

                            // Cột Mã Hóa Đơn
                            worksheet.Cells[row, 4].Value = item.MaHoaDon;

                            // Cột Tổng Tiền (định dạng tiền tệ)
                            worksheet.Cells[row, 5].Value = item.TongTien?.ToString("N0");

                            row++;
                        }
                        worksheet.Cells["d3"].Value = totalRevenue.ToString("N0");

                       
                        // Tự động điều chỉnh độ rộng cột
                       // worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Lưu file Excel tại vị trí đã chọn
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));
                    }

                    // Thông báo thành công
                    MessageBox.Show("Đã xuất báo cáo doanh thu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDoanhThuTheoNhomSP(DateTime startDate, DateTime endDate)
        {
            try
            {
                // Lấy tất cả danh mục món ăn
                var danhMucMonAnList = db.DanhMucMonAns.ToList(); // Lấy tất cả danh mục món ăn

                // Tạo một danh sách để lưu kết quả
                var result = new List<dynamic>();

                foreach (var danhMuc in danhMucMonAnList)
                {
                    // Tính tổng doanh thu cho danh mục này
                    var doanhThu = db.MonAns
                                    .Where(m => m.MaDanhMuc == danhMuc.MaDanhMuc)
                                    .Join(db.ChiTietHoaDons, m => m.MaMonAn, ct => ct.MaMonAn, (m, ct) => new { ct, m })
                                    .Join(db.HoaDons, joined => joined.ct.MaHoaDon, h => h.MaHoaDon, (joined, h) => new { joined, h })
                                    .Where(x => x.h.ThoiGian >= startDate && x.h.ThoiGian <= endDate)
                                    .Sum(x => x.joined.ct.ThanhTien) ?? 0;  // Nếu không có doanh thu thì mặc định là 0

                    // Thêm danh mục và doanh thu vào kết quả
                    result.Add(new
                    {
                        TenDanhMuc = danhMuc.TenDanhMuc,
                        DoanhThu = doanhThu
                    });
                }

                // Hiển thị kết quả trên biểu đồ
                chart1.Series.Clear();
                var series = chart1.Series.Add("Nhóm sản phẩm");

                // Duyệt qua kết quả và thêm vào biểu đồ
                foreach (var item in result)
                {
                    series.Points.AddXY(item.TenDanhMuc, item.DoanhThu);
                }
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

                chart1.Invalidate(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải doanh thu theo nhóm sản phẩm: " + ex.Message);
            }
        }
        private void Tongsohoadon()
        {
            try
            {
                // Tính tổng số hóa đơn
                int totalInvoiceCount = db.HoaDons.Count();

                // Gán tổng số hóa đơn vào Label (ví dụ: labelTotalInvoiceCount)
                label6.Text = $"{totalInvoiceCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số hóa đơn: {ex.Message}");
            }
        }
        private void Tongdoanhthu()
        {
            try
            {
                decimal totalRevenue = db.DoanhThus.Sum(dt => dt.TongTien.GetValueOrDefault());
                label4.Text = $"{totalRevenue:N0} VNĐ"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng doanh thu: {ex.Message}");
            }
        }
        private void Cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? selectedYear = cb1.SelectedItem as int?;
            int? selectedMonth = cb2.SelectedItem as int?;
            if (selectedYear.HasValue && selectedMonth.HasValue)
            {
                Doanhthuthang(selectedYear.Value, selectedMonth.Value);
                Hoadontheothang(selectedYear.Value, selectedMonth.Value);
                DateTime startDate = new DateTime(selectedYear.Value, selectedMonth.Value, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);
                chart1.Series.Clear();
                LoadDoanhThuTheoNhomSP(startDate, endDate);               
            }
            else
            {
                // Thông báo hoặc xử lý khi không có giá trị hợp lệ cho năm hoặc tháng
                MessageBox.Show("Vui lòng chọn năm và tháng hợp lệ.");
            }
        }
        private void Hoadontheothang(int? selectedYear, int? selectedMonth)
        {
            try
            {
                int invoiceCountByMonth = db.HoaDons.Count(hd => hd.NgayHoaDon.Value.Year == selectedYear && hd.NgayHoaDon.Value.Month == selectedMonth);

               
                label10.Text = $"{invoiceCountByMonth}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính số hóa đơn theo tháng: {ex.Message}");
            }
        }
        private void Doanhthuthang(int? selectedYear, int? selectedMonth)
        {
            try
            {
                // Lọc doanh thu theo năm và tháng đã chọn
                var query = db.DoanhThus.AsQueryable();

                // Nếu có năm được chọn, lọc theo năm
                if (selectedYear.HasValue)
                {
                    query = query.Where(dt => dt.NgayGhiNhan.Value.Year == selectedYear.Value);
                }

                // Nếu có tháng được chọn, lọc theo tháng
                if (selectedMonth.HasValue)
                {
                    query = query.Where(dt => dt.NgayGhiNhan.Value.Month == selectedMonth.Value);
                }

                // Tính tổng doanh thu
                decimal totalRevenue = query.Sum(dt => dt.TongTien ?? 0);

                label9.Text = $" {totalRevenue.ToString("N0")} VNĐ";
            }
            catch (Exception )
            {
                label9.Text = "0";
                
            }
        }
        private void LoadYearData()
        {   
                var years = db.HoaDons
                    .Where(hd => hd.ThoiGian.HasValue) // Kiểm tra ThoiGian có giá trị không null
                    .Select(hd => hd.ThoiGian.Value.Year) // Lấy năm từ ThoiGian
                    .Distinct()  // Lấy các năm khác nhau
                    .OrderBy(year => year)  // Sắp xếp theo thứ tự năm
                    .ToList();

                cb1.DataSource = years;
        }      
        private void LoadMonthData()
        {
                var months = Enumerable.Range(1, 12).ToList();
                cb2.DataSource = months;
        }
        private void Hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  
            {
               
                int maHoaDon = Convert.ToInt32(hoadon.Rows[e.RowIndex].Cells["MaHoaDon"].Value);

                LoadChiTietHoaDon(maHoaDon);
            }
        }
        private void LoadHoaDonData()
        {
            try
            {
                // Truy vấn lấy cột MaHoaDon, ThoiGian, TongTien từ bảng HoaDons
                var hoaDonList = db.HoaDons.Select(hd => new
                {
                    ThoiGian = hd.ThoiGian,  
                    hd.TongTien,
                    hd.TenNhanVien,
                    hd.MaHoaDon
                    
                }).ToList();

                // Gán dữ liệu vào DataGridView
                hoadon.DataSource = hoaDonList;

                hoadon.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
                hoadon.Columns["ThoiGian"].HeaderText = "Thời Gian";
                hoadon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                hoadon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                // Định dạng cột Tổng Tiền là kiểu tiền tệ
                hoadon.Columns["TongTien"].DefaultCellStyle.Format = "C0"; // C0 là định dạng tiền tệ (VNĐ)

                // Định dạng cột Thời Gian (Thời gian có thể định dạng tùy ý, ví dụ: dd/MM/yyyy HH:mm:ss)
                hoadon.Columns["ThoiGian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; // Định dạng thời gian
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }
        private void LoadChiTietHoaDon(int maHoaDon)
        {
            try
            {
                // Truy vấn chi tiết hóa đơn từ bảng ChiTietHoaDons dựa trên MaHoaDon
                var chiTietHoaDonList = db.ChiTietHoaDons.Where(ct => ct.MaHoaDon == maHoaDon)
                                                      .Select(ct => new
                                                      {
                                                          TenMonAn = ct.MonAn.TenMonAn,  // Hiển thị tên món ăn
                                                          ct.SoLuong,
                                                          ct.Gia,
                                                          ThanhTien = ct.ThanhTien,
                                                          ct.MaMonAn,
                                                      }).ToList();

                // Gán dữ liệu vào DataGridView chitiet
                chitiet.DataSource = chiTietHoaDonList;

                // Thiết lập các tên cột cho dễ hiểu
                chitiet.Columns["MaMonAn"].HeaderText = "Mã Món Ăn";
                chitiet.Columns["TenMonAn"].HeaderText = "Tên Món Ăn";
                chitiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                chitiet.Columns["Gia"].HeaderText = "Giá";
                chitiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                // Định dạng cột Thành Tiền là kiểu tiền tệ
                chitiet.Columns["ThanhTien"].DefaultCellStyle.Format = "C0"; // C0 là định dạng tiền tệ (VNĐ)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}");
            }
        }
    }
}
