using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class KhachHang_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public KhachHang_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<KhachHang_DTO> lay5KH_GanDay()
        {
            List<KhachHang_DTO> result = new List<KhachHang_DTO>();
            var list = db.KhachHangs.OrderByDescending(n => n.NGAYTAO).Take(5);
            foreach (KhachHang kh in list)
                result.Add(new KhachHang_DTO
                {
                    MaKH = kh.MaKH,
                    TaiKhoan = kh.TaiKhoan,
                    DiaChi = kh.DiaChi,
                    DienThoai1 = kh.DienThoai,
                    GioiTinh = kh.GioiTinh,
                    HoTen = kh.HoTen,
                    MatKhau = kh.MatKhau,
                    Status = kh.Status
                });

            return result;
        }

        public KhachHang_DTO layKhachHang(int maKH)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(n => n.MaKH.Equals(maKH));
            if (kh == null)
                return null;
            return new KhachHang_DTO
            {
                MaKH = kh.MaKH,
                TaiKhoan = kh.TaiKhoan,
                DiaChi = kh.DiaChi,
                DienThoai1 = kh.DienThoai,
                GioiTinh = kh.GioiTinh,
                HoTen = kh.HoTen,
                MatKhau = kh.MatKhau,
                Status = kh.Status
            };
        }
    }
}