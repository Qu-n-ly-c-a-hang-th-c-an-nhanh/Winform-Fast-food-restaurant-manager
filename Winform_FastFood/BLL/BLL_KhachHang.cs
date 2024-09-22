using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
   public class BLL_KhachHang
    {
        private readonly DAL_KhachHang _DAL_KhachHang;

        public BLL_KhachHang()
        {
            _DAL_KhachHang = new DAL_KhachHang();
        }

        public List<KhachHang> DanhSachKhachHang()
        {
            return _DAL_KhachHang.LayDanhSachkhachhang();
        }

        public void them(KhachHang _khachhang)
        {
            _DAL_KhachHang.Them(_khachhang);
        }

        //public List<string> DanhsachQuyen()
        //{
        //    return DAL_KhachHang.PhanQuyen();
        //}
        //public List<string> Danhsachchucvu()
        //{
        //    return DAL_KhachHang.ChucVu();
        //}

        public void xoa(int id)
        {
            _DAL_KhachHang.Xoa(id);
        }
        public void sua(KhachHang _khachhang)
        {
            _DAL_KhachHang.Sua(_khachhang);
        }
        public IList<KhachHang> DanhSachTimKiem(string ten)
        {
            return _DAL_KhachHang.TimKiem(ten);
        }
    }
}
