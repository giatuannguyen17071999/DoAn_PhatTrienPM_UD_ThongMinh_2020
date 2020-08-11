using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;
using DTO;
using System.IO;

namespace ControlDesign
{
    public partial class UCSanPham : UserControl
    {
        private string imgPolder = FunctionStatic.imgPolder;
        private ToolStripStatusLabel ctrTrangThaiHover;

        public void setControlTrangThaiHover(ToolStripStatusLabel ctr)
        {
            ctrTrangThaiHover = ctr;
        }

        private void loadPicHinh(Control ctr, string fName)
        {
            using (FileStream fs = new FileStream(fName, FileMode.Open, FileAccess.Read))
            {
                ctr.BackgroundImage = Image.FromStream(fs);
                fs.Dispose();
                ctr.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        public UCSanPham(SanPham_DTO sanPham)
        {
            InitializeComponent();

            UserControl pn = this;
            pn.Width = 200;
            pn.Height = 280;
            pn.BackColor = Color.Gray;
            pn.Cursor = Cursors.Default;
            pn.BorderStyle = BorderStyle.Fixed3D;

            Panel pnAnh = new Panel();
            pnAnh.Name = "pnAnhSanPham";
            pnAnh.Size = new Size(180, 150);
            pnAnh.Top = 10;
            pnAnh.Left = 10;
            pnAnh.BackColor = Color.White;
            loadPicHinh(pnAnh, imgPolder + sanPham.Hinh);
            pnAnh.Tag = sanPham;

            Label lbMaSP = new Label();
            lbMaSP.AutoSize = true;
            lbMaSP.TextAlign = ContentAlignment.MiddleCenter;
            lbMaSP.BackColor = Color.DarkRed;
            lbMaSP.ForeColor = Color.Gold;
            lbMaSP.Text = string.Format("MaSP: {0}", sanPham.MaSP);
            lbMaSP.Top = lbMaSP.Left = 5;
            pnAnh.Controls.Add(lbMaSP);

            Label lbGia = new Label();
            lbGia.Width = 180;
            lbGia.Height = 20;
            lbGia.Top = 170;
            lbGia.Left = 10;
            lbGia.BackColor = Color.DarkRed;
            lbGia.ForeColor = Color.Gold;
            lbGia.Font = new Font(lbGia.Font.FontFamily, 11.0f);
            lbGia.TextAlign = ContentAlignment.MiddleCenter;
            lbGia.Text = string.Format("Giá {0:N0} VND", sanPham.GiaBan);

            Label lbSLTon = new Label();
            lbSLTon.Width = 180;
            lbSLTon.Height = 20;
            lbSLTon.Top = 200;
            lbSLTon.Left = 10;
            lbSLTon.ForeColor = Color.Gold;
            lbSLTon.Font = new Font(lbGia.Font.FontFamily, 11.0f);
            lbSLTon.TextAlign = ContentAlignment.MiddleCenter;
            lbSLTon.Text = string.Format("Tồn Kho {0:N0} Cái", sanPham.SlTon);

            Label lbTenSanPham = new Label();
            lbTenSanPham.Width = 180;
            lbTenSanPham.Height = 40;
            lbTenSanPham.Top = 230;
            lbTenSanPham.Left = 10;
            lbTenSanPham.ForeColor = Color.Gold;
            lbTenSanPham.Font = new Font(lbGia.Font.FontFamily, 7f);
            lbTenSanPham.TextAlign = ContentAlignment.MiddleCenter;
            lbTenSanPham.Text = sanPham.TenSP;

            pn.Controls.Add(pnAnh);
            pn.Controls.Add(lbGia);
            pn.Controls.Add(lbSLTon);
            pn.Controls.Add(lbTenSanPham);

            pnAnh.Cursor = Cursors.Hand;
            pnAnh.MouseMove += pnAnh_MouseMove;
            pnAnh.MouseLeave += pnAnh_MouseLeave;
            pnAnh.Click += null;
        }

        void pnAnh_MouseLeave(object sender, EventArgs e)
        {
            Control ct = (sender as Control).Parent;
            ct.BackColor = Color.Gray;
            if (ctrTrangThaiHover != null)
                ctrTrangThaiHover.Text = string.Empty;
        }

        void pnAnh_MouseMove(object sender, MouseEventArgs e)
        {
            Control ct = (sender as Control).Parent;
            ct.BackColor = Color.DarkOrchid;
            SanPham_DTO sp = ct.Controls["pnAnhSanPham"].Tag as SanPham_DTO;
            if (ctrTrangThaiHover != null)
                ctrTrangThaiHover.Text = sp.TenSP;
        }
    }
}
