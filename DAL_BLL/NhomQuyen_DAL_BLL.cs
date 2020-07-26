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

        public void lamMoiTaiTatCaQuyen_choNhom()
        {
            PHANQUYEN pq;
            var nhoms = db.NHOMQUYENs;
            var quyens = db.QUYENs;
            foreach (NHOMQUYEN n in nhoms)
                foreach (QUYEN q in quyens)
                {
                    pq = db.PHANQUYENs.FirstOrDefault(t => t.MANHOM.Equals(n.MANHOM) && t.MAQUYEN.Equals(q.MAQUYEN));
                    if (pq == null)
                    {
                        pq = new PHANQUYEN();
                        pq.MANHOM = n.MANHOM;
                        pq.MAQUYEN = q.MAQUYEN;
                        pq.COQUYEN = false;
                        db.PHANQUYENs.InsertOnSubmit(pq);
                    }
                }    

            db.SubmitChanges();
        }

        public string insert(string pMaNhom,string pTenNhom,string pGhiChu)
        {
            if (db.NHOMQUYENs.Any(nq => nq.MANHOM == pMaNhom))
                return "Đã tồn tại nhóm quyền có mã này !";
            else
            {
                try
                {
                    NHOMQUYEN nq = new NHOMQUYEN();
                    nq.MANHOM = pMaNhom;
                    nq.TENNHOM = pTenNhom;
                    nq.GHICHU = pGhiChu;
                    db.NHOMQUYENs.InsertOnSubmit(nq);
                    db.SubmitChanges();
                    return "Thêm thành công !";
                }
                catch(Exception e)
                {
                    return "Thêm thất bại !\nLoi: " + e.Message; 
                }
            }
        }
        public string edit(string pMaNhom, string pTenNhom, string pGhiChu)
        {
            if (!db.NHOMQUYENs.Any(n => n.MANHOM == pMaNhom))
                return "Không tồn tại nhóm quyền có mã này !";
            NHOMQUYEN nq = db.NHOMQUYENs.FirstOrDefault(n => n.MANHOM == pMaNhom);
            try
            {
                nq.TENNHOM = pTenNhom;
                nq.GHICHU = pGhiChu;
                db.SubmitChanges();
                return "Cập nhật thành công !";
            }
            catch (Exception e)
            {
                return "Cập nhật thất bại !\nLoi: " + e.Message;
            }
        }

        public string delete(string pMaNhom)
        {
            string references = beingUseInAnotherTable(pMaNhom);
            NHOMQUYEN nq = db.NHOMQUYENs.FirstOrDefault(n => n.MANHOM == pMaNhom);
            if (nq == null)
                return "Không tồn tại nhóm quyền này trong bảng !";
            else if(!String.IsNullOrEmpty(references))
            {
                return references;
            }    
            else
            {
                try
                {
                    db.NHOMQUYENs.DeleteOnSubmit(nq);
                    db.SubmitChanges();
                    return "Xóa thành công !";
                }
                catch
                {
                    return "Xóa thất bại !";
                }
            }
        }
        private string beingUseInAnotherTable(string pMaNhom)
        {
            if (db.PHANQUYENs.Any(pq => pq.MANHOM == pMaNhom))
                return "Mã nhớm này đang được sử dụng trong bảng PHÂN QUYỀN, không thể XOÁ !";
            if(db.PHANNHANVIEN_VAONHOMQUYENs.Any(n => n.MANHOM == pMaNhom))
                return "Mã nhớm này đang được sử dụng trong bảng PHANNHANVIEN_VAONHOMQUYENs, không thể XOÁ !";
            return null;
        }


    }
}
