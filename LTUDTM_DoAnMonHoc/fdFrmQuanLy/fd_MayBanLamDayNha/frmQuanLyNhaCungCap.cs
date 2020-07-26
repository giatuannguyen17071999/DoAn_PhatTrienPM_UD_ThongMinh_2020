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
using DevExpress.XtraGrid.Views.Grid;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class frmQuanLyNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        private NhaCungCap_DAL_BLL nhaCungCap;
        private string maNCC;
        private string tenNCC;
        private string diaChi;
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
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled  = false;
        }
        private void capNhatTextBox()
        {
            cbNhaCC.Text = maNCC;
            txtTenNCC.Text = tenNCC;
            txtDiaChi.Text = diaChi;
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
            maNCC = cbNhaCC.Text.Trim();
            tenNCC = txtTenNCC.Text.Trim();
            diaChi = txtDiaChi.Text.Trim();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            luuTrangThai();
            btnThem.Text = btnThem.Text.Equals("Thêm") ? "Lưu" : "Thêm";
            if(btnThem.Text.Equals("Thêm")) // An nut them lan 2
            {
                if (!daNhapLieu())
                {
                    MessageBox.Show("Ban phai nhap lieu day du !");
                    cbNhaCC.Focus();
                    return;
                }
                string result = nhaCungCap.insert(maNCC,tenNCC,diaChi);
                MessageBox.Show(result);
                loadGvNhaCC();
                capNhatTextBox();
                gv_NhaCC.Enabled = true;
                setBtnClearFalse();
            }
            else //Vua nhan nut them
            {
                setBtnClearTrue();
                reStart();
                gv_NhaCC.Enabled = false;
                
            }
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
            luuTrangThai();
            btnSua.Text = btnSua.Text.Equals("Sửa") ? "Cập nhật" : "Sửa";
            if (btnSua.Text.Equals("Sửa")) // An nut sửa lan 2
            {
                kiemTraTruocKhiEditDelete();
                string result = nhaCungCap.edit(cbNhaCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim());
                MessageBox.Show(result);
                loadGvNhaCC();
                reStart();
                capNhatTextBox();
                gv_NhaCC.Enabled = true;
                setBtnClearFalse();
                cbNhaCC.Enabled = true;
            }
            else //Vua nhan nut sửa
            {
                setBtnClearTrue();
                capNhatTextBox();
                cbNhaCC.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = btnThem.Enabled = false;
                gv_NhaCC.Enabled = false;

            }
        }

        private void frmQuanLyNhaCungCung_Load(object sender, EventArgs e)
        {
            nhaCungCap = new NhaCungCap_DAL_BLL();
            loadCbMaNCC();
            loadGvNhaCC();
            reStart();
            setBtnClearFalse();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            btnClear.Text = btnClear.Text.Equals("Huỷ") ? "" : "Huỷ";
            if(btnClear.Text.Equals(""))
            {
                btnClear.Enabled = false;
                btnSua.Text = "Sửa";
                btnThem.Text = "Thêm";
                capNhatTextBox();
                btnSua.Enabled = btnXoa.Enabled = false;
                btnThem.Enabled = true;
                gv_NhaCC.Enabled = true;
                cbNhaCC.Focus();
                cbNhaCC.Enabled = true;
            }    
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
            maNCC = gridNhaCC.GetRowCellValue(e.RowHandle, "MaNCC").ToString();
            tenNCC = gridNhaCC.GetRowCellValue(e.RowHandle, "TenNCC").ToString();
            diaChi = gridNhaCC.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
            cbNhaCC.Text = maNCC;
            txtTenNCC.Text = tenNCC;
            txtDiaChi.Text = diaChi;
            btnSua.Enabled = btnXoa.Enabled  = true;
        }


    }
}