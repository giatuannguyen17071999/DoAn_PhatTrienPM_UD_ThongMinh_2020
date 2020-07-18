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
        public int? GiaBan { get => giaBan; set => giaBan = value; }
    }
}
