using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Linq;

namespace DAL
{
    public class DAL_NhanVien
    {
        private readonly FastFoodDataContext _context;

        public DAL_NhanVien()
        {
            _context = new FastFoodDataContext();
        }


        public List<nhanvien> LayDanhSachNhanVien()
        {
            return _context.nhanviens.ToList();
        }
        public List<string> ChucVu()
        {
            return _context.nhanviens.Select(nv => nv.ChucVu).Distinct().ToList();
        }
        public List<string> PhanQuyen()
        {
            return _context.nhanviens.Select(nv => nv.Quyen).Distinct().ToList();
        }
        public void Them(nhanvien _nhanvien)
        {
            _context.nhanviens.InsertOnSubmit(_nhanvien);
            _context.SubmitChanges();
        }
        public void Xoa(int id)
        {
            var Xoa = _context.nhanviens.SingleOrDefault(nv => nv.MaNhanVien == id);
            if (Xoa != null)
            {
                _context.nhanviens.DeleteOnSubmit(Xoa);
                _context.SubmitChanges();
            }
        }
        public void Sua(nhanvien SuaNhanVien)
        {
            var sua = _context.nhanviens.SingleOrDefault(nv => nv.MaNhanVien == SuaNhanVien.MaNhanVien);
            if (sua != null)
            {
                sua.TenNhanVien = SuaNhanVien.TenNhanVien;
                sua.MatKhau = SuaNhanVien.MatKhau;
                sua.ChucVu = SuaNhanVien.ChucVu;
                sua.Luong = SuaNhanVien.Luong;
                sua.TenDangNhap = SuaNhanVien.TenDangNhap;
                sua.Quyen = SuaNhanVien.Quyen;

                _context.SubmitChanges();
            }

        }
        public List<nhanvien> TimKiem(string ten)
        {
            return _context.nhanviens
                           .Where(nv => nv.TenNhanVien.ToLower().Contains(ten.ToLower())) 
                           .ToList();
        }
    }
}
