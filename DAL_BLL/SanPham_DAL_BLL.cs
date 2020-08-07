using DTO;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class SanPham_DAL_BLL
    {
        public enum ETimKim
        {
            TIM_GIA_DUOI,
            TIM_GIA_TREN,
            TIM_THEO_MA,
            TIM_THEM_TEN
        }

        private QL_MBTBDTDataContext db;

        public SanPham_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<SanPham_DTO> latTaCa()
        {
            List<SanPham_DTO> result = new List<SanPham_DTO>();
            foreach (SanPham sp in db.SanPhams.Where(n => n.ISDELETE == false))
                result.Add(new SanPham_DTO
                {
                    MaSP = sp.MaSP.Trim(),
                    MaLoai = sp.MaLoai,
                    TenSP = sp.TenSP,
                    Hinh = sp.Hinh,
                    GiaBan = sp.GiaBan,
                    CreateDate = sp.CreatedDate,
                    MoTa = sp.Description,
                    SlTon = sp.SL_TON
                });

            return result;
        }

        public List<SanPham_DTO> timKiemSanPham(ETimKim eTim, string key)
        {
            List<SanPham_DTO> result = new List<SanPham_DTO>();
            List<SanPham> list = new List<SanPham>();
            switch (eTim)
            {
                case ETimKim.TIM_GIA_DUOI:
                    {
                        int gia;
                        int.TryParse(key, out gia);
                        if (gia == 0)
                            list = null;
                        else
                            list = db.SanPhams.Where(n => n.GiaBan <= gia && n.ISDELETE == false).ToList();
                        break;
                    }
                case ETimKim.TIM_GIA_TREN:
                    {
                        decimal gia;
                        decimal.TryParse(key, out gia);
                        if (gia == 0)
                            list = null;
                        else
                            list = db.SanPhams.Where(n => n.GiaBan >= gia && n.ISDELETE == false).ToList();
                        break;
                    }
                case ETimKim.TIM_THEO_MA:
                    {
                        list = db.SanPhams.Where(n => n.MaSP.Equals(key) && n.ISDELETE == false).ToList();
                        break;
                    }
                case ETimKim.TIM_THEM_TEN:
                    {
                        list = db.SanPhams.Where(n => n.TenSP.Contains(key) && n.ISDELETE == false).ToList();
                        break;
                    }
            }
            if (list == null)
                return null;
            foreach (SanPham sp in list)
                result.Add(new SanPham_DTO
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    GiaBan = sp.GiaBan,
                    Hinh = sp.Hinh,
                    MaLoai = sp.MaLoai,
                    MoTa = sp.Description,
                    SlTon = sp.SL_TON,
                    CreateDate = sp.CreatedDate
                });

            return result;
        }

        public void locTiep_TheoGia(ref List<SanPham_DTO> list ,int cGia)
        {
            if (cGia == 0)
                list = list.Where(n => n.GiaBan < 2000000).ToList();
            else if (cGia == 1)
                list = list.Where(n => n.GiaBan < 5000000).ToList();
            else list = list.Where(n => n.GiaBan >= 5000000).ToList();
        }

        public void locTiep_TheoTheLoai(ref List<SanPham_DTO> list, int maLoai)
        {
            list = list.Where(n => n.MaLoai == maLoai).ToList();
        }

        public List<SanPham_DTO> latTaCa(int maLoai)
        {
            List<SanPham_DTO> result = new List<SanPham_DTO>();
            foreach (SanPham sp in db.SanPhams.Where(n => n.MaLoai.Equals(maLoai) && n.ISDELETE == false))
                result.Add(new SanPham_DTO
                {
                    MaSP = sp.MaSP.Trim(),
                    MaLoai = sp.MaLoai,
                    TenSP = sp.TenSP,
                    Hinh = sp.Hinh,
                    GiaBan = sp.GiaBan,
                    CreateDate = sp.CreatedDate,
                    MoTa = sp.Description,
                    SlTon = sp.SL_TON
                });

            return result;
        }

        public List<SanPham_DTO> locTheoDanhMuc(int maDM)
        {
            List<SanPham_DTO> result = new List<SanPham_DTO>();
            var list = db.SanPhams.Where(n => n.LoaiSP.MaDM.Equals(maDM) && n.ISDELETE == false);
            foreach (SanPham sp in list)
                result.Add(new SanPham_DTO
                {
                    MaSP = sp.MaSP.Trim(),
                    MaLoai = sp.MaLoai,
                    TenSP = sp.TenSP,
                    Hinh = sp.Hinh,
                    GiaBan = sp.GiaBan,
                    CreateDate = sp.CreatedDate,
                    MoTa = sp.Description,
                    SlTon = sp.SL_TON
                });

            return result;
        }

        public SanPham_DTO laySanPham(string maSP)
        {
            var sp = db.SanPhams.FirstOrDefault(n => n.MaSP.Equals(maSP) && n.ISDELETE == false);
            if (sp == null)
                return null;
            return new SanPham_DTO
            {
                MaSP = sp.MaSP.Trim(),
                MaLoai = sp.MaLoai,
                TenSP = sp.TenSP,
                Hinh = sp.Hinh,
                GiaBan = sp.GiaBan,
                CreateDate = sp.CreatedDate,
                MoTa = sp.Description,
                SlTon = sp.SL_TON
            };
        }

        public EStatus them(SanPham sp)
        {
            SanPham spTim = db.SanPhams.FirstOrDefault(n => n.MaSP.Equals(sp.MaSP));
            if (spTim != null)
                return EStatus.TRUNG_KHOA;
            spTim = db.SanPhams.FirstOrDefault(n => n.TenSP.Equals(sp.TenSP));
            if (spTim != null)
                return EStatus.TRUNG_TEN;
            db.SanPhams.InsertOnSubmit(sp);
            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

        public bool xoa(string maSP)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(n => n.MaSP.Equals(maSP));
            if (sp == null)
                return false;
            sp.ISDELETE = true;
            db.SubmitChanges();
            if (!sp.Hinh.Equals(FunctionStatic.imgNotFound))
                FunctionStatic.xoaHinh(sp.Hinh);
            return true;
        }

        public EStatus sua(SanPham sp)
        {
            SanPham spTim = db.SanPhams.FirstOrDefault(n => n.MaSP.Equals(sp.MaSP));
            if (spTim == null)
                return EStatus.THAT_BAI;

            spTim.TenSP = sp.TenSP;
            spTim.SL_TON = sp.SL_TON;
            spTim.GiaBan = sp.GiaBan;
            spTim.MaLoai = sp.MaLoai;
            spTim.CreatedDate = sp.CreatedDate;
            spTim.Description = sp.Description;
            spTim.ISDELETE = sp.ISDELETE;

            if (!sp.Hinh.Equals(FunctionStatic.imgNotFound))
                spTim.Hinh = FunctionStatic.capNhatHinh(spTim.Hinh, sp.Hinh);

            db.SubmitChanges();

            return EStatus.THANH_CONG;
        }

        public string phatSinhMaTuDong()
        {
            return FunctionStatic.phatSinhMaSP("SP", 8, timMaxIndex() + 1);
        }

        private int timMaxIndex()
        {
            int max = 0;
            int g;
            foreach(SanPham sp in db.SanPhams)
            {
                g = int.Parse(sp.MaSP.Substring(2));
                if (g > max)
                    max = g;
            }

            return max;
        }
    }
}