using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHang_DTO
    {
        private int maDH, maKH;
        private DateTime? ngayGiao;
        private DateTime ngayDat;
        private bool? daThanhToan;
        private decimal? tongTien;

        [DisplayName("Mã Đơn Hàng")]
        public int MaDH { get => maDH; set => maDH = value; }
        [DisplayName("Mã Khách Hàng")]
        public int MaKH { get => maKH; set => maKH = value; }
        [DisplayName("Ngày Giao")]
        public DateTime? NgayGiao { get => ngayGiao; set => ngayGiao = value; }
        [DisplayName("Ngày Đặt")]
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }
        [DisplayName("Đã Thanh Toán")]
        public bool? DaThanhToan { get => daThanhToan; set => daThanhToan = value; }
        [DisplayName("Tổng Tiền")]
        public decimal? TongTien { get => tongTien; set => tongTien = value; }

        public override string ToString()
        {
            return string.Format("[ maDH: {0}; ngayDat: {1}; tongTien: {2} ]", maDH, ngayDat.ToString("dd/MM/yyyy") , tongTien);
        }
    }
}
