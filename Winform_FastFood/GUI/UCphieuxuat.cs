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
    public partial class UCphieuxuat : DevExpress.XtraEditors.XtraUserControl
    {
        readonly private FastFoodDataContext db;
        private nhanvien _nhanVien;

        public UCphieuxuat(nhanvien nhanVien)
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _nhanVien = nhanVien;
            db = new FastFoodDataContext();
            LoadCT();
            LoadCT7day();
            CotThemCheckBox();
            searchControl1.TextChanged += SearchControl1_TextChanged;
            button2.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }
        private void SearchControl1_TextChanged(object sender, EventArgs e)
        {
            LoadCT(searchControl1.Text);
        }
        private void CotThemCheckBox()
        {
            DataGridViewCheckBoxColumn cotCheckBox = new DataGridViewCheckBoxColumn();
            cotCheckBox.HeaderText = "Thêm";
            cotCheckBox.Name = "them";
            cotCheckBox.Width = 50;
            dataGridView1.Columns.Insert(0, cotCheckBox);
        }
        private void LoadCT7day()
        {
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Truy vấn dữ liệu tồn kho từ bảng TonKho và kết hợp với bảng NguyenLieu để lấy tên nguyên liệu
            var query = from tk in db.TonKhos
                        join nl in db.NguyenLieus on tk.MaNguyenLieu equals nl.MaNguyenLieu
                        where tk.NgayNhap <= currentDate.AddDays(-7) // Lọc các phiếu nhập từ hơn 7 ngày trước
                        && tk.SoLuong > 0 // Chỉ lấy các nguyên liệu có số lượng > 0
                        select new
                        {
                            TenNguyenLieu = nl.TenNguyenLieu,  // Lấy tên nguyên liệu
                            tk.SoLuong,                        // Lấy số lượng tồn kho
                            tk.NgayNhap                        // Lấy ngày nhập
                        };

            // Đưa dữ liệu vào DataGridView
            dataGridView4.DataSource = query.ToList();

            // Tùy chọn: Cấu hình các cột nếu muốn
            dataGridView4.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dataGridView4.Columns["SoLuong"].HeaderText = "Số Lượng";
            dataGridView4.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các DateTimePicker
            DateTime startDate = dateTimePicker1.Value.Date;  // Chọn ngày bắt đầu
            DateTime endDate = dateTimePicker2.Value.Date;    // Chọn ngày kết thúc

            // Đảm bảo rằng endDate phải là cuối ngày
            endDate = endDate.AddDays(1).AddSeconds(-1); // Chuyển ngày kết thúc thành cuối ngày (23:59:59)

            try
            {
                // Lọc dữ liệu từ cơ sở dữ liệu hoặc từ danh sách theo ngày
                var query = from XuatKho in db.XuatKhos
                            join nhanVien in db.nhanviens on XuatKho.MaNhanVien equals nhanVien.MaNhanVien
                            where XuatKho.NgayXuat >= startDate && XuatKho.NgayXuat <= endDate
                            select new
                            {
                                MaXuatKho = XuatKho.MaXuatKho,
                                Ngayxuat = XuatKho.NgayXuat,
                                TenNhanVien = nhanVien.TenNhanVien,
                                TongTien = XuatKho.TongTien
                            };

                // Tạo DataTable để chứa dữ liệu đã lọc
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã xuất kho");
                dataTable.Columns.Add("Ngày xuất");
                dataTable.Columns.Add("Tên nhân viên");
                dataTable.Columns.Add("Tổng tiền");

                // Thêm dữ liệu vào DataTable
                foreach (var item in query)
                {
                    dataTable.Rows.Add(item.MaXuatKho, item.Ngayxuat, item.TenNhanVien, item.TongTien);
                }

                // Cập nhật dataGridView2 với dữ liệu đã lọc
                dataGridView2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc hóa đơn: " + ex.Message);
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                // Lấy MaNhapKho từ cột "Mã nhập kho" của hàng được chọn
                int maXuatKho = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["Mã xuất kho"].Value);

                // Gọi hàm để tải chi tiết phiếu nhập tương ứng vào dataGridView3
                LoadChiTietPhieuXuat(maXuatKho);
            }
        }
        private void LoadChiTietPhieuXuat(int maXuatKho)
        {
            try
            {
                // Truy vấn chi tiết phiếu nhập dựa trên MaNhapKho
                var query = from chiTiet in db.ChiTietPhieuXuats
                            join nguyenLieu in db.NguyenLieus on chiTiet.MaNguyenLieu equals nguyenLieu.MaNguyenLieu
                            where chiTiet.MaXuatKho == maXuatKho
                            select new
                            {
                                chiTiet.MaNguyenLieu,
                                nguyenLieu.TenNguyenLieu,
                                chiTiet.SoLuongXuat,
                                chiTiet.DonGia,
                                chiTiet.ThanhTien
                            };

                // Tạo DataTable để chứa dữ liệu chi tiết
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã Nguyên Liệu");
                dataTable.Columns.Add("Tên Nguyên Liệu");
                dataTable.Columns.Add("Số Lượng xuất");
                dataTable.Columns.Add("Đơn Giá");
                dataTable.Columns.Add("Thành Tiền");

                // Thêm dữ liệu vào DataTable
                foreach (var item in query)
                {
                    dataTable.Rows.Add(item.MaNguyenLieu, item.TenNguyenLieu, item.SoLuongXuat, item.DonGia, item.ThanhTien);
                }

                // Cập nhật dataGridView3 với dữ liệu chi tiết phiếu nhập
                dataGridView3.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phiếu nhập: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e) => taoHD(_nhanVien);
        private void taoHD(nhanvien _nhanVien)
        {
            button4.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
            // Reset DataSource của DataGridView
            dataGridView3.DataSource = null;
            dataGridView2.DataSource = null;

            try
            {
                // Kiểm tra _nhanVien có null không
                if (_nhanVien == null)
                {
                    MessageBox.Show("Thông tin nhân viên không hợp lệ.");
                    return;
                }

                var maNhanVien = _nhanVien.MaNhanVien;
                string tenNhanVien = _nhanVien.TenNhanVien;

                // Tạo một danh sách mới của các phiếu nhập
                var newPhieuNhapList = new List<XuatKho>
        {
            new XuatKho
            {
                NgayXuat = DateTime.Now,      
                MaNhanVien = maNhanVien,      
                TongTien = 0                 
            }
        };

                // Cập nhật lại dataGridView2 với dữ liệu mới
                dataGridView2.DataSource = newPhieuNhapList;

                // Ẩn các cột không cần thiết, chỉ hiển thị các cột mong muốn
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    if (col.Name != "NgayXuat" && col.Name != "MaNhanVien" && col.Name != "TongTien")
                    {
                        col.Visible = false;
                    }
                }

                // Cập nhật lại tên các cột trong dataGridView2
                dataGridView2.Columns["NgayXuat"].HeaderText = "Ngày xuất";
                dataGridView2.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dataGridView2.Columns["TongTien"].HeaderText = "Tổng Tiền";

                // Thêm cột "Tên Nhân Viên" vào dataGridView2 nếu chưa có
                if (!dataGridView2.Columns.Contains("TenNhanVien"))
                {
                    DataGridViewTextBoxColumn tenNhanVienColumn = new DataGridViewTextBoxColumn();
                    tenNhanVienColumn.Name = "TenNhanVien";
                    tenNhanVienColumn.HeaderText = "Tên Nhân Viên";
                    tenNhanVienColumn.ValueType = typeof(string);
                    dataGridView2.Columns.Add(tenNhanVienColumn);
                }

                // Cập nhật giá trị của cột "Tên Nhân Viên" cho dòng đã tạo
                dataGridView2.Rows[0].Cells["TenNhanVien"].Value = tenNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo phiếu xuất: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;
            dataGridView3.DataSource = null;
            dataGridView2.DataSource = null;
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
            dataGridView1.DataSource = query.ToList();

            // Cập nhật tiêu đề cột
            dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";
            dataGridView1.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu DataGridView3 đang dùng DataTable làm nguồn dữ liệu
            DataTable dataTableCT = (DataTable)dataGridView3.DataSource;

            // Nếu không có DataSource, tạo mới DataTable
            if (dataTableCT == null)
            {
                dataTableCT = new DataTable();
                dataTableCT.Columns.Add("Tên Nguyên Liệu");
                dataTableCT.Columns.Add("Số Lượng");
                dataTableCT.Columns.Add("Ngày Nhập");
                dataTableCT.Columns.Add("Tổng Tiền"); // Thêm cột "Tổng Tiền"

                // Gán DataTable cho DataGridView3
                dataGridView3.DataSource = dataTableCT;
            }

            // Duyệt qua tất cả các dòng trong DataGridView1
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra xem checkbox có được chọn không
                if (Convert.ToBoolean(row.Cells["them"].Value))
                {
                    // Tạo một dòng mới cho DataTable của DataGridView3
                    DataRow newRow = dataTableCT.NewRow();

                    // Sao chép dữ liệu từ DataGridView1 sang DataTable
                    newRow["Tên Nguyên Liệu"] = row.Cells["TenNguyenLieu"].Value;
                    newRow["Số Lượng"] = row.Cells["SoLuong"].Value;
                    newRow["Ngày Nhập"] = row.Cells["NgayNhap"].Value;

                    // Lấy giá trị giaNhap từ bảng NguyenLieu, nếu không có thì gán mặc định là 0
                    string tenNguyenLieu = row.Cells["TenNguyenLieu"].Value.ToString();
                    decimal giaNhap = db.NguyenLieus
                                        .Where(nl => nl.TenNguyenLieu == tenNguyenLieu)
                                        .Select(nl => nl.GiaNhap)
                                        .FirstOrDefault() ?? 0; // Nếu giaNhap là null thì gán giá trị 0

                    // Lấy số lượng từ DataGridView
                    decimal soLuong = Convert.ToDecimal(row.Cells["SoLuong"].Value);

                    // Tính Tổng Tiền
                    decimal tongTien = giaNhap * soLuong;

                    // Thêm giá trị Tổng Tiền vào DataRow
                    newRow["Tổng Tiền"] = tongTien;

                    // Kiểm tra nếu dòng đã tồn tại trong DataTable, nếu có thì không thêm
                    bool isDuplicate = false;
                    foreach (DataRow existingRow in dataTableCT.Rows)
                    {
                        if (existingRow["Tên Nguyên Liệu"].ToString() == newRow["Tên Nguyên Liệu"].ToString() &&
                            existingRow["Số Lượng"].ToString() == newRow["Số Lượng"].ToString() &&
                            existingRow["Ngày Nhập"].ToString() == newRow["Ngày Nhập"].ToString())
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    // Nếu không phải dòng trùng, thì thêm vào DataTable
                    if (!isDuplicate)
                    {
                        dataTableCT.Rows.Add(newRow);
                    }
                    else
                    {
                        // Hiển thị thông báo khi sản phẩm đã có
                        MessageBox.Show("Sản phẩm \"" + newRow["Tên Nguyên Liệu"].ToString() + "\" đã có trong danh sách!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }

                // Đặt lại giá trị checkbox "them" về false sau khi đã xử lý
                row.Cells["them"].Value = false;
            }

            // Cập nhật tổng tiền vào DataGridView2
            decimal totalAmount = CalculateTotalAmount(dataGridView3);
            // Giả sử bạn có một cột trong DataGridView2 để hiển thị tổng tiền
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows[0].Cells["TongTien"].Value = totalAmount; // Cập nhật cột Tổng Tiền trong DataGridView2
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu DataGridView3 đang dùng DataTable làm nguồn dữ liệu
            DataTable dataTableCT = (DataTable)dataGridView3.DataSource;

            // Nếu không có DataSource, tạo mới DataTable
            if (dataTableCT == null)
            {
                dataTableCT = new DataTable();
                dataTableCT.Columns.Add("Tên Nguyên Liệu");
                dataTableCT.Columns.Add("Số Lượng");
                dataTableCT.Columns.Add("Ngày Nhập");
                dataTableCT.Columns.Add("Tổng Tiền"); // Thêm cột "Tổng Tiền"

                // Gán DataTable cho DataGridView3
                dataGridView3.DataSource = dataTableCT;
            }

            // Duyệt qua tất cả các dòng trong DataGridView4 và sao chép vào DataGridView3
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                // Tạo một dòng mới cho DataTable của DataGridView3
                DataRow newRow = dataTableCT.NewRow();

                // Sao chép dữ liệu từ DataGridView4 sang DataTable
                newRow["Tên Nguyên Liệu"] = row.Cells["TenNguyenLieu"].Value;
                newRow["Số Lượng"] = row.Cells["SoLuong"].Value;
                newRow["Ngày Nhập"] = row.Cells["NgayNhap"].Value;

                // Lấy giá trị giaNhap từ bảng NguyenLieu, nếu không có thì gán mặc định là 0
                string tenNguyenLieu = row.Cells["TenNguyenLieu"].Value.ToString();
                decimal giaNhap = db.NguyenLieus
                                    .Where(nl => nl.TenNguyenLieu == tenNguyenLieu)
                                    .Select(nl => nl.GiaNhap)
                                    .FirstOrDefault() ?? 0; // Nếu giaNhap là null thì gán giá trị 0

                // Lấy số lượng từ DataGridView
                decimal soLuong = Convert.ToDecimal(row.Cells["SoLuong"].Value);

                // Tính Tổng Tiền
                decimal tongTien = giaNhap * soLuong;

                // Thêm giá trị Tổng Tiền vào DataRow
                newRow["Tổng Tiền"] = tongTien;

                // Kiểm tra nếu dòng đã tồn tại trong DataTable, nếu có thì không thêm
                bool isDuplicate = false;
                foreach (DataRow existingRow in dataTableCT.Rows)
                {
                    if (existingRow["Tên Nguyên Liệu"].ToString() == newRow["Tên Nguyên Liệu"].ToString() &&
                        existingRow["Số Lượng"].ToString() == newRow["Số Lượng"].ToString() &&
                        existingRow["Ngày Nhập"].ToString() == newRow["Ngày Nhập"].ToString())
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                // Nếu không phải dòng trùng, thì thêm vào DataTable
                if (!isDuplicate)
                {
                    dataTableCT.Rows.Add(newRow);
                }
            }

            // Cập nhật tổng tiền vào DataGridView2
            decimal totalAmount = CalculateTotalAmount(dataGridView3);
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows[0].Cells["TongTien"].Value = totalAmount;
            }
        }

        private decimal CalculateTotalAmount(DataGridView dgv)
        {
            decimal total = 0;

            // Duyệt qua tất cả các dòng trong DataGridView và cộng tổng tiền
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Tổng Tiền"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Tổng Tiền"].Value);
                }
            }

            return total;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            button2.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button1.Enabled = true;
            try
            {
                // Kiểm tra xem dataGridView2 (Phiếu xuất) có dữ liệu không
                if (dataGridView2.Rows.Count > 0)
                {
                    // Lấy thông tin phiếu xuất từ dataGridView2
                    DateTime ngayXuat = Convert.ToDateTime(dataGridView2.Rows[0].Cells["NgayXuat"].Value);
                    int maNhanVien = Convert.ToInt32(dataGridView2.Rows[0].Cells["MaNhanVien"].Value);
                    decimal tongTien = Convert.ToDecimal(dataGridView2.Rows[0].Cells["TongTien"].Value);

                    // Tạo bản ghi mới trong bảng XuatKho
                    XuatKho phieuXuat = new XuatKho
                    {
                        NgayXuat = ngayXuat,
                        MaNhanVien = maNhanVien,
                        TongTien = tongTien
                    };

                    // Thêm phiếu xuất vào cơ sở dữ liệu
                    db.XuatKhos.InsertOnSubmit(phieuXuat);
                    db.SubmitChanges();

                    // Lấy MaXuatKho vừa tạo
                    int maXuatKho = phieuXuat.MaXuatKho;

                    // Kiểm tra xem dataGridView3 (Chi tiết phiếu xuất) có dữ liệu không
                    if (dataGridView3.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dataGridView3.Rows)
                        {
                            if (row.IsNewRow) continue;  // Bỏ qua dòng mới chưa được điền dữ liệu

                            // Lấy thông tin từ các cột của dataGridView3 (Chi tiết phiếu xuất)
                            string tenNguyenLieu = row.Cells["Tên Nguyên Liệu"].Value?.ToString(); // Kiểm tra giá trị null
                            int soLuongXuat = Convert.ToInt32(row.Cells["Số Lượng"].Value);
                            DateTime ngayNhap = Convert.ToDateTime(row.Cells["Ngày Nhập"].Value);
                            decimal tongTienChiTiet = Convert.ToDecimal(row.Cells["Tổng Tiền"].Value);

                            // Kiểm tra tên nguyên liệu có tồn tại trong bảng NguyenLieu không
                            var nguyenLieu = db.NguyenLieus.SingleOrDefault(nl => nl.TenNguyenLieu == tenNguyenLieu);
                            if (nguyenLieu != null)
                            {
                                // Tạo bản ghi chi tiết phiếu xuất trong bảng ChiTietPhieuXuat
                                ChiTietPhieuXuat chiTiet = new ChiTietPhieuXuat
                                {
                                    MaXuatKho = maXuatKho,
                                    MaNguyenLieu = nguyenLieu.MaNguyenLieu,
                                    SoLuongXuat = soLuongXuat,
                                    DonGia = tongTienChiTiet / soLuongXuat,  // Đơn giá được tính từ Tổng Tiền / Số Lượng
                                    ThanhTien = tongTienChiTiet
                                };

                                // Thêm chi tiết vào cơ sở dữ liệu
                                db.ChiTietPhieuXuats.InsertOnSubmit(chiTiet);

                                // Kiểm tra sự tồn tại của bản ghi trong bảng Tồn Kho dựa trên MaNguyenLieu
                                var tonKho = db.TonKhos.SingleOrDefault(tk => tk.MaNguyenLieu == nguyenLieu.MaNguyenLieu);

                                if (tonKho != null)
                                {
                                    // Kiểm tra xem số lượng tồn kho có đủ để xuất không
                                    if (tonKho.SoLuong >= soLuongXuat)
                                    {
                                        // Nếu đủ, trừ số lượng tồn kho
                                        tonKho.SoLuong -= soLuongXuat;  // Cập nhật số lượng tồn kho
                                    }
                                    else
                                    {
                                        // Nếu không đủ, đặt số lượng tồn kho về 0
                                        tonKho.SoLuong = 0;
                                    }
                                }
                                else
                                {
                                    // Nếu không tồn tại bản ghi tồn kho, có thể tạo mới hoặc báo lỗi tùy theo yêu cầu
                                    MessageBox.Show("Không tìm thấy thông tin tồn kho cho nguyên liệu: " + tenNguyenLieu);
                                }
                            }
                            else
                            {
                                // Nếu không tìm thấy nguyên liệu trong cơ sở dữ liệu
                                MessageBox.Show("Không tìm thấy nguyên liệu: " + tenNguyenLieu);
                                return; // Dừng lại nếu có nguyên liệu không tìm thấy
                            }
                        }

                        // Lưu tất cả chi tiết phiếu xuất và cập nhật tồn kho vào cơ sở dữ liệu
                        db.SubmitChanges();

                        // Thông báo thành công
                        MessageBox.Show("Đã lưu phiếu xuất, chi tiết phiếu xuất và cập nhật tồn kho thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không có chi tiết phiếu xuất để lưu!");
                    }

                    // Xóa dữ liệu trong các dataGridView sau khi lưu thành công
                    dataGridView2.DataSource = null;
                    dataGridView3.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Không có phiếu xuất để lưu!");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi lưu phiếu xuất và chi tiết: " + ex.Message);
            }
        }





    }
}
