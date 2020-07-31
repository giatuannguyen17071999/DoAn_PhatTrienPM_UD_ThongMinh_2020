using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class LoaiSP_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public LoaiSP_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<LoaiSP_DTO> layTatCa()
        {
            List<LoaiSP_DTO> result = new List<LoaiSP_DTO>();
            foreach (LoaiSP l in db.LoaiSPs.Where(n => n.ISDELETE != true))
                result.Add(new LoaiSP_DTO
                {
                    MaLoai = l.MaLoai,
                    MaDM = l.MaDM,
                    TenLoaiSP = l.TenLoaiSP
                });

            return result;
        }

        public List<LoaiSP_DTO> layTatCa(int maDM)
        {
            List<LoaiSP_DTO> result = new List<LoaiSP_DTO>();
            foreach (LoaiSP l in db.LoaiSPs.Where(n => n.MaDM == maDM && n.ISDELETE != true))
                result.Add(new LoaiSP_DTO
                {
                    MaLoai = l.MaLoai,
                    MaDM = l.MaDM,
                    TenLoaiSP = l.TenLoaiSP
                });

            return result;
        }

        public IQueryable<LoaiSP> layTatCaLoaiSP()
        {
            return from lsp in db.LoaiSPs where lsp.ISDELETE != true select lsp;
        }

        public LoaiSP LoaiSanPhamTheoMaLoaiSP(int MaLoaiSP)
        {
            LoaiSP lsp;
            return lsp = db.LoaiSPs.Where(m => m.MaLoai == MaLoaiSP).FirstOrDefault();
        }
        public bool XoaLoaiSanPham(String MaLoaiSP)
        {
            LoaiSP lsp = db.LoaiSPs.Where(m => m.MaLoai.Equals(MaLoaiSP)).FirstOrDefault();
            if (lsp != null)
            {
                lsp.ISDELETE = true;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool SuaLoaiSanPham(String MaLoaiSP, String TenLoaiSp, String MaDM)
        {

            LoaiSP lsp = db.LoaiSPs.Where(m => m.MaLoai.Equals(MaLoaiSP)).FirstOrDefault();
            if (lsp != null)
            {
                if (TimTenTrung(TenLoaiSp) == 1)
                    return false;
                lsp.TenLoaiSP = TenLoaiSp;
                lsp.MaDM = int.Parse(MaDM);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool ThemLoaiSanPham(String TenLoaiSanPham, String MaDM)
        {
            if (TimTenTrung(TenLoaiSanPham) == 1)
            {
                LoaiSP lsp = db.LoaiSPs.FirstOrDefault(n => n.TenLoaiSP.Equals(TenLoaiSanPham));
                lsp.ISDELETE = false;
                db.SubmitChanges();
                return true;
            }
            else
            {
                LoaiSP lsp = new LoaiSP();
                lsp.TenLoaiSP = TenLoaiSanPham;
                lsp.MaDM = int.Parse(MaDM);
                lsp.ISDELETE = false;
                db.LoaiSPs.InsertOnSubmit(lsp);
                db.SubmitChanges();
                return true;
            }
        }
        private int TimTenTrung(String TenLoaiSanPham)
        {
            String tenloaisanpham = TenLoaiSanPham.Trim();
            LoaiSP lsp = db.LoaiSPs.Where(n => n.TenLoaiSP.Equals(tenloaisanpham)).FirstOrDefault();
            if (lsp != null)
                return 1;

            return 0;
        }
    }
}
