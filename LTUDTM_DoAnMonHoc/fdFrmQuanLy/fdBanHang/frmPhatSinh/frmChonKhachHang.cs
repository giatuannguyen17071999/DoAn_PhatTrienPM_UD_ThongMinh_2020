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
using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy.frmPhatSinh;

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
            loadCboxKhachHang(false);
        }

        private void loadCboxKhachHang(bool isFull)
        {
            cboxLayKhachHang.DataSource = null;
            cboxLayKhachHang.DisplayMember = "taiKhoan";
            cboxLayKhachHang.ValueMember = "maKH";
            if (isFull)
                cboxLayKhachHang.DataSource = khDAL_BLL.LayKhachHangs();
            else
                cboxLayKhachHang.DataSource = khDAL_BLL.lay5KH_GanDay();
        }

        private void cboxLayKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadThongTin();
        }

        private void loadThongTin()
        {
          var maKH = cboxLayKhachHang.SelectedValue;
            if (maKH == null)
                return;
            var kh = khDAL_BLL.layKhachHang(int.Parse(maKH.ToString()));
            lbHoTenKH.Text = kh.HoTen;
            lbDiaChi.Text = kh.DiaChi;
            lbGioiTinh.Text = kh.GioiTinh;
            lbDienThoai.Text = kh.DienThoai1;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            KhachHang k = cboxLayKhachHang.SelectedItem as KhachHang;
            khChon = new KhachHang_DTO()
            {
                DiaChi = k.DiaChi,
                DienThoai1 = k.DienThoai,
                Email = k.Email,
                GioiTinh = k.GioiTinh,
                HoTen = k.HoTen,
                MaKH = k.MaKH,
                MatKhau = k.MatKhau,
                Status = k.Status,
                TaiKhoan = k.TaiKhoan
            };
            if (k.NgaySinh != null)
            {
                try
                {
                    khChon.NgaySinh = DateTime.ParseExact(k.NgaySinh.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null);
                }
                catch
                {

                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            object dataSource = khDAL_BLL.LayKhachHangs();
            frmTim frmTim = new frmTim(dataSource, new int[] { 0, 1, 3, 5, 6}, 0);
            DialogResult res = frmTim.ShowDialog();

            if (res == DialogResult.Yes)
            {
                loadCboxKhachHang(true);
                cboxLayKhachHang.SelectedValue = int.Parse(frmTim.valueGET);
            }
        }
    }
}