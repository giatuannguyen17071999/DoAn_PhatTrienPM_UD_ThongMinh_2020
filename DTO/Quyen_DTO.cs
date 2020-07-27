using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Quyen_DTO
    {
        public const int COL_MAQUYEN = 0;
        public const int COL_TENQUYEN = 1;

        private string maQuyen,
            tenQuyen,
            ghiChu;

        [DisplayName("Mã Quyền")]
        public string MaQuyen { get => maQuyen; set => maQuyen = value; }
        [DisplayName("Tên Quyền")]
        public string TenQuyen { get => tenQuyen; set => tenQuyen = value; }
        [DisplayName("Ghi Chú")]
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
