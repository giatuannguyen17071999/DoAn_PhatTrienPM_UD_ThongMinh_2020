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
    public partial class frmQuanLyQuyen : DevExpress.XtraEditors.XtraForm
    {
        private Quyen_DTO _tmpDto;
        private readonly Quyen_DAL_BLL _dataQuyen;
        private readonly PhanQuyen_DAL_BLL _dataPhanQuyen;
        public frmQuanLyQuyen()
        {
            _dataQuyen = new Quyen_DAL_BLL();
            _dataPhanQuyen = new PhanQuyen_DAL_BLL();
            InitializeComponent();
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Add"))
            {
                _tmpDto = new Quyen_DTO()
                {
                    MaQuyen = txtMaQuyen.Text,
                    TenQuyen = txtTenQuyen.Text,
                    GhiChu = txtGhiChu.Text,
                };
                btnThem.Text = "Cancel";

                ResetControl();

                txtMaQuyen.Enabled = !txtMaQuyen.Enabled;
                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;


                btnUpdate.Enabled = !btnUpdate.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnSave.Enabled = !btnSave.Enabled;

                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                btnThem.Text = "Add";

                txtMaQuyen.Text = _tmpDto.MaQuyen;
                txtTenQuyen.Text = _tmpDto.TenQuyen;
                txtGhiChu.Text = _tmpDto.GhiChu;



                txtMaQuyen.Enabled = !txtMaQuyen.Enabled;
                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;



                btnUpdate.Enabled = !btnUpdate.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnSave.Enabled = !btnSave.Enabled;


                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }

        }

        private void LoadGridViewQuyen()
        {
            dgvQuyen.DataSource = _dataQuyen.layTatCa();
            gvQuyen.Columns["MaQuyen"].OptionsColumn.AllowEdit = false;
            gvQuyen.Columns["MaQuyen"].OptionsColumn.ReadOnly = true;
        }

        private void btnUpdateQuyen_Click(object sender, EventArgs e)
        {

            if (btnUpdate.Text.Equals("Update"))
            {
                _tmpDto = new Quyen_DTO()
                {
                    MaQuyen = txtMaQuyen.Text,
                    TenQuyen = txtTenQuyen.Text,
                    GhiChu = txtGhiChu.Text
                };
                btnUpdate.Text = "Cancel";

                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;



                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnSave.Enabled = !btnSave.Enabled;


                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                btnUpdate.Text = "Update";

                txtTenQuyen.Text = _tmpDto.TenQuyen;
                txtGhiChu.Text = _tmpDto.GhiChu;

                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;

                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnSave.Enabled = !btnSave.Enabled;

                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }

        }
        public void ResetControl()
        {
            txtGhiChu.ResetText();
            txtMaQuyen.ResetText();
            txtTenQuyen.ResetText();
        }
        private void frmQuanLyQuyen_Load(object sender, EventArgs e)
        {
            LoadGridViewQuyen();
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {

            if (btnXoa.Text.Equals("Delete"))
            {
                btnXoa.Text = "Cancel";
                btnThem.Enabled = !btnThem.Enabled;
                btnUpdate.Enabled = !btnUpdate.Enabled;
                btnSave.Enabled = !btnSave.Enabled;
                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                btnXoa.Text = "Delete";
                btnUpdate.Enabled = !btnUpdate.Enabled;
                btnThem.Enabled = !btnThem.Enabled;
                btnSave.Enabled = !btnSave.Enabled;
                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }

        }
        private void gvQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var kq = _dataQuyen.UpdateQuyen(new Quyen_DTO()
            {
                TenQuyen = gvQuyen.GetRowCellValue(e.RowHandle, "TenQuyen").ToString(),
                MaQuyen = gvQuyen.GetRowCellValue(e.RowHandle, "MaQuyen").ToString(),
                GhiChu = gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu") != null ? gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu").ToString() : null
            });
            MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gvQuyen_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtMaQuyen.Text = gvQuyen.GetRowCellValue(e.RowHandle, "MaQuyen").ToString();
            if (gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu") != null)
            {
                txtGhiChu.Text = gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu").ToString();
            }
            else
            {
                txtGhiChu.ResetText();
            }
            txtTenQuyen.Text = gvQuyen.GetRowCellValue(e.RowHandle, "TenQuyen").ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Cancel"))
            {
                if (string.IsNullOrEmpty(txtMaQuyen.Text)  &&
                    string.IsNullOrEmpty(txtTenQuyen.Text))
                {
                    MessageBox.Show("Tên Quyền Và Mã Quyền Phải Điền Đầy Đủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!_dataQuyen.GetById(txtMaQuyen.Text))
                {

                    var kq = _dataQuyen.AddQuyen(new Quyen_DTO()
                    {
                        TenQuyen = txtTenQuyen.Text,
                        MaQuyen = txtMaQuyen.Text,
                        GhiChu = txtGhiChu.Text
                    });

                    MessageBox.Show("Them " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThem.Text = "Add";
                    ResetControl();
                    btnThem.Text = "Add";

                    txtMaQuyen.Text = _tmpDto.MaQuyen;
                    txtTenQuyen.Text = _tmpDto.TenQuyen;
                    txtGhiChu.Text = _tmpDto.GhiChu;



                    txtMaQuyen.Enabled = !txtMaQuyen.Enabled;
                    txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                    txtGhiChu.Enabled = !txtGhiChu.Enabled;



                    btnUpdate.Enabled = !btnUpdate.Enabled;
                    btnXoa.Enabled = !btnXoa.Enabled;
                    btnSave.Enabled = !btnSave.Enabled;


                    dgvQuyen.Enabled = !dgvQuyen.Enabled;
                }
                else
                {
                    MessageBox.Show("Đã Có Tên Quyền Này Rồi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (btnUpdate.Text.Equals("Cancel"))
            {
                if (!_dataQuyen.GetById(txtMaQuyen.Text)) return;
                var kq = _dataQuyen.UpdateQuyen(new Quyen_DTO()
                {
                    TenQuyen = txtTenQuyen.Text,
                    MaQuyen = txtMaQuyen.Text,
                    GhiChu = txtGhiChu.Text
                });
                MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Text = "Update";

                txtTenQuyen.Text = _tmpDto.TenQuyen;
                txtGhiChu.Text = _tmpDto.GhiChu;

                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;

                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnSave.Enabled = !btnSave.Enabled;

                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                if (!_dataQuyen.GetById(txtMaQuyen.Text))
                {
                   return;
                }
                var kq = _dataQuyen.XoaQuyen(txtMaQuyen.Text);
                MessageBox.Show("Xóa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXoa.Text = "Delete";
                btnUpdate.Enabled = !btnUpdate.Enabled;
                btnThem.Enabled = !btnThem.Enabled;
                btnSave.Enabled = !btnSave.Enabled;
                dgvQuyen.Enabled = !dgvQuyen.Enabled;

            }
            _dataQuyen.SaveChanged();
            LoadGridViewQuyen();
}
    }
}