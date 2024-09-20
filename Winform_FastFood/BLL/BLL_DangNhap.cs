using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_DangNhap
    {
        private readonly DAL_DangNhap _DAL_DangNhap;

        public BLL_DangNhap() {
            _DAL_DangNhap = new DAL_DangNhap();
        }

        public bool XacThucDangNhap(string TenDangNhap, string MatKhau) {
            var nhanvien = _DAL_DangNhap.DangNhap(TenDangNhap, MatKhau);
            return nhanvien != null;
        }
    }
}
