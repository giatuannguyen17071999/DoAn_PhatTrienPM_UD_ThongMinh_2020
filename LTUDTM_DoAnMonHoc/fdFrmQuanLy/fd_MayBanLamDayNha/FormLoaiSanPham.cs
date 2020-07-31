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

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class FormLoaiSanPham : DevExpress.XtraEditors.XtraForm
    {
        LoaiSP_DAL_BLL loaisanphams = new LoaiSP_DAL_BLL();
        DanhMuc_DAL_BLL danhmucs = new DanhMuc_DAL_BLL();
        public FormLoaiSanPham()
        {
            InitializeComponent();
            load();
        }
        int rowHienTai = -1;
        bool isThem = false;
        bool isSua = false;

        private void load()
        {
            loaisanphams = new LoaiSP_DAL_BLL();
            gcChuaDuLieu.DataSource = loaisanphams.layTatCaLoaiSP();
        }
        private void LoadDanhMuc()
        {
            lookupTenDM.Properties.DataSource = danhmucs.layTatCaDanhMuc();
            lookupTenDM.Properties.DisplayMember = "TenDM";
            lookupTenDM.Properties.ValueMember = "MaDM";
            lookupTenDM.ItemIndex = 0;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String tacvu = barbtnThem.Caption.Trim();
            if (tacvu.Equals("Thêm"))
            {
                isThem = true;
                barbtnThem.Caption = "Hủy";
                barbtnSua.Enabled = false;
                txtTenLoaiSP.Enabled = true;
                lookupTenDM.Enabled = true;
                txtTenLoaiSP.Text = "";
            }
            else if (tacvu.Equals("Hủy"))
            {
                isThem = false;
                barbtnThem.Caption = "Thêm";
                txtTenLoaiSP.Enabled = false;
                lookupTenDM.Enabled = false;
                barbtnSua.Enabled = true;
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult kq = XtraMessageBox.Show("Bạn Muốn Xóa Không ? ", "Thông Báo", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                if (rowHienTai < 0)
                    return;
                String MaLoaiSP = gvHienThiDuLieu.GetRowCellValue(rowHienTai, "MaLoai").ToString();
                bool ketqua = loaisanphams.XoaLoaiSanPham(MaLoaiSP);
                if (ketqua == true)
                {
                    load();
                    XtraMessageBox.Show("Đã Xóa Thành Công ");
                   
                }
                else
                {
                    load();
                    XtraMessageBox.Show("Xóa Không Thành Công ");
                }
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String tacvu = barbtnSua.Caption.Trim();
            if (tacvu.Equals("Sửa"))
            {
                isSua = true;
                barbtnSua.Caption = "Hủy";
                barbtnThem.Enabled = false;
                txtTenLoaiSP.Enabled = true;
            }
            else if (tacvu.Equals("Hủy"))
            {
                isSua = false;
                barbtnSua.Caption = "Sửa";
                barbtnThem.Enabled = true;
                txtTenLoaiSP.Enabled = false;
            }
        }

        private void barbtnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load();
        }
        private void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThem == true)
            {
                String TenLoaiSanPham = txtTenLoaiSP.Text;
                String MaDM = lookupTenDM.EditValue.ToString();

                if (TenLoaiSanPham == "" || String.IsNullOrEmpty(TenLoaiSanPham) || lookupTenDM.EditValue == null)
                {
                    XtraMessageBox.Show("Không Được Để Trống !!!");
                    return;
                }
                else
                {
                    bool kq = loaisanphams.ThemLoaiSanPham(TenLoaiSanPham, MaDM);
                    if (kq == true)
                    {
                        isThem = false;
                        barbtnThem.Caption = "Thêm";
                        txtTenLoaiSP.Enabled = false;
                        lookupTenDM.Enabled = false;
                        barbtnSua.Enabled = true;
                        load();
                        XtraMessageBox.Show("Bạn Đã Thêm Thành Công !!!");
                    }
                    else
                    {
                        isThem = false;
                        barbtnThem.Caption = "Thêm";
                        txtTenLoaiSP.Enabled = false;
                        barbtnSua.Enabled = true;
                        lookupTenDM.Enabled = false;
                        load();
                        XtraMessageBox.Show("Tên Danh Mục Này Đã Tồn Tại !!!");
                    }
                }
            }
            if (isSua == true)
            {
                String TenLoaiSanPham = txtTenLoaiSP.Text;
                String MaDanhMuc = lookupTenDM.EditValue.ToString();
                if (TenLoaiSanPham == "" || String.IsNullOrEmpty(TenLoaiSanPham) || lookupTenDM.EditValue == null)
                {
                    XtraMessageBox.Show("Không Được Để Trống !!!");
                    return;
                }
                else
                {
                    bool kq = loaisanphams.SuaLoaiSanPham(lsp.MaLoai.ToString(), txtTenLoaiSP.Text, lookupTenDM.EditValue.ToString());
                    if (kq == true)
                    {
                        isSua = false;
                        barbtnSua.Caption = "Sửa";
                        barbtnThem.Enabled = true;
                        txtTenLoaiSP.Enabled = false;
                        load();
                        XtraMessageBox.Show("Cập Nhập Thành Công");
                    }
                    else
                    {
                        isSua = false;
                        barbtnSua.Caption = "Sửa";
                        barbtnThem.Enabled = true;
                        txtTenLoaiSP.Enabled = false;
                        load();
                        XtraMessageBox.Show("Cập Nhập Thất Bại");
                    }
                }
            }
        }

        private void FormLoaiSanPham_Load(object sender, EventArgs e)
        {
            load();
            LoadDanhMuc();
        }
        LoaiSP lsp;
        private void gvHienThiDuLieu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            rowHienTai = e.FocusedRowHandle;
            if (rowHienTai < 0)
                return;
            txtTenLoaiSP.Text = gvHienThiDuLieu.GetRowCellValue(rowHienTai, "TenLoaiSP").ToString();
            String MaLoaiSP = gvHienThiDuLieu.GetRowCellValue(rowHienTai, "MaLoai").ToString();
            lsp = new LoaiSP();

            int maloaisp = int.Parse(MaLoaiSP);
            lsp = loaisanphams.LoaiSanPhamTheoMaLoaiSP(maloaisp);
            lookupTenDM.EditValue = lsp.MaDM;
        }
    }
}