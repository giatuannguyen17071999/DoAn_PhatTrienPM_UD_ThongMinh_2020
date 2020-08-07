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
using System.Collections;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Pdf.Native;
using LTUDTM_DoAnMonHoc.Report;
using DevExpress.XtraReports.UI;

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
        private NHANVIEN nvLamViec;

        private List<CTDonHang> ctDonHangs;

        public frmBanHang(NHANVIEN nvLamViec)
        {
            InitializeComponent();
            this.nvLamViec = nvLamViec;
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
            ctDonHangs = new List<CTDonHang>();

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
            List<SanPham_DTO> sanPhams = null;
            string cboxSelect = (cboxTimKiem.SelectedItem as KeyValue).Key;
            if (cboxSelect.Equals("masp"))
                sanPhams = spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_THEO_MA, tbTimKiem.Text);
            else
                sanPhams = spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_THEM_TEN, tbTimKiem.Text);

            if (cbCongThemGiaTien.Checked)
            {
                int cGia = 0;
                if (rdoDuoi5Trieu.Checked)
                    cGia = 1;
                else if (rdoTren5Trieu.Checked)
                    cGia = 2;
                spDAL_BLL.locTiep_TheoGia(ref sanPhams, cGia);
            }
            if (cbLocThemLoaiSP.Checked)
            {
                TreeNode nodeSel = trvDanhMuc_TheLoai.SelectedNode;
                if (nodeSel == null || nodeSel.Level != 1)
                {
                    FunctionStatic.hienThiThongBaoLoi("Bạn Chưa Chọn Thể Loại!");
                    trvDanhMuc_TheLoai.ExpandAll();
                    return;
                }
                LoaiSP_DTO lsp = nodeSel.Tag as LoaiSP_DTO;
                spDAL_BLL.locTiep_TheoTheLoai(ref sanPhams, lsp.MaLoai);
            }    
            

            if (sanPhams == null)
                return;
            lbHienThiSoLuongSanPham.Text = string.Format("Đã Hiển Thị [{0}] Sản Phẩm Cho [{1}]", sanPhams.Count, "Tìm Kiếm");
            taiSanPhams(sanPhams);
            trvDanhMuc_TheLoai.SelectedNode = null;
        }

        private void loadTrvDanhMuc_TheLoai()
        {
            ImageList iml = new ImageList();
            Image i1 = Image.FromFile(imgPolder+"cate0_64.png");
            Image i2 = Image.FromFile(imgPolder + "cate1_48.png");
            trvDanhMuc_TheLoai.ImageList = iml;

            iml.Images.Add(i1);
            iml.Images.Add(i2);

            List<DanhMuc_DTO> dms = dmDAL_BLL.layTatCa();
            List<LoaiSP_DTO> lsps;

            TreeNode tNode, tNodeChild;
            foreach(DanhMuc_DTO dm in dms)
            {
                tNode = new TreeNode();
                tNode.Tag = dm;
                tNode.Text = dm.TenDM;
                tNode.ImageIndex = 0;
                //child
                lsps = loaiDAL_BLL.layTatCa(dm.MaDM);
                foreach(LoaiSP_DTO lsp in lsps)
                {
                    tNodeChild = new TreeNode();
                    tNodeChild.Tag = lsp.MaLoai;
                    tNodeChild.Text = lsp.TenLoaiSP;
                    tNodeChild.Tag = lsp;
                    tNodeChild.ImageIndex = 1;
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
            //pnIconChaoMung.BackgroundImage = Image.FromFile(imgPolder + "iconChaoMungUser.png");
            //pnIconChaoMung.BackgroundImageLayout = ImageLayout.Center;
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
            Control pnAnh = sender as Control;
            SanPham_DTO sp = (pnAnh.Tag) as SanPham_DTO;
            if (sp.SlTon == null || sp.SlTon == 0)
            {
                FunctionStatic.hienThiThongBaoLoi("Sản Phẩm Này Đã Hết Hàng!");
                return;
            }

            if (khChoInHoaDon == null)
            {
                frmChonKhachHang frm = new frmChonKhachHang();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.Cancel)
                    return;
                khChoInHoaDon = frm.khChon;
                themMotDongHoaDon_ChuaLuu();
                hienThiThongTinDonHang();
                themMotKhachHangCho(khChoInHoaDon);
            }

            themMotChiTietDonHang_ChuaLuu(sp);
            hienThiTongTien_TongSLMua();
            tabCT.SelectedIndex = 1;
        }

        private void hienThiTongTien_TongSLMua()
        {
            txtTongTien.Text = string.Format("{0:N0}", dhChoInHoaDon.TONGTIEN);
            txtTongSoLuong.Text = string.Format("{0} Cái", ctDonHangs.Sum(n => n.SoLuong));
        }

        private void hienThiThongTinDonHang()
        {
            lbHoaDonCho.Text = "Hóa Đơn Đang Chờ: [ "+dhChoInHoaDon.MaDH+" ]";
            lbMaKhachHangGH.Text = khChoInHoaDon.MaKH.ToString();
            lbTenKhachHangGH.Text = khChoInHoaDon.HoTen;
            lbSDTGH.Text = khChoInHoaDon.DienThoai1.ToString();
            lbDiaChiKhachHangGH.Text = khChoInHoaDon.DiaChi;
        }

        private void themMotChiTietDonHang_ChuaLuu(SanPham_DTO sp)
        {
            CTDonHang ctDon = new CTDonHang();
            ctDon.MaDH = dhChoInHoaDon.MaDH;
            ctDon.MaSP = sp.MaSP;
            ctDon.SoLuong = 1;
            ctDon.DonGia = sp.GiaBan;

            CTDonHang ctTim = ctDonHangs.FirstOrDefault(n => n.MaDH.Equals(ctDon.MaDH) && n.MaSP.Equals(ctDon.MaSP));

            bool isThem = ctTim == null;
            if (!isThem)
            {
                FunctionStatic.hienThiThongBaoLoi("Lỗi Thêm một chi tiết đơn hàng!");
                return;
            }

            //Them vao list don hang temp
            ctDonHangs.Add(ctDon);

            //cap nhat tong tien don hang.
            decimal tien = int.Parse(ctDon.SoLuong.ToString()) * decimal.Parse(ctDon.DonGia.ToString());
            if (dhChoInHoaDon.TONGTIEN == null)
                dhChoInHoaDon.TONGTIEN = tien;
            else
                dhChoInHoaDon.TONGTIEN = decimal.Parse(dhChoInHoaDon.TONGTIEN.ToString()) + tien;

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
            lbKhachCho.Click += LbKhachCho_Click;
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
                //ctDonHangDAL_BLL.xoa(dhChoInHoaDon.MaDH);
                //dhDAL_BLL.xoa(dhChoInHoaDon.MaDH);
                dhChoInHoaDon = null;
                khChoInHoaDon = null;
                ctDonHangs.Clear();
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
            CTDonHang ctTim = ctDonHangs.FirstOrDefault(n => n.MaDH.Equals(dhChoInHoaDon.MaDH) && n.MaSP.Equals(sp.MaSP));
            bool isXoa = ctDonHangs.Remove(ctTim);
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
            ImageList iml = new ImageList();
            trvLichSuGiaoDich.ImageList = iml;

            Image i1 = Image.FromFile(imgPolder + "bill_96.png");
            Image i2 = Image.FromFile(imgPolder + "khachhang_100.png");
            Image i3 = Image.FromFile(imgPolder + "product_64.png");

            iml.Images.Add(i1);
            iml.Images.Add(i2);
            iml.Images.Add(i3);

            trvLichSuGiaoDich.Nodes.Clear();
            int maDH;
            KhachHang_DTO khTmp;
            DonHang_DTO dh;
            List<CTDonHang> ctDons;
            TreeNode n0, n1, n2;

            for (int i = 0; i < donHangs.Count; i++)
            {
                dh = donHangs[i];
                maDH = dh.MaDH;
                n0 = new TreeNode(dh.ToString());
                n0.Tag = maDH;
                n0.ImageIndex = 0;

                trvLichSuGiaoDich.Nodes.Add(n0);
                khTmp = khDAL_BLL.layKhachHang(int.Parse(dh.MaKH.ToString()));
                n1 = new TreeNode(khTmp.ToString());
                n1.Tag = dh.MaDH;
                n1.ImageIndex = 1;

                trvLichSuGiaoDich.Nodes[i].Nodes.Add(n1);
                ctDons = ctDonHangDAL_BLL.laySanPhamDH_Mua(dh.MaDH);
                foreach (CTDonHang ct in ctDons)
                {
                    n2 = new TreeNode(string.Format("[Ma SP: {0} - SL Mua: {1}]", ct.MaSP.Trim(), ct.SoLuong));
                    n2.Tag = dh.MaDH;
                    n2.ImageIndex = 2;
                    trvLichSuGiaoDich.Nodes[i].Nodes[0].Nodes.Add(n2);
                }
            }

            trvLichSuGiaoDich.ExpandAll();
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
            string maSP = lbSlMua.Tag.ToString();
            SanPham_DTO sp = spDAL_BLL.laySanPham(maSP);
            CTDonHang ctTim = ctDonHangs.First(n => n.MaDH.Equals(dhChoInHoaDon.MaDH) && n.MaSP.Equals(maSP));
            int sl = int.Parse(ctTim.SoLuong.ToString()) + 1;

            if (sl > sp.SlTon)
            {
                FunctionStatic.hienThiThongBaoLoi("Đã Vượt Quá Số Lượng Tồn!");
                return;
            }

            ctTim.SoLuong = sl;
            //cap nhat tong tien
            
            decimal Ttien = decimal.Parse(dhChoInHoaDon.TONGTIEN.ToString()) + int.Parse(sp.GiaBan.ToString());
            dhChoInHoaDon.TONGTIEN = Ttien;

            hienThiTongTien_TongSLMua();
            lbSlMua.Text = string.Format("SL Mua: {0}", sl);
        }

        private void LbGiamSL_Click(object sender, EventArgs e)
        {
            Control lbSlMua = (sender as Control).Tag as Control;
            string maSP = lbSlMua.Tag.ToString();
            CTDonHang ctTim = ctDonHangs.First(n => n.MaDH.Equals(dhChoInHoaDon.MaDH) && n.MaSP.Equals(maSP));

            if (int.Parse(ctTim.SoLuong.ToString()) < 2)
                return;
            
            int sl = int.Parse(ctTim.SoLuong.ToString()) - 1;
            ctTim.SoLuong = sl;
            //cap nhat tong tien
            SanPham_DTO sp = spDAL_BLL.laySanPham(maSP);
            decimal Ttien = decimal.Parse(dhChoInHoaDon.TONGTIEN.ToString()) - int.Parse(sp.GiaBan.ToString());
            dhChoInHoaDon.TONGTIEN = Ttien;

            hienThiTongTien_TongSLMua();
            lbSlMua.Text = string.Format("SL Mua: {0}", sl);
        }

        private void themMotDongHoaDon_ChuaLuu()
        {
            dhChoInHoaDon = new DonHang();
            dhChoInHoaDon.MaKH = khChoInHoaDon.MaKH;
            dhChoInHoaDon.NgayDat = DateTime.Now;
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
            List<SanPham_DTO> sanPhams = null;
            if (e.Node.Level == 1)
            {
                LoaiSP_DTO lsp = e.Node.Tag as LoaiSP_DTO;
                sanPhams = spDAL_BLL.latTaCa(lsp.MaLoai);
            }
            else if (e.Node.Level == 0)
            {
                DanhMuc_DTO dm = e.Node.Tag as DanhMuc_DTO;
                sanPhams = spDAL_BLL.locTheoDanhMuc(dm.MaDM);
            }
            if (sanPhams == null)
                return;
            lbHienThiSoLuongSanPham.Text = string.Format("Đã Hiển Thị [{0}] Sản Phẩm Cho [{1}]", sanPhams.Count, e.Node.Text);
            taiSanPhams(sanPhams);
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
            //ctDonHangDAL_BLL.xoa(dhChoInHoaDon.MaDH);
            pnGioHang.Controls.Clear();
            ctDonHangs.Clear();
            dhChoInHoaDon.TONGTIEN = 0;
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
            decimal tTien = 0;
            foreach (CTDonHang ct in ctDonHangs)
            {
                themMotSanPham_vaoGioHang_GiaoDien(spDAL_BLL.laySanPham(ct.MaSP), int.Parse(ct.SoLuong.ToString()));
                tTien += int.Parse(ct.SoLuong.ToString()) * decimal.Parse(ct.DonGia.ToString());
            }
            dhChoInHoaDon.TONGTIEN = tTien;
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
                {
                    SanPham_DTO sp = spDAL_BLL.laySanPham(ct.MaSP);
                    if (sp != null)
                        lstBLichSuGiaoDich.Items.Add(sp);
                }
            }
        }

        private void cboxLocTheoLichSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Test
            taiTrvLichSuGiaoDich();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (ctDonHangs.Count == 0)
            {
                FunctionStatic.hienThiThongBaoLoi("Hóa đơn chưa có sản phẩm nào!");
                return;
            }

            //in hoa don
            //cap nhat trang thai thanh toan
            dhChoInHoaDon.DaThanhToan = true;
            bool isTT = dhDAL_BLL.them(dhChoInHoaDon, ctDonHangs);
            dhDAL_BLL.taoView(dhChoInHoaDon.MaDH);

            if (isTT)
            {
                inHoaDon();
                
                ganKhachHangTuChoiMua();
                taiTrvLichSuGiaoDich();
                ctDonHangs.Clear();
                taiSanPhams(spDAL_BLL.latTaCa());
                //FunctionStatic.hienThiThongBaoThanhCong("In Hoa Don Thanh Cong");
            }
            else
            {
                FunctionStatic.hienThiThongBaoLoi("Loi Gi do");
            }
        }

        private void inHoaDon()
        {
            rptInHoaDon rpt = new rptInHoaDon();
            DateTime dt = DateTime.Now;
            rpt.Parameters["parNgayThangNam"].Value = string.Format("Thành Phố Hồ Chí Minh, Ngày {0}, Tháng {1}, Năm {2}", dt.Day, dt.Month, dt.Year) ;
            rpt.Parameters["parHoaDon"].Value = string.Format("Hóa Đơn: {0}", dhChoInHoaDon.MaDH) ;
            rpt.Parameters["parTenKH"].Value =khChoInHoaDon.HoTen;
            rpt.Parameters["parSDT"].Value = khChoInHoaDon.DienThoai1 ;
            rpt.Parameters["parTongTien"].Value = dhChoInHoaDon.TONGTIEN;
            rpt.Parameters["parGioiTinh"].Value = khChoInHoaDon.GioiTinh;
            string tienChu = FunctionStatic.So_chu(double.Parse(dhChoInHoaDon.TONGTIEN.ToString()));
            rpt.Parameters["parTienChu"].Value = tienChu;
            rpt.Parameters["parNguoiLap"].Value = nvLamViec.TENNHANVIEN;
            rpt.ShowPreview();

            dhChoInHoaDon = null;
            khChoInHoaDon = null;
        }
    }
}