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
using MyLibrary;
using DAL_BLL;
using DevExpress.ClipboardSource.SpreadsheetML;
using DTO;
using System.IO;
using DevExpress.XtraEditors.Filtering.Templates;
using LTUDTM_DoAnMonHoc.fdExcelExport;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class frmQuanLySanPham : DevExpress.XtraEditors.XtraForm
    {
        private AppControl appCtr;
        private int rowSelected;
        private bool isThem;

        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            appCtr = new AppControl();
            isThem = false;

            //load
            reloadSanPham();
            loadMaLoai();
            setReadOnly(true);
            gvSanPham.Columns[SanPham_DTO.COL_STT].Visible = false;

            //event
            gvSanPham.RowClick += GvSanPham_RowClick;
        }

        private void GvSanPham_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int r = e.RowHandle;
            if (r > -1 && r < gvSanPham.RowCount)
                rowSelected = r;
            else
                rowSelected = -1;

            bindding(true);
        }

        private void bindding(bool isRead)
        {
            if (rowSelected == -1)
            {
                clearText();
                return;
            }
            string maSP = FunctionStatic.layTextGridView(gvSanPham, rowSelected, SanPham_DTO.COL_MASP);
            SanPham_DTO sp = appCtr.getSpDAL_BLL().laySanPham(maSP);
            tbMaSP.Text = sp.MaSP;
            tbTenSP.Text = sp.TenSP;
            tbMoTa.Text = sp.MoTa;
            tbSoLuongTon.Text = sp.SlTon == null ? "0" : sp.SlTon.ToString();
            if (isRead)
                tbGiaBan.Text = string.Format("{0:N0} VND", sp.GiaBan);
            else
                tbGiaBan.Text = string.Format("{0}", sp.GiaBan);
            cboxLoaiSP.SelectedValue = sp.MaLoai;
            if (sp.CreateDate != null)
                dtpNgayTao.Value = DateTime.Parse(sp.CreateDate.ToString());

            string fileName = FunctionStatic.imgPolder + sp.Hinh;
            if (File.Exists(fileName))
                loadPicHinh(fileName);
            else
                loadPicHinh(FunctionStatic.imgPolder + FunctionStatic.imgNotFound);
            picHinhAnh.Tag = FunctionStatic.imgNotFound;
        }

        private void setReadOnly(bool isRead)
        {
            tbGiaBan.ReadOnly = tbMaSP.ReadOnly = tbMoTa.ReadOnly =
                tbSoLuongTon.ReadOnly = tbTenSP.ReadOnly = isRead;
            dtpNgayTao.Enabled = picHinhAnh.Enabled = !isRead;
            if (isRead)
                cboxLoaiSP.DropDownStyle = ComboBoxStyle.Simple;
            else
                cboxLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void reloadSanPham()
        {
            dgvSanPham.DataSource = appCtr.getSpDAL_BLL().latTaCa();
            if (gvSanPham.RowCount != 0)
                rowSelected = 0;
            else
                rowSelected = -1;
            picHinhAnh.Tag = FunctionStatic.imgNotFound;
            dtpNgayTao.Value = DateTime.Now;
            bindding(true);
        }

        private void loadMaLoai()
        {
            cboxLoaiSP.DisplayMember = "TenLoaiSP";
            cboxLoaiSP.ValueMember = "MaLoai";
            cboxLoaiSP.DataSource = appCtr.getLoaiDAL_BLL().layTatCa();
        }

        private void clearText()
        {
            tbGiaBan.Text = tbMaSP.Text = tbMoTa.Text =
                tbSoLuongTon.Text = tbTenSP.Text = string.Empty;
            loadPicHinh(FunctionStatic.imgPolder + FunctionStatic.imgNotFound);
        }

        private void initTask()
        {
            isThem = true;
            clearText();
            setReadOnly(false);
            loadPicHinh(FunctionStatic.imgPolder + FunctionStatic.imgNotFound);
            dtpNgayTao.Value = DateTime.Now;
        }

        private void initHuy()
        {
            isThem = false;
            bindding(true);
            setReadOnly(true);
            btnXoa.Enabled = btnSua.Enabled = btnDong.Enabled = btnThem.Enabled = dgvSanPham.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.ToLower().Equals("hủy"))
            {
                initHuy();
                btnThem.Text = "Thêm Sản Phẩm";
            }
            else
            {
                initTask();
                btnThem.Text = "Hủy";
                tbMaSP.ReadOnly = true;
                tbMaSP.Text = appCtr.getSpDAL_BLL().phatSinhMaTuDong();
                tbGiaBan.ReadOnly = tbSoLuongTon.ReadOnly = true;
                tbGiaBan.Text = tbSoLuongTon.Text = "Cập nhật khi nhập hàng!";
                btnXoa.Enabled = btnSua.Enabled = btnDong.Enabled = dgvSanPham.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!isThem && tbSoLuongTon.ReadOnly == true)
            {
                FunctionStatic.hienThiThongBaoLoi("Không có tác vụ nào để lưu");
                return;
            }

            SanPham sp = new SanPham();
            sp.MaSP = tbMaSP.Text;
            if (string.IsNullOrEmpty(sp.MaSP))
            {
                FunctionStatic.hienThiThongBaoLoi("Mã sản phẩm khác rỗng!");
                return;
            }
            sp.TenSP = tbTenSP.Text;
            if (string.IsNullOrEmpty(sp.TenSP))
            {
                FunctionStatic.hienThiThongBaoLoi("Tên sản phẩm khác rỗng!");
                return;
            }
            
            sp.MaLoai = int.Parse(cboxLoaiSP.SelectedValue.ToString());
            sp.CreatedDate = dtpNgayTao.Value;
            sp.Description = tbMoTa.Text;
            sp.ISDELETE = false;

            if (isThem)
            {
                if (picHinhAnh.Tag.ToString().Equals(FunctionStatic.imgNotFound))
                    sp.Hinh = FunctionStatic.imgNotFound;
                else
                    sp.Hinh = FunctionStatic.copyHinh(picHinhAnh.Tag.ToString());
                
                sp.GiaBan = sp.SL_TON = 0;
                EStatus task = appCtr.getSpDAL_BLL().them(sp);
                if (task == EStatus.TRUNG_KHOA)
                {
                    FunctionStatic.hienThiThongBaoLoi("Thêm thất bại => trùng mã!");
                    return;
                }
                if (task == EStatus.TRUNG_TEN)
                {
                    FunctionStatic.hienThiThongBaoLoi("Thêm thất bại => trùng tên!");
                    return;
                }
                FunctionStatic.hienThiThongBaoThanhCong("Thêm thành công!");
                reloadSanPham();
                btnThem.Text = "Thêm Sản Phẩm";
                initHuy();
            }
            else
            {
                //sua
                if (picHinhAnh.Tag.ToString().Equals(FunctionStatic.imgNotFound))
                    sp.Hinh = FunctionStatic.imgNotFound;
                else
                    sp.Hinh = picHinhAnh.Tag.ToString();

                if (string.IsNullOrEmpty(tbSoLuongTon.Text) || string.IsNullOrEmpty(tbGiaBan.Text))
                {
                    FunctionStatic.hienThiThongBaoLoi("Nhập Sai số lượng hoặc đơn giá");
                    return;
                }

                sp.SL_TON = int.Parse(tbSoLuongTon.Text);
                sp.GiaBan = int.Parse(tbGiaBan.Text);
                EStatus task = appCtr.getSpDAL_BLL().sua(sp);
                if (task == EStatus.THAT_BAI)
                {
                    FunctionStatic.hienThiThongBaoLoi("Sửa thất bại => không tìm thấy!");
                    return;
                }
                if (task == EStatus.TRUNG_TEN)
                {
                    FunctionStatic.hienThiThongBaoLoi("Sửa thất bại => trùng tên!");
                    return;
                }

                FunctionStatic.hienThiThongBaoThanhCong("Sửa thành công!");
                reloadSanPham();
                btnSua.Text = "Sửa Sản Phẩm";
                initHuy();
                bindding(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rowSelected == -1)
            {
                FunctionStatic.hienThiThongBaoLoi("Chưa Chọn Sản Phẩm!");
                return;
            }

            string maSP = FunctionStatic.layTextGridView(gvSanPham, rowSelected, SanPham_DTO.COL_MASP);
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Bạn có chắc xóa sản phẩm có mã [ "+maSP+" ]");
            if (res != DialogResult.Yes)
                return;

            bool task = appCtr.getSpDAL_BLL().xoa(maSP);
            if (!task)
            {
                FunctionStatic.hienThiThongBaoLoi("Xóa không thành công!");
                return;
            }

            FunctionStatic.hienThiThongBaoThanhCong("Xóa sản phẩm thành công!");
            reloadSanPham();
            bindding(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.ToLower().Equals("hủy"))
            {
                initHuy();
                btnSua.Text = "Sửa Sản Phẩm";
            }
            else
            {
                initTask();
                btnSua.Text = "Hủy";
                btnXoa.Enabled = btnThem.Enabled = btnDong.Enabled = dgvSanPham.Enabled = false;
                tbTenSP.ReadOnly = true;
                tbMaSP.ReadOnly = true;
                bindding(false);
                isThem = false;
                tbTenSP.Focus();
                tbTenSP.SelectAll();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Xác nhận đóng ?");
            if (res != DialogResult.Yes)
                return;
            Close();
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            string fNguon = FunctionStatic.chonFileNameHinhAnh();
            if (fNguon == null)
                picHinhAnh.Tag = FunctionStatic.imgNotFound;
            else
                picHinhAnh.Tag = fNguon;

            loadPicHinh(fNguon);
        }

        private void loadPicHinh(string fName)
        {
            using (FileStream fs = new FileStream(fName, FileMode.Open, FileAccess.Read))
            {
                picHinhAnh.BackgroundImage = Image.FromStream(fs);
                fs.Dispose();
                picHinhAnh.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void tbMaSP_TabIndexChanged(object sender, EventArgs e)
        {
            setSelectAll(sender);
        }

        private void setSelectAll(object sender)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;
            if (tb.Focused && !tb.ReadOnly)
                tb.SelectAll();
        }

        private void tbMaSP_MouseClick(object sender, MouseEventArgs e)
        {
            //setSelectAll(sender);
        }

        private void gvSanPham_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string maSP = FunctionStatic.layTextGridView(gvSanPham, rowSelected, SanPham_DTO.COL_MASP);
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Bạn có muốn cập nhật sản phẩm có mã: [ "+maSP+" ]?");
            if (res != DialogResult.Yes)
                return;

            FunctionStatic.hienThiThongBaoThanhCong("Chua lam cap nhat");
        }

        private void btnXuatExel_Click(object sender, EventArgs e)
        {
            ExcelExport ex = new ExcelExport();
            string fileName = "SanPhams";
            bool isEx = ex.ExportSanPhams(appCtr.getSpDAL_BLL().latTaCa(), ref fileName, false);
            if (isEx)
                ex.OpenFile(fileName);
        }
    }
}