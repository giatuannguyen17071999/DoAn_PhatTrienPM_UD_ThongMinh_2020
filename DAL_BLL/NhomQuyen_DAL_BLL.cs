using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class NhomQuyen_DAL_BLL
    {
        private QL_MBTBDTDataContext db;

        public NhomQuyen_DAL_BLL()
        {
            db = new QL_MBTBDTDataContext();
        }

        public List<NhomQuyen_DTO> layTatCa()
        {
            List<NhomQuyen_DTO> result = new List<NhomQuyen_DTO>();
            foreach (NHOMQUYEN nq in db.NHOMQUYENs)
                result.Add(new NhomQuyen_DTO
                {
                    MaNhom = nq.MANHOM,
                    TenNhom = nq.TENNHOM,
                    GhiChu = nq.GHICHU
                });

            return result;
        }

        public List<Quyen_DTO> layQuyenChoNhom(string maNhom, bool isQuyen)
        {
            List<Quyen_DTO> result = new List<Quyen_DTO>();
            var list = from q in db.QUYENs
                       join p in db.PHANQUYENs
                       on q.MAQUYEN equals p.MAQUYEN
                       where p.MANHOM.Equals(maNhom)
                       && p.COQUYEN == isQuyen
                       select q;
            foreach (QUYEN q in list)
                result.Add(new Quyen_DTO
                {
                    MaQuyen = q.MAQUYEN,
                    TenQuyen = q.TENQUYEN,
                    GhiChu = q.GHICHU
                });

            return result;
        }

        public void lamMoiTaiTatCaQuyen_CANTHAN()
        {
            var nhoms = db.NHOMQUYENs;
            var quyens = db.QUYENs;
            foreach (NHOMQUYEN n in nhoms)
                foreach (QUYEN q in quyens)
                    db.PHANQUYENs.InsertOnSubmit(new PHANQUYEN
                    {
                        MANHOM = n.MANHOM,
                        MAQUYEN = q.MAQUYEN,
                        COQUYEN = false
                    });

            db.SubmitChanges();
        }
    }
}
