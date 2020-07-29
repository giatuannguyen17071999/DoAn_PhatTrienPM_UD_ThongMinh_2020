using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DonHang_DAL_BLL
    {
        private QL_MBTBDTDataContext db;
        private CTDonHang_DAL_BLL dbBillDetail;
        public DonHang_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
            dbBillDetail = new CTDonHang_DAL_BLL();
        }

        #region Phần Của Việt

        public int taoView(int maDH)
        {
            string query = string.Format("ALTER VIEW V_CTHOADON_IN AS SELECT C.MaSP, S.TenSP, C.SoLuong, C.DonGia FROM SanPham S, CTDonHang C WHERE S.MaSP = C.MaSP AND MaDH = {0}", maDH);
            return db.ExecuteCommand(query);
        }

        public DonHang them(DonHang dh )
        {
            db.DonHangs.InsertOnSubmit(dh);
            return dh;
        }

        public decimal? layTongTien(int maDH)
        {
            DonHang dhTim = db.DonHangs.FirstOrDefault(n => n.MaDH.Equals(maDH));
            return dhTim == null ? -1 : dhTim.TONGTIEN;
        }

        public int layTongSoLuongCTSanPhamMua(int maDH)
        {
            int sl = 0;
            foreach (CTDonHang ct in db.CTDonHangs.Where(n => n.MaDH.Equals(maDH)))
                sl += int.Parse(ct.SoLuong.ToString());

            return sl;
        }

        public DonHang layDonHangCho()
        {
            return db.DonHangs.FirstOrDefault(n => n.DaThanhToan == false);
        }

        public bool xoa(int maDH)
        {
            _PublicStatic.clearCache(db);
            DonHang dhTim = db.DonHangs.FirstOrDefault(n => n.MaDH.Equals(maDH));
            if (dhTim == null)
                return false;
            db.DonHangs.DeleteOnSubmit(dhTim);
            db.SubmitChanges();
            return true;
        }

        public enum ELichSu
        {
            LICH_SU_NGAY,
            LICH_SU_THANG,
            LICH_SU_NAM,
            LICH_SU_TAT_CA
        }

        public List<DonHang_DTO> layLichSuGiaoDich(ELichSu eLich)
        {
            IQueryable<DonHang> list = null;
            switch (eLich)
            {
                case ELichSu.LICH_SU_NGAY:
                    list = from dh in db.DonHangs where dh.NgayDat.Day.Equals(DateTime.Now.Day) && dh.NgayDat.Month.Equals(DateTime.Now.Month) && dh.NgayDat.Year.Equals(DateTime.Now.Year) && dh.DaThanhToan == true select dh;
                    break;
                case ELichSu.LICH_SU_THANG:
                    list = from dh in db.DonHangs where dh.NgayDat.Month.Equals(DateTime.Now.Month) && dh.NgayDat.Year.Equals(DateTime.Now.Year) && dh.DaThanhToan == true select dh;
                    break;
                case ELichSu.LICH_SU_NAM:
                    list = from dh in db.DonHangs where dh.NgayDat.Year.Equals(DateTime.Now.Year) && dh.DaThanhToan == true select dh;
                    break;
                default:
                    list = from dh in db.DonHangs where dh.DaThanhToan == true select dh;
                    break;
            }

            List<DonHang_DTO> result = new List<DonHang_DTO>();
            foreach (DonHang dh in list)
                result.Add(new DonHang_DTO
                {
                    MaDH = dh.MaDH,
                    MaKH = int.Parse(dh.MaKH.ToString()),
                    DaThanhToan = dh.DaThanhToan,
                    NgayDat = dh.NgayDat,
                    NgayGiao = dh.NgayGiao,
                    TongTien = dh.TONGTIEN
                });

            return result;
        }

        public bool capNhatTrangThaiThanhToan(int maDH, bool isThanhToan)
        {
            DonHang dhTim = db.DonHangs.FirstOrDefault(n => n.MaDH.Equals(maDH));
            if (dhTim == null)
                return false;
            dhTim.DaThanhToan = isThanhToan;
            db.SubmitChanges();
            return true;
        }

        public bool them(DonHang dh, List<CTDonHang> ctHDs)
        {
            try
            {
                db.DonHangs.InsertOnSubmit(dh);
                db.SubmitChanges();
                foreach (CTDonHang ct in ctHDs)
                {
                    ct.MaDH = dh.MaDH;
                    db.CTDonHangs.InsertOnSubmit(ct);
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion


        #region Phần Của Long

        public bool XoaHoaDon(List<DonHang> lstDonHangs)
        {
            try
            {

                lstDonHangs.ForEach(x => dbBillDetail.xoa(x.MaDH));
                db.DonHangs.DeleteAllOnSubmit(lstDonHangs);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DonHang> LayDonHangs(int maKH)
        {
            return db.DonHangs.Where(x => x.MaKH == maKH).ToList();
        }
        #endregion
    }
}