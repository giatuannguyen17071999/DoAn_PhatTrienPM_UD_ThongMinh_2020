using DTO;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhanQuyen_DAL_BLL
    {
        private QL_MBTBDTDataContext db;
        
        public PhanQuyen_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public void them(PhanQuyen_DTO pQuyen)
        {
            db.PHANQUYENs.InsertOnSubmit(new PHANQUYEN
            {
                MANHOM = pQuyen.MaNhom,
                MAQUYEN = pQuyen.MaQuyen,
                COQUYEN = pQuyen.CoQuyen
            });
            db.SubmitChanges();
        }

        public EStatus capNhat(PhanQuyen_DTO pQuyen)
        {
            PHANQUYEN tim = db.PHANQUYENs.FirstOrDefault(n => n.MANHOM.Equals(pQuyen.MaNhom) && n.MAQUYEN.Equals(pQuyen.MaQuyen));
            if (tim == null)
                return EStatus.LOI;
            tim.COQUYEN = pQuyen.CoQuyen;
            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }
    }
}
