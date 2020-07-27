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

            if (string.IsNullOrEmpty(txtMaQuyen.Text)) return;
            var kq = _dataQuyen.AddQuyen(new Quyen_DTO()
            {
                TenQuyen = txtTenQuyen.Text,
                MaQuyen = txtMaQuyen.Text,
                GhiChu = txtGhiChu.Text
            });

            MessageBox.Show("Them " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridViewQuyen();
        }

        private void LoadGridViewQuyen()
        {
            dgvQuyen.DataSource = _dataQuyen.layTatCa();
            gvQuyen.Columns["MaQuyen"].OptionsColumn.AllowEdit = false;
            gvQuyen.Columns["MaQuyen"].OptionsColumn.ReadOnly = true;
        }

        private void btnUpdateQuyen_Click(object sender, EventArgs e)
        {
            if (!_dataQuyen.GetById(txtMaQuyen.Text)) return;
            var kq = _dataQuyen.UpdateQuyen(new Quyen_DTO()
            {
                TenQuyen = txtTenQuyen.Text,
                MaQuyen = txtMaQuyen.Text,
                GhiChu = txtGhiChu.Text
            });
            MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridViewQuyen();
        }

        private void frmQuanLyQuyen_Load(object sender, EventArgs e)
        {
            LoadGridViewQuyen();
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            if (_dataPhanQuyen.GetById(txtMaQuyen.Text))
            {
                var layPhanQuyens = _dataPhanQuyen.layTheoQuyen(txtMaQuyen.Text).Select(x => new PHANQUYEN()
                {
                    MAQUYEN = x.MaQuyen,
                    MANHOM = x.MaNhom,
                    COQUYEN = x.CoQuyen
                }).ToList();
                _dataPhanQuyen.xoaPhanQuyen(layPhanQuyens);
            }
            var kq = _dataQuyen.XoaQuyen(txtMaQuyen.Text);
            MessageBox.Show("Xóa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridViewQuyen();

        }
        private void gvQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var kq = _dataQuyen.UpdateQuyen(new Quyen_DTO()
            {
                TenQuyen = gvQuyen.GetRowCellValue(e.RowHandle, "TenQuyen").ToString(),
                MaQuyen = gvQuyen.GetRowCellValue(e.RowHandle, "MaQuyen").ToString(),
                GhiChu = gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu").ToString()
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
    }
}