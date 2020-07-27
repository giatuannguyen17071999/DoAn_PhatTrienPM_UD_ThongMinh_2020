using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_PhieuNhap_Print
    {
        public const int COL_MAPN = 0;
        public const int COL_MASP = 1;

        private string maPN, maSP, tenSP, giaNhap;
        private int? slNhap;
        private DateTime? ngayNhap;

        [DisplayName("Mã Phiếu")]
        public string MaPN { get => maPN; set => maPN = value; }
        [DisplayName("Mã Sản Phẩm")]
        public string MaSP { get => maSP; set => maSP = value; }
        [DisplayName("Tên Sản Phẩm")]
        public string TenSP { get => tenSP; set => tenSP = value; }
        [DisplayName("Giá Nhập")]
        public string GiaNhap { get => giaNhap; set => giaNhap = value; }
        [DisplayName("Số Lượng")]
        public int? SlNhap { get => slNhap; set => slNhap = value; }
        [DisplayName("Ngày Nhập")]
        public DateTime? NgayNhap { get => ngayNhap; set => ngayNhap = value; }
    }
}
