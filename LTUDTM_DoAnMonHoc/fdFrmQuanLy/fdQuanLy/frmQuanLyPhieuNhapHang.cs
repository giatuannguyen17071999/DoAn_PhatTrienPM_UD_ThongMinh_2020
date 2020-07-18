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

            //load
            loadNhaCC();
            loadSanPham();
            loadCboxMaPN(null);
            loadCTPhieuNhap();

            //Event
            btnThemPhieuNhap.Click += BtnThemPhieuNhap_Click;
            cboxMaPhieu.SelectedIndexChanged += CboxMaPhieu_SelectedIndexChanged;
            btnThemSanPham.Click += BtnThemSanPham_Click;
            gvChiTietPN.PopupMenuShowing += GvChiTietPN_PopupMenuShowing;
        }

        private void GvChiTietPN_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            { 
                popupMenuChiTietPN.ShowPopup(MousePosition);
                rowCTPNhapSelected = e.HitInfo.RowHandle;
            }
        }

        private void BtnThemSanPham_Click(object sender, EventArgs e)
        {
            var maPN = cboxMaPhieu.SelectedValue;
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

            EStatus status = ctPN_DAL_BLL.them(ctPN);
            if (status != EStatus.THANH_CONG)
            {
                FunctionStatic.hienThiThongBaoLoi("Thêm Phiếu Nhập Không thành công!");
                return;
            }

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
            dgvChiTietPN.DataSource = ctPN_DAL_BLL.layPhieuNhap_s(maPN.ToString());
            decimal tongTien = pn_DAL_BLL.layTongTien(maPN.ToString());
            tbTongTien.Text = string.Format("{0:N0} VND", tongTien);
        }

        private void BtnThemPhieuNhap_Click(object sender, EventArgs e)
        {
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

            EStatus status = pn_DAL_BLL.them(pn);
            if (status != EStatus.THANH_CONG)
            {
                FunctionStatic.hienThiThongBaoLoi("Thêm không thành công!");
                return;
            }

            FunctionStatic.hienThiThongBaoThanhCong("Thêm phiếu nhập thành công!");
            loadCboxMaPN(maPN);
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
            bool isXoa = ctPN_DAL_BLL.xoa(maPN, maSP);
            if (!isXoa)
            {
                FunctionStatic.hienThiThongBaoLoi("Xóa Không thành công!");
                return;
            }
            FunctionStatic.hienThiThongBaoThanhCong("Đã xóa thành công");
            loadCTPhieuNhap();
        }

        private void barItemSuaCTPN_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (rowCTPNhapSelected < 0)
                return;

            frmSuaCT_PhieuNhap frmSua = new frmSuaCT_PhieuNhap();
            DialogResult res = frmSua.ShowDialog();

            if (res != DialogResult.OK)
                return;

            string maPN = FunctionStatic.layTextGridView(gvChiTietPN, rowCTPNhapSelected, CT_PhieuNhap_Print.COL_MAPN),
                maSP = FunctionStatic.layTextGridView(gvChiTietPN, rowCTPNhapSelected, CT_PhieuNhap_Print.COL_MASP);
            int soLuong = frmSua.soLuong;
            decimal giaNhap = frmSua.donGia;
            bool isSua = ctPN_DAL_BLL.sua(new CT_PHIEU_NHAP
            {
                MAPN = maPN,
                MASP = maSP,
                SL_NHAP = soLuong,
                GIANHAP = giaNhap
            });

            if (!isSua)
            {
                FunctionStatic.hienThiThongBaoLoi("Sửa Chi tiết phiếu nhập này bị lỗi!");
                return;
            }

            FunctionStatic.hienThiThongBaoThanhCong("Sửa Chi tiêt này thành công");
            loadCTPhieuNhap();
        }
    }
}