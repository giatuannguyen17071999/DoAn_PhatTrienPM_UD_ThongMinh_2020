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
using MyLibrary;
using System.Threading;
using ControlDesign;
using System.Runtime.CompilerServices;
using LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdBanHang.frmPhatSinh;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdBanHang
{
    public partial class frmBanHang : DevExpress.XtraEditors.XtraForm
    {
        private DanhMuc_DAL_BLL dmDAL_BLL;
        private LoaiSP_DAL_BLL loaiDAL_BLL;
        private string imgPolder = FunctionStatic.imgPolder;
        private SanPham_DAL_BLL spDAL_BLL;
        private KhachHang_DTO khChoInHoaDon;
        private DonHang dhChoInHoaDon;
        private DonHang_DAL_BLL dhDAL_BLL;
        private CTDonHang_DAL_BLL ctDonHangDAL_BLL;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            //khoi tao
            dmDAL_BLL = new DanhMuc_DAL_BLL();
            loaiDAL_BLL = new LoaiSP_DAL_BLL();
            spDAL_BLL = new SanPham_DAL_BLL();
            dhDAL_BLL = new DonHang_DAL_BLL();
            ctDonHangDAL_BLL = new CTDonHang_DAL_BLL();

            //load
            loadTrvDanhMuc_TheLoai();
            initMyComponent();
            taiSanPhams(spDAL_BLL.latTaCa());
            loadCboxTimKiem();

            //event
            btnTimKiem.Click += BtnTimKiem_Click;
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string cboxSelect = (cboxTimKiem.SelectedItem as KeyValue).Key;
            if (cboxSelect.Equals("masp"))
                taiSanPhams(spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_THEO_MA, tbTimKiem.Text));
            else
                taiSanPhams(spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_THEM_TEN, tbTimKiem.Text));
        }

        private void loadTrvDanhMuc_TheLoai()
        {
            List<DanhMuc_DTO> dms = dmDAL_BLL.layTatCa();
            List<LoaiSP_DTO> lsps;

            TreeNode tNode, tNodeChild;
            foreach(DanhMuc_DTO dm in dms)
            {
                tNode = new TreeNode();
                tNode.Tag = dm;
                tNode.Text = dm.TenDM;
                //child
                lsps = loaiDAL_BLL.layTatCa(dm.MaDM);
                foreach(LoaiSP_DTO lsp in lsps)
                {
                    tNodeChild = new TreeNode();
                    tNodeChild.Tag = lsp.MaLoai;
                    tNodeChild.Text = lsp.TenLoaiSP;
                    tNodeChild.Tag = lsp;
                    tNode.Nodes.Add(tNodeChild);
                }

                trvDanhMuc_TheLoai.Nodes.Add(tNode);
            }
        }

        private void initMyComponent()
        {
            CheckForIllegalCrossThreadCalls = false;

            pnSanPhams.BackColor = Color.FromArgb(180, 174, 181);
            pnLogo.BackgroundImage = Image.FromFile(imgPolder + "logoSieuThi.png");
            pnLogo.BackgroundImageLayout = ImageLayout.Stretch;
            lbIconInfo.Image = Image.FromFile(imgPolder + "iconInfo1.png");
            pnTacVus.BackColor = Color.LightBlue;
            pnThongKeHomNay.BackgroundImage = Image.FromFile(imgPolder + "iconPhanTichBanHang.png");
            pnThongKeHomNay.BackgroundImageLayout = ImageLayout.Center;
            pnBaoCaoHomNay.BackgroundImage = Image.FromFile(imgPolder + "iconBaoCaoBanHang.png");
            pnBaoCaoHomNay.BackgroundImageLayout = ImageLayout.Center;
            pnIconChaoMung.BackgroundImage = Image.FromFile(imgPolder + "iconChaoMungUser.png");
            pnIconChaoMung.BackgroundImageLayout = ImageLayout.Center;
            lbKhachHangDoi.TextAlign = ContentAlignment.MiddleCenter;
            lbKhachHangDoi.Text = "Khách Hàng Đang Chờ In Hóa Đơn";
            rdoDuoi2Trieu.Checked = true;
            lbChaoMung.TextAlign = ContentAlignment.MiddleLeft;
            //lbChaoMung.Text = string.Format("Chào Mừng Nhân Viên: {0} ({1})", nhanVien["TaiKhoan"].ToString(), nhanVien["TenNV"].ToString());
            cboxLocTheoLichSu.SelectedIndex = 0;
        }

        private UserControl sanXuatPanel(SanPham_DTO sanPham)
        {
            UCSanPham ucSP = new UCSanPham(sanPham);
            ucSP.setControlTrangThaiHover(ttripLblShowTrangThai);
            Control ctr = ucSP.Controls["pnAnhSanPham"];
            ctr.Click += Ctr_Click;

            return ucSP;
        }

        private void Ctr_Click(object sender, EventArgs e)
        {
            if (khChoInHoaDon == null)
            {
                frmChonKhachHang frm = new frmChonKhachHang();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.Cancel)
                    return;
                khChoInHoaDon = frm.khChon;
                themMotDongHoaDon();
            }

            Control pnAnh = sender as Control;
            SanPham_DTO sp = (pnAnh.Tag) as SanPham_DTO;
            themMotChiTietDonHang(sp);
            tabCT.SelectedIndex = 1;
         }

        private void themMotChiTietDonHang(SanPham_DTO sp)
        {
            CTDonHang ctDon = new CTDonHang();
            ctDon.MaDH = dhChoInHoaDon.MaDH;
            ctDon.MaSP = sp.MaSP;
            ctDon.SoLuong = 1;
            ctDon.DonGia = sp.GiaBan;
            bool isThem = ctDonHangDAL_BLL.them(ctDon);
            if (!isThem)
            {
                FunctionStatic.hienThiThongBaoLoi("Lỗi Thêm một chi tiết đơn hàng!");
                return;
            }
            FunctionStatic.hienThiThongBaoThanhCong("Thêm một chi tiết đơn hàng thành công!");
            themMotSanPham_vaoGioHang_GiaoDien(sp);
        }

        private UCSanPham laSanPhamTonTaiTrongGioHang(string maSP)
        {
            foreach (Control ctr in pnGioHang.Controls)
                if (((ctr.Controls["pnAnhSanPham"].Tag) as SanPham_DTO).MaSP.Equals(maSP))
                    return ctr as UCSanPham;
            return null;
        }

        private void themMotSanPham_vaoGioHang_GiaoDien(SanPham_DTO sanPham)
        {
            UCSanPham UCSPTim = laSanPhamTonTaiTrongGioHang(sanPham.MaSP);
            if (UCSPTim != null)
            {
                int sl = int.Parse(UCSPTim.Controls["lbSoLuongSanPham"].Tag.ToString());
                Label lbSL = UCSPTim.Controls["lbSoLuongSanPham"] as Label;
                lbSL.Tag = (sl + 1).ToString();
                lbSL.Text = string.Format("SL Mua: {0}", lbSL.Tag);
                //setTongTienGioHang();
                return;
            }

            UserControl UCItemGioHang = sanXuatPanel(sanPham);
            UCItemGioHang.Height = 350;

            Label lbSperator = new Label();
            lbSperator.Width = 200;
            lbSperator.Height = 10;
            lbSperator.BackColor = Color.White;
            lbSperator.Top = 280;
            UCItemGioHang.Controls.Add(lbSperator);

            Label lbChonSoLuongMua = new Label();
            lbChonSoLuongMua.AutoSize = false;
            lbChonSoLuongMua.Width = 200;
            lbChonSoLuongMua.TextAlign = ContentAlignment.MiddleCenter;
            lbChonSoLuongMua.Text = "CHỌN SỐ LƯỢNG SẢN PHẨM";
            lbChonSoLuongMua.Top = 290;
            lbChonSoLuongMua.ForeColor = Color.DarkRed;
            lbChonSoLuongMua.Font = new Font(lbChonSoLuongMua.Font.FontFamily, 9f, FontStyle.Bold);
            UCItemGioHang.Controls.Add(lbChonSoLuongMua);

            Label lbGiamSL = new Label();
            Label lbTangSL = new Label();
            lbGiamSL.Text = "-";
            lbTangSL.Text = "+";
            lbGiamSL.Cursor = lbTangSL.Cursor = Cursors.Hand;
            lbGiamSL.Width = lbGiamSL.Height = lbTangSL.Width = lbTangSL.Height = 30;
            lbGiamSL.BackColor = lbTangSL.BackColor = Color.DarkSalmon;
            lbGiamSL.ForeColor = lbTangSL.ForeColor = Color.DarkRed;
            lbGiamSL.Font = lbTangSL.Font = new Font(lbGiamSL.Font.FontFamily, 14f, FontStyle.Bold);
            lbGiamSL.Top = lbTangSL.Top = 310;
            lbGiamSL.TextAlign = lbTangSL.TextAlign = ContentAlignment.MiddleCenter;
            lbGiamSL.Left = 10;
            lbTangSL.Left = 150;
            //lbGiamSL.Click += lbGiamSL_Click;
            //lbTangSL.Click += lbTangSL_Click;

            UCItemGioHang.Controls.Add(lbGiamSL);
            UCItemGioHang.Controls.Add(lbTangSL);

            Label lbSoLuongSanPham = new Label();
            lbSoLuongSanPham.Name = "lbSoLuongSanPham";
            lbSoLuongSanPham.Tag = 1;
            lbSoLuongSanPham.Width = 100;
            lbSoLuongSanPham.Height = 30;
            lbSoLuongSanPham.BackColor = Color.DarkOliveGreen;
            lbSoLuongSanPham.ForeColor = Color.White;
            lbSoLuongSanPham.TextAlign = ContentAlignment.MiddleCenter;
            lbSoLuongSanPham.Text = string.Format("SL Mua: {0}", lbSoLuongSanPham.Tag);
            lbSoLuongSanPham.Top = 310;
            lbSoLuongSanPham.Left = 45;
            UCItemGioHang.Controls.Add(lbSoLuongSanPham);

            //pnItemGioHang.Controls["pnAnhSanPham"].Click -= pnAnh_Click;
            //pnItemGioHang.Controls["pnAnhSanPham"].Click += pnAnhSanPhamGioHang_click;
            int space = 20;
            int soT = pnGioHang.Controls.Count / 3, soL = pnGioHang.Controls.Count % 3;// soT: Buoc Nhay Top | soL: Buoc Nhay L
            if (pnGioHang.Controls.Count == 0)
                soL = 0;
            int top = soT * (UCItemGioHang.Height + space),
                left = soL * (UCItemGioHang.Width + space);
            UCItemGioHang.Top = top;
            UCItemGioHang.Left = left;
            pnGioHang.Controls.Add(UCItemGioHang);
            //setTongTienGioHang();
        }

        private void themMotDongHoaDon()
        {
            dhChoInHoaDon = new DonHang();
            dhChoInHoaDon.MaKH = khChoInHoaDon.MaKH;
            dhChoInHoaDon = dhDAL_BLL.them(dhChoInHoaDon);
            MessageBox.Show(dhChoInHoaDon.MaDH.ToString());
        }

        private void taiSanPhams(List<SanPham_DTO> sanPhams)
        {
            Thread th = new Thread(() =>
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    pnSanPhams.Controls.Clear();
                    pnSanPhams.AutoScroll = true;
                    UserControl pn;
                    int dem = 0, px = 0, py = 0, space = 20, sl = sanPhams.Count;
                    ttripProgessBarTienTrinhTaiSanPhams.Minimum = 0;
                    ttripProgessBarTienTrinhTaiSanPhams.Maximum = sl;
                    ttripProgessBarTienTrinhTaiSanPhams.Step = 1;
                    for (int i = 0; i < sl; i++)
                    {
                        pn = sanXuatPanel(sanPhams[i]);

                        pn.Location = new Point(px++ * (pn.Width + space) + space, py * (pn.Height + space) + space);
                        pnSanPhams.Controls.Add(pn);
                        ttripProgessBarTienTrinhTaiSanPhams.PerformStep();
                        if (i == sl - 1)
                            ttripProgessBarTienTrinhTaiSanPhams.Value = 0;
                        if (dem++ == 4)
                        {
                            px = 0;
                            py += 1;
                            dem = 0;
                        }
                    }
                });
            });
            th.Start();
        }

        private void lbIconInfo_MouseMove(object sender, MouseEventArgs e)
        {
            lbIconInfo.Image = Image.FromFile(imgPolder + "iconInfo2.png");
            lbIconInfo.Cursor = Cursors.Hand;
        }

        private void lbIconInfo_MouseLeave(object sender, EventArgs e)
        {
            lbIconInfo.Image = Image.FromFile(imgPolder + "iconInfo1.png");
        }

        private void pnThongKeHomNay_MouseMove(object sender, MouseEventArgs e)
        {
            Control ct = sender as Control;
            ct.BackColor = Color.LightCoral;
        }

        private void pnThongKeHomNay_MouseLeave(object sender, EventArgs e)
        {
            Control ct = sender as Control;
            ct.BackColor = Color.LightBlue;
        }

        private void rdoDuoi2Trieu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            if (rdb.Name.Equals(rdoDuoi2Trieu.Name))
                taiSanPhams(spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_GIA_DUOI, "2000000"));
            else if (rdb.Name.Equals(rdoDuoi5Trieu.Name))
                taiSanPhams(spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_GIA_DUOI, "5000000"));
            else
                taiSanPhams(spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_GIA_TREN, "5000000"));
        }

        private void loadCboxTimKiem()
        {
            cboxTimKiem.Items.Add(new KeyValue { Key = "masp", Value = "Tìm Theo Mã" });
            cboxTimKiem.Items.Add(new KeyValue { Key= "tensp", Value= "Tìm Theo Tên"});

            cboxTimKiem.DisplayMember = "Value";
            cboxTimKiem.ValueMember = "key";

            cboxTimKiem.SelectedIndex = 0;
        }

        private void trvDanhMuc_TheLoai_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                LoaiSP_DTO lsp = e.Node.Tag as LoaiSP_DTO;
                taiSanPhams(spDAL_BLL.latTaCa(lsp.MaLoai));
            }
            else if (e.Node.Level == 0)
            {
                DanhMuc_DTO dm = e.Node.Tag as DanhMuc_DTO;
                taiSanPhams(spDAL_BLL.locTheoDanhMuc(dm.MaDM));
            }
        }
    }
}