using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace DAL_BLL
{
    public class NhanVien_DAL_BLL
    {
        private QL_MBTBDTDataContext db;
        private PhanNhanVienVaoNhomQuyen_DAL_BLL _dataPvnq;

        public NhanVien_DAL_BLL()
        {
            _dataPvnq = new PhanNhanVienVaoNhomQuyen_DAL_BLL();
            db = new QL_MBTBDTDataContext();
        }

        #region Phần Của Việt

        public NHANVIEN layNhanVien(string uName)
        {
            return db.NHANVIENs.FirstOrDefault(n => n.USERNAME.Equals(uName));
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

        #endregion

        #region Phần Của Long

        public EStatus XoaNhanVien(string username)
        {

            var nv = db.NHANVIENs.SingleOrDefault(x => x.USERNAME.Equals(username));
            if (nv == null)
            {
                return EStatus.THAT_BAI;
            }

            var layNhomQuyen = _dataPvnq.layTheoMaUser(username);
            if (layNhomQuyen.Any())
            {
                if (!_dataPvnq.XoaNhieuNhomQuyen(layNhomQuyen))
                {
                    return EStatus.THAT_BAI;
                }
            }
            db.NHANVIENs.DeleteOnSubmit(nv);

            return EStatus.THANH_CONG;

        }
        public void SaveChanged()
        {
            db.SubmitChanges();
        }
        public EStatus UpdateNhanVien(NhanVien_DTO nvDto)
        {
            var nv = db.NHANVIENs.SingleOrDefault(x => x.USERNAME == nvDto.UserName);
            if (nv == null) return EStatus.LOI;
            nv.USERNAME = nvDto.UserName;
            nv.PASS = nvDto.Pass;
            nv.EMAIL = nvDto.Email;
            nv.HOATDONG = nvDto.HoatDong;
            nv.TENNHANVIEN = nvDto.TenNhanVien;
            return EStatus.THANH_CONG;
        }
        public bool GetById(string username)
        {
            return db.NHANVIENs.Any(x => x.USERNAME.Equals(username));
        }
        public bool EmailIsValid(string emailAddress)
        {
            try
            {
                var mailAddress = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public EStatus AddNhanVien(NhanVien_DTO nvDto)
        {
            try
            {

                db.NHANVIENs.InsertOnSubmit(new NHANVIEN()
                {
                    EMAIL = nvDto.Email,
                    HOATDONG = nvDto.HoatDong,
                    PASS = nvDto.Pass,
                    TENNHANVIEN = nvDto.TenNhanVien,
                    USERNAME = nvDto.UserName
                });
                return EStatus.THANH_CONG;
            }
            catch (Exception)
            {
                return EStatus.LOI;
            }
        }
        #endregion
    }
}