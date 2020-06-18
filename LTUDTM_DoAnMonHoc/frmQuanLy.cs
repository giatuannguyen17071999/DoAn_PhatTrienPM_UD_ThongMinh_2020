using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy;
using MyFunctionStatic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTUDTM_DoAnMonHoc
{
    public partial class frmQuanLy : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void mnuQuanLyNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.disposeAllFromButNotThis(this);
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void mnuQuanLyQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.disposeAllFromButNotThis(this);
            frmQuanLyQuyen frm = new frmQuanLyQuyen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuQuanLyNhomQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.disposeAllFromButNotThis(this);
            frmQuanLyNhomQuyen frm = new frmQuanLyNhomQuyen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPhanNhanVienVaoNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.disposeAllFromButNotThis(this);
            frmPhanNhanVienVaoNhom frm = new frmPhanNhanVienVaoNhom();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPhanQuyenChoNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionStatic.disposeAllFromButNotThis(this);
            frmPhanQuyenChoNhom frm = new frmPhanQuyenChoNhom();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
