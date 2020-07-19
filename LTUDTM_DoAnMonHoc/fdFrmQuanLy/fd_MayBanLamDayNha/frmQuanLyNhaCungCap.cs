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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            kiemTraTruocKhiEditDelete();
            string result = nhaCungCap.delete(cbNhaCC.Text.Trim());
            MessageBox.Show(result);
            loadGvNhaCC();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kiemTraTruocKhiEditDelete();
            string result = nhaCungCap.edit(cbNhaCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim());
            MessageBox.Show(result);
            loadGvNhaCC();
        }

        private void frmQuanLyNhaCungCung_Load(object sender, EventArgs e)
        {
            nhaCungCap = new NhaCungCap_DAL_BLL();
            loadCbMaNCC();
            loadGvNhaCC();
        }
    }
}