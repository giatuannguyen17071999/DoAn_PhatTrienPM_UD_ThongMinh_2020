using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DanhMuc_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public DanhMuc_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<DanhMuc_DTO> layTatCa()
        {
            List<DanhMuc_DTO> result = new List<DanhMuc_DTO>();
            foreach (DanhMuc dm in db.DanhMucs.Where(n => n.ISDELETE != true))
                result.Add(new DanhMuc_DTO
                {
                    MaDM = dm.MaDM,
                    TenDM = dm.TenDM
                });

            return result;
        }
        public IQueryable<DanhMuc> layTatCaDanhMuc()
        {
            return from dm in db.DanhMucs select dm;
        }
        public DanhMuc DanhMucTheoMa(int MaDM)
        {
            DanhMuc dm;
            return dm = db.DanhMucs.Where(m => m.MaDM == MaDM).FirstOrDefault();
        }
        public bool XoaDanhMuc(String MaDM)
        {
            DanhMuc dm = db.DanhMucs.Where(m => m.MaDM.Equals(MaDM)).FirstOrDefault();
            if (dm != null)
            {
                dm.ISDELETE = true;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool SuaDanhMuc(String MaDM, String TenDanhMuc)
        {

            DanhMuc dm = db.DanhMucs.Where(m => m.MaDM.Equals(MaDM)).FirstOrDefault();
            if (dm != null)
            {
                if (TimTenTrung(TenDanhMuc) == 1)
                    return false;
                dm.TenDM = TenDanhMuc;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool ThemDanhMuc(String TenDanhMuc)
        {
            if (TimTenTrung(TenDanhMuc) == 1)
            {
                DanhMuc dm = db.DanhMucs.FirstOrDefault(n => n.TenDM.Equals(TenDanhMuc));
                dm.ISDELETE = false;
                db.SubmitChanges();
                return true;
            }
            else
            {
                DanhMuc dm = new DanhMuc();
                dm.TenDM = TenDanhMuc;
                dm.ISDELETE = false;
                db.DanhMucs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
        }
        private int TimTenTrung(String TenDanhMuc)
        {
            String tenDanhMuc = TenDanhMuc.Trim();
            DanhMuc dm = db.DanhMucs.Where(n => n.TenDM.Equals(tenDanhMuc)).FirstOrDefault();
            if (dm != null)
                return 1;

            return 0;
        }
    }
}
