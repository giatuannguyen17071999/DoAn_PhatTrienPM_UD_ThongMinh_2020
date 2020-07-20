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

                MessageBox.Show(kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadGridViewQuyen()
        {
            dgvQuyen.DataSource = _dataQuyen.layTatCa();
        }

        private void btnUpdateQuyen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaQuyen.Text)) return;
            var kq = _dataQuyen.UpdateQuyen(new Quyen_DTO()
            {
                TenQuyen = txtTenQuyen.Text,
                MaQuyen = txtMaQuyen.Text,
                GhiChu = txtGhiChu.Text
            });
            MessageBox.Show(kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmQuanLyQuyen_Load(object sender, EventArgs e)
        {
            LoadGridViewQuyen();
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaQuyen.Text)) return;
            var layPhanQuyens = _dataPhanQuyen.layTheoQuyen(txtMaQuyen.Text).Select(x => new PHANQUYEN()
            {
                MAQUYEN = x.MaQuyen,
                MANHOM = x.MaNhom,
                COQUYEN = x.CoQuyen
            }).ToList();
            if (layPhanQuyens.Count > 0)
            {
                if (_dataPhanQuyen.xoaPhanQuyen(layPhanQuyens))
                {
                    var kq = _dataQuyen.XoaQuyen(txtMaQuyen.Text);

                    MessageBox.Show(kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var kq = _dataQuyen.XoaQuyen(txtMaQuyen.Text);
                MessageBox.Show(kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }
    }
}