using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanQuyen_DTO
    {
        private string maNhom,
            maQuyen;
        private bool? coQuyen;

        [DisplayName("Mã Nhóm")]
        public string MaNhom { get => maNhom; set => maNhom = value; }
        [DisplayName("Mã Quyền")]
        public string MaQuyen { get => maQuyen; set => maQuyen = value; }
        [DisplayName("Có Quyền")]
        public bool? CoQuyen { get => coQuyen; set => coQuyen = value; }
    }
}
