using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        private int maKH;
        private string taiKhoan, matKhau, hoTen, gioiTinh, DienThoai, diaChi,email;
        private bool status;
        private DateTime ngaysinh;

        [DisplayName("Mã Khách Hàng")]
        public int MaKH { get => maKH; set => maKH = value; }
        [DisplayName("Tên Tài Khoản")]
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        [DisplayName("Mật Khẩu")]
        public string MatKhau { get => matKhau; set => matKhau = value; }
        [DisplayName("Họ Tên")]
        public string HoTen { get => hoTen; set => hoTen = value; }
        [DisplayName("Email")]
        public string Email { get => email; set => email = value; }
        [DisplayName("Giới Tính")]
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        [DisplayName("Điện Thoại")]
        public string DienThoai1 { get => DienThoai; set => DienThoai = value; }
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get => diaChi; set => diaChi = value; }
        [DisplayName("Trạng Thái")]
        public bool Status { get => status; set => status = value; }
        [DisplayName("Trạng Thái")]
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public override string ToString()
        {
            return string.Format("[maKH: {0}; tenKH: {1}; SDT: {2} ]", MaKH, HoTen, DienThoai);
        }
    }
}
