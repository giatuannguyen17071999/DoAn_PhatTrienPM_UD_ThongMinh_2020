using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DTO;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class frnQuanLyKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private readonly KhachHang_DAL_BLL _dataKH;
        private KhachHang_DTO _tmpDto;
        public frnQuanLyKhachHang()
        {
            InitializeComponent();
            _dataKH = new KhachHang_DAL_BLL();
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ResetControl()
        {
            txtUserName.ResetText();
            txtAddress.ResetText();
            txtPassword.ResetText();
            txtTenKH.ResetText();
            cboGender.ResetText();
            chkStatus.Checked = false;
            txtEmail.ResetText();
            txtPhone.ResetText();
            dtpDOB.Value = DateTimePicker.MaximumDateTime;
        }
        private void btnThemUser_Click(object sender, EventArgs e)
        {
            if (btnThemUser.Text.Equals("Add"))
            {
                _tmpDto = new KhachHang_DTO()
                {
                    TaiKhoan = txtUserName.Text,
                    Email = txtEmail.Text,
                    Status = chkStatus.Checked,
                    MatKhau = txtPassword.Text,
                    HoTen = txtTenKH.Text,
                    GioiTinh = cboGender.SelectedText,
                    DiaChi = txtAddress.Text,
                    DienThoai1 = txtPhone.Text
                };
                btnThemUser.Text = "Cancel";

                ResetControl();

                txtUserName.Enabled = !txtUserName.Enabled;
                txtEmail.Enabled = !txtEmail.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenKH.Enabled = !txtTenKH.Enabled;
                dtpDOB.Enabled = !dtpDOB.Enabled;
                cboGender.Enabled = !cboGender.Enabled;
                txtPhone.Enabled = !txtPhone.Enabled;
                txtAddress.Enabled = !txtAddress.Enabled;



                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                btnXoaUser.Enabled = !btnXoaUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;

                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnThemUser.Text = "Add";

                txtEmail.Text = _tmpDto.Email;
                txtPassword.Text = _tmpDto.MatKhau;
                txtTenKH.Text = _tmpDto.HoTen;
                txtUserName.Text = _tmpDto.TaiKhoan;
                chkStatus.Checked = _tmpDto.Status;
                dtpDOB.Value = DateTime.Parse(dtpDOB.Value.ToShortDateString());
                cboGender.SelectedText = _tmpDto.GioiTinh;
                txtAddress.Text = _tmpDto.DiaChi;
                txtPhone.Text = _tmpDto.DienThoai1;


                txtUserName.Enabled = !txtUserName.Enabled;
                txtEmail.Enabled = !txtEmail.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenKH.Enabled = !txtTenKH.Enabled;
                dtpDOB.Enabled = !dtpDOB.Enabled;
                cboGender.Enabled = !cboGender.Enabled;
                txtPhone.Enabled = !txtPhone.Enabled;
                txtAddress.Enabled = !txtAddress.Enabled;


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
                _tmpDto = new KhachHang_DTO()
                {
                    TaiKhoan = txtUserName.Text,
                    Email = txtEmail.Text,
                    Status = chkStatus.Checked,
                    MatKhau = txtPassword.Text,
                    HoTen = txtTenKH.Text,
                    GioiTinh = cboGender.SelectedText,
                    DiaChi = txtAddress.Text,
                    DienThoai1 = txtPhone.Text
                };
                btnUpdateUser.Text = "Cancel";


                txtEmail.Enabled = !txtEmail.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenKH.Enabled = !txtTenKH.Enabled;
                dtpDOB.Enabled = !dtpDOB.Enabled;
                cboGender.Enabled = !cboGender.Enabled;
                txtPhone.Enabled = !txtPhone.Enabled;
                txtAddress.Enabled = !txtAddress.Enabled;



                btnThemUser.Enabled = !btnThemUser.Enabled;
                btnXoaUser.Enabled = !btnXoaUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;


                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnUpdateUser.Text = "Update";

                txtEmail.Text = _tmpDto.Email;
                txtPassword.Text = _tmpDto.MatKhau;
                txtTenKH.Text = _tmpDto.HoTen;
                chkStatus.Checked = _tmpDto.Status;
                dtpDOB.Value = DateTime.Parse(dtpDOB.Value.ToShortDateString());
                cboGender.SelectedText = _tmpDto.GioiTinh;
                txtAddress.Text = _tmpDto.DiaChi;
                txtPhone.Text = _tmpDto.DienThoai1;


                txtEmail.Enabled = !txtEmail.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenKH.Enabled = !txtTenKH.Enabled;
                dtpDOB.Enabled = !dtpDOB.Enabled;
                cboGender.Enabled = !cboGender.Enabled;
                txtPhone.Enabled = !txtPhone.Enabled;
                txtAddress.Enabled = !txtAddress.Enabled;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnThemUser.Text.Equals("Cancel"))
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(cboGender.Text))
                {
                    MessageBox.Show("Thông Tin Phải Được Điền Đầy Đủ", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (!_dataKH.GetById(txtUserName.Text))
                {
                    if (_dataKH.EmailIsValid(txtEmail.Text))
                    {
                        if (_dataKH.IsNumber(txtPhone.Text) && txtPhone.Text.Length >= 10)
                        {
                            if (!_dataKH.CheckKhachHang(txtPhone.Text))
                            {
                                var kq = _dataKH.AddKhachHang(new KhachHang_DTO()
                                {
                                    TaiKhoan = txtUserName.Text,
                                    Email = txtEmail.Text,
                                    Status = chkStatus.Checked,
                                    MatKhau = txtPassword.Text,
                                    HoTen = txtTenKH.Text,
                                    GioiTinh = cboGender.Text,
                                    DiaChi = txtAddress.Text,
                                    DienThoai1 = txtPhone.Text,
                                    NgaySinh = DateTime.Parse(dtpDOB.Value.ToShortDateString())
                                });

                                MessageBox.Show("Thêm " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnThemUser.Text = "Add";

                                ResetControl();
                                txtEmail.Enabled = !txtEmail.Enabled;
                                chkStatus.Enabled = !chkStatus.Enabled;
                                txtPassword.Enabled = !txtPassword.Enabled;
                                txtTenKH.Enabled = !txtTenKH.Enabled;
                                dtpDOB.Enabled = !dtpDOB.Enabled;
                                cboGender.Enabled = !cboGender.Enabled;
                                txtPhone.Enabled = !txtPhone.Enabled;
                                txtAddress.Enabled = !txtAddress.Enabled;
                                txtUserName.Enabled = false;
                                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                                btnXoaUser.Enabled = !btnXoaUser.Enabled;
                                btnSave.Enabled = !btnSave.Enabled;

                                dgvUser.Enabled = !dgvUser.Enabled;
                            }
                            else
                            {
                                MessageBox.Show("Đã có SDT Này Rồi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không Đúng Định Dạng Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
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
                if (!_dataKH.GetById(txtUserName.Text)) return;
                if (_dataKH.EmailIsValid(txtEmail.Text))
                {
                    if (_dataKH.IsNumber(txtPhone.Text) && txtPhone.Text.Length > 10)
                    {
                        if (!_dataKH.CheckKhachHang(txtPhone.Text))
                        {
                            var khDto = new KhachHang_DTO()
                            {
                                TaiKhoan = txtUserName.Text,
                                Email = txtEmail.Text,
                                Status = chkStatus.Checked,
                                MatKhau = txtPassword.Text,
                                HoTen = txtTenKH.Text,
                                GioiTinh = cboGender.Text,
                                DiaChi = txtAddress.Text,
                                DienThoai1 = txtPhone.Text,
                                NgaySinh = DateTime.Parse(dtpDOB.Value.ToShortDateString())
                            };
                            var kq = _dataKH.UpdateKhachHang(khDto);
                            MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnUpdateUser.Text = "Update";
                            txtUserName.Enabled = false;

                            txtEmail.Enabled = !txtEmail.Enabled;
                            chkStatus.Enabled = !chkStatus.Enabled;
                            txtPassword.Enabled = !txtPassword.Enabled;
                            txtTenKH.Enabled = !txtTenKH.Enabled;
                            dtpDOB.Enabled = !dtpDOB.Enabled;
                            cboGender.Enabled = !cboGender.Enabled;
                            txtPhone.Enabled = !txtPhone.Enabled;
                            txtAddress.Enabled = !txtAddress.Enabled;
                            btnThemUser.Enabled = !btnThemUser.Enabled;
                            btnXoaUser.Enabled = !btnXoaUser.Enabled;
                            btnSave.Enabled = !btnSave.Enabled;
                            dgvUser.Enabled = !dgvUser.Enabled;
                        }
                        else
                        {
                            MessageBox.Show("Đã có SDT Này Rồi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không Đúng Định Dạng Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!_dataKH.GetById(txtUserName.Text)) return;
                var kq = _dataKH.XoaKhachHang(int.Parse(gvUser.GetRowCellValue(0, "MaKH").ToString()));
                ResetControl();
                MessageBox.Show("Xóa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnXoaUser.Text = "Delete";
                btnUpdateUser.Enabled = !btnUpdateUser.Enabled;
                btnThemUser.Enabled = !btnThemUser.Enabled;
                btnSave.Enabled = !btnSave.Enabled;
                dgvUser.Enabled = !dgvUser.Enabled;
            }

            ResetControl();
            _dataKH.SaveChanged();
            LoadGridViewKH();
        }

        private void gvUser_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Email")
            {
                if (!_dataKH.EmailIsValid(gvUser.GetRowCellValue(e.RowHandle, "Email").ToString()))
                {
                    MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var khDto = new KhachHang_DTO
            {
                TaiKhoan = gvUser.GetRowCellValue(e.RowHandle, "TaiKhoan").ToString(),
                Email = gvUser.GetRowCellValue(e.RowHandle, "Email") != null
                    ? gvUser.GetRowCellValue(e.RowHandle, "Email").ToString()
                    : null,
                Status = bool.Parse(gvUser.GetRowCellValue(e.RowHandle, "Status").ToString()),
                MatKhau = gvUser.GetRowCellValue(e.RowHandle, "MatKhau").ToString(),
                HoTen = gvUser.GetRowCellValue(e.RowHandle, "HoTen").ToString(),
                GioiTinh = gvUser.GetRowCellValue(e.RowHandle, "GioiTinh").ToString(),
                DiaChi = gvUser.GetRowCellValue(e.RowHandle, "DiaChi") != null
                    ? gvUser.GetRowCellValue(e.RowHandle, "DiaChi").ToString()
                    : null,
                DienThoai1 = gvUser.GetRowCellValue(e.RowHandle, "DienThoai") != null
                    ? gvUser.GetRowCellValue(e.RowHandle, "DienThoai").ToString()
                    : null
            };
            if (gvUser.GetRowCellValue(e.RowHandle, "NgaySinh") != null)
            {
                khDto.NgaySinh = DateTime.Parse(gvUser.GetRowCellValue(e.RowHandle, "NgaySinh").ToString());
                var kq = _dataKH.UpdateKhachHang(khDto);
                MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon
                    .Information);
            }
        }

        private void gvUser_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtUserName.Text = gvUser.GetRowCellValue(e.RowHandle, "TaiKhoan").ToString().Trim();
            txtEmail.Text = gvUser.GetRowCellValue(e.RowHandle, "Email") != null
                ? gvUser.GetRowCellValue(e.RowHandle, "Email").ToString().Trim()
                : null;
            chkStatus.Checked = bool.Parse(gvUser.GetRowCellValue(e.RowHandle, "Status").ToString().Trim());
            txtPassword.Text = gvUser.GetRowCellValue(e.RowHandle, "MatKhau").ToString().Trim();
            txtTenKH.Text = gvUser.GetRowCellValue(e.RowHandle, "HoTen").ToString().Trim();
            cboGender.Text = gvUser.GetRowCellValue(e.RowHandle, "GioiTinh").ToString().Trim();
            txtAddress.Text = gvUser.GetRowCellValue(e.RowHandle, "DiaChi") != null
                ? gvUser.GetRowCellValue(e.RowHandle, "DiaChi").ToString().Trim()
                : null;
            txtPhone.Text = gvUser.GetRowCellValue(e.RowHandle, "DienThoai") != null
                ? gvUser.GetRowCellValue(e.RowHandle, "DienThoai").ToString().Trim()
                : null;
            if (gvUser.GetRowCellValue(e.RowHandle, "NgaySinh") != null)
            {
                dtpDOB.Value = DateTime.Parse(gvUser.GetRowCellValue(e.RowHandle, "NgaySinh").ToString());
            }
        }

        private void frnQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadGridViewKH();
            cboGender.SelectedIndex = 0;
        }

        private void LoadGridViewKH()
        {
            dgvUser.DataSource = _dataKH.LayKhachHangs();
            gvUser.Columns["MaKH"].Visible = false;
            gvUser.Columns["TaiKhoan"].OptionsColumn.AllowEdit = false;
            gvUser.Columns["TaiKhoan"].OptionsColumn.ReadOnly = true;
            gvUser.Columns["MatKhau"].ColumnEdit = txtPasswordChar;
        }
    }
}