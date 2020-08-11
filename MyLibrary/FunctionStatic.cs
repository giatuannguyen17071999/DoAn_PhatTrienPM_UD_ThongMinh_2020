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
        public const string imgPolder = @"Contents/Images/";
        public const string imgNotFound = "imgNotFound.jpg";
        public const string GIOI_THIEU_UNG_DUNG =
            "TRƯỜNG ĐẠI HỌC CÔNG NGHIỆP THỰC PHẨM\n" +
            "THÀNH PHỐ HỒ CHÍ MINH\n" +
            "Đồ án môn công nghệ phần mềm\n" +
            "Năm Học 2020\n" +
            "CÁC THÀNH VIÊN TRONG NHÓM\n" +
            "1. NGUYỄN QUỐC VIỆT\n" +
            "2. LÝ XUÂN THÀNH\n";

        public const string GIOI_THIEU_TRUONG = 
            "TRƯỜNG ĐẠI HỌC CÔNG NGHIỆP THỰC PHẨM\n" +
            "THÀNH PHỐ HỒ CHÍ MINH";

        public const string GIOI_THIEU_TEN_MON = 
            "Đồ án môn công nghệ phần mềm\n" +
            "Năm Học 2020";

        public const string GIOI_THIEU_THANH_VIEN =
            "CÁC THÀNH VIÊN TRONG NHÓM\n" +
            "1. NGUYỄN QUỐC VIỆT\n" +
            "2. LÝ XUÂN THÀNH";

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

        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }

        private static string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }


            return Ktach;

        }

        public static string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";

            return lso_chu.ToString().Trim();

        }

        public static string phatSinhMaSP(string prefix, int max, int id)
        {
            int sChuSo = id.ToString().Length;
            max -= prefix.Length ;
            for (int i = 0; i < max - sChuSo; i++)
                prefix += "0";
            return prefix + id.ToString();
        }
    }
}