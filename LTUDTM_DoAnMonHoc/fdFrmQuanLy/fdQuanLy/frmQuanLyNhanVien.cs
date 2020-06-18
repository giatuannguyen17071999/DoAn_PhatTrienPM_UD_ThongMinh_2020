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

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmQuanLyNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void nHANVIENSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHANVIENSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_BanThietBiDienTu);

        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_BanThietBiDienTu.NHANVIENS' table. You can move, or remove it, as needed.
            this.nHANVIENSTableAdapter.Fill(this.dS_BanThietBiDienTu.NHANVIENS);

        }
    }
}