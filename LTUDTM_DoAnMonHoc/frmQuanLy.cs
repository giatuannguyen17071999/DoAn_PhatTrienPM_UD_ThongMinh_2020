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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DAL_BLL;
using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy.frmPhatSinh;
using System.Threading;
using LTUDTM_DoAnMonHoc.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using DevExpress.Utils.Text;
using DevExpress.XtraRichEdit.Import.Doc;
using DevExpress.CodeParser;

namespace LTUDTM_DoAnMonHoc
{
    public partial class frmQuanLy : DevExpress.XtraEditors.XtraForm
    {
        private AppControl appCtr;
        public NHANVIEN nVien;

        public frmQuanLy(NHANVIEN nVien)
        {
            InitializeComponent();
            this.nVien = nVien;
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
            FunctionStatic.hienThiFormMoi(this, new frmBanHang(nVien));
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
            if (xtraTabbedMdiManager.SelectedPage == null)
                return;
            Form frm = xtraTabbedMdiManager.SelectedPage.MdiChild;
            if (frm.Name.Equals("frmBanHang") || frm.Name.Equals("frmThongTin"))
                ribbonMain.Minimized = true;
            else
                ribbonMain.Minimized = false;
        }

        private void mnuQuanLyNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmQuanLyNhanVien());
        }

        private void mnuQuanLyQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmQuanLyQuyen());
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            appCtr = new AppControl();

            FunctionStatic.hienThiFormMoi(this, new frmThongTin());
            loadPhanQuyen();
            barItemWellcomUser.Caption = string.Format("Chào Mừng: [ {0} ]", nVien.TENNHANVIEN);
        }

        private void mnuThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frmThongTin());
        }

        private void loadPhanQuyen()
        {
            Thread th = new Thread(new ThreadStart(()=>
            {
                foreach (RibbonPageCategory cate in ribbonMain.PageCategories)
                    foreach (RibbonPage page in cate.Pages)
                        foreach (RibbonPageGroup group in page.Groups)
                            foreach (BarItemLink item in group.ItemLinks)
                                if (item.Item is BarButtonItem)
                                {
                                    BarButtonItem button = (BarButtonItem)item.Item;
                                    if (button.Tag != null)
                                    {
                                        string tag = button.Tag.ToString();
                                        button.Enabled = false;

                                        PHANQUYEN pq;
                                        bool isSet = false;
                                        var nhoms = appCtr.getPnvNhomQuyenDAL_BLL().layTheoMaUser("admin");
                                        foreach (var n in nhoms)
                                        {
                                            var quyens = appCtr.getQDAL_BLL().layTatCa();
                                            foreach (var q in quyens)
                                            {
                                                pq = appCtr.getPqDAL_BLL().layTheoKhoaChinh(n.MANHOM, q.MaQuyen);
                                                if (pq != null && pq.COQUYEN == true && pq.MAQUYEN.Equals(tag))
                                                {
                                                    button.Enabled = true;
                                                    isSet = true;
                                                    break;
                                                }
                                            }
                                            if (isSet)
                                                break;
                                        }
                                    }
                                }
            }));

            th.Start();
        }

        private void mnuKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionStatic.hienThiFormMoi(this, new frnQuanLyKhachHang());
        }

        private void mnuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            dangXuat();
        }

        public void dangXuat()
        {
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Xác nhận đăng xuất?");
            if (res != DialogResult.Yes)
                return;
            Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            Close();
        }
    }
}