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
            InitializeComponent();
        }

        private NhanVien_DTO _tmpDto;
        private readonly NhanVien_DAL_BLL _dataNv;
        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadGridViewUser();
        }

        private void LoadGridViewUser()
        {
            dgvUser.DataSource = _dataNv.layTatCa();
            gvUser.Columns["UserName"].OptionsColumn.AllowEdit = false;
            gvUser.Columns["UserName"].OptionsColumn.ReadOnly = true;
            gvUser.Columns["Pass"].ColumnEdit = txtPasswordChar;
        }
        public void ResetControl()
        {
            txtUserName.ResetText();
            txtTenNV.ResetText();
            txtPassword.ResetText();
            txtEmail.ResetText();
            chkStatus.Checked = false;
        }
        private void btnThemUser_Click(object sender, EventArgs e)
        {

            if (btnThemUser.Text.Equals("Add"))
            {
                _tmpDto = new NhanVien_DTO()
                {
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    HoatDong = chkStatus.Checked,
                    Pass = txtPassword.Text,
                    TenNhanVien = txtTenNV.Text
                };
                btnThemUser.Text = "Cancel";

                ResetControl();

                txtUserName.Enabled = !txtUserName.Enabled;
                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenNV.Enabled = !txtTenNV.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;


                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                btnXoaUser.Enabled = !btnXoaUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;

                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnThemUser.Text = "Add";

                txtEmail.Text = _tmpDto.Email;
                txtPassword.Text = _tmpDto.Pass;
                txtTenNV.Text = _tmpDto.TenNhanVien;
                txtUserName.Text = _tmpDto.UserName;
                chkStatus.Checked = _tmpDto.HoatDong.Value;

                txtUserName.Enabled = !txtUserName.Enabled;
                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenNV.Enabled = !txtTenNV.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;


                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                btnXoaUser.Enabled = !btnXoaUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;


                dgvUser.Enabled = !dgvUser.Enabled;
            }

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {

            if (btnUpdateUser.Text.Equals("Update"))
            {
                _tmpDto = new NhanVien_DTO()
                {
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    HoatDong = chkStatus.Checked,
                    Pass = txtPassword.Text,
                    TenNhanVien = txtTenNV.Text
                };
                btnUpdateUser.Text = "Cancel";

                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenNV.Enabled = !txtTenNV.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;


                btnThemUser.Enabled = !btnThemUser.Enabled;
                btnXoaUser.Enabled = !btnXoaUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;


                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnUpdateUser.Text = "Update";

                txtEmail.Text = _tmpDto.Email;
                txtPassword.Text = _tmpDto.Pass;
                txtTenNV.Text = _tmpDto.TenNhanVien;
                chkStatus.Checked = _tmpDto.HoatDong.Value;

                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenNV.Enabled = !txtTenNV.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;

                btnThemUser.Enabled = !btnThemUser.Enabled;
                btnXoaUser.Enabled = !btnXoaUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;

                dgvUser.Enabled = !dgvUser.Enabled;
            }
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if (btnXoaUser.Text.Equals("Delete"))
            {
                btnXoaUser.Text = "Cancel";
                btnThemUser.Enabled = !btnThemUser.Enabled;
                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;
                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnXoaUser.Text = "Delete";
                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                btnThemUser.Enabled = !btnThemUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;
                dgvUser.Enabled = !dgvUser.Enabled;
            }

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
                Email = gvUser.GetRowCellValue(e.RowHandle, "Email") != null ? gvUser.GetRowCellValue(e.RowHandle, "Email").ToString() : null,
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnThemUser.Text.Equals("Cancel"))
            {
                if (string.IsNullOrEmpty(txtUserName.Text) && string.IsNullOrEmpty(txtPassword.Text) &&
                    string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtTenNV.Text))
                {
                    MessageBox.Show("Thông Tin Phải Được Điền Đầy Đủ", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (!_dataNv.GetById(txtUserName.Text))
                {
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
                        MessageBox.Show("Thêm " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemUser.Text = "Add";
                        ResetControl();

                        txtUserName.Enabled = !txtUserName.Enabled;
                        txtEmail.Enabled = !txtEmail.Enabled;
                        txtPassword.Enabled = !txtPassword.Enabled;
                        txtTenNV.Enabled = !txtTenNV.Enabled;
                        chkStatus.Enabled = !chkStatus.Enabled;


                        btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                        btnXoaUser.Enabled = !btnXoaUser.Enabled;
                        btnSave.Enabled = !btnSave.Enabled;


                        dgvUser.Enabled = !dgvUser.Enabled;
                    }
                    else
                    {
                        MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Đã Có Tài Khoản Này Rồi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (btnUpdateUser.Text.Equals("Cancel"))
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
                    MessageBox.Show("Cập Nhật " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnUpdateUser.Text = "Update";
                    ResetControl();
                    txtEmail.Enabled = !txtEmail.Enabled;
                    txtPassword.Enabled = !txtPassword.Enabled;
                    txtTenNV.Enabled = !txtTenNV.Enabled;
                    chkStatus.Enabled = !chkStatus.Enabled;

                    btnThemUser.Enabled = !btnThemUser.Enabled;
                    btnXoaUser.Enabled = !btnXoaUser.Enabled;
                    btnSave.Enabled = !btnSave.Enabled;

                    dgvUser.Enabled = !dgvUser.Enabled;
                }
                else
                {
                    MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!_dataNv.GetById(txtUserName.Text)) return;
                var kq = _dataNv.XoaNhanVien(txtUserName.Text);
                ResetControl();
                MessageBox.Show("Xóa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnXoaUser.Text = "Delete";
                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                btnThemUser.Enabled = !btnThemUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;
                dgvUser.Enabled = !dgvUser.Enabled;
            }
            _dataNv.SaveChanged();
            LoadGridViewUser();
        }
    }
}