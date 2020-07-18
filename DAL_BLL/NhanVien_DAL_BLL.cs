using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class NhanVien_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public NhanVien_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<NhanVien_DTO> layTatCa()
        {
            List<NhanVien_DTO> result = new List<NhanVien_DTO>();
            foreach (NHANVIEN nv in db.NHANVIENs)
                result.Add(new NhanVien_DTO
                {
                    UserName = nv.USERNAME,
                    Pass = nv.PASS,
                    TenNhanVien = nv.TENNHANVIEN,
                    Email = nv.EMAIL,
                    HoatDong = nv.HOATDONG
                });

            return result;
        }

        public IQueryable layNhanVienTheoMaNhom(string maNhom)
        {
            var list = from nv in db.NHANVIENs 
                       join p in db.PHANNHANVIEN_VAONHOMQUYENs 
                       on nv.USERNAME equals p.USERNAME 
                       where p.MANHOM.Equals(maNhom) 
                       select new { nv.USERNAME, nv.TENNHANVIEN, nv.EMAIL, p.GHICHU};

            return list;
        }

        
    }
}