using DTO;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class CT_PhieuNhap_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public CT_PhieuNhap_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<CT_PhieuNhap_Print> layPhieuNhap_s(string maPN)
        {
            List<CT_PhieuNhap_Print> result = new List<CT_PhieuNhap_Print>();
            var list = from p in db.PHIEU_NHAPs
                       join c in db.CT_PHIEU_NHAPs
                       on p.MAPN equals c.MAPN
                       join s in db.SanPhams
                       on c.MASP equals s.MaSP
                       where p.MAPN.Equals(maPN)
                       select new { p.MAPN, s.MaSP, s.TenSP, c.SL_NHAP, c.GIANHAP, p.NGAYNHAP};

            foreach (var ct in list)
                result.Add(new CT_PhieuNhap_Print
                {
                    MaPN = ct.MAPN,
                    MaSP = ct.MaSP,
                    TenSP = ct.TenSP,
                    SlNhap = ct.SL_NHAP,
                    GiaNhap = string.Format("{0:N0} VND", ct.GIANHAP),
                    NgayNhap = ct.NGAYNHAP
                });

            return result;
        }

        public List<CT_PhieuNhap_Print> layPhieuNhap_s(PHIEU_NHAP pn, List<CT_PHIEU_NHAP> ctPhieuNhaps)
        {
            List<CT_PhieuNhap_Print> result = new List<CT_PhieuNhap_Print>();
            SanPham_DTO sp;
            SanPham_DAL_BLL spDAL_BLL = new SanPham_DAL_BLL();
            foreach (CT_PHIEU_NHAP ct in ctPhieuNhaps)
            {
                sp = spDAL_BLL.laySanPham(ct.MASP);

                result.Add(new CT_PhieuNhap_Print
                {
                    MaPN = pn.MAPN,
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    NgayNhap = pn.NGAYNHAP,
                    GiaNhap = string.Format("{0:N0}", ct.GIANHAP),
                    SlNhap = ct.SL_NHAP
                });
            }

            return result;
        }

        public EStatus them(CT_PHIEU_NHAP ctPN)
        {
            CT_PHIEU_NHAP ctTim = db.CT_PHIEU_NHAPs.FirstOrDefault(n => n.MAPN.Equals(ctPN.MAPN) && n.MASP.Equals(ctPN.MASP));
            if (ctTim != null)
                return EStatus.TRUNG_KHOA;
            db.CT_PHIEU_NHAPs.InsertOnSubmit(ctPN);
            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

        public bool xoa(string maPN, string maSP)
        {
            CT_PHIEU_NHAP ctTim = db.CT_PHIEU_NHAPs.FirstOrDefault(n => n.MAPN.Equals(maPN) && n.MASP.Equals(maSP));
            if (ctTim == null)
                return false;
            db.CT_PHIEU_NHAPs.DeleteOnSubmit(ctTim);
            db.SubmitChanges();
            return true;
        }

        public bool sua(CT_PHIEU_NHAP ct)
        {
            CT_PHIEU_NHAP ctTim = db.CT_PHIEU_NHAPs.FirstOrDefault(n => n.MAPN.Equals(ct.MAPN) && n.MASP.Equals(ct.MASP));
            if (ctTim == null)
                return false;
            ctTim.SL_NHAP = ct.SL_NHAP;
            ctTim.GIANHAP = ct.GIANHAP;
            db.SubmitChanges();
            return true;
        }
    }
}