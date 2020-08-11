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
using MyLibrary;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy.frmPhatSinh
{
    public partial class frmTim : DevExpress.XtraEditors.XtraForm
    {
        private object dataSource;
        private int[] colsVisible;
        private int rowGET;
        public string valueGET;
        
        public frmTim(object dataSource, int[] colsVisible, int rowGET)
        {
            InitializeComponent();
            this.dataSource = dataSource;
            this.colsVisible = colsVisible;
            this.rowGET = rowGET;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (gvTim.GetSelectedRows() == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Bạn Chưa Chọn Khách Hàng!");
                return;
            }

            int row = gvTim.GetSelectedRows()[0];

            valueGET = gvTim.GetRowCellValue(row, gvTim.Columns[rowGET]).ToString();
            DialogResult = DialogResult.Yes;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Bạn có muốn thoát!");
            if (res == DialogResult.Yes)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void frmTim_Load(object sender, EventArgs e)
        {
            dgvTim.DataSource = dataSource;

            if (colsVisible != null)
            {
                for (int i = 0; i < gvTim.Columns.Count; i++)
                    if (!isColsVisible(i))
                        gvTim.Columns[i].Visible = false;
            }
        }

        private bool isColsVisible(int col)
        {
            for (int i = 0; i < colsVisible.Length; i++)
                if (colsVisible[i] == col)
                    return true;
            return false;
        }
    }
}