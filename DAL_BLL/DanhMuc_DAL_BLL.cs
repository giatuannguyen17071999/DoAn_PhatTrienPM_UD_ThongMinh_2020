using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DanhMuc_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public DanhMuc_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<DanhMuc_DTO> layTatCa()
        {
            List<DanhMuc_DTO> result = new List<DanhMuc_DTO>();
            foreach (DanhMuc dm in db.DanhMucs)
                result.Add(new DanhMuc_DTO
                {
                    MaDM = dm.MaDM,
                    TenDM = dm.TenDM
                });

            return result;
        }
    }
}
