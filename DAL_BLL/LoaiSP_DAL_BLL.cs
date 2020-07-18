using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class LoaiSP_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public LoaiSP_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<LoaiSP_DTO> layTatCa()
        {
            List<LoaiSP_DTO> result = new List<LoaiSP_DTO>();
            foreach (LoaiSP l in db.LoaiSPs)
                result.Add(new LoaiSP_DTO
                {
                    MaLoai = l.MaLoai,
                    MaDM = l.MaDM,
                    TenLoaiSP = l.TenLoaiSP
                });

            return result;
        }

        public List<LoaiSP_DTO> layTatCa(int maDM)
        {
            List<LoaiSP_DTO> result = new List<LoaiSP_DTO>();
            foreach (LoaiSP l in db.LoaiSPs.Where(n => n.MaDM == maDM))
                result.Add(new LoaiSP_DTO
                {
                    MaLoai = l.MaLoai,
                    MaDM = l.MaDM,
                    TenLoaiSP = l.TenLoaiSP
                });

            return result;
        }
    }
}
