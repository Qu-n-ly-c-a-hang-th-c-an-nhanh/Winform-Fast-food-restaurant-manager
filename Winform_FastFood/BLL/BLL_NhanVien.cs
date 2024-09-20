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

        public void them(nhanvien _nhanvien)
        {
            _DAL_NhanVien.Them(_nhanvien);
        }
    }
}
