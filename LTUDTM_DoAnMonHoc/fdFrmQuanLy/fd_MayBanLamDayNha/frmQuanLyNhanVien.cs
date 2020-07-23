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
            gvUser.Columns["UserName"].OptionsColumn.AllowEdit = false;
            gvUser.Columns["UserName"].OptionsColumn.ReadOnly = true;
        }

        private void btnThemUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) return;
            if (_dataNv.EmailIsValid(txtEmail.Text))
            {
                var kq = _dataNv.AddNhanVien(new NhanVien_DTO()
                {
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    HoatDong = chkStatus.Checked,
                    Pass = txtPassword.Text,
                    TenNhanVien = txtTenNV.Text
                });
                MessageBox.Show("Them " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridViewUser();
            }
            else
            {
                MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (!_dataNv.GetById(txtUserName.Text)) return;
            if (_dataNv.EmailIsValid(txtEmail.Text))
            {
                var kq = _dataNv.UpdateNhanVien(new NhanVien_DTO()
                {
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    HoatDong = chkStatus.Checked,
                    Pass = txtPassword.Text,
                    TenNhanVien = txtTenNV.Text
                });
                MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridViewUser();
            }
            else
            {
                MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {

            if (_datapvnq.GetById(txtUserName.Text))
            {
                var layNhomQuyen = _datapvnq.layTheoMaUser(txtUserName.Text).Select(x => new PHANNHANVIEN_VAONHOMQUYEN()
                {
                    GHICHU = x.GhiChu,
                    MANHOM = x.MaNhom,
                    USERNAME = x.UserName
                }).ToList();
                _datapvnq.XoaNhieuNhomQuyen(layNhomQuyen);
            }
            var kq = _dataNv.XoaNhanVien(txtUserName.Text);
            MessageBox.Show("Xóa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadGridViewUser();
        }

        private void gvUser_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Email")
            {
                if (!_dataNv.EmailIsValid(gvUser.GetRowCellValue(e.RowHandle, "Email").ToString()))
                {
                    MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            var kq = _dataNv.UpdateNhanVien(new NhanVien_DTO()
            {
                UserName = gvUser.GetRowCellValue(e.RowHandle, "UserName").ToString(),
                Email = gvUser.GetRowCellValue(e.RowHandle, "Email").ToString(),
                HoatDong = bool.Parse(gvUser.GetRowCellValue(e.RowHandle, "HoatDong").ToString()),
                Pass = gvUser.GetRowCellValue(e.RowHandle, "Pass").ToString(),
                TenNhanVien = gvUser.GetRowCellValue(e.RowHandle, "TenNhanVien").ToString()
            });
            MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gvUser_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtUserName.Text = gvUser.GetRowCellValue(e.RowHandle, "UserName").ToString();
            if (gvUser.GetRowCellValue(e.RowHandle, "Email") != null)
            {
                txtEmail.Text = gvUser.GetRowCellValue(e.RowHandle, "Email").ToString();
            }
            else
            {
                txtEmail.ResetText();
            }
            txtPassword.Text = gvUser.GetRowCellValue(e.RowHandle, "Pass").ToString();
            txtTenNV.Text = gvUser.GetRowCellValue(e.RowHandle, "TenNhanVien").ToString();
            chkStatus.Checked = bool.Parse(gvUser.GetRowCellValue(e.RowHandle, "HoatDong").ToString());
        }
    }
}