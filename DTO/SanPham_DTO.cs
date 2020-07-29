using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham_DTO
    {
        public const int COL_MASP = 0;
        public const int COL_MALOAI = 1;
        public const int COL_TENSP = 2;
        public const int COL_HINHANH = 3;
        public const int COL_GIABAN = 4;
        public const int COL_NGAYTAO = 5;
        public const int COL_MOTA = 6;
        public const int COL_SLTON = 7;
        public const int COL_STT = 8;

        private string maSP,
            tenSP,
            hinh,
            moTa;
        private DateTime? createDate;
        private int? slTon, maLoai, giaBan;

        [DisplayName("Mã Sản Phẩm")]
        public string MaSP { get => maSP; set => maSP = value; }
        [DisplayName("Tên Sản Phẩm")]
        public string TenSP { get => tenSP; set => tenSP = value; }
        [DisplayName("Hình")]
        public string Hinh { get => hinh; set => hinh = value; }
        [DisplayName("Mô Tả")]
        public string MoTa { get => moTa; set => moTa = value; }
        [DisplayName("Ngày Tạo")]
        public DateTime? CreateDate { get => createDate; set => createDate = value; }
        [DisplayName("Số Lượng Tồn")]
        public int? SlTon { get => slTon; set => slTon = value; }
        [DisplayName("Mã Loại")]
        public int? MaLoai { get => maLoai; set => maLoai = value; }
        [DisplayName("Giá Bán")]
        public int? GiaBan { get => giaBan; set => giaBan = value; }
        public int STT { get => sTT; set => sTT = value; }

        public override string ToString()
        {
            return string.Format("[ maSP:{0}; tenSP:{1}; donGia:{2} ]", maSP, tenSP, giaBan);
        }

        private int sTT;
    }
}
