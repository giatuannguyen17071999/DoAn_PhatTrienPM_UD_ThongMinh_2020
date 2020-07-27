using DTO;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhanNhanVienVaoNhomQuyen_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public PhanNhanVienVaoNhomQuyen_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        #region Phan Cua Viet

        public List<PHANNHANVIEN_VAONHOMQUYEN> layTheoUserName(string uName)
        {
            return db.PHANNHANVIEN_VAONHOMQUYENs.Where(n => n.USERNAME.Equals(uName)).ToList();
        }

        public PhanNhanVienVaoNhomQuyen_DTO layTheoKhoaChinh(string uName, string maNhom)
        {
            PHANNHANVIEN_VAONHOMQUYEN p = db.PHANNHANVIEN_VAONHOMQUYENs.FirstOrDefault(n => n.USERNAME.Equals(uName) && n.MANHOM.Equals(maNhom));
            return p == null ?
                null :
                new PhanNhanVienVaoNhomQuyen_DTO
                {
                    UserName = p.USERNAME,
                    MaNhom = p.MANHOM,
                    GhiChu = p.GHICHU
                };
        }

        public EStatus them(PhanNhanVienVaoNhomQuyen_DTO pNV_NQ)
        {
            PhanNhanVienVaoNhomQuyen_DTO pTim = layTheoKhoaChinh(pNV_NQ.UserName, pNV_NQ.MaNhom);
            if (pTim != null)
                return EStatus.TRUNG_KHOA;

            if (pNV_NQ == null ||
                string.IsNullOrEmpty(pNV_NQ.UserName) ||
                string.IsNullOrEmpty(pNV_NQ.MaNhom))
                return EStatus.SAI_CAU_TRUC;
            db.PHANNHANVIEN_VAONHOMQUYENs.InsertOnSubmit(new PHANNHANVIEN_VAONHOMQUYEN
            {
                USERNAME = pNV_NQ.UserName,
                MANHOM = pNV_NQ.MaNhom,
                GHICHU = pNV_NQ.GhiChu
            });

            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

        public EStatus xoa(string uName, string maNhom)
        {
            PHANNHANVIEN_VAONHOMQUYEN p = db.PHANNHANVIEN_VAONHOMQUYENs.FirstOrDefault(n => n.USERNAME.Equals(uName) && n.MANHOM.Equals(maNhom));
            if (p == null)
                return EStatus.LOI;
            db.PHANNHANVIEN_VAONHOMQUYENs.DeleteOnSubmit(p);
            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

        #endregion

        #region Phan Cua Long

        public List<PHANNHANVIEN_VAONHOMQUYEN> layTheoMaUser(string uName)
        {
            return db.PHANNHANVIEN_VAONHOMQUYENs.Where(n => n.USERNAME.Equals(uName)).ToList();
        }
        public bool XoaNhieuNhomQuyen(List<PHANNHANVIEN_VAONHOMQUYEN> lst)
        {
            try
            {
                db.PHANNHANVIEN_VAONHOMQUYENs.DeleteAllOnSubmit(lst);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                string tmp = e.Message;
                return false;
            }
        }
        #endregion
    }
}
