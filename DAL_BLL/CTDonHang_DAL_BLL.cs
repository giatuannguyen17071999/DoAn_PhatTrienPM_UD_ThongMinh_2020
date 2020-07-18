using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class CTDonHang_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public CTDonHang_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public bool them(CTDonHang ctDon)
        {
            CTDonHang ctTim = db.CTDonHangs.FirstOrDefault(n => n.MaDH.Equals(ctDon.MaDH) && n.MaSP.Equals(ctDon.MaSP));
            if (ctTim != null)
                return false;
            db.CTDonHangs.InsertOnSubmit(ctDon);
            db.SubmitChanges();
            return true;
        }
    }
}
