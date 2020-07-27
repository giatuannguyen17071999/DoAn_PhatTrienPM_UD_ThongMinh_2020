using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_PhieuNhap_DTO
    {
        private int maPN;
        private int? slNhap;
        private string maSP;
        private decimal? giaNhap;

        [DisplayName("Mã Phiếu Nhập")]
        public int MaPN { get => maPN; set => maPN = value; }
        [DisplayName("Số Lượng Nhập")]
        public int? SlNhap { get => slNhap; set => slNhap = value; }
        [DisplayName("Mã Sản Phẩm")]
        public string MaSP { get => maSP; set => maSP = value; }
        [DisplayName("Giá Nhập")]
        public decimal? GiaNhap { get => giaNhap; set => giaNhap = value; }
    }
}
