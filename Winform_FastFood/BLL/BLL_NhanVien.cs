using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_NhanVien
    {
        private readonly DAL_NhanVien _DAL_NhanVien;

        public BLL_NhanVien()
        {
            _DAL_NhanVien = new DAL_NhanVien();
        }

        public List<nhanvien> DanhSachNhanVien()
        {
            return _DAL_NhanVien.LayDanhSachNhanVien();
        }
        public List<string> DanhsachQuyen()
        {
            return _DAL_NhanVien.PhanQuyen();
        }
        public List<string> Danhsachchucvu()
        {
            return _DAL_NhanVien.ChucVu();
        }
        public void them(nhanvien _nhanvien)
        {
            _DAL_NhanVien.Them(_nhanvien);
        }
        public void xoa(int id) {
            _DAL_NhanVien.Xoa(id);
        }
        public void sua(nhanvien _nhanvien) {
            _DAL_NhanVien.Sua(_nhanvien);
        }
        public IList<nhanvien> DanhSachTimKiem(string ten)
        {
            return _DAL_NhanVien.TimKiem(ten);
        }
    }
}
