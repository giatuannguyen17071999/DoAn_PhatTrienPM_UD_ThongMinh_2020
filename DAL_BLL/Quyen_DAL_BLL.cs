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
        private PhanQuyen_DAL_BLL _datapq;
        public Quyen_DAL_BLL()
        {
            _db = new QL_MBTBDTDataContext();
            _datapq = new PhanQuyen_DAL_BLL();
        }



        #region Phần Của Long
        public IQueryable<Quyen_DTO> layTatCa()
        {
            return _db.QUYENs.Select(nv => new Quyen_DTO { MaQuyen = nv.MAQUYEN, TenQuyen = nv.TENQUYEN, GhiChu = nv.GHICHU });
        }
        public EStatus XoaQuyen(string mq)
        {

            var nv = _db.QUYENs.SingleOrDefault(x => x.MAQUYEN.Equals(mq));
            if (nv == null)
            {
                return EStatus.THAT_BAI;
            }

            var layNhomQuyen = _datapq.layTheoQuyen(mq);
            if (layNhomQuyen.Any())
            {
                if (!_datapq.xoaPhanQuyen(layNhomQuyen))
                {
                    return EStatus.THAT_BAI;
                }
            }
            _db.QUYENs.DeleteOnSubmit(nv);

            return EStatus.THANH_CONG;


        }

        public void SaveChanged()
        {
            _db.SubmitChanges();
        }
        public bool GetById(string mq)
        {
            return _db.QUYENs.Any(t => t.MAQUYEN.Equals(mq));
        }
        public EStatus UpdateQuyen(Quyen_DTO qDto)
        {
            var nv = _db.QUYENs.SingleOrDefault(x => x.MAQUYEN == qDto.MaQuyen);
            if (nv == null) return EStatus.LOI;
            nv.MAQUYEN = qDto.MaQuyen;
            nv.TENQUYEN = qDto.TenQuyen;
            nv.GHICHU = qDto.GhiChu;

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
