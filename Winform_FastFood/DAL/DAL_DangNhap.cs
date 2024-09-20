using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Linq;

namespace DAL
{
    public class DAL_DangNhap
    {
        private readonly FastFoodDataContext _context;

        public DAL_DangNhap()
        {
            _context = new FastFoodDataContext();
        }

        public nhanvien DangNhap(string TenDangNhap , string MatKhau) {
            return _context.nhanviens.FirstOrDefault(nd => nd.TenDangNhap == TenDangNhap && nd.MatKhau == MatKhau);
        }
    }
}
