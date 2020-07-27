using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        public const int COL_USERNAME = 0;

        private string userName,
            pass,
            tenNhanVien,
            email;
        private bool? hoatDong;

        [DisplayName("Tên Đăng Nhập")]
        public string UserName { get => userName; set => userName = value; }
        [DisplayName("Mật Khẩu")]
        public string Pass { get => pass; set => pass = value; }
        [DisplayName("Tên Nhân Viên")]
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        [DisplayName("Email")]
        public string Email { get => email; set => email = value; }
        [DisplayName("Hoạt Động")]
        public bool? HoatDong { get => hoatDong; set => hoatDong = value; }
    }
}
