using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary.fdPopup;

namespace MyLibrary
{
    public class FunctionStatic
    {
        public const string imgPolder = @"../../Contents/Images/";

        public static void hienThiFormMoi(Form frmCha, Form frmDich)
        {
            foreach (Form f in frmCha.MdiChildren)
                if (f.GetType() == frmDich.GetType())
                    f.Close();
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
    }
}