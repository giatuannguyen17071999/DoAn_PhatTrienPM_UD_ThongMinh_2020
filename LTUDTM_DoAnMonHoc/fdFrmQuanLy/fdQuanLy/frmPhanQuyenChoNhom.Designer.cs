namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    partial class frmPhanQuyenChoNhom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridNhomQuyens = new DevExpress.XtraGrid.GridControl();
            this.nHOMQUYENSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_BanThietBiDienTu = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTu();
            this.gridViewNhomQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMãNhóm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTênNhóm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChú = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLuuPhanQuyenChoNhom = new System.Windows.Forms.Button();
            this.gridHienThiPhanQuyenChoNhom = new DevExpress.XtraGrid.GridControl();
            this.dtHienThiPhanQuyenChoNhomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nHOMQUYENSTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.NHOMQUYENSTableAdapter();
            this.tableAdapterManager = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.TableAdapterManager();
            this.dtHienThiPhanQuyenChoNhomTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.dtHienThiPhanQuyenChoNhomTableAdapter();
            this.phanquyenTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.PHANQUYENTableAdapter();
            this.colMãQuyền = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTênQuyền = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCóQuyền = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhomQuyens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMQUYENSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhomQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHienThiPhanQuyenChoNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHienThiPhanQuyenChoNhomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridNhomQuyens, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLuuPhanQuyenChoNhom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridHienThiPhanQuyenChoNhom, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 372);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridNhomQuyens
            // 
            this.gridNhomQuyens.DataSource = this.nHOMQUYENSBindingSource;
            this.gridNhomQuyens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNhomQuyens.Location = new System.Drawing.Point(3, 40);
            this.gridNhomQuyens.MainView = this.gridViewNhomQuyen;
            this.gridNhomQuyens.Name = "gridNhomQuyens";
            this.gridNhomQuyens.Size = new System.Drawing.Size(354, 329);
            this.gridNhomQuyens.TabIndex = 1;
            this.gridNhomQuyens.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNhomQuyen});
            // 
            // nHOMQUYENSBindingSource
            // 
            this.nHOMQUYENSBindingSource.DataMember = "NHOMQUYENS";
            this.nHOMQUYENSBindingSource.DataSource = this.dS_BanThietBiDienTu;
            // 
            // dS_BanThietBiDienTu
            // 
            this.dS_BanThietBiDienTu.DataSetName = "DS_BanThietBiDienTu";
            this.dS_BanThietBiDienTu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridViewNhomQuyen
            // 
            this.gridViewNhomQuyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMãNhóm,
            this.colTênNhóm,
            this.colGhiChú});
            this.gridViewNhomQuyen.GridControl = this.gridNhomQuyens;
            this.gridViewNhomQuyen.Name = "gridViewNhomQuyen";
            this.gridViewNhomQuyen.OptionsBehavior.Editable = false;
            this.gridViewNhomQuyen.OptionsBehavior.ReadOnly = true;
            this.gridViewNhomQuyen.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewNhomQuyen_RowClick_1);
            // 
            // colMãNhóm
            // 
            this.colMãNhóm.FieldName = "Mã Nhóm";
            this.colMãNhóm.Name = "colMãNhóm";
            this.colMãNhóm.Visible = true;
            this.colMãNhóm.VisibleIndex = 0;
            // 
            // colTênNhóm
            // 
            this.colTênNhóm.FieldName = "Tên Nhóm";
            this.colTênNhóm.Name = "colTênNhóm";
            this.colTênNhóm.Visible = true;
            this.colTênNhóm.VisibleIndex = 1;
            // 
            // colGhiChú
            // 
            this.colGhiChú.FieldName = "Ghi Chú";
            this.colGhiChú.Name = "colGhiChú";
            this.colGhiChú.Visible = true;
            this.colGhiChú.VisibleIndex = 2;
            // 
            // btnLuuPhanQuyenChoNhom
            // 
            this.btnLuuPhanQuyenChoNhom.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLuuPhanQuyenChoNhom.Location = new System.Drawing.Point(569, 3);
            this.btnLuuPhanQuyenChoNhom.Name = "btnLuuPhanQuyenChoNhom";
            this.btnLuuPhanQuyenChoNhom.Size = new System.Drawing.Size(149, 31);
            this.btnLuuPhanQuyenChoNhom.TabIndex = 0;
            this.btnLuuPhanQuyenChoNhom.Text = "Lưu Tất Cả Thay Đổi";
            this.btnLuuPhanQuyenChoNhom.UseVisualStyleBackColor = true;
            this.btnLuuPhanQuyenChoNhom.Click += new System.EventHandler(this.btnLuuPhanQuyenChoNhom_Click);
            // 
            // gridHienThiPhanQuyenChoNhom
            // 
            this.gridHienThiPhanQuyenChoNhom.DataSource = this.dtHienThiPhanQuyenChoNhomBindingSource;
            this.gridHienThiPhanQuyenChoNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHienThiPhanQuyenChoNhom.Location = new System.Drawing.Point(363, 40);
            this.gridHienThiPhanQuyenChoNhom.MainView = this.gridView2;
            this.gridHienThiPhanQuyenChoNhom.Name = "gridHienThiPhanQuyenChoNhom";
            this.gridHienThiPhanQuyenChoNhom.Size = new System.Drawing.Size(355, 329);
            this.gridHienThiPhanQuyenChoNhom.TabIndex = 2;
            this.gridHienThiPhanQuyenChoNhom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // dtHienThiPhanQuyenChoNhomBindingSource
            // 
            this.dtHienThiPhanQuyenChoNhomBindingSource.DataMember = "dtHienThiPhanQuyenChoNhom";
            this.dtHienThiPhanQuyenChoNhomBindingSource.DataSource = this.dS_BanThietBiDienTu;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMãQuyền,
            this.colTênQuyền,
            this.colCóQuyền});
            this.gridView2.GridControl = this.gridHienThiPhanQuyenChoNhom;
            this.gridView2.Name = "gridView2";
            // 
            // nHOMQUYENSTableAdapter
            // 
            this.nHOMQUYENSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CT_PHIEU_NHAPTableAdapter = null;
            this.tableAdapterManager.CTDonHangTableAdapter = null;
            this.tableAdapterManager.DanhMucTableAdapter = null;
            this.tableAdapterManager.DonHangTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.LoaiSPTableAdapter = null;
            this.tableAdapterManager.NHANVIENSTableAdapter = null;
            this.tableAdapterManager.NHOMQUYENSTableAdapter = this.nHOMQUYENSTableAdapter;
            this.tableAdapterManager.PHANNHANVIEN_VAONHOMQUYENTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHIEU_NHAPTableAdapter = null;
            this.tableAdapterManager.QUYENSTableAdapter = null;
            this.tableAdapterManager.SanPhamTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dtHienThiPhanQuyenChoNhomTableAdapter
            // 
            this.dtHienThiPhanQuyenChoNhomTableAdapter.ClearBeforeFill = true;
            // 
            // phanquyenTableAdapter
            // 
            this.phanquyenTableAdapter.ClearBeforeFill = true;
            // 
            // colMãQuyền
            // 
            this.colMãQuyền.FieldName = "Mã Quyền";
            this.colMãQuyền.Name = "colMãQuyền";
            this.colMãQuyền.OptionsColumn.AllowEdit = false;
            this.colMãQuyền.OptionsColumn.ReadOnly = true;
            this.colMãQuyền.Visible = true;
            this.colMãQuyền.VisibleIndex = 0;
            // 
            // colTênQuyền
            // 
            this.colTênQuyền.FieldName = "Tên Quyền";
            this.colTênQuyền.Name = "colTênQuyền";
            this.colTênQuyền.OptionsColumn.AllowEdit = false;
            this.colTênQuyền.OptionsColumn.ReadOnly = true;
            this.colTênQuyền.Visible = true;
            this.colTênQuyền.VisibleIndex = 1;
            // 
            // colCóQuyền
            // 
            this.colCóQuyền.FieldName = "Có Quyền";
            this.colCóQuyền.Name = "colCóQuyền";
            this.colCóQuyền.Visible = true;
            this.colCóQuyền.VisibleIndex = 2;
            // 
            // frmPhanQuyenChoNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 372);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPhanQuyenChoNhom";
            this.Text = "frmPhanQuyenChoNhom";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhanQuyenChoNhom_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNhomQuyens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMQUYENSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhomQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHienThiPhanQuyenChoNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHienThiPhanQuyenChoNhomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLuuPhanQuyenChoNhom;
        private DS_BanThietBiDienTu dS_BanThietBiDienTu;
        private System.Windows.Forms.BindingSource nHOMQUYENSBindingSource;
        private DS_BanThietBiDienTuTableAdapters.NHOMQUYENSTableAdapter nHOMQUYENSTableAdapter;
        private DS_BanThietBiDienTuTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gridNhomQuyens;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNhomQuyen;
        private System.Windows.Forms.BindingSource dtHienThiPhanQuyenChoNhomBindingSource;
        private DS_BanThietBiDienTuTableAdapters.dtHienThiPhanQuyenChoNhomTableAdapter dtHienThiPhanQuyenChoNhomTableAdapter;
        private DevExpress.XtraGrid.GridControl gridHienThiPhanQuyenChoNhom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DS_BanThietBiDienTuTableAdapters.PHANQUYENTableAdapter phanquyenTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colMãNhóm;
        private DevExpress.XtraGrid.Columns.GridColumn colTênNhóm;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChú;
        private DevExpress.XtraGrid.Columns.GridColumn colMãQuyền;
        private DevExpress.XtraGrid.Columns.GridColumn colTênQuyền;
        private DevExpress.XtraGrid.Columns.GridColumn colCóQuyền;
    }
}