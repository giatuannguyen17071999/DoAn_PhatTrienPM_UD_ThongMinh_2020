using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL_BLL;
using MyLibrary;
using DTO;
using DevExpress.XtraBars;
using DevExpress.Utils;
using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy.frmPhatSinh;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmQuanLyPhieuNhapHang : DevExpress.XtraEditors.XtraForm
    {
        //Khai báo biến tại đây
        private NhaCungCap_DAL_BLL nCC_DAL_BLL;
        private SanPham_DAL_BLL sPham_DAL_BLL;
        private CT_PhieuNhap_DAL_BLL ctPN_DAL_BLL;
        private PhieuNhap_DAL_BLL pn_DAL_BLL;
        private int rowCTPNhapSelected;

        private PHIEU_NHAP pnTmp;
        private List<CT_PHIEU_NHAP> ctPhieuNhapsTmp;

        public frmQuanLyPhieuNhapHang()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhieuNhapHang_Load(object sender, EventArgs e)
        {
            //Khởi tạo biến.
            nCC_DAL_BLL = new NhaCungCap_DAL_BLL();
            sPham_DAL_BLL = new SanPham_DAL_BLL();
            ctPN_DAL_BLL = new CT_PhieuNhap_DAL_BLL();
            pn_DAL_BLL = new PhieuNhap_DAL_BLL();
            rowCTPNhapSelected = -1;
            pnTmp = null;
            ctPhieuNhapsTmp = new List<CT_PHIEU_NHAP>();

            //load
            loadNhaCC();
            loadSanPham();
            loadCboxMaPN(null);
            loadCTPhieuNhap();
            bindding();

            //Event
            btnThemPhieuNhap.Click += BtnThemPhieuNhap_Click;
            cboxMaPhieu.SelectedIndexChanged += CboxMaPhieu_SelectedIndexChanged;
            cboxMaSanPham.SelectedIndexChanged += CboxMaSanPham_SelectedIndexChanged;
            btnThemSanPham.Click += BtnThemSanPham_Click;
            gvChiTietPN.PopupMenuShowing += GvChiTietPN_PopupMenuShowing;
            btnLuu.Click += bntLuu_Click;
        }

        private void CboxMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindding();
        }

        private void bindding()
        {
            var maSP = cboxMaSanPham.SelectedValue;
            if (maSP == null) return;
            SanPham_DTO sp = sPham_DAL_BLL.laySanPham(maSP.ToString());
            if (sp == null) return;
            tbDonGia.Text = sp.GiaBan == null ? "0" : sp.GiaBan.ToString();
            tbSoLuong.Text = sp.SlTon == null ? "0" : sp.SlTon.ToString();
        }

        private void GvChiTietPN_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow && pnTmp != null)
            {
                string maPN = FunctionStatic.layTextGridView(gvChiTietPN, e.HitInfo.RowHandle, 0);
                if (maPN.Equals(pnTmp.MAPN))
                {
                    popupMenuChiTietPN.ShowPopup(MousePosition);
                    rowCTPNhapSelected = e.HitInfo.RowHandle;
                    return;
                }
            }
            FunctionStatic.hienThiThongBaoLoi("Không thể sửa hoặc xóa!");
        }

        private void BtnThemSanPham_Click(object sender, EventArgs e)
        {
            if (pnTmp == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Chưa có phiếu nhập nào đang chờ!");
                return;
            }

            var maPN = cboxMaPhieu.SelectedValue;
            if (maPN == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Mã phiếu nhập không được để trống!");
                return;
            }
            if (!maPN.ToString().Equals(pnTmp.MAPN))
            {
                FunctionStatic.hienThiThongBaoLoi("Phiếu nhập này đã được lưu, không thêm chi tiết được!");
                return;
            }

            var maSP = cboxMaSanPham.SelectedValue;
            if (maPN == null || maSP == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Du Lieu Nhap Chua Hop Le");
                return;
            }

            string strSoLuong = tbSoLuong.Text,
                strGiaNhap = tbDonGia.Text;

            if (string.IsNullOrEmpty(strSoLuong) || string.IsNullOrEmpty(strGiaNhap))
            {
                FunctionStatic.hienThiThongBaoLoi("kiểm Tra lại số lượng và đơn giá nhập");
                return;
            }

            int slNhap = int.Parse(strSoLuong);
            decimal giaNhap = decimal.Parse(strGiaNhap);

            string mess = string.Format("Xác nhận thêm chi tiết phiếu cho sản phẩm có mã[ {0} ] vào phiếu có mã [ {1} ]", maSP.ToString(), maPN.ToString());
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo(mess);
            if (res == DialogResult.No)
                return;

            CT_PHIEU_NHAP ctPN = new CT_PHIEU_NHAP();
            ctPN.MAPN = maPN.ToString();
            ctPN.MASP = maSP.ToString();
            ctPN.SL_NHAP = slNhap;
            ctPN.GIANHAP = giaNhap;

            bool isThem = ctPhieuNhapsTmp.FirstOrDefault(n => n.MAPN.Equals(ctPN.MAPN) && n.MASP.Equals(ctPN.MASP)) == null;
            if (!isThem)
            {
                FunctionStatic.hienThiThongBaoLoi("Thêm Phiếu Nhập Không thành công!");
                return;
            }

            //them phieu vao danh sach temp
            ctPhieuNhapsTmp.Add(ctPN);
            //cap nhat tong tien
            pnTmp.TONGTIEN = decimal.Parse(pnTmp.TONGTIEN.ToString()) + (ctPN.SL_NHAP * ctPN.GIANHAP);

            FunctionStatic.hienThiThongBaoThanhCong("Thêm phiếu nhập thành công");
            loadCTPhieuNhap();
        }

        private void CboxMaPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCTPhieuNhap();
        }

        private void loadCTPhieuNhap()
        {
            var maPN = cboxMaPhieu.SelectedValue;
            if (maPN == null) return;
            if (pnTmp == null || !pnTmp.MAPN.Equals(maPN.ToString()))
            {
                dgvChiTietPN.DataSource = ctPN_DAL_BLL.layPhieuNhap_s(maPN.ToString());
                decimal tongTien = pn_DAL_BLL.layTongTien(maPN.ToString());
                tbTongTien.Text = string.Format("{0:N0} VND", tongTien);
            }
            else
            {
                dgvChiTietPN.DataSource = null;
                dgvChiTietPN.DataSource = ctPN_DAL_BLL.layPhieuNhap_s(pnTmp, ctPhieuNhapsTmp);
                decimal tongTien = pnTmp.TONGTIEN == null ? 0 : decimal.Parse(pnTmp.TONGTIEN.ToString());
                tbTongTien.Text = string.Format("{0:N0} VND", tongTien);
            }
        }

        private void BtnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            if (pnTmp != null)
            {
                FunctionStatic.hienThiThongBaoLoi("Có phiếu nhập đang cần chờ sử lý! Thêm không thành");
                return;
            }

            tbMaPhieuNhap.Text = pn_DAL_BLL.phatSinhMaTuDong();
            string maPN = tbMaPhieuNhap.Text;
            if (string.IsNullOrEmpty(maPN))
            {
                FunctionStatic.hienThiThongBaoLoi("Mã PN khác rỗng");
                return;
            }

            var maNCC = cboxMaNhaCC.SelectedValue;
            if (maNCC == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Chưa có nhà cung cấp!");
                return;
            }

            DateTime ngayNhap = dtpNgayNhap.Value;

            PHIEU_NHAP pn = new PHIEU_NHAP();
            pn.MAPN = maPN;
            pn.NHACC = maNCC.ToString();
            pn.NGAYNHAP = ngayNhap;
            pn.TONGTIEN = 0;

            pnTmp = pn;

            FunctionStatic.hienThiThongBaoThanhCong("Có 1 phiếu nhập đang chờ!");

            lbPhieuNhapCho.Text = "Phiếu Chờ: "+pn.MAPN + "\n NHẤP ĐỂ XÓA";
            lbPhieuNhapCho.Visible = true;
            List<PhieuNhap_DTO> dataSource = cboxMaPhieu.DataSource as List<PhieuNhap_DTO>;
            dataSource.Add(new PhieuNhap_DTO
            {
                MaPN = pn.MAPN,
                NgayNhap = pn.NGAYNHAP,
                NhaCC = pn.NHACC,
                TongTien = pn.TONGTIEN
            });
            cboxMaPhieu.DataSource = null;
            cboxMaPhieu.DisplayMember = "maPN";
            cboxMaPhieu.ValueMember = "maPN";
            cboxMaPhieu.DataSource = dataSource;
            cboxMaPhieu.SelectedValue = maPN;
        }

        private void loadNhaCC()
        {
            cboxMaNhaCC.DataSource = nCC_DAL_BLL.layTatCa();
            cboxMaNhaCC.DisplayMember = "TenNCC";
            cboxMaNhaCC.ValueMember = "MaNCC";
        }

        private void loadSanPham()
        {
            cboxMaSanPham.DataSource = sPham_DAL_BLL.latTaCa();
            cboxMaSanPham.DisplayMember = "MaSP";
            cboxMaSanPham.ValueMember = "MaSP";
        }

        private void loadCboxMaPN(string maPN)
        {
            cboxMaPhieu.DataSource = pn_DAL_BLL.layTatCa();
            cboxMaPhieu.DisplayMember = "MaPN";
            cboxMaPhieu.ValueMember = "MaPN";
            if (!string.IsNullOrEmpty(maPN))
                cboxMaPhieu.SelectedValue = maPN;
        }

        private void itemPopupXoaCTPN_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (rowCTPNhapSelected < 0)
                return;
            string maPN = FunctionStatic.layTextGridView(gvChiTietPN, rowCTPNhapSelected, 0),
                maSP = FunctionStatic.layTextGridView(gvChiTietPN, rowCTPNhapSelected, 1);
            string mess = string.Format("Xác nhận xóa [ {0} - {1} ]", maPN, maSP);
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo(mess);
            if (res == DialogResult.No)
                return;

            CT_PHIEU_NHAP isXoa = ctPhieuNhapsTmp.FirstOrDefault(n => n.MAPN.Equals(maPN) && n.MASP.Equals(maSP));
            if (isXoa == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Xóa Không thành công!");
                return;
            }

            decimal tongTien = decimal.Parse(pnTmp.TONGTIEN.ToString()) - (int.Parse(isXoa.SL_NHAP.ToString()) * decimal.Parse(isXoa.GIANHAP.ToString()));
            pnTmp.TONGTIEN = tongTien;
            ctPhieuNhapsTmp.Remove(isXoa);

            FunctionStatic.hienThiThongBaoThanhCong("Đã xóa thành công");
            loadCTPhieuNhap();
        }

        private void barItemSuaCTPN_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (rowCTPNhapSelected < 0)
                return;

            string maPN = FunctionStatic.layTextGridView(gvChiTietPN, rowCTPNhapSelected, CT_PhieuNhap_Print.COL_MAPN),
                maSP = FunctionStatic.layTextGridView(gvChiTietPN, rowCTPNhapSelected, CT_PhieuNhap_Print.COL_MASP);

            CT_PHIEU_NHAP ctSua = ctPhieuNhapsTmp.FirstOrDefault(n => n.MASP.Equals(maSP) && n.MAPN.Equals(maPN));
            frmSuaCT_PhieuNhap frmSua = new frmSuaCT_PhieuNhap(ctSua);
            DialogResult res = frmSua.ShowDialog();

            if (res != DialogResult.OK)
                return;

            int soLuong = frmSua.soLuong;
            decimal giaNhap = frmSua.donGia;
            CT_PHIEU_NHAP ctTim = ctPhieuNhapsTmp.FirstOrDefault(n => n.MAPN.Equals(maPN) && n.MASP.Equals(maSP));
            bool isSua = ctTim != null;

            if (!isSua)
            {
                FunctionStatic.hienThiThongBaoLoi("Sửa Chi tiết phiếu nhập này bị lỗi!");
                return;
            }

            //cap nhat;
            ctTim.SL_NHAP = soLuong;
            ctTim.GIANHAP = giaNhap;

            pnTmp.TONGTIEN = tinhTongTienCTPN_temp();
            
            FunctionStatic.hienThiThongBaoThanhCong("Sửa Chi tiêt này thành công");
            loadCTPhieuNhap();
        }

        private decimal tinhTongTienCTPN_temp()
        {
            decimal tongTien = 0;
            foreach (CT_PHIEU_NHAP ct in ctPhieuNhapsTmp)
                tongTien += int.Parse(ct.SL_NHAP.ToString()) * decimal.Parse(ct.GIANHAP.ToString());

            return tongTien;
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            bool isLuu = pn_DAL_BLL.them(pnTmp, ctPhieuNhapsTmp);
            if (!isLuu)
            {
                FunctionStatic.hienThiThongBaoLoi("Lưu Phiếu nhập không Thành công!");
                return;
            }

            pnTmp = null;
            ctPhieuNhapsTmp.Clear();
            FunctionStatic.hienThiThongBaoThanhCong("Thêm phiếu nhập thành công");
            lbPhieuNhapCho.Visible = false;
        }

        private void lbPhieuNhapCho_Click(object sender, EventArgs e)
        {
            pnTmp = null;
            ctPhieuNhapsTmp.Clear();
            lbPhieuNhapCho.Visible = false;
            dgvChiTietPN.DataSource = null;
            dgvChiTietPN.DataSource = ctPhieuNhapsTmp;
            loadCboxMaPN(null);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            object dataSource = sPham_DAL_BLL.latTaCa();
            frmTim frmT = new frmTim(dataSource, new int[] { 0, 1, 4, 7}, 0);
            DialogResult res = frmT.ShowDialog();
            if (res == DialogResult.Yes)
            {
                cboxMaSanPham.SelectedValue = frmT.valueGET;
            }
        }
    }
}