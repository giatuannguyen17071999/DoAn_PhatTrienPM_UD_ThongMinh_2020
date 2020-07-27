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

        #region Phần của Việt

        public PHANQUYEN layTheoKhoaChinh(string maNhom, string maQuyen)
        {
            return db.PHANQUYENs.FirstOrDefault(n => n.MANHOM.Equals(maNhom) && n.MAQUYEN.Equals(maQuyen));
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

        #endregion

        #region Phần Của Long

        public List<PHANQUYEN> layTheoQuyen(string ma)
        {
            return db.PHANQUYENs.Where(x => x.MAQUYEN.Equals(ma)).ToList();
        }



        public bool GetById(string mq)
        {
            return db.PHANQUYENs.Any(x => x.MAQUYEN.Equals(mq));
        }
        public bool xoaPhanQuyen(List<PHANQUYEN> q)
        {
            try
            {
                db.PHANQUYENs.DeleteAllOnSubmit(q);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
