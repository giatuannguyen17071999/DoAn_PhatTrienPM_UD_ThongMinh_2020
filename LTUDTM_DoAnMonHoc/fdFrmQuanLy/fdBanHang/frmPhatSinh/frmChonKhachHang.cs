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
using DTO;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdBanHang.frmPhatSinh
{
    public partial class frmChonKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private KhachHang_DAL_BLL khDAL_BLL;
        public KhachHang_DTO khChon;

        public frmChonKhachHang()
        {
            InitializeComponent();
        }

        private void frmChonKhachHang_Load(object sender, EventArgs e)
        {
            khDAL_BLL = new KhachHang_DAL_BLL();
            //load
            loadCboxKhachHang();
        }

        private void loadCboxKhachHang()
        {
            cboxLayKhachHang.DisplayMember = "taiKhoan";
            cboxLayKhachHang.ValueMember = "maKH";
            cboxLayKhachHang.DataSource = khDAL_BLL.lay5KH_GanDay();
        }

        private void cboxLayKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadThongTin();
        }

        private void loadThongTin()
        {
          var maKH = cboxLayKhachHang.SelectedValue.ToString();
            if (maKH == null)
                return;
            var kh = khDAL_BLL.layKhachHang(int.Parse(maKH));
            lbHoTenKH.Text = kh.HoTen;
            lbDiaChi.Text = kh.DiaChi;
            lbGioiTinh.Text = kh.GioiTinh;
            lbDienThoai.Text = kh.DienThoai1;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            khChon = cboxLayKhachHang.SelectedItem as KhachHang_DTO;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}