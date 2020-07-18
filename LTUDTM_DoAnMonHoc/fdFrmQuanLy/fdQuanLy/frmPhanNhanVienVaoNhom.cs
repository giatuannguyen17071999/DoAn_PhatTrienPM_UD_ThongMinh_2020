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
using DevExpress.Utils;

namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    public partial class frmPhanNhanVienVaoNhom : DevExpress.XtraEditors.XtraForm
    {
        //Khai báo biến tại đây
        private NhomQuyen_DAL_BLL nQuyen_DAL_BLL;
        private NhanVien_DAL_BLL nVien_DAL_BLL;
        private PhanNhanVienVaoNhomQuyen_DAL_BLL pNV_NQ_DAL_BLL;
        private int rowNhanVienSelected;
        private int rowPhanQuyenSelected;

        public frmPhanNhanVienVaoNhom()
        {
            InitializeComponent();
        }

        private void frmPhanNhanVienVaoNhom_Load(object sender, EventArgs e)
        {
            //khởi tạo biến tại đây
            nQuyen_DAL_BLL = new NhomQuyen_DAL_BLL();
            nVien_DAL_BLL = new NhanVien_DAL_BLL();
            pNV_NQ_DAL_BLL = new PhanNhanVienVaoNhomQuyen_DAL_BLL();
            rowNhanVienSelected = -1;
            rowPhanQuyenSelected = -1;

            //load mới tại đây
            loadNhomQuyens();
            loadNhanViens();
            loadNhanVienTheoNhom();

            //sự kiên tại đây
            gvNhanViens.RowClick += GvNhanViens_RowClick;
            gvPhanNhanVienVaoNhomQuyen.RowClick += GvPhanNhanVienVaoNhomQuyen_RowClick;
            btnThemNhanVien_QuaPhai.Click += BtnThemNhanVien_QuaPhai_Click;
            btnXoaNhanVienQuaTrai.Click += BtnXoaNhanVienQuaTrai_Click;
        }

        private void GvPhanNhanVienVaoNhomQuyen_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowPhanQuyenSelected = e.RowHandle;
        }

        private void BtnXoaNhanVienQuaTrai_Click(object sender, EventArgs e)
        {
            if (rowPhanQuyenSelected == -1)
                return;

            string uName = FunctionStatic.layTextGridView(gvPhanNhanVienVaoNhomQuyen, rowPhanQuyenSelected, PhanNhanVienVaoNhomQuyen_DTO.COL_USERNAME);
            if (string.IsNullOrEmpty(uName))
            {
                FunctionStatic.hienThiThongBaoLoi("Chọn nhân viên để xoá bị lỗi");
                return;
            }

            var maNhom = cboxNhomQuyen.SelectedValue;
            if (maNhom == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Chưa chọn nhóm quyền!");
                return;
            }

            //Chắc chắn?
            string mess = string.Format("Sắp xóa nhân viên {0} tại nhóm {1}", uName, cboxNhomQuyen.SelectedItem);
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo(mess);
            if (res == DialogResult.No)
                return;

            EStatus status = pNV_NQ_DAL_BLL.xoa(uName, maNhom.ToString());
            if (status == EStatus.THANH_CONG)
            {
                FunctionStatic.hienThiThongBaoThanhCong("Xóa Nhân viên thành công");
                loadNhanVienTheoNhom();
            }
            else
                FunctionStatic.hienThiThongBaoLoi("Đã Gặp lỗi xóa nhân viên khỏi nhóm!");
        }

        private void BtnThemNhanVien_QuaPhai_Click(object sender, EventArgs e)
        {
            if (rowNhanVienSelected == -1)
            {
                FunctionStatic.hienThiThongBaoLoi("Chưa chọn nhân viên để thêm");
                return;
            }

            string uName = FunctionStatic.layTextGridView(gvNhanViens, rowNhanVienSelected, NhanVien_DTO.COL_USERNAME);
            if (string.IsNullOrEmpty(uName))
            {
                FunctionStatic.hienThiThongBaoLoi("Chọn nhân viên để thêm bị lỗi");
                return;
            }

            var maNhom = cboxNhomQuyen.SelectedValue;
            if (maNhom == null)
            {
                FunctionStatic.hienThiThongBaoLoi("Chưa chọn nhóm quyền!");
                return;
            }

            //Chắc chắn?
            string mess = string.Format("Sắp phân cho {0} có quyền {1}", uName, cboxNhomQuyen.SelectedItem);
            DialogResult res = FunctionStatic.hienThiCauHoiYesNo(mess);
            if (res == DialogResult.No)
                return;

            string ghiChu = FunctionStatic.layGhiChuTuNguoiDung();

            //Thêm Nhan viên vào nhóm.
            PhanNhanVienVaoNhomQuyen_DTO pNV_NQ = new PhanNhanVienVaoNhomQuyen_DTO();
            pNV_NQ.UserName = uName;
            pNV_NQ.MaNhom = maNhom.ToString();
            pNV_NQ.GhiChu = ghiChu;

            EStatus status = pNV_NQ_DAL_BLL.them(pNV_NQ);
            if (status == EStatus.THANH_CONG)
            {
                FunctionStatic.hienThiThongBaoThanhCong("Phân nhân viên thành công!");
                loadNhanVienTheoNhom();
            }
            else
                FunctionStatic.hienThiThongBaoLoi("Phân nhân viên thất bại!");
        }

        private void GvNhanViens_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowNhanVienSelected = e.RowHandle;
        }

        private void loadNhomQuyens()
        {
            cboxNhomQuyen.DataSource = nQuyen_DAL_BLL.layTatCa();
            cboxNhomQuyen.DisplayMember = "TenNhom";
            cboxNhomQuyen.ValueMember = "MaNhom";
        }

        private void loadNhanViens()
        {
            dgvNhanViens.DataSource = nVien_DAL_BLL.layTatCa();
        }

        private void loadNhanVienTheoNhom()
        {
            var maNhom = cboxNhomQuyen.SelectedValue;
            if (maNhom == null)
                return;
            dgvPhanNhanVienVaoNhoms.DataSource = nVien_DAL_BLL.layNhanVienTheoMaNhom(maNhom.ToString());
        }

        private void cboxNhomQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadNhanVienTheoNhom();
        }
    }
}