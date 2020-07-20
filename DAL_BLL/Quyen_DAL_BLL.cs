using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MyLibrary;

namespace DAL_BLL
{
    public class Quyen_DAL_BLL
    {
        private readonly QL_MBTBDTDataContext _db;

        public Quyen_DAL_BLL()
        {
            _db = new QL_MBTBDTDataContext();
        }



        #region Phần Của Long
        public IQueryable<Quyen_DTO> layTatCa()
        {
            return _db.QUYENs.Select(nv => new Quyen_DTO { MaQuyen = nv.MAQUYEN, TenQuyen = nv.TENQUYEN, GhiChu = nv.GHICHU });
        }
        public bool XoaQuyen(string mq)
        {
            var q = _db.QUYENs.SingleOrDefault(x => x.MAQUYEN == mq);
            if (q == null)
            {
                return false;
            }
            _db.QUYENs.DeleteOnSubmit(q);
            _db.SubmitChanges();
            return true;

        }

        public EStatus UpdateQuyen(Quyen_DTO qDto)
        {
            var nv = _db.QUYENs.SingleOrDefault(x => x.MAQUYEN == qDto.MaQuyen);
            if (nv == null) return EStatus.LOI;
            nv.MAQUYEN = qDto.MaQuyen;
            nv.TENQUYEN = qDto.TenQuyen;
            nv.GHICHU = qDto.GhiChu;
            _db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

        public EStatus AddQuyen(Quyen_DTO qDto)
        {
            try
            {

                _db.QUYENs.InsertOnSubmit(new QUYEN()
                {
                    MAQUYEN = qDto.MaQuyen,
                    TENQUYEN = qDto.TenQuyen,
                    GHICHU = qDto.GhiChu
                });
                _db.SubmitChanges();
                return EStatus.THANH_CONG;
            }
            catch (Exception)
            {
                return EStatus.LOI;
            }
        }
        #endregion
    }
}
