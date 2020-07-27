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


        public string insert(string pMaNCC, string pTenNCC, string pDiaChi)
        {
            if (db.NHACUNGCAPs.Any(ncc => ncc.MANCC == pMaNCC))
                return "Đã tồn tại nhà cung cấp có mã này !";
            else
            {
                try
                {
                    NHACUNGCAP ncc = new NHACUNGCAP();
                    ncc.MANCC = pMaNCC;
                    ncc.TENNCC = pTenNCC;
                    ncc.DIACHI = pDiaChi;
                    db.NHACUNGCAPs.InsertOnSubmit(ncc);
                    db.SubmitChanges();
                    return "Thêm thành công !";
                }
                catch (Exception e)
                {
                    return "Thêm thất bại !\nLoi: " + e.Message;
                }
            }
        }
        public string edit(string pMaNCC, string pTenNCC, string pDiaChi)
        {
            if (!db.NHACUNGCAPs.Any(ncc => ncc.MANCC == pMaNCC))
                return "Không tồn tại nhà cung cấp có mã này !";
            NHACUNGCAP nhaCC = db.NHACUNGCAPs.FirstOrDefault(n => n.MANCC == pMaNCC);
            try
            {
                nhaCC.TENNCC = pTenNCC;
                nhaCC.DIACHI = pDiaChi;
                db.SubmitChanges();
                return "Cập nhật thành công !";
            }
            catch (Exception e)
            {
                return "Cập nhật thất bại !\nLoi: " + e.Message;
            }
        }

        public string delete(string pMaNCC)
        {
            string references = beingUseInAnotherTable(pMaNCC);
            NHACUNGCAP nhaCC = db.NHACUNGCAPs.FirstOrDefault(n => n.MANCC == pMaNCC);
            if (nhaCC == null)
                return "Không tồn tại nhà cung cấp này trong bảng !";
            else if (!String.IsNullOrEmpty(references))
            {
                return references;
            }
            else
            {
                try
                {
                    db.NHACUNGCAPs.DeleteOnSubmit(nhaCC);
                    db.SubmitChanges();
                    return "Xóa thành công !";
                }
                catch
                {
                    return "Xóa thất bại !";
                }
            }
        }
        private string beingUseInAnotherTable(string pMaNCC)
        {
            if (db.PHIEU_NHAPs.Any(pn => pn.NHACC == pMaNCC))
                return "Mã nhớm này đang được sử dụng trong bảng PHIEU_NHAP, không thể XOÁ !";
            return null;
        }


    }
}