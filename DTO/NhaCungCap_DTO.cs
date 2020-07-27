using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        private string maNCC,
            tenNCC,
            diaChi;

        [DisplayName("Mã Nhà cung Cấp")]
        public string MaNCC { get => maNCC; set => maNCC = value; }
        [DisplayName("Tên Nhà Cung Cấp")]
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
