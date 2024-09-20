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

        public void Them(nhanvien _nhanvien)
        {
            _context.nhanviens.InsertOnSubmit(_nhanvien);
            _context.SubmitChanges();
        }
       
    }
}
