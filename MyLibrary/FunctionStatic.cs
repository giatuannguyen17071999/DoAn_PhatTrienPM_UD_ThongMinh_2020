using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary.fdPopup;
using System.IO;
using DevExpress.XtraBars.Ribbon;

namespace MyLibrary
{
    public class FunctionStatic
    {
        public const string imgPolder = @"../../Contents/Images/";
        public const string imgNotFound = "imgNotFound.jpg";
        public const string GIOI_THIEU_UNG_DUNG =
            "TRƯỜNG ĐẠI HỌC CÔNG NGHIỆP THỰC PHẨM\n" +
            "THÀNH PHỐ HỒ CHÍ MINH\n" +
            "Đồ án môn công nghệ phần mềm\n" +
            "Năm Học 2020\n" +
            "CÁC THÀNH VIÊN TRONG NHÓM\n" +
            "1. NGUYỄN QUỐC VIỆT\n" +
            "2. BÙI VŨ TRƯỜNG\n" +
            "3. TRẦN BẢO LONG\n" +
            "4. LÝ XUÂN THÀNH\n" +
            "5. NGUYỄN TRẦN GIA TUẤN";

        public const string GIOI_THIEU_TRUONG = 
            "TRƯỜNG ĐẠI HỌC CÔNG NGHIỆP THỰC PHẨM\n" +
            "THÀNH PHỐ HỒ CHÍ MINH";

        public const string GIOI_THIEU_TEN_MON = 
            "Đồ án môn công nghệ phần mềm\n" +
            "Năm Học 2020";

        public const string GIOI_THIEU_THANH_VIEN =
            "CÁC THÀNH VIÊN TRONG NHÓM\n" +
            "1. NGUYỄN QUỐC VIỆT\n" +
            "2. BÙI VŨ TRƯỜNG\n" +
            "3. TRẦN BẢO LONG\n" +
            "4. LÝ XUÂN THÀNH\n" +
            "5. NGUYỄN TRẦN GIA TUẤN";

        public static void hienThiFormMoi(Form frmCha, Form frmDich)
        {
            foreach (Form f in frmCha.MdiChildren)
                if (f.GetType() == frmDich.GetType())
                    f.Close();

            if (frmDich.Name.Equals("frmBanHang") || frmDich.Name.Equals("frmThongTin"))
            {
                RibbonControl rid = frmCha.Controls["ribbonMain"] as RibbonControl;
                rid.Minimized = true;
            }
            else
            {
                RibbonControl rid = frmCha.Controls["ribbonMain"] as RibbonControl;
                rid.Minimized = false;
            }
            frmDich.MdiParent = frmCha;
            frmDich.Show();
        }

        public static string layTextGridView(GridView gridView,int row, int col)
        {
            if (row < 0 || row >= gridView.RowCount)
                return null;
            var text = gridView.GetRowCellValue(row, gridView.Columns[col]);
            return text == null ? null : text.ToString();
        }

        public static void hienThiThongBaoLoi(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void hienThiThongBaoThanhCong(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult hienThiCauHoiYesNo(string mess)
        {
            return MessageBox.Show(mess, "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static string layGhiChuTuNguoiDung()
        {
            string ghiChu = null;
            frmThemGhiChu frmThemGhiChu = new frmThemGhiChu();
            DialogResult result = frmThemGhiChu.ShowDialog();
            if (result == DialogResult.Yes)
                ghiChu = frmThemGhiChu.GHICHU;

            return ghiChu;
        }

        public static string chonFileNameHinhAnh()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
            DialogResult res = of.ShowDialog();
            return res == DialogResult.OK ? of.FileName : null;
        }

        public static string copyHinh(string fNguon)
        {
            if (string.IsNullOrEmpty(fNguon))
                return string.Empty;
            DateTime dt = DateTime.Now;
            string fDich = string.Format("sp{0}_{1}_{2}_{3}_{4}_{5}.jpg", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            File.Copy(fNguon, imgPolder + fDich);
            return fDich;
        }

        public static void xoaHinh(string tenHinh)
        {
            if (File.Exists(imgPolder + tenHinh))
                File.Delete(imgPolder + tenHinh);
        }

        public static string capNhatHinh(string tenHinhCu, string fNguon)
        {
            if (!tenHinhCu.Equals(imgNotFound))
                xoaHinh(tenHinhCu);
            return copyHinh(fNguon);
        }
    }
}