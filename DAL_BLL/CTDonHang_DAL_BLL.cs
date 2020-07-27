using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class CTDonHang_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public CTDonHang_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public bool them(CTDonHang ctDon)
        {
            var list = db.CTDonHangs.ToList();
            CTDonHang ctTim = db.CTDonHangs.FirstOrDefault(n => n.MaDH.Equals(ctDon.MaDH) && n.MaSP.Equals(ctDon.MaSP));
            if (ctTim != null)
                return false;

            db.CTDonHangs.InsertOnSubmit(ctDon);
            return true;
        }

        public int tangSoLuong(int maDH, string maSP)
        {
            CTDonHang ctTim = db.CTDonHangs.FirstOrDefault(n => n.MaDH.Equals(maDH) && n.MaSP.Equals(maSP));
            if (ctTim == null)
                return -1;
            ctTim.SoLuong += 1;
            db.SubmitChanges();
            return int.Parse(ctTim.SoLuong.ToString());
        }

        public int giamSoLuong(int maDH, string maSP)
        {
            CTDonHang ctTim = db.CTDonHangs.FirstOrDefault(n => n.MaDH.Equals(maDH) && n.MaSP.Equals(maSP));
            if (ctTim == null)
                return -1;
            int sl = int.Parse(ctTim.SoLuong.ToString());
            if (sl > 1)
            {
                ctTim.SoLuong -= 1;
                db.SubmitChanges();
                return int.Parse(ctTim.SoLuong.ToString());
            }
            return 1;
        }

        public bool xoa(int maDH, string maSP)
        {
            CTDonHang ctTim = db.CTDonHangs.FirstOrDefault(n => n.MaDH.Equals(maDH) && n.MaSP.Equals(maSP));
            if (ctTim == null)
                return false;
            db.CTDonHangs.DeleteOnSubmit(ctTim);
            db.SubmitChanges();
            _PublicStatic.clearCache(db);
            return true;
        }

        public void xoa(int maDH)
        {
                db.CTDonHangs.DeleteAllOnSubmit(db.CTDonHangs.Where(n => n.MaDH.Equals(maDH)));
                db.SubmitChanges();
        }

        public List<CTDonHang> laySanPhamDH_Mua(int maDH)
        {
            return db.CTDonHangs.Where(n => n.MaDH.Equals(maDH)).ToList();
        }
    }
}
