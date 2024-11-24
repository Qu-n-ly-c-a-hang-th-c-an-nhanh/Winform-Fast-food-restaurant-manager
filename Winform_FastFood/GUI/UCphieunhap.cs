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
    public partial class UCphieunhap : DevExpress.XtraEditors.XtraUserControl
    {
        
        readonly private FastFoodDataContext db;
        private nhanvien _nhanVien;
        public UCphieunhap(nhanvien nhanVien)
        {
            db = new FastFoodDataContext();
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.CellValueChanged += DataGridView3_CellValueChanged;
            dataGridView2.CellClick += DataGridView2_CellClick;
            searchControl1.TextChanged += SearchControl1_TextChanged;
            LoadNguyenLieu();
            CotThemCheckBox();
            button4.Enabled = false;
            button6.Enabled = false;
            button2.Enabled = false;
            _nhanVien = nhanVien;
        }

        private void SearchControl1_TextChanged(object sender, EventArgs e)
        {
            LoadNguyenLieu(searchControl1.Text);
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào một hàng (không phải header)
            if (e.RowIndex >= 0)
            {
                // Lấy MaNhapKho từ cột "Mã nhập kho" của hàng được chọn
                int maNhapKho = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["Mã nhập kho"].Value);

                // Gọi hàm để tải chi tiết phiếu nhập tương ứng vào dataGridView3
                LoadChiTietPhieuNhap(maNhapKho);
            }
        }
        private void LoadChiTietPhieuNhap(int maNhapKho)
        {
            try
            {
                // Truy vấn chi tiết phiếu nhập dựa trên MaNhapKho
                var query = from chiTiet in db.ChiTietPhieuNhaps
                            join nguyenLieu in db.NguyenLieus on chiTiet.MaNguyenLieu equals nguyenLieu.MaNguyenLieu
                            where chiTiet.MaNhapKho == maNhapKho
                            select new
                            {
                                chiTiet.MaNguyenLieu,
                                nguyenLieu.TenNguyenLieu,
                                chiTiet.SoLuongNhap,
                                chiTiet.DonGia,
                                chiTiet.ThanhTien
                            };

                // Tạo DataTable để chứa dữ liệu chi tiết
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã Nguyên Liệu");
                dataTable.Columns.Add("Tên Nguyên Liệu");
                dataTable.Columns.Add("Số Lượng Nhập");
                dataTable.Columns.Add("Đơn Giá");
                dataTable.Columns.Add("Thành Tiền");

                // Thêm dữ liệu vào DataTable
                foreach (var item in query)
                {
                    dataTable.Rows.Add(item.MaNguyenLieu, item.TenNguyenLieu, item.SoLuongNhap, item.DonGia, item.ThanhTien);
                }

                // Cập nhật dataGridView3 với dữ liệu chi tiết phiếu nhập
                dataGridView3.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phiếu nhập: " + ex.Message);
            }
        }
        private void DataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView3.Columns["Số lượng nhập"].Index)
                {
                    DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                    int soLuongNhap = Convert.ToInt32(row.Cells["Số lượng nhập"].Value);
                    decimal giaNhap = Convert.ToDecimal(row.Cells["Đơn giá"].Value);

                    // Cập nhật lại thành tiền
                    decimal thanhTien = giaNhap * soLuongNhap;
                    row.Cells["Thành tiền"].Value = thanhTien;

                    // Nếu số lượng nhập = 0, xóa dòng đó
                    if (soLuongNhap == 0)
                    {
                        dataGridView3.Rows.RemoveAt(e.RowIndex);
                    }

                    // Cập nhật lại tổng tiền trong dataGridView2
                    UpdateTongTien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa số lượng nhập: " + ex.Message);
            }
        }
        private void LoadNguyenLieu(string searchText = "")
        {
            // Kiểm tra nếu có văn bản tìm kiếm
            var query = db.NguyenLieus.AsQueryable();

            // Nếu có văn bản tìm kiếm, lọc các nguyên liệu theo mã hoặc tên nguyên liệu
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(nl =>  nl.TenNguyenLieu.Contains(searchText));
            }

            // Thực hiện truy vấn và chuyển dữ liệu sang DataTable
            var result = query.Select(nl => new
            {
                nl.MaNguyenLieu,
                nl.TenNguyenLieu,
                nl.GiaNhap,
                nl.DonViTinh
            }).ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Mã Nguyên Liệu");
            dataTable.Columns.Add("Tên Nguyên Liệu");
            dataTable.Columns.Add("Đơn Vị Tính");
            dataTable.Columns.Add("Giá Nhập");

            // Thêm dữ liệu vào DataTable
            foreach (var item in result)
            {
                DataRow row = dataTable.NewRow();
                row["Mã Nguyên Liệu"] = item.MaNguyenLieu;
                row["Tên Nguyên Liệu"] = item.TenNguyenLieu;
                row["Giá Nhập"] = item.GiaNhap?.ToString("N0") ?? "0";  
                row["Đơn Vị Tính"] = item.DonViTinh;
                dataTable.Rows.Add(row);
            }

            // Đưa dữ liệu vào DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void CotThemCheckBox()
        {
            DataGridViewCheckBoxColumn cotCheckBox = new DataGridViewCheckBoxColumn();
            cotCheckBox.HeaderText = "Thêm";
            cotCheckBox.Name = "them";
            cotCheckBox.Width = 50;
            dataGridView1.Columns.Insert(0, cotCheckBox);
        }
        private void taoHD(nhanvien _nhanVien) {
            button4.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = false;
            button6.Enabled = true;

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
                var newPhieuNhapList = new List<NhapKho>
        {
            new NhapKho
            {
                NgayNhap = DateTime.Now,      // Ngày Nhập hiện tại
                MaNhanVien = maNhanVien,      // Mã Nhân Viên
                TongTien = 0                  // Tổng tiền là 0
            }
        };

                // Cập nhật lại dataGridView2 với dữ liệu mới
                dataGridView2.DataSource = newPhieuNhapList;

                // Ẩn các cột không cần thiết, chỉ hiển thị các cột mong muốn
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    if (col.Name != "NgayNhap" && col.Name != "MaNhanVien" && col.Name != "TongTien")
                    {
                        col.Visible = false;
                    }
                }

                // Cập nhật lại tên các cột trong dataGridView2
                dataGridView2.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
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
                MessageBox.Show("Lỗi khi tạo phiếu nhập: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e) => taoHD(_nhanVien);

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem dataGridView3 đã có DataSource chưa
                DataTable dataTableCT = (DataTable)dataGridView3.DataSource;

                // Nếu chưa có DataSource, tạo mới DataTable
                if (dataTableCT == null)
                {
                    dataTableCT = new DataTable();
                    dataTableCT.Columns.Add("Mã nguyên liệu");
                    dataTableCT.Columns.Add("Tên nguyên liệu");
                    dataTableCT.Columns.Add("Số lượng nhập");
                    dataTableCT.Columns.Add("Đơn giá");
                    dataTableCT.Columns.Add("Thành tiền");
                }

                // Duyệt qua tất cả các hàng trong dataGridView1 và kiểm tra checkbox
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Kiểm tra nếu checkbox trong cột "them" được chọn (checked)
                    if (Convert.ToBoolean(row.Cells["them"].Value))
                    {
                        // Lấy thông tin từ các ô trong hàng được chọn
                        int manguyenlieu = Convert.ToInt32(row.Cells["Mã Nguyên liệu"].Value);
                        string tenNguyenLieu = row.Cells["Tên Nguyên Liệu"].Value.ToString();
                        decimal giaNhap = Convert.ToDecimal(row.Cells["Giá Nhập"].Value);

                        // Lấy số lượng nhập từ ô khác, ví dụ một TextBox hoặc mặc định là 1
                        int soLuongNhap = 1; // Bạn có thể thay thế giá trị này bằng giá trị nhập từ TextBox hoặc cột khác nếu có

                        // Tính thành tiền = Đơn giá * Số lượng nhập
                        decimal thanhTien = giaNhap * soLuongNhap;

                        // Thêm dòng vào DataTable của dataGridView3
                        dataTableCT.Rows.Add(manguyenlieu, tenNguyenLieu, soLuongNhap, giaNhap, thanhTien);
                    }

                    // Sau khi thêm, xóa checkbox đã được chọn
                    row.Cells["them"].Value = false;
                }

                // Cập nhật lại dataGridView3 với DataTable mới
                dataGridView3.DataSource = dataTableCT;

                // Cập nhật lại tổng tiền trong dataGridView2
                UpdateTongTien();

            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                MessageBox.Show("Lỗi khi thêm vào Chi Tiết Phiếu Nhập: " + ex.Message);
            }
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
                var query = from nhapKho in db.NhapKhos
                            join nhanVien in db.nhanviens on nhapKho.MaNhanVien equals nhanVien.MaNhanVien
                            where nhapKho.NgayNhap >= startDate && nhapKho.NgayNhap <= endDate
                            select new
                            {
                                MaNhapKho = nhapKho.MaNhapKho,
                                NgayNhap = nhapKho.NgayNhap,
                                TenNhanVien = nhanVien.TenNhanVien,
                                TongTien = nhapKho.TongTien
                            };

                // Tạo DataTable để chứa dữ liệu đã lọc
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã nhập kho");
                dataTable.Columns.Add("Ngày nhập");
                dataTable.Columns.Add("Tên nhân viên");
                dataTable.Columns.Add("Tổng tiền");

                // Thêm dữ liệu vào DataTable
                foreach (var item in query)
                {
                    dataTable.Rows.Add(item.MaNhapKho, item.NgayNhap, item.TenNhanVien, item.TongTien);
                }

                // Cập nhật dataGridView2 với dữ liệu đã lọc
                dataGridView2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc hóa đơn: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;

            try
            {
                // Kiểm tra xem dataGridView2 có dữ liệu không (phiếu nhập)
                if (dataGridView2.Rows.Count > 0)
                {
                    // Lấy thông tin phiếu nhập từ dataGridView2
                    DateTime ngayNhap = Convert.ToDateTime(dataGridView2.Rows[0].Cells["NgayNhap"].Value);
                    int maNhanVien = Convert.ToInt32(dataGridView2.Rows[0].Cells["MaNhanVien"].Value);
                    decimal tongTien = Convert.ToDecimal(dataGridView2.Rows[0].Cells["TongTien"].Value);

                    // Tạo bản ghi mới trong bảng NhapKho
                    NhapKho phieuNhap = new NhapKho
                    {
                        NgayNhap = ngayNhap,
                        MaNhanVien = maNhanVien,
                        TongTien = tongTien
                    };

                    // Thêm phiếu nhập vào cơ sở dữ liệu
                    db.NhapKhos.InsertOnSubmit(phieuNhap);
                    db.SubmitChanges();

                    // Lấy MaNhapKho vừa tạo
                    int maNhapKho = phieuNhap.MaNhapKho;

                    // Kiểm tra xem dataGridView3 có dữ liệu không (chi tiết phiếu nhập)
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        // Lấy thông tin từ các cột của dataGridView3
                        int maNguyenLieu = Convert.ToInt32(row.Cells["Mã Nguyên Liệu"].Value);
                        int soLuongNhap = Convert.ToInt32(row.Cells["Số Lượng Nhập"].Value);
                        decimal donGia = Convert.ToDecimal(row.Cells["Đơn Giá"].Value);
                        decimal thanhTien = Convert.ToDecimal(row.Cells["Thành Tiền"].Value);

                        // Kiểm tra xem Mã Nguyên Liệu có tồn tại trong bảng NguyenLieu không
                        var nguyenLieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu == maNguyenLieu);
                        if (nguyenLieu != null)
                        {
                            // Tạo bản ghi mới trong bảng ChiTietPhieuNhap
                            ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap
                            {
                                MaNhapKho = maNhapKho,
                                MaNguyenLieu = maNguyenLieu,
                                SoLuongNhap = soLuongNhap,
                                DonGia = donGia,
                                ThanhTien = thanhTien
                            };

                            // Thêm chi tiết vào cơ sở dữ liệu
                            db.ChiTietPhieuNhaps.InsertOnSubmit(chiTiet);

                            // Kiểm tra sự tồn tại của bản ghi trong bảng Tồn Kho dựa trên MaNguyenLieu
                            var tonKho = db.TonKhos.SingleOrDefault(tk => tk.MaNguyenLieu == maNguyenLieu);

                            if (tonKho != null)
                            {
                                // Nếu bản ghi tồn kho đã có, chỉ cần cập nhật số lượng tồn kho và ngày nhập
                                tonKho.SoLuong += soLuongNhap;  // Cập nhật số lượng tồn kho
                                tonKho.NgayNhap = ngayNhap;     // Cập nhật ngày nhập (nếu cần thiết)
                            }
                            else
                            {
                                // Nếu không tồn tại bản ghi, tạo mới bản ghi tồn kho
                                TonKho tonKhoMoi = new TonKho
                                {
                                    MaNguyenLieu = maNguyenLieu,
                                    SoLuong = soLuongNhap, // Ghi nhận số lượng nhập
                                    NgayNhap = ngayNhap    // Ghi nhận ngày nhập
                                };

                                // Thêm bản ghi tồn kho mới vào cơ sở dữ liệu
                                db.TonKhos.InsertOnSubmit(tonKhoMoi);
                            }
                        }
                    }

                    // Lưu tất cả chi tiết phiếu nhập và cập nhật tồn kho vào cơ sở dữ liệu
                    db.SubmitChanges();

                    // Thông báo thành công
                    MessageBox.Show("Đã lưu phiếu nhập, chi tiết phiếu nhập và cập nhật tồn kho thành công!");
                    dataGridView3.DataSource = null;
                    dataGridView2.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Không có phiếu nhập để lưu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập và chi tiết: " + ex.Message);
            }
        }



        private void UpdateTongTien()
        {
            try
            {
                decimal tongTien = 0;

                // Duyệt qua tất cả các dòng trong dataGridView3 và tính tổng tiền
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells["Thành tiền"].Value != null)
                    {
                        tongTien += Convert.ToDecimal(row.Cells["Thành tiền"].Value);
                    }
                }

                // Cập nhật tổng tiền trong dataGridView2 (phiếu nhập)
                if (dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Rows[0].Cells["TongTien"].Value = tongTien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tổng tiền: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
    
            button2.Enabled = false;
            button1.Enabled = true;
            button6.Enabled = false;
            dataGridView3.DataSource = null;
            dataGridView2.DataSource = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
                // Xác định trạng thái checkbox cần thiết, là "checked" (chọn) hoặc "unchecked" (bỏ chọn)
                bool isChecked = true;  // Thay đổi giá trị này nếu bạn muốn bỏ chọn tất cả thay vì chọn

                // Duyệt qua tất cả các dòng trong DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Kiểm tra xem cột "them" là cột checkbox
                    if (row.Cells["them"] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        // Cập nhật giá trị của checkbox
                        checkBoxCell.Value = isChecked;
                    }
                }
            

        }
    }
}
