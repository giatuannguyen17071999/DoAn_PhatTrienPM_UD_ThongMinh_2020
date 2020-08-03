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

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class frmThongTin : DevExpress.XtraEditors.XtraForm
    {
        public frmThongTin()
        {
            InitializeComponent();
        }

        private void frmThongTin_Load(object sender, EventArgs e)
        {
            lbTruong.Text = FunctionStatic.GIOI_THIEU_TRUONG;
            lbGioiThieuTenMon.Text = FunctionStatic.GIOI_THIEU_TEN_MON;
            lbThanhVien.Text = FunctionStatic.GIOI_THIEU_THANH_VIEN;
        }
    }
}