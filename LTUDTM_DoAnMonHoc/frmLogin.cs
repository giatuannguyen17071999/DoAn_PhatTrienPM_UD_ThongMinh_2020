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
using MyLibrary;
using DevExpress.Internal;
using LTUDTM_DoAnMonHoc.SERVER_CONF;

namespace LTUDTM_DoAnMonHoc
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private NhanVien_DAL_BLL nvDAL_BLL;
        public frmLogin()
        {
            InitializeComponent();
            nvDAL_BLL = new NhanVien_DAL_BLL();
        }

        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMatKhau.Checked)
                tbMatKhau.PasswordChar = '\0';
            else
                tbMatKhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string strConn;
            if (!_PublicStatic.laKetNoiDB(out strConn))
            {
                FunctionStatic.hienThiThongBaoLoi("Kết nối DB Không thành công! Chuổi Kết Nối Hiện tại\n"+strConn);
                return;
            }

            string uName = tbTenDangNhap.Text,
                pass = tbMatKhau.Text;
            NHANVIEN nv = nvDAL_BLL.layNhanVien(uName);
            if (nv == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Sai tên đăng nhập!");
                return;
            }

            if (!nv.PASS.Equals(pass))
            {
                FunctionStatic.hienThiThongBaoLoi("Sai mật khẩu");
                return;
            }

            FunctionStatic.hienThiCauHoiYesNo(strConn);

            frmQuanLy frmQL = new frmQuanLy(nv);
            this.Hide();
            frmQL.ShowDialog();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThayDoiServer_Click(object sender, EventArgs e)
        {
            frmThayDoiServer frm = new frmThayDoiServer();
            frm.ShowDialog();
            Close();
        }
    }
}