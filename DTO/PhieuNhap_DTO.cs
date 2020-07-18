using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap_DTO
    {
        private string maPN,
                nhaCC;
        private DateTime? ngayNhap;
        private decimal? tongTien;

        [DisplayName("Mã Phiếu Nhập")]
        public string MaPN { get => maPN; set => maPN = value; }
        [DisplayName("Mã Nhà Cung Cấp")]
        public string NhaCC { get => nhaCC; set => nhaCC = value; }
        [DisplayName("Ngày Nhập")]
        public DateTime? NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        [DisplayName("Tổng Tiền")]
        public decimal? TongTien { get => tongTien; set => tongTien = value; }
    }
}