using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTDonHang_DTO
    {
        private int maDH, soLuong;
        private string maSP;
        private decimal? donGia;

        [DisplayName("Mã Khách Hàng")]
        public int MaDH { get => maDH; set => maDH = value; }
        [DisplayName("Số Lượng")]
        public int SoLuong { get => soLuong; set => soLuong = value; }
        [DisplayName("Mã Sản Phẩm")]
        public string MaSP { get => maSP; set => maSP = value; }
        [DisplayName("Đơn Giá")]
        public decimal? DonGia { get => donGia; set => donGia = value; }
    }
}
