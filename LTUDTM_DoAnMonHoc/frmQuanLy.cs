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
using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy;
using MyLibrary;
using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdBanHang;
using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha;

namespace LTUDTM_DoAnMonHoc
{
    public partial class frmQuanLy : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void mnuPhanNhanVienVaoNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmPhanNhanVienVaoNhom());
        }

        private void mnuPhanQuyenChoNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmPhanQuyenChoNhom());
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmQuanLyPhieuNhapHang());
        }

        private void barItemGiaoDienBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmBanHang());
        }

        private void mnuQuanLyNhomQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmQuanLyNhomQuyen());
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmQuanLyNhaCungCap());
        }

        private void mnuQuanLyDanhMuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new FormDanhMuc());
        }

        private void mnuQuanLyLoaiSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new FormLoaiSanPham());
        }

        private void mnuSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmQuanLySanPham());
        }

        private void xtraTabbedMdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            Form frm = xtraTabbedMdiManager.SelectedPage.MdiChild;
            if (frm.Name.Equals("frmBanHang"))
                ribbonMain.Minimized = true;
            else
                ribbonMain.Minimized = false;
        }

        private void mnuQuanLyNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmQuanLyNhanVien());
        }
    }
}