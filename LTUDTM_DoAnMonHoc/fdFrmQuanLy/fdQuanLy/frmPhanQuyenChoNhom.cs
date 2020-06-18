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
using MyFunctionStatic;
using DevExpress.XtraGrid.Views.Grid;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmPhanQuyenChoNhom : DevExpress.XtraEditors.XtraForm
    {
        public const int GRID_NHOM_COL_MANHOM = 0;
        public const int GRID_HIENTHI_COL_MAQUYEN = 0;
        public const int GRID_HIENTHI_COL_COQUYEN = 2;

        public frmPhanQuyenChoNhom()
        {
            InitializeComponent();
        }

        private void nHOMQUYENSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHOMQUYENSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_BanThietBiDienTu);

        }

        private void frmPhanQuyenChoNhom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_BanThietBiDienTu.NHOMQUYENS' table. You can move, or remove it, as needed.
            this.nHOMQUYENSTableAdapter.Fill(this.dS_BanThietBiDienTu.NHOMQUYENS);

            phanquyenTableAdapter.Fill(dS_BanThietBiDienTu.PHANQUYEN);

            
        }

        private void gridViewNhomQuyen_RowClick(object sender, RowClickEventArgs e)
        {
            loadHienThiNhanVienTheoNhom();
        }

        private void loadHienThiNhanVienTheoNhom()
        {
            string maNhom = FunctionStatic.getValueRowSelectedGridControl(gridNhomQuyens, 0);
            if (maNhom == null)
                return;
            dtHienThiPhanQuyenChoNhomTableAdapter.Fill(dS_BanThietBiDienTu.dtHienThiPhanQuyenChoNhom, maNhom);
        }
        private void gridViewNhomQuyen_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            string maNhom = FunctionStatic.getValueRowSelectedGridControl(gridNhomQuyens, 0);
            if (maNhom == null)
                return;
            dtHienThiPhanQuyenChoNhomTableAdapter.Fill(dS_BanThietBiDienTu.dtHienThiPhanQuyenChoNhom, maNhom);
        }

        private void gridViewNhomQuyen_RowClick_1(object sender, RowClickEventArgs e)
        {
            string maNhom = FunctionStatic.getValueRowSelectedGridControl(gridNhomQuyens, GRID_NHOM_COL_MANHOM);
            if (maNhom == null)
                return;
            dtHienThiPhanQuyenChoNhomTableAdapter.Fill(dS_BanThietBiDienTu.dtHienThiPhanQuyenChoNhom, maNhom);
        }

        private void btnLuuPhanQuyenChoNhom_Click(object sender, EventArgs e)
        {
            GridView grid = gridHienThiPhanQuyenChoNhom.FocusedView as GridView;
            string maNhom = FunctionStatic.getValueRowSelectedGridControl(gridNhomQuyens, GRID_NHOM_COL_MANHOM);
            if (string.IsNullOrEmpty(maNhom))
                return;

            DataRow dr;
            string maQuyen, tmp;
            bool coQuyen;
            for (int i = 0; i< grid.RowCount; i++)
            {
                dr = grid.GetDataRow(i);
                coQuyen = true;
                maQuyen = dr[GRID_HIENTHI_COL_MAQUYEN].ToString();
                tmp = dr[GRID_HIENTHI_COL_COQUYEN].ToString();
                if (string.IsNullOrEmpty(tmp) || tmp.ToLower().Equals("false"))
                    coQuyen = false;
                //Kiem tra ton tai
                dr = dS_BanThietBiDienTu.PHANQUYEN.Rows.Find(new string[] { maNhom, maQuyen});
                if (dr == null)
                    phanquyenTableAdapter.Insert(maNhom, maQuyen, coQuyen);
                else
                    phanquyenTableAdapter.MY_UPDATE(coQuyen, maNhom, maQuyen);
            }

            phanquyenTableAdapter.Fill(dS_BanThietBiDienTu.PHANQUYEN);
            loadHienThiNhanVienTheoNhom();
        }
    }
}