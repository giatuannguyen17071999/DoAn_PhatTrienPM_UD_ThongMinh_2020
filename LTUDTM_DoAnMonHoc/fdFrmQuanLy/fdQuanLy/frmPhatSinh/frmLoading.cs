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

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy.frmPhatSinh
{
    public partial class frmLoading : DevExpress.XtraEditors.XtraForm
    {
        public frmLoading(string taskName)
        {
            InitializeComponent();
            lbTaskName.Text = taskName;
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {

        }
    }
}