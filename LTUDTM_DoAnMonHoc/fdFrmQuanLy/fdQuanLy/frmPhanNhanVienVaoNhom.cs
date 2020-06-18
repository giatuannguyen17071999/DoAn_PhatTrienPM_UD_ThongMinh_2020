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
using DevExpress.Utils;
using DevExpress.Internal;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmPhanNhanVienVaoNhom : DevExpress.XtraEditors.XtraForm
    {
        public const int GRID_NHANVIEN_COL_USERNAME = 0;
        public const int GRID_HIENTHI_COL_USERNAME = 0;
        public const int GRID_HIENTHI_COL_MANHOM = 2;

        public frmPhanNhanVienVaoNhom()
        {
            InitializeComponent();
        }

        private void frmPhanNhanVienVaoNhom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_BanThietBiDienTu.NHOMQUYENS' table. You can move, or remove it, as needed.
            this.nHOMQUYENSTableAdapter.Fill(this.dS_BanThietBiDienTu.NHOMQUYENS);
            // TODO: This line of code loads data into the 'dS_BanThietBiDienTu.NHANVIENS' table. You can move, or remove it, as needed.
            this.nHANVIENSTableAdapter.Fill(this.dS_BanThietBiDienTu.NHANVIENS);

            phannhanvieN_VAONHOMQUYENTableAdapter.Fill(dS_BanThietBiDienTu.PHANNHANVIEN_VAONHOMQUYEN);
            loadNhanVienTheoMaNhom();
        }

        private void nHOMQUYENSComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadNhanVienTheoMaNhom();
        }

        private void loadNhanVienTheoMaNhom()
        {
            if (cboxNhomQuyen.SelectedValue == null)
                return;
            string maNhom = cboxNhomQuyen.SelectedValue.ToString();
            dtHienThiNhanVienTheoMaNhomTableAdapter.Fill(dS_BanThietBiDienTu.dtHienThiNhanVienTheoMaNhom, maNhom);
        }

        private void btnThemNhanVien_QuaTrai_Click(object sender, EventArgs e)
        {
            string uName = FunctionStatic.getValueRowSelectedGridControl(gridViewNhanViens, GRID_NHANVIEN_COL_USERNAME);
            if (string.IsNullOrEmpty(uName))
                return;
            if (cboxNhomQuyen.SelectedValue == null)
                return;

            string maNhom = cboxNhomQuyen.SelectedValue.ToString();

            //Kiem tra ton tai
            DataRow dr = dS_BanThietBiDienTu.PHANNHANVIEN_VAONHOMQUYEN.Rows.Find(new string[] { uName, maNhom});
            if (dr != null)
                MessageBox.Show("Đã tìm thấy nhân viên này trong nhóm","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                phannhanvieN_VAONHOMQUYENTableAdapter.Insert(uName, maNhom, null);
                phannhanvieN_VAONHOMQUYENTableAdapter.Fill(dS_BanThietBiDienTu.PHANNHANVIEN_VAONHOMQUYEN);
                loadNhanVienTheoMaNhom();
            }
        }

        private void btnXoaNhanVienQuaPhai_Click(object sender, EventArgs e)
        {
            int row = FunctionStatic.getRowSelectedGridControl(gridViewHienThiNhanVienTheoNhom);
            if (row < 0)
                return;
            else
            {
                string uName = FunctionStatic.getValueRowSelectedGridControl(gridViewHienThiNhanVienTheoNhom, GRID_HIENTHI_COL_USERNAME),
                    maNhom = FunctionStatic.getValueRowSelectedGridControl(gridViewHienThiNhanVienTheoNhom, GRID_HIENTHI_COL_MANHOM);
                int del = phannhanvieN_VAONHOMQUYENTableAdapter.MY_DELETE(uName, maNhom);
                if (del > 0)
                {
                    MessageBox.Show("Đã xóa nhân viên ra khỏi nhóm này", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    phannhanvieN_VAONHOMQUYENTableAdapter.Fill(dS_BanThietBiDienTu.PHANNHANVIEN_VAONHOMQUYEN);
                    loadNhanVienTheoMaNhom();
                }
            }
        }
    }
}