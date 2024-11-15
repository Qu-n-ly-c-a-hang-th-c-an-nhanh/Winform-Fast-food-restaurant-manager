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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace GUI
{
    public partial class TrangChu : UserControl
    {
        public TrangChu()
        {
            InitializeComponent();
            LoadTopSellingData();
            bestsaler();
        }

        private void LoadTopSellingData()
        {
            using (var db = new FastFoodDataContext()) // Khởi tạo DataContext
            {
                // Truy vấn LINQ để lấy top 10 món ăn bán chạy
                var topSellingItems = (from cthd in db.ChiTietHoaDons
                                       group cthd by cthd.MaMonAn into g
                                       orderby g.Sum(cthd => cthd.SoLuong) descending
                                       select new
                                       {
                                           MaMonAn = g.Key,
                                           TongSoLuong = g.Sum(cthd => cthd.SoLuong) ?? 0 
                                       }).Take(10).ToList();

                // Tạo danh sách để chứa dữ liệu món ăn bán chạy
                List<MenuItem> items = new List<MenuItem>();

                // Duyệt qua kết quả và lấy thêm thông tin từ bảng Món ăn (MonAns)
                foreach (var item in topSellingItems)
                {
                    var menuItem = db.MonAns.FirstOrDefault(m => m.MaMonAn == item.MaMonAn);
                    if (menuItem != null)
                    {
                        items.Add(new MenuItem
                        {
                            Name = menuItem.TenMonAn,
                            Quantity = item.TongSoLuong
                        });
                    }
                }

                // Cập nhật biểu đồ
                UpdateChart(items);
            }
        }


        // Cập nhật biểu đồ với danh sách món ăn bán chạy
        private void UpdateChart(List<MenuItem> items)
        {
            // Xóa các chuỗi và khu vực đồ họa cũ
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Tạo mới khu vực đồ họa cho biểu đồ
            ChartArea chartArea = new ChartArea("ChartArea1");
            chart1.ChartAreas.Add(chartArea);

            // Tạo một chuỗi cho biểu đồ cột
            Series series = new Series("Món ăn")
            {
                ChartType = SeriesChartType.Column, // Loại biểu đồ cột
                IsValueShownAsLabel = true, // Hiển thị giá trị trên cột
                BorderWidth = 2 // Thêm đường viền cho cột
                
            };

            // Thêm dữ liệu vào chuỗi
            foreach (var item in items)
            {
                series.Points.AddXY(item.Name, item.Quantity);
            }

            // Thêm chuỗi vào biểu đồ
            chart1.Series.Add(series);

            // Cập nhật tiêu đề trục
            chartArea.AxisX.Title = "Món ăn";
            chartArea.AxisY.Title = "Số lượng bán";

            // Cập nhật các cấu hình trục nếu cần thiết
            chartArea.AxisX.Interval = 1; // Đảm bảo các giá trị trên trục X có khoảng cách phù hợp
            chartArea.AxisY.Interval = 5; // Tương tự cho trục Y

            chartArea.AxisX.MajorGrid.LineWidth = 0; 
            chartArea.AxisY.MajorGrid.LineWidth = 0;

            chartArea.AxisX.LineWidth = 0;
            chartArea.AxisY.LineWidth = 0;

            chartArea.AxisX.LabelStyle.Angle = 80;
        }
      
        private void bestsaler()
        {
            using (var db = new FastFoodDataContext()) // Khởi tạo DataContext
            {
                // Truy vấn LINQ để lấy món ăn bán chạy nhất trong tuần từ bảng HoaDon
                var bestSellingItem = (from cthd in db.ChiTietHoaDons
                                       join hd in db.HoaDons on cthd.MaHoaDon equals hd.MaHoaDon
                                       where hd.NgayHoaDon >= DateTime.Now.AddDays(-7)
                                       group cthd by cthd.MaMonAn into g
                                       orderby g.Sum(cthd => cthd.SoLuong) descending
                                       select new
                                       {
                                           MaMonAn = g.Key,
                                           TongSoLuong = g.Sum(cthd => cthd.SoLuong) ?? 0
                                       }).FirstOrDefault();

                // Lấy thông tin món ăn từ bảng MonAns nếu có
                var menuItem = bestSellingItem != null ? db.MonAns.FirstOrDefault(m => m.MaMonAn == bestSellingItem.MaMonAn) : null;

                // Cập nhật tên món ăn lên Label
                lb_tenp.Text = menuItem?.TenMonAn ?? "Không tìm thấy món ăn bán chạy nhất";

                // Cập nhật giá món ăn lên Label lb_gia
                lb_gia.Text = string.Format("Giá: {0:C}", menuItem?.Gia ?? 0);  // Nếu không có giá, hiển thị 0

                string imagePath = menuItem?.HinhAnh;
               
                    pic.Image = Image.FromFile(imagePath);  // Dùng đường dẫn file để tải hình ảnh
            }
        }
    }

    // Lớp đại diện cho món ăn bán chạy
    public class MenuItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

