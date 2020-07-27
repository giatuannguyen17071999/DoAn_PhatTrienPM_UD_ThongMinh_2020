using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhMuc_DTO
    {
        private int maDM;
        private string tenDM;

        [DisplayName("Mã Danh Mục")]
        public int MaDM { get => maDM; set => maDM = value; }
        [DisplayName("Tên Danh Mục")]
        public string TenDM { get => tenDM; set => tenDM = value; }
    }
}