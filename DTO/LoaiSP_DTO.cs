using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSP_DTO
    {
        private int maLoai;
        private int? maDM;
        private string tenLoaiSP;

        [DisplayName("Mã Loại")]
        public int MaLoai { get => maLoai; set => maLoai = value; }
        [DisplayName("Mã Danh Mục")]
        public int? MaDM { get => maDM; set => maDM = value; }
        [DisplayName("Tên Loại Sản Phẩm")]
        public string TenLoaiSP { get => tenLoaiSP; set => tenLoaiSP = value; }
    }
}
