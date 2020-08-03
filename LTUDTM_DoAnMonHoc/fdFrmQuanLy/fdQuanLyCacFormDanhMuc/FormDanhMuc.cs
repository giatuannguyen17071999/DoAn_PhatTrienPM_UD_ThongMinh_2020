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
using DevExpress.ClipboardSource.SpreadsheetML;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    public partial class FormDanhMuc : DevExpress.XtraEditors.XtraForm
    {
        DanhMuc_DAL_BLL danhmucs = new DanhMuc_DAL_BLL();
        public FormDanhMuc()
        {
            InitializeComponent();
            load();
        }
        int rowHienTai = -1;
        bool isThem = false;
        bool isSua = false;

        private void load()
        {
            gcChuaDuLieu.DataSource = danhmucs.layTatCa();
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String tacvu = barbtnThem.Caption.Trim();
            if(tacvu.Equals("Thêm"))
            {
                isThem = true;
                barbtnThem.Caption = "Hủy";
                barbtnSua.Enabled = false;
                txtTenDanhMuc.Enabled = true;
                txtTenDanhMuc.Text = "";
            }
            else if (tacvu.Equals("Hủy"))
            {
                isThem = false;
                barbtnThem.Caption = "Thêm";
                txtTenDanhMuc.Enabled = false;
                barbtnSua.Enabled = true;
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
                txtTenDanhMuc.Enabled = true;
            }
            else if (tacvu.Equals("Hủy"))
            {
                isSua = false;
                barbtnSua.Caption = "Sửa";
                barbtnThem.Enabled = true;
                txtTenDanhMuc.Enabled = false;
            }
        }

        private void barbtnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load();
        }

        private void gvHienThiDuLieu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            rowHienTai = e.FocusedRowHandle;
            if (rowHienTai < 0)
                return;
            txtTenDanhMuc.Text = gvHienThiDuLieu.GetRowCellValue(rowHienTai, "TenDM").ToString();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String MaDM = gvHienThiDuLieu.GetRowCellValue(rowHienTai, "MaDM").ToString();
            DialogResult quyetdinh = XtraMessageBox.Show("Bạn Muốn Xóa Không ? ", "Thông Báo ", MessageBoxButtons.YesNo);
            if(quyetdinh==DialogResult.Yes)
            {
                bool kq = danhmucs.XoaDanhMuc(MaDM);
                if (kq)
                {
                    XtraMessageBox.Show("Đã Xóa Thành Công");
                    load();
                }
                else
                {
                    XtraMessageBox.Show("Xóa Không Thành Công");
                    load();
                }
            }    
        }

        private void barbtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(isThem==true)
            {
                String TenDanhMuc = txtTenDanhMuc.Text;
                if(string.IsNullOrEmpty(TenDanhMuc)|| TenDanhMuc == " ")
                {
                    XtraMessageBox.Show("Không Được Để Trống !!!");
                }
                else
                {
                    bool kq = danhmucs.ThemDanhMuc(TenDanhMuc);
                    if (kq == true)
                    {
                        isThem = false;
                        barbtnThem.Caption = "Thêm";
                        txtTenDanhMuc.Enabled = false;
                        barbtnSua.Enabled = true;
                        load();
                        XtraMessageBox.Show("Bạn Đã Thêm Thành Công !!!");
                    }
                    else
                    {
                        isThem = false;
                        barbtnThem.Caption = "Thêm";
                        txtTenDanhMuc.Enabled = false;
                        barbtnSua.Enabled = true;
                        load();
                        XtraMessageBox.Show("Tên Danh Mục Này Đã Tồn Tại !!!");
                    }
                }
            }
            if(isSua==true)
            {
                String TenDanhMuc = txtTenDanhMuc.Text;
                String MaDM = gvHienThiDuLieu.GetRowCellValue(rowHienTai, "MaDM").ToString();
                if (TenDanhMuc == "" || String.IsNullOrEmpty(TenDanhMuc))
                {
                    XtraMessageBox.Show("Không Được Để Trống !!!");
                    return;
                }
                else
                {
                    bool kq = danhmucs.SuaDanhMuc(MaDM, txtTenDanhMuc.Text);
                    if (kq == true)
                    {
                        isSua = false;
                        barbtnSua.Caption = "Sửa";
                        barbtnThem.Enabled = true;
                        txtTenDanhMuc.Enabled = false;
                        load();
                        XtraMessageBox.Show("Cập Nhập Thành Công");
                        
                    }
                    else
                    {
                        isSua = false;
                        barbtnSua.Caption = "Sửa";
                        barbtnThem.Enabled = true;
                        txtTenDanhMuc.Enabled = false;
                        load();
                        XtraMessageBox.Show("Cập Nhập Thất Bại");
                    }
                }
            }
        }
    }
}