using DTO;
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
            foreach (SanPham sp in db.SanPhams)
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
                            list = db.SanPhams.Where(n => n.GiaBan <= gia).ToList();
                        break;
                    }
                case ETimKim.TIM_GIA_TREN:
                    {
                        decimal gia;
                        decimal.TryParse(key, out gia);
                        if (gia == 0)
                            list = null;
                        else
                            list = db.SanPhams.Where(n => n.GiaBan >= gia).ToList();
                        break;
                    }
                case ETimKim.TIM_THEO_MA:
                    {
                        list = db.SanPhams.Where(n => n.MaSP.Equals(key)).ToList();
                        break;
                    }
                case ETimKim.TIM_THEM_TEN:
                    {
                        list = db.SanPhams.Where(n => n.TenSP.Contains(key)).ToList();
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

        public List<SanPham_DTO> latTaCa(int maLoai)
        {
            List<SanPham_DTO> result = new List<SanPham_DTO>();
            foreach (SanPham sp in db.SanPhams.Where(n => n.MaLoai.Equals(maLoai)))
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
            var list = db.SanPhams.Where(n => n.LoaiSP.MaDM.Equals(maDM));
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
    }
}