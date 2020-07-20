﻿using System;
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
using System.Collections;
using DevExpress.Data.Linq.Helpers;

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
        private KhachHang_DAL_BLL khDAL_BLL;

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
            khDAL_BLL = new KhachHang_DAL_BLL();

            //load
            loadTrvDanhMuc_TheLoai();
            initMyComponent();
            taiSanPhams(spDAL_BLL.latTaCa());
            loadCboxTimKiem();
            kiemTraVaChuanBiKhiHoaDonCho();
            taiTrvLichSuGiaoDich();

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
                hienThiThongTinDonHang();
                themMotKhachHangCho(khChoInHoaDon);
            }

            Control pnAnh = sender as Control;
            SanPham_DTO sp = (pnAnh.Tag) as SanPham_DTO;
            themMotChiTietDonHang(sp);
            hienThiTongTien_TongSLMua();
            tabCT.SelectedIndex = 1;
        }

        private void hienThiTongTien_TongSLMua()
        {
            decimal? tongTien = dhDAL_BLL.layTongTien(dhChoInHoaDon.MaDH);
            txtTongTien.Text = tongTien == null ? string.Format("{0:N0}", 0) : string.Format("{0:N0}", tongTien);
            txtTongSoLuong.Text = string.Format("{0} Cái", dhDAL_BLL.layTongSoLuongCTSanPhamMua(dhChoInHoaDon.MaDH));
        }

        private void hienThiThongTinDonHang()
        {
            lbHoaDonCho.Text = "Hóa Đơn Đang Chờ: [ "+dhChoInHoaDon.MaDH+" ]";
            lbMaKhachHangGH.Text = khChoInHoaDon.MaKH.ToString();
            lbTenKhachHangGH.Text = khChoInHoaDon.HoTen;
            lbSDTGH.Text = khChoInHoaDon.DienThoai1.ToString();
            lbDiaChiKhachHangGH.Text = khChoInHoaDon.DiaChi;
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
            themMotSanPham_vaoGioHang_GiaoDien(sp, 1);
        }

        private void themMotKhachHangCho(KhachHang_DTO khCho)
        {
            pnKhachHangDois.Controls.Clear();
            Label lbKhachCho = new Label();
            lbKhachCho.Cursor = Cursors.Hand;
            lbKhachCho.Width = 300;
            lbKhachCho.Height = 30;
            lbKhachCho.BackColor = Color.DarkRed;
            lbKhachCho.ForeColor = Color.Gold;
            string str = string.Format("Mã: {0} | Tên: {1} | SDT: {2}", khCho.MaKH, khCho.HoTen, khCho.DienThoai1);
            lbKhachCho.TextAlign = ContentAlignment.MiddleCenter;
            lbKhachCho.Text = str;
            lbKhachCho.Top = 4;
            lbKhachCho.Left = 10;
            lbKhachCho.Click += LbKhachCho_Click; ;
            lbKhachCho.MouseMove += lbKhachCho_MouseMove;
            lbKhachCho.MouseLeave += lbKhachCho_MouseLeave;
            pnKhachHangDois.Controls.Add(lbKhachCho);
        }

        void lbKhachCho_MouseLeave(object sender, EventArgs e)
        {
            ttripLblShowTrangThai.Text = string.Empty;
        }

        void lbKhachCho_MouseMove(object sender, MouseEventArgs e)
        {
            ttripLblShowTrangThai.Text = "Nhấn Trái Chuộc vào để xóa khách hàng này";
        }

        private void LbKhachCho_Click(object sender, EventArgs e)
        {
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Bạn Có Chắc Muốn Xóa Khách Hàng Đang Chờ Này Không?");
            if (res == DialogResult.Yes)
            {
                ctDonHangDAL_BLL.xoa(dhChoInHoaDon.MaDH);
                dhDAL_BLL.xoa(dhChoInHoaDon.MaDH);
                dhChoInHoaDon = null;
                khChoInHoaDon = null;
                ganKhachHangTuChoiMua();
            }
        }

        private void ganKhachHangTuChoiMua()
        {
            pnKhachHangDois.Controls.Clear();
            lbMaKhachHangGH.Text = txtTongSoLuong.Text = lbTenKhachHangGH.Text = lbSDTGH.Text = txtTongTien.Text = "null";
            pnGioHang.Controls.Clear();
            tabCT.SelectedIndex = 0;
        }

        private UCSanPham laSanPhamTonTaiTrongGioHang(string maSP)
        {
            foreach (Control ctr in pnGioHang.Controls)
                if (((ctr.Controls["pnAnhSanPham"].Tag) as SanPham_DTO).MaSP.Equals(maSP))
                    return ctr as UCSanPham;
            return null;
        }

        private void themMotSanPham_vaoGioHang_GiaoDien(SanPham_DTO sanPham, int sl)
        {
            UCSanPham UCSPTim = laSanPhamTonTaiTrongGioHang(sanPham.MaSP);
            if (UCSPTim != null)
            {
                int slLay = int.Parse(UCSPTim.Controls["lbSoLuongSanPham"].Tag.ToString());
                Label lbSL = UCSPTim.Controls["lbSoLuongSanPham"] as Label;
                lbSL.Tag = (slLay + 1).ToString();
                lbSL.Text = string.Format("SL Mua: {0}", lbSL.Tag);
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
            Label lbSoLuongSanPham = new Label();
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

            lbSoLuongSanPham.Tag = sanPham.MaSP;
            lbGiamSL.Tag = lbTangSL.Tag = lbSoLuongSanPham;
            lbGiamSL.Click += LbGiamSL_Click;
            lbTangSL.Click += LbTangSL_Click;

            UCItemGioHang.Controls.Add(lbGiamSL);
            UCItemGioHang.Controls.Add(lbTangSL);

            lbSoLuongSanPham.Name = "lbSoLuongSanPham";
            lbSoLuongSanPham.Width = 100;
            lbSoLuongSanPham.Height = 30;
            lbSoLuongSanPham.BackColor = Color.DarkOliveGreen;
            lbSoLuongSanPham.ForeColor = Color.White;
            lbSoLuongSanPham.TextAlign = ContentAlignment.MiddleCenter;
            lbSoLuongSanPham.Text = string.Format("SL Mua: {0}", sl);
            lbSoLuongSanPham.Top = 310;
            lbSoLuongSanPham.Left = 45;
            UCItemGioHang.Controls.Add(lbSoLuongSanPham);

            UCItemGioHang.Controls["pnAnhSanPham"].Click -= Ctr_Click;
            UCItemGioHang.Controls["pnAnhSanPham"].Click += pnAnhGioHang_Click;
            int space = 20;
            int soT = pnGioHang.Controls.Count / 3, soL = pnGioHang.Controls.Count % 3;// soT: Buoc Nhay Top | soL: Buoc Nhay L
            if (pnGioHang.Controls.Count == 0)
                soL = 0;
            int top = soT * (UCItemGioHang.Height + space),
                left = soL * (UCItemGioHang.Width + space);
            UCItemGioHang.Top = top;
            UCItemGioHang.Left = left;
            pnGioHang.Controls.Add(UCItemGioHang);
        }

        private void pnAnhGioHang_Click(object sender, EventArgs e)
        {
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Bạn có chắc muốn xóa sản phẩm này khỏi chi tiết?");
            if (res == DialogResult.No)
                return;

            SanPham_DTO sp = (sender as Control).Tag as SanPham_DTO;
            bool isXoa = ctDonHangDAL_BLL.xoa(dhChoInHoaDon.MaDH, sp.MaSP);
            if (isXoa)
            {
                UCSanPham ucTim = laSanPhamTonTaiTrongGioHang(sp.MaSP);
                if (ucTim != null)
                {
                    pnGioHang.Controls.Clear();
                    lamMoiLaiGioHang();
                }
            }
        }

        private void taiTrvLichSuGiaoDich(List<DonHang_DTO> donHangs)
        {
            trvLichSuGiaoDich.Nodes.Clear();
            int maDH;
            KhachHang_DTO khTmp;
            DonHang_DTO dh;
            List<CTDonHang> ctDons;
            for (int i = 0; i < donHangs.Count; i++)
            {
                dh = donHangs[i];
                maDH = dh.MaDH;
                trvLichSuGiaoDich.Nodes.Add(dh.ToString());
                trvLichSuGiaoDich.Nodes[i].Tag = maDH;
                khTmp = khDAL_BLL.layKhachHang(int.Parse(dh.MaKH.ToString()));
                trvLichSuGiaoDich.Nodes[i].Nodes.Add(khTmp.ToString());
                trvLichSuGiaoDich.Nodes[i].Nodes[0].Tag = dh.MaDH;
                ctDons = ctDonHangDAL_BLL.laySanPhamDH_Mua(dh.MaDH);
                foreach (CTDonHang ct in ctDons)
                    trvLichSuGiaoDich.Nodes[i].Nodes[0].Nodes.Add(string.Format("[Ma SP: {0} - SL Mua: {1}]", ct.MaSP.Trim(), ct.SoLuong));
            }

            //trvLichSuGiaoDich.ExpandAll();
        }

        private void taiTrvLichSuGiaoDich()
        {
            string filter = cboxLocTheoLichSu.SelectedItem.ToString();
            if (filter.Equals("Tất Cả"))
                taiTrvLichSuGiaoDich(dhDAL_BLL.layLichSuGiaoDich(DonHang_DAL_BLL.ELichSu.LICH_SU_TAT_CA));
            else if (filter.Equals("Hôm Nay"))
                taiTrvLichSuGiaoDich(dhDAL_BLL.layLichSuGiaoDich(DonHang_DAL_BLL.ELichSu.LICH_SU_NGAY));
            else if (filter.Equals("Tháng Này"))
                taiTrvLichSuGiaoDich(dhDAL_BLL.layLichSuGiaoDich(DonHang_DAL_BLL.ELichSu.LICH_SU_THANG));
            else
                taiTrvLichSuGiaoDich(dhDAL_BLL.layLichSuGiaoDich(DonHang_DAL_BLL.ELichSu.LICH_SU_NAM));
        }

        private void LbTangSL_Click(object sender, EventArgs e)
        {
            Control lbSlMua = (sender as Control).Tag as Control;
            int sl = ctDonHangDAL_BLL.tangSoLuong(dhChoInHoaDon.MaDH, lbSlMua.Tag.ToString());
            hienThiTongTien_TongSLMua();
            lbSlMua.Text = string.Format("SL Mua: {0}", sl);
        }

        private void LbGiamSL_Click(object sender, EventArgs e)
        {
            Control lbSlMua = (sender as Control).Tag as Control;
            int sl = ctDonHangDAL_BLL.giamSoLuong(dhChoInHoaDon.MaDH, lbSlMua.Tag.ToString());
            hienThiTongTien_TongSLMua();
            lbSlMua.Text = string.Format("SL Mua: {0}", sl);
        }

        private void themMotDongHoaDon()
        {
            dhChoInHoaDon = new DonHang();
            dhChoInHoaDon.MaKH = khChoInHoaDon.MaKH;
            dhChoInHoaDon = dhDAL_BLL.them(dhChoInHoaDon);
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

        private void btnMuaThem_Click(object sender, EventArgs e)
        {
            tabCT.SelectedIndex = 0;
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo("Bạn chắc muốn xóa tất cả chi tiết đơn hàng này?");
            if (res == DialogResult.No)
                return;
            ctDonHangDAL_BLL.xoa(dhChoInHoaDon.MaDH);
            pnGioHang.Controls.Clear();
            hienThiTongTien_TongSLMua();
        }

        private void kiemTraVaChuanBiKhiHoaDonCho()
        {
            DonHang dhCho = dhDAL_BLL.layDonHangCho();
            if (dhCho == null)
                return;
            dhChoInHoaDon = dhCho;
            khChoInHoaDon = khDAL_BLL.layKhachHang(int.Parse(dhCho.MaKH.ToString()));
            lamMoiLaiGioHang();
        }

        private void lamMoiLaiGioHang()
        {
            List<CTDonHang> list = ctDonHangDAL_BLL.laySanPhamDH_Mua(dhChoInHoaDon.MaDH);
            foreach (CTDonHang ct in list)
                themMotSanPham_vaoGioHang_GiaoDien(spDAL_BLL.laySanPham(ct.MaSP), int.Parse(ct.SoLuong.ToString()));
            themMotKhachHangCho(khChoInHoaDon);
            hienThiThongTinDonHang();
            hienThiTongTien_TongSLMua();
        }

        private void trvLichSuGiaoDich_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            lstBLichSuGiaoDich.Items.Clear();
            if (node.Level == 0 || node.Level == 1)
            {
                int maDH = int.Parse(node.Tag.ToString());
                foreach (CTDonHang ct in ctDonHangDAL_BLL.laySanPhamDH_Mua(maDH))
                    lstBLichSuGiaoDich.Items.Add(spDAL_BLL.laySanPham(ct.MaSP).ToString());
            }
        }

        private void cboxLocTheoLichSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            taiTrvLichSuGiaoDich();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            //in hoa don
            //cap nhat trang thai thanh toan
            bool isTT = dhDAL_BLL.capNhatTrangThaiThanhToan(dhChoInHoaDon.MaDH, true);

            if (isTT)
            {
                dhChoInHoaDon = null;
                khChoInHoaDon = null;
                ganKhachHangTuChoiMua();
                taiTrvLichSuGiaoDich();
                FunctionStatic.hienThiThongBaoThanhCong("In Hoa Don Thanh Cong");
            }
        }
    }
}