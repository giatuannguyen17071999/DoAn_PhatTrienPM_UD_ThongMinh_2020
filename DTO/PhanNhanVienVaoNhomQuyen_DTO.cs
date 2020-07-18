using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanNhanVienVaoNhomQuyen_DTO
    {
        public const int COL_USERNAME = 0;

        private string userName,
            maNhom,
            ghiChu;

        [DisplayName("Tên Đăng Nhập")]
        public string UserName { get => userName; set => userName = value; }
        [DisplayName("Mã Nhóm")]
        public string MaNhom { get => maNhom; set => maNhom = value; }
        [DisplayName("Ghi Chú")]
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
