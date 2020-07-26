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

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class frmQuanLyNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        private NhaCungCap_DAL_BLL nhaCungCap;
        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }
        private void loadCbMaNCC()
        {
            cbNhaCC.DataSource = nhaCungCap.layTatCa();
            cbNhaCC.DisplayMember = "MaNCC";
            cbNhaCC.ValueMember = "MaNCC";
        }
        private void loadGvNhaCC()
        {
            gv_NhaCC.DataSource = nhaCungCap.layTatCa();
            gridNhaCC.Columns["MaNCC"].OptionsColumn.AllowEdit = false;
            gridNhaCC.Columns["MaNCC"].OptionsColumn.ReadOnly = true;
        }
        private bool daNhapLieu()
        {
            return !String.IsNullOrEmpty(cbNhaCC.Text.Trim()) && !String.IsNullOrEmpty(txtDiaChi.Text.Trim())
                     && !String.IsNullOrEmpty(txtTenNCC.Text.Trim());
        }
        private void kiemTraTruocKhiEditDelete()
        {
            string maNCC = cbNhaCC.Text.Trim();
            if (String.IsNullOrEmpty(maNCC))
            {
                MessageBox.Show("Ban phai nhap lieu cho ô Mã nhà cung cấp !");
                cbNhaCC.Focus();
                return;
            }
        }
        private void reStart()
        {
            txtTenNCC.Text = txtDiaChi.Text = "";
            btnSua.Enabled = btnXoa.Enabled = btnClear.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!daNhapLieu())
            {
                MessageBox.Show("Ban phai nhap lieu day du !");
                cbNhaCC.Focus();
                return;
            }
            string result = nhaCungCap.insert(cbNhaCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim());
            MessageBox.Show(result);
            loadGvNhaCC();
            reStart();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult resultMes = MessageBox.Show("Bạn có chắc muốn xoá nhà cung cấp này ?", "Are you sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resultMes == DialogResult.No)
                return;
            kiemTraTruocKhiEditDelete();
            string result = nhaCungCap.delete(cbNhaCC.Text.Trim());
            MessageBox.Show(result);
            loadGvNhaCC();
            reStart();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kiemTraTruocKhiEditDelete();
            string result = nhaCungCap.edit(cbNhaCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim());
            MessageBox.Show(result);
            loadGvNhaCC();
            reStart();
        }

        private void frmQuanLyNhaCungCung_Load(object sender, EventArgs e)
        {
            nhaCungCap = new NhaCungCap_DAL_BLL();
            loadCbMaNCC();
            loadGvNhaCC();
            reStart();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            reStart();
            cbNhaCC.Focus();
        }
        private void gridNhaCC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            string result = nhaCungCap.edit(
                gridNhaCC.GetRowCellValue(rowIndex, "MaNCC").ToString(),
                 gridNhaCC.GetRowCellValue(rowIndex, "TenNCC").ToString(),
                  gridNhaCC.GetRowCellValue(rowIndex, "DiaChi").ToString()
                );
            MessageBox.Show(result);
            gridNhaCC.SelectRow(rowIndex);
        }

        private void gridNhaCC_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            cbNhaCC.Text = gridNhaCC.GetRowCellValue(e.RowHandle, "MaNCC").ToString();
            txtTenNCC.Text = gridNhaCC.GetRowCellValue(e.RowHandle, "TenNCC").ToString();
            txtDiaChi.Text = gridNhaCC.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
            btnSua.Enabled = btnXoa.Enabled = btnClear.Enabled = true;
        }


    }
}