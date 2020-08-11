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
using DAL_BLL;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy.frmPhatSinh
{
    public partial class frmSuaCT_PhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public int soLuong;
        public decimal donGia;

        public frmSuaCT_PhieuNhap(CT_PHIEU_NHAP ct)
        {
            InitializeComponent();

            tbSoLuong.Text = ct.SL_NHAP.ToString();
            tbDonGia.Text = ct.GIANHAP.ToString();
        }

        private void frmSuaCT_PhieuNhap_Load(object sender, EventArgs e)
        {
            soLuong = -1;
            donGia = -1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strSoLuong = tbSoLuong.Text,
                strDonGia = tbDonGia.Text;
            if (string.IsNullOrEmpty(strSoLuong) || string.IsNullOrEmpty(strDonGia))
            {
                FunctionStatic.hienThiThongBaoLoi("Kiểm Tra lại số lượng và đơn giá!");
                return;
            }

            soLuong = int.Parse(strSoLuong);
            donGia = decimal.Parse(strDonGia);
            DialogResult = DialogResult.OK;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}