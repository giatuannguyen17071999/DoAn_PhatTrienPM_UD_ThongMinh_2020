using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class NhaCungCap_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public NhaCungCap_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<NhaCungCap_DTO> layTatCa()
        {
            List<NhaCungCap_DTO> result = new List<NhaCungCap_DTO>();
            foreach (NHACUNGCAP n in db.NHACUNGCAPs)
                result.Add(new NhaCungCap_DTO
                {
                    MaNCC = n.MANCC,
                    TenNCC = n.TENNCC,
                    DiaChi = n.DIACHI
                });

            return result;
        }
    }
}