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
using System.Drawing.Text;
using MyLibrary;
using DTO;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmPhanQuyenChoNhom : DevExpress.XtraEditors.XtraForm
    {
        //khai báo biến tại đây
        private NhomQuyen_DAL_BLL nQuyen_DAL_BLL;
        private PhanQuyen_DAL_BLL pQuyen_DAL_BLL;
        private int rowNhomQuyenSelected;
        private int rowQuyenNhomCoSelected;
        private int rowQuyenNhomChuaCoSelected;

        public frmPhanQuyenChoNhom()
        {
            InitializeComponent();
        }

        private void frmPhanQuyenChoNhom_Load(object sender, EventArgs e)
        {
            //khởi tạo tại đây
            nQuyen_DAL_BLL = new NhomQuyen_DAL_BLL();
            pQuyen_DAL_BLL = new PhanQuyen_DAL_BLL();
            rowNhomQuyenSelected = -1;
            rowQuyenNhomCoSelected = rowQuyenNhomChuaCoSelected = -1;

            //load tại đây
            nQuyen_DAL_BLL.lamMoiTaiTatCaQuyen_choNhom();
            loadNhomQuyen();
            loadQuyenChoNhom();

            //event tại đây
            gvNhomQuyen.RowClick += GvNhomQuyen_RowClick;
            btnThemQuyenChoNhom.Click += BtnThemQuyenChoNhom_Click;
            btnBoQuyenChoNhom.Click += BtnBoQuyenChoNhom_Click;
            gvQuyenNhomCo.RowClick += GvQuyenNhomCo_RowClick;
            gvQuyenNhomChuaCo.RowClick += GvQuyenNhomChuaCo_RowClick;
        }

        private void GvQuyenNhomChuaCo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowQuyenNhomChuaCoSelected = e.RowHandle;
        }

        private void GvQuyenNhomCo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowQuyenNhomCoSelected = e.RowHandle;
        }

        private void BtnBoQuyenChoNhom_Click(object sender, EventArgs e)
        {
            if (rowNhomQuyenSelected < 0 || rowQuyenNhomCoSelected < 0)
                return;

            string maNhom = FunctionStatic.layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_MANHOM),
                maQuyen = FunctionStatic.layTextGridView(gvQuyenNhomCo, rowQuyenNhomCoSelected, Quyen_DTO.COL_MAQUYEN),
                tenNhom = FunctionStatic.layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_TENNHOM),
                tenQuyen = FunctionStatic.layTextGridView(gvQuyenNhomCo, rowQuyenNhomCoSelected, Quyen_DTO.COL_TENQUYEN);

            string mess = string.Format("Chuẩn bị tước quyền [{0}] cho nhóm [{1}]", tenQuyen, tenNhom);
            DialogResult dRest = FunctionStatic.hienThiCauHoiYesNo(mess);
            if (dRest == DialogResult.No)
                return;

            PhanQuyen_DTO pQuyen = new PhanQuyen_DTO
            {
                MaNhom = maNhom,
                MaQuyen = maQuyen,
                CoQuyen = false
            };

            EStatus status = pQuyen_DAL_BLL.capNhat(pQuyen);
            if (status != EStatus.THANH_CONG)
            {
                FunctionStatic.hienThiThongBaoLoi("Tước quyền cho nhóm thất bại!");
                return;
            }

            FunctionStatic.hienThiThongBaoThanhCong("Tước quyền cho nhóm thành công");
            loadQuyenChoNhom();
        }

        private void BtnThemQuyenChoNhom_Click(object sender, EventArgs e)
        {
            if (rowNhomQuyenSelected < 0 || rowQuyenNhomChuaCoSelected < 0)
                return;

            string maNhom = FunctionStatic.layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_MANHOM),
                maQuyen = FunctionStatic.layTextGridView(gvQuyenNhomChuaCo, rowQuyenNhomChuaCoSelected, Quyen_DTO.COL_MAQUYEN),
                tenNhom = FunctionStatic.layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_TENNHOM),
                tenQuyen = FunctionStatic.layTextGridView(gvQuyenNhomChuaCo, rowQuyenNhomChuaCoSelected, Quyen_DTO.COL_TENQUYEN);

            string mess = string.Format("Chuẩn bị thêm quyền [{0}] cho nhóm [{1}]", tenQuyen, tenNhom);
            DialogResult dRest = FunctionStatic.hienThiCauHoiYesNo(mess);
            if (dRest == DialogResult.No)
                return;

            PhanQuyen_DTO pQuyen = new PhanQuyen_DTO
            {
                MaNhom = maNhom,
                MaQuyen = maQuyen,
                CoQuyen = true
            };

            EStatus status = pQuyen_DAL_BLL.capNhat(pQuyen);
            if (status != EStatus.THANH_CONG)
            {
                FunctionStatic.hienThiThongBaoLoi("Thêm quyền cho nhóm thất bại!");
                return;
            }

            FunctionStatic.hienThiThongBaoThanhCong("Thêm quyền cho nhóm thành công");
            loadQuyenChoNhom();
        }

        private void GvNhomQuyen_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowNhomQuyenSelected = e.RowHandle;
            loadQuyenChoNhom();
        }

        private void loadNhomQuyen()
        {
            var source = nQuyen_DAL_BLL.layTatCa();
            dgvNhomQuyens.DataSource = source;
        }

        private void loadQuyenChoNhom()
        {
            if (rowNhomQuyenSelected < 0)
                return;
            string maNhom = FunctionStatic.layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_MANHOM);
            dgvQuenNhomCo.DataSource = nQuyen_DAL_BLL.layQuyenChoNhom(maNhom, true);
            dgvQuyenNhomChuaCo.DataSource = nQuyen_DAL_BLL.layQuyenChoNhom(maNhom, false);
        }
    }
}