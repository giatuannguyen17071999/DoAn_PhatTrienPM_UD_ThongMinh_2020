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
    public partial class frmQuanLyNhomQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyNhomQuyen()
        {
            InitializeComponent();
        }

        private void nHOMQUYENSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHOMQUYENSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_BanThietBiDienTu);

        }

        private void frmQuanLyNhomQuyen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_BanThietBiDienTu.NHOMQUYENS' table. You can move, or remove it, as needed.
            this.nHOMQUYENSTableAdapter.Fill(this.dS_BanThietBiDienTu.NHOMQUYENS);

        }
    }
}