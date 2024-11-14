//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DTO;
//using System.Data.Linq;

//namespace DAL
//{
//    public class DAL_DangNhap
//    {
//        private readonly FastFoodDataContext _context;

//        public DAL_DangNhap()
//        {
//            _context = new FastFoodDataContext();
//        }

//        public nhanvien DangNhap(string TenDangNhap , string MatKhau) {
//            return _context.nhanviens.FirstOrDefault(nd => nd.TenDangNhap == TenDangNhap && nd.MatKhau == MatKhau);
//        }
//    }
//}

using DTO; // Thêm dòng này nếu bạn sử dụng lớp NhanVien từ namespace DTO

using System.Linq; // Đảm bảo thêm namespace này để sử dụng LINQ
using System.Data.Linq; // Đảm bảo có thư viện này nếu bạn đang sử dụng LINQ to SQL

namespace DAL
{
    public class DAL_DangNhap
    {
        private readonly FastFoodDataContext _db;

        public DAL_DangNhap()
        {
            _db = new FastFoodDataContext();
        }

        public nhanvien DangNhap(string TenDangNhap, string MatKhau)
        {
            // Truy vấn cơ sở dữ liệu để tìm nhân viên có tên đăng nhập và mật khẩu khớp
            var nhanVien = _db.nhanviens.FirstOrDefault(nv => nv.TenDangNhap == TenDangNhap && nv.MatKhau == MatKhau);
            return nhanVien;
        }

    }
}


