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
using MyLibrary;
using DAL_BLL;
using DevExpress.ClipboardSource.SpreadsheetML;
using DTO;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class frmQuanLySanPham : DevExpress.XtraEditors.XtraForm
    {
        private AppControl appCtr;
        private int rowSelected;

        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            appCtr = new AppControl();

            //load
            reloadSanPham();

            //event
            gvSanPham.RowClick += GvSanPham_RowClick;
        }

        private void GvSanPham_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int r = e.RowHandle;
            if (r > -1 && r < gvSanPham.RowCount)
                rowSelected = r;
            else
                rowSelected = -1;

            bindding();
        }

        private void bindding()
        {
            if (rowSelected == -1)
                return;
            tbMaSP.Text = FunctionStatic.layTextGridView(gvSanPham, rowSelected, SanPham_DTO.COL_MASP);
            tbTenSP.Text = FunctionStatic.layTextGridView(gvSanPham, rowSelected, SanPham_DTO.COL_TENSP);
        }

        private void reloadSanPham()
        {
            dgvSanPham.DataSource = appCtr.getSpDAL_BLL().latTaCa();
        }
    }
}