using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhomQuyen_DTO
    {
        public const int COL_MANHOM = 0;
        public const int COL_TENNHOM = 1;

        private string maNhom,
            tenNhom,
            ghiChu;

        [DisplayName("Mã Nhóm")]
        public string MaNhom { get => maNhom; set => maNhom = value; }
        [DisplayName("Tên Nhóm")]
        public string TenNhom { get => tenNhom; set => tenNhom = value; }
        [DisplayName("Ghi Chú")]
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public override string ToString()
        {
            return string.Format("[ {0} ]",tenNhom);
        }
    }
}
