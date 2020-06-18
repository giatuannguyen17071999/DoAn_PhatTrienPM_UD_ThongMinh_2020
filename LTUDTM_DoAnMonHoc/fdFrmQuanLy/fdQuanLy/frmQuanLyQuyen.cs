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
    public partial class frmQuanLyQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyQuyen()
        {
            InitializeComponent();
        }

        private void qUYENSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.qUYENSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_BanThietBiDienTu);

        }

        private void frmQuanLyQuyen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_BanThietBiDienTu.QUYENS' table. You can move, or remove it, as needed.
            this.qUYENSTableAdapter.Fill(this.dS_BanThietBiDienTu.QUYENS);

        }
    }
}