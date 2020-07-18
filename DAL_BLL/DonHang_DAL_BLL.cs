using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DonHang_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public DonHang_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public DonHang them(DonHang dh )
        {
            db.DonHangs.InsertOnSubmit(dh);
            db.SubmitChanges();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DonHangs);
            return dh;
        }
    }
}