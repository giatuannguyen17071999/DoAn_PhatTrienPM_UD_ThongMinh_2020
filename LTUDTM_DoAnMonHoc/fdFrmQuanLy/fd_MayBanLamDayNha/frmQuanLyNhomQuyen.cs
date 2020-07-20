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
        }
        private bool daNhapLieu()
        {
            return !String.IsNullOrEmpty(cbMaNhom.Text.Trim()) && !String.IsNullOrEmpty(txtTenNhom.Text.Trim())
                     && !String.IsNullOrEmpty(txtGhiChu.Text.Trim());
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!daNhapLieu())
            {
                MessageBox.Show("Ban phai nhap lieu day du !");
                cbMaNhom.Focus();
                return;
            }
            string result = nhomQuyen.insert(cbMaNhom.Text.Trim(), txtTenNhom.Text.Trim(), txtGhiChu.Text.Trim());
            MessageBox.Show(result);
            loadGvNhomQuyen();
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            kiemTraTruocKhiEditDelete();
            string result = nhomQuyen.delete(cbMaNhom.Text.Trim());
            MessageBox.Show(result);
            loadGvNhomQuyen();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kiemTraTruocKhiEditDelete();
            string result = nhomQuyen.edit(cbMaNhom.Text.Trim(), txtTenNhom.Text.Trim(), txtGhiChu.Text.Trim());
            MessageBox.Show(result);
            loadGvNhomQuyen();
        }

        private void frmQuanLyNhomQuyen_Load(object sender, EventArgs e)
        {
            nhomQuyen = new NhomQuyen_DAL_BLL();
            loadCbMaNhom();
            loadGvNhomQuyen();
        }
    }
}