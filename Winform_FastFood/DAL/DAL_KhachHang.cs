using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Linq;

namespace DAL
{
   public class DAL_KhachHang
    {
        private readonly FastFoodDataContext _context;

        public DAL_KhachHang()
        {
            _context = new FastFoodDataContext();
        }
        public List<KhachHang> LayDanhSachkhachhang()
        {
            return _context.KhachHangs.ToList();
        }

        public void Them(KhachHang _khachHang)
        {
            _context.KhachHangs.InsertOnSubmit(_khachHang);
            _context.SubmitChanges();
        }

        //public List<string> ChucVu()
        //{
        //    return _context.nhanviens.Select(nv => nv.ChucVu).Distinct().ToList();
        //}
        //public List<string> PhanQuyen()
        //{
        //    return _context.nhanviens.Select(nv => nv.Quyen).Distinct().ToList();
        //}

        public void Xoa(int id)
        {
            var Xoa = _context.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == id);
            if (Xoa != null)
            {
                _context.KhachHangs.DeleteOnSubmit(Xoa);
                _context.SubmitChanges();
            }
        }
        public void Sua(KhachHang SuakhachHang)
        {
            var sua = _context.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == SuakhachHang.MaKhachHang);
            if (sua != null)
            {
                sua.TenKhachHang = SuakhachHang.TenKhachHang;
                sua.MatKhau = SuakhachHang.MatKhau;
                sua.Email = SuakhachHang.Email;
                sua.DienThoai = SuakhachHang.DienThoai;
                sua.TenDangNhap = SuakhachHang.TenDangNhap;
                sua.DiaChi = SuakhachHang.DiaChi;

                _context.SubmitChanges();
            }

        }
        public List<KhachHang> TimKiem(string ten)
        {
            return _context.KhachHangs
                           .Where(kh => kh.TenKhachHang.ToLower().Contains(ten.ToLower()))
                           .ToList();
        }
    }
}
