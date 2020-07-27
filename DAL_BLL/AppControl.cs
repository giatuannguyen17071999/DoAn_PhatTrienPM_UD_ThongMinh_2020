using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class AppControl
    {
        private SanPham_DAL_BLL spDAL_BLL;
        private LoaiSP_DAL_BLL loaiDAL_BLL;
        private NhomQuyen_DAL_BLL nhQuyenDAL_BLL;
        private Quyen_DAL_BLL qDAL_BLL;
        private PhanQuyen_DAL_BLL pqDAL_BLL;
        private PhanNhanVienVaoNhomQuyen_DAL_BLL pnvNhomQuyenDAL_BLL;

        public AppControl()
        {
            spDAL_BLL = new SanPham_DAL_BLL();
            loaiDAL_BLL = new LoaiSP_DAL_BLL();
            nhQuyenDAL_BLL = new NhomQuyen_DAL_BLL();
            qDAL_BLL = new Quyen_DAL_BLL();
            pqDAL_BLL = new PhanQuyen_DAL_BLL();
            pnvNhomQuyenDAL_BLL = new PhanNhanVienVaoNhomQuyen_DAL_BLL();
        }

        public PhanNhanVienVaoNhomQuyen_DAL_BLL getPnvNhomQuyenDAL_BLL()
        {
            return pnvNhomQuyenDAL_BLL;
        }

        public PhanQuyen_DAL_BLL getPqDAL_BLL()
        {
            return pqDAL_BLL;
        }

        public Quyen_DAL_BLL getQDAL_BLL()
        {
            return qDAL_BLL;
        }

        public NhomQuyen_DAL_BLL getNhQuyenDAL_BLL()
        {
            return nhQuyenDAL_BLL;
        }

        public SanPham_DAL_BLL getSpDAL_BLL()
        {
            return spDAL_BLL;
        }

        public LoaiSP_DAL_BLL getLoaiDAL_BLL()
        {
            return loaiDAL_BLL;
        }
    }
}
