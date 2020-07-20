using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using DevExpress.XtraEditors;
using DTO;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmQuanLyNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyNhanVien()
        {
            _dataNv = new NhanVien_DAL_BLL();
            _datapvnq = new PhanNhanVienVaoNhomQuyen_DAL_BLL();
            InitializeComponent();
        }

        private readonly NhanVien_DAL_BLL _dataNv;
        private readonly PhanNhanVienVaoNhomQuyen_DAL_BLL _datapvnq;
        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadGridViewUser();
        }

        private void LoadGridViewUser()
        {
            dgvUser.DataSource = _dataNv.layTatCa();
        }

        private void btnThemUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) return;
            var kq = _dataNv.AddNhanVien(new NhanVien_DTO()
            {
                UserName = txtUserName.Text,
                Email = txtEmail.Text,
                HoatDong = chkStatus.Checked,
                Pass = txtPassword.Text,
                TenNhanVien = txtTenNV.Text
            });
            MessageBox.Show(kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) return;
            var kq = _dataNv.UpdateNhanVien(new NhanVien_DTO()
            {
                UserName = txtUserName.Text,
                Email = txtEmail.Text,
                HoatDong = chkStatus.Checked,
                Pass = txtPassword.Text,
                TenNhanVien = txtTenNV.Text
            });
            MessageBox.Show(kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) return;
            var layNhomQuyen = _datapvnq.layTheoMaUser(txtUserName.Text).Select(x => new PHANNHANVIEN_VAONHOMQUYEN()
            {
                GHICHU = x.GhiChu,
                MANHOM = x.MaNhom,
                USERNAME = x.UserName
            }).ToList();
            if (layNhomQuyen.Count > 0)
            {
                if (_datapvnq.XoaNhieuNhomQuyen(layNhomQuyen))
                {
                    var kq = _dataNv.XoaNhanVien(txtUserName.Text);
                    MessageBox.Show("Xóa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var kq = _dataNv.XoaNhanVien(txtUserName.Text);
                MessageBox.Show(kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}