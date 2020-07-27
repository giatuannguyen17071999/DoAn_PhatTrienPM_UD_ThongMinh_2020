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

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmQuanLyNhomQuyen : DevExpress.XtraEditors.XtraForm
    {
        private NhomQuyen_DAL_BLL nhomQuyen;
        private string maNhom;
        private string tenNhom;
        private string ghiChu;
        public frmQuanLyNhomQuyen()
        {
            InitializeComponent();
        }
        private void loadCbMaNhom()
        {
            cbMaNhom.DataSource = nhomQuyen.layTatCa();
            cbMaNhom.DisplayMember = "MaNhom";
            cbMaNhom.ValueMember = "MaNhom";
        }
        private void loadGvNhomQuyen()
        {
            gv_NhomQuyen.DataSource = nhomQuyen.layTatCa();
            gridNhomQuyen.Columns["MaNhom"].OptionsColumn.AllowEdit = false;
            gridNhomQuyen.Columns["MaNhom"].OptionsColumn.ReadOnly = true;
        }
        private bool daNhapLieu()
        {
            return !String.IsNullOrEmpty(cbMaNhom.Text.Trim()) && !String.IsNullOrEmpty(txtTenNhom.Text.Trim())
                     && !String.IsNullOrEmpty(txtGhiChu.Text.Trim());
        }
        private void reStart()
        {
            txtTenNhom.Text = txtGhiChu.Text = "";
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled  = false;
        }
        private void kiemTraTruocKhiEditDelete()
        {
            string maNhom = cbMaNhom.Text.Trim();
            if (String.IsNullOrEmpty(maNhom))
            {
                MessageBox.Show("Ban phai nhap lieu cho ô Mã nhóm !");
                cbMaNhom.Focus();
                return;
            }
        }
        private void capNhatTextBox()
        {
            cbMaNhom.Text = maNhom;
            txtTenNhom.Text = tenNhom;
            txtGhiChu.Text = ghiChu;
        }
        private void setBtnClearTrue()
        {
            btnClear.Text = "Huỷ";
            btnClear.Enabled = true;
        }
        private void setBtnClearFalse()
        {
            btnClear.Enabled = false;
            btnClear.Text = "";
        }
        private void luuTrangThai()
        {
            maNhom = cbMaNhom.Text.Trim();
            tenNhom = txtTenNhom.Text.Trim();
            ghiChu = txtGhiChu.Text.Trim();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            luuTrangThai();
            btnThem.Text = btnThem.Text.Equals("Thêm") ? "Lưu" : "Thêm";
            if (btnThem.Text.Equals("Thêm")) // An nut them lan 2
            {
                if (!daNhapLieu())
                {
                    MessageBox.Show("Ban phai nhap lieu day du !");
                    cbMaNhom.Focus();
                    return;
                }
                string result = nhomQuyen.insert(cbMaNhom.Text.Trim(), txtTenNhom.Text.Trim(), txtGhiChu.Text.Trim());
                MessageBox.Show(result);
                loadGvNhomQuyen();
                capNhatTextBox();
                gv_NhomQuyen.Enabled = true;
                setBtnClearFalse();
            }
            else //Vua nhan nut them
            {
                setBtnClearTrue();
                reStart();
                gv_NhomQuyen.Enabled = false;

            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult resultMes = MessageBox.Show("Bạn có chắc muốn xoá nhóm quyền này ?", "Are you sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resultMes == DialogResult.No)
                return;
            kiemTraTruocKhiEditDelete();
            string result = nhomQuyen.delete(cbMaNhom.Text.Trim());
            MessageBox.Show(result);
            loadGvNhomQuyen();
            reStart();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            luuTrangThai();
            btnSua.Text = btnSua.Text.Equals("Sửa") ? "Cập nhật" : "Sửa";
            if (btnSua.Text.Equals("Sửa")) // An nut sửa lan 2
            {
                kiemTraTruocKhiEditDelete();
                string result = nhomQuyen.edit(cbMaNhom.Text.Trim(), txtTenNhom.Text.Trim(), txtGhiChu.Text.Trim());
                MessageBox.Show(result);
                loadGvNhomQuyen();
                reStart();
                capNhatTextBox();
                gv_NhomQuyen.Enabled = true;
                setBtnClearFalse();
                cbMaNhom.Enabled = true;
            }
            else //Vua nhan nut sửa
            {
                setBtnClearTrue();
                capNhatTextBox();
                cbMaNhom.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = btnThem.Enabled = false;
                gv_NhomQuyen.Enabled = false;

            }
        }

        private void frmQuanLyNhomQuyen_Load(object sender, EventArgs e)
        {
            nhomQuyen = new NhomQuyen_DAL_BLL();
            loadCbMaNhom();
            loadGvNhomQuyen();
            reStart();
            setBtnClearFalse();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            btnClear.Text = btnClear.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnClear.Text.Equals(""))
            {
                btnClear.Enabled = false;
                btnSua.Text = "Sửa";
                btnThem.Text = "Thêm";
                capNhatTextBox();
                btnSua.Enabled = btnXoa.Enabled = false;
                btnThem.Enabled = true;
                gv_NhomQuyen.Enabled = true;
                cbMaNhom.Focus();
                cbMaNhom.Enabled = true;
            }
        }
        private void gridNhomQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            string result = nhomQuyen.edit(
                gridNhomQuyen.GetRowCellValue(rowIndex, "MaNhom").ToString(),
                gridNhomQuyen.GetRowCellValue(rowIndex, "TenNhom").ToString(),
                gridNhomQuyen.GetRowCellValue(rowIndex, "GhiChu").ToString()
                );
            MessageBox.Show(result);
            gridNhomQuyen.SelectRow(rowIndex);
        }

        private void gridNhomQuyen_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            maNhom = gridNhomQuyen.GetRowCellValue(e.RowHandle, "MaNhom").ToString();
            tenNhom = gridNhomQuyen.GetRowCellValue(e.RowHandle, "TenNhom").ToString();
            ghiChu = gridNhomQuyen.GetRowCellValue(e.RowHandle, "GhiChu").ToString();
            cbMaNhom.Text = maNhom;
            txtTenNhom.Text = tenNhom;
            txtGhiChu.Text = ghiChu;
            btnSua.Enabled = btnXoa.Enabled  = true;
        }


    }
}