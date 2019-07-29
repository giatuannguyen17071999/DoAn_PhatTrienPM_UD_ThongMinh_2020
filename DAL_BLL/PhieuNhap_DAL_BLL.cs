using DTO;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhieuNhap_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public PhieuNhap_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public EStatus them(PHIEU_NHAP pn)
        {
            //ton?
            PHIEU_NHAP pTim = db.PHIEU_NHAPs.FirstOrDefault(n => n.MAPN == pn.MAPN);
            if (pTim != null)
                return EStatus.TRUNG_KHOA;
            db.PHIEU_NHAPs.InsertOnSubmit(pn);
            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

        public List<PhieuNhap_DTO> layTatCa()
        {
            List<PhieuNhap_DTO> result = new List<PhieuNhap_DTO>();
            foreach (PHIEU_NHAP pn in db.PHIEU_NHAPs)
                result.Add(new PhieuNhap_DTO
                {
                    MaPN = pn.MAPN,
                    NgayNhap = pn.NGAYNHAP,
                    TongTien = pn.TONGTIEN,
                    NhaCC = pn.NHACC
                });

            return result;
        }

        public decimal layTongTien(string maPN)
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.PHIEU_NHAPs);
            var tim = from p in db.PHIEU_NHAPs where p.MAPN.Equals(maPN) select p;
            PHIEU_NHAP pn = tim.First();

            if (pn == null || pn.TONGTIEN == null)
                return 0;
            return decimal.Parse(pn.TONGTIEN.ToString());
        }

        public bool them(PHIEU_NHAP pn, List<CT_PHIEU_NHAP> ctPNs)
        {
            if (ctPNs.Count == 0)
                return false;
            try
            {
                db.PHIEU_NHAPs.InsertOnSubmit(pn);
                db.SubmitChanges();
                foreach (CT_PHIEU_NHAP ct in ctPNs)
                    db.CT_PHIEU_NHAPs.InsertOnSubmit(ct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string phatSinhMaTuDong()
        {
            return FunctionStatic.phatSinhMaSP("PN", 20, timMaxIndex() + 1);
        }

        private int timMaxIndex()
        {
            int max = 0;
            int g;
            foreach (PHIEU_NHAP sp in db.PHIEU_NHAPs)
            {
                g = int.Parse(sp.MAPN.Substring(2));
                if (g > max)
                    max = g;
            }

            return max;
        }
    }
}