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
    public class KhachHang_DAL_BLL
    {
        private QL_MBTBDTDataContext db;
        private DonHang_DAL_BLL dbBill;
        public KhachHang_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
            dbBill = new DonHang_DAL_BLL();
        }

        #region Phần Của Việt

        public List<KhachHang_DTO> lay5KH_GanDay()
        {
            List<KhachHang_DTO> result = new List<KhachHang_DTO>();
            var list = db.KhachHangs.OrderByDescending(n => n.NGAYTAO).Take(5);
            foreach (KhachHang kh in list)
                result.Add(new KhachHang_DTO
                {
                    MaKH = kh.MaKH,
                    TaiKhoan = kh.TaiKhoan,
                    DiaChi = kh.DiaChi,
                    DienThoai1 = kh.DienThoai,
                    GioiTinh = kh.GioiTinh,
                    HoTen = kh.HoTen,
                    MatKhau = kh.MatKhau,
                    Status = kh.Status,
                    Email = kh.Email
                });

            return result;
        }

        public KhachHang_DTO layKhachHang(int maKH)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(n => n.MaKH.Equals(maKH));
            if (kh == null)
                return null;
            return new KhachHang_DTO
            {
                MaKH = kh.MaKH,
                TaiKhoan = kh.TaiKhoan,
                DiaChi = kh.DiaChi,
                DienThoai1 = kh.DienThoai,
                GioiTinh = kh.GioiTinh,
                HoTen = kh.HoTen,
                MatKhau = kh.MatKhau,
                Status = kh.Status,
                Email = kh.Email
            };
        }

        #endregion

        #region Phần Của Long
        public bool KiemTraDinhDangNgay(string s)
        {
            return DateTime.TryParseExact(s, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        }

        public List<KhachHang> LayKhachHangs()
        {
            return db.KhachHangs.ToList();
        }
        public EStatus XoaKhachHang(int id)
        {

            var kh = db.KhachHangs.SingleOrDefault(x => x.MaKH == id);
            if (kh == null)
            {
                return EStatus.THAT_BAI;
            }

            var layHoaDon = dbBill.LayDonHangs(id);
            if (layHoaDon.Any())
            {
                if (!dbBill.XoaHoaDon(layHoaDon))
                {
                    return EStatus.THAT_BAI;
                }
            }

            db.KhachHangs.DeleteOnSubmit(kh);

            return EStatus.THANH_CONG;

        }
        public void SaveChanged()
        {
            db.SubmitChanges();
        }
        public EStatus UpdateKhachHang(KhachHang_DTO khDto)
        {
            var kh = db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == khDto.TaiKhoan);
            if (kh == null) return EStatus.LOI;
            kh.TaiKhoan = khDto.TaiKhoan;
            kh.MatKhau = khDto.MatKhau;
            kh.Email = khDto.Email;
            kh.Status = khDto.Status;
            kh.HoTen = khDto.HoTen;
            kh.DiaChi = khDto.DiaChi;
            kh.DienThoai = khDto.DienThoai1;
            kh.GioiTinh = khDto.GioiTinh;
            kh.NGAYTAO = DateTime.Now;
            kh.NgaySinh = khDto.NgaySinh;
            return EStatus.THANH_CONG;
        }
        public bool GetById(string username)
        {
            return db.KhachHangs.Any(x => x.TaiKhoan.Trim().Equals(username.Trim()));
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
        public EStatus AddKhachHang(KhachHang_DTO khDto)
        {
            try
            {

                db.KhachHangs.InsertOnSubmit(new KhachHang()
                {
                    TaiKhoan = khDto.TaiKhoan,
                    MatKhau = khDto.MatKhau,
                    Email = khDto.Email,
                    Status = khDto.Status,
                    HoTen = khDto.HoTen,
                    DiaChi = khDto.DiaChi,
                    DienThoai = khDto.DienThoai1,
                    GioiTinh = khDto.GioiTinh,
                    NGAYTAO = DateTime.Now,
                    NgaySinh = khDto.NgaySinh
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