namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    partial class frmPhanNhanVienVaoNhom
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
            this.dS_BanThietBiDienTu = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTu();
            this.nHANVIENSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIENSTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.NHANVIENSTableAdapter();
            this.tableAdapterManager = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.TableAdapterManager();
            this.nHOMQUYENSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHOMQUYENSTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.NHOMQUYENSTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridViewHienThiNhanVienTheoNhom = new DevExpress.XtraGrid.GridControl();
            this.dtHienThiNhanVienTheoMaNhomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridViewNhanViens = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboxNhomQuyen = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemNhanVien_QuaTrai = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaNhanVienQuaPhai = new DevExpress.XtraEditors.SimpleButton();
            this.dtHienThiNhanVienTheoMaNhomTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.dtHienThiNhanVienTheoMaNhomTableAdapter();
            this.phannhanvieN_VAONHOMQUYENTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.PHANNHANVIEN_VAONHOMQUYENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMQUYENSBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHienThiNhanVienTheoNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHienThiNhanVienTheoMaNhomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhanViens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dS_BanThietBiDienTu
            // 
            this.dS_BanThietBiDienTu.DataSetName = "DS_BanThietBiDienTu";
            this.dS_BanThietBiDienTu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nHANVIENSBindingSource
            // 
            this.nHANVIENSBindingSource.DataMember = "NHANVIENS";
            this.nHANVIENSBindingSource.DataSource = this.dS_BanThietBiDienTu;
            // 
            // nHANVIENSTableAdapter
            // 
            this.nHANVIENSTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.NHANVIENSTableAdapter = this.nHANVIENSTableAdapter;
            this.tableAdapterManager.NHOMQUYENSTableAdapter = null;
            this.tableAdapterManager.PHANNHANVIEN_VAONHOMQUYENTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHIEU_NHAPTableAdapter = null;
            this.tableAdapterManager.QUYENSTableAdapter = null;
            this.tableAdapterManager.SanPhamTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nHOMQUYENSBindingSource
            // 
            this.nHOMQUYENSBindingSource.DataMember = "NHOMQUYENS";
            this.nHOMQUYENSBindingSource.DataSource = this.dS_BanThietBiDienTu;
            // 
            // nHOMQUYENSTableAdapter
            // 
            this.nHOMQUYENSTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.gridViewHienThiNhanVienTheoNhom, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.gridViewNhanViens, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboxNhomQuyen, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(939, 756);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridViewHienThiNhanVienTheoNhom
            // 
            this.gridViewHienThiNhanVienTheoNhom.DataSource = this.dtHienThiNhanVienTheoMaNhomBindingSource;
            this.gridViewHienThiNhanVienTheoNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewHienThiNhanVienTheoNhom.Location = new System.Drawing.Point(518, 78);
            this.gridViewHienThiNhanVienTheoNhom.MainView = this.gridView2;
            this.gridViewHienThiNhanVienTheoNhom.Name = "gridViewHienThiNhanVienTheoNhom";
            this.gridViewHienThiNhanVienTheoNhom.Size = new System.Drawing.Size(418, 675);
            this.gridViewHienThiNhanVienTheoNhom.TabIndex = 3;
            this.gridViewHienThiNhanVienTheoNhom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // dtHienThiNhanVienTheoMaNhomBindingSource
            // 
            this.dtHienThiNhanVienTheoMaNhomBindingSource.DataMember = "dtHienThiNhanVienTheoMaNhom";
            this.dtHienThiNhanVienTheoMaNhomBindingSource.DataSource = this.dS_BanThietBiDienTu;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridViewHienThiNhanVienTheoNhom;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            // 
            // gridViewNhanViens
            // 
            this.gridViewNhanViens.DataSource = this.nHANVIENSBindingSource;
            this.gridViewNhanViens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewNhanViens.Location = new System.Drawing.Point(3, 78);
            this.gridViewNhanViens.MainView = this.gridView1;
            this.gridViewNhanViens.Name = "gridViewNhanViens";
            this.gridViewNhanViens.Size = new System.Drawing.Size(416, 675);
            this.gridViewNhanViens.TabIndex = 1;
            this.gridViewNhanViens.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridViewNhanViens;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // cboxNhomQuyen
            // 
            this.cboxNhomQuyen.DataSource = this.nHOMQUYENSBindingSource;
            this.cboxNhomQuyen.DisplayMember = "Tên Nhóm";
            this.cboxNhomQuyen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cboxNhomQuyen.FormattingEnabled = true;
            this.cboxNhomQuyen.Location = new System.Drawing.Point(518, 51);
            this.cboxNhomQuyen.Name = "cboxNhomQuyen";
            this.cboxNhomQuyen.Size = new System.Drawing.Size(418, 21);
            this.cboxNhomQuyen.TabIndex = 0;
            this.cboxNhomQuyen.ValueMember = "Mã Nhóm";
            this.cboxNhomQuyen.SelectedIndexChanged += new System.EventHandler(this.nHOMQUYENSComboBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnThemNhanVien_QuaTrai);
            this.flowLayoutPanel1.Controls.Add(this.btnXoaNhanVienQuaPhai);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(425, 78);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(87, 675);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnThemNhanVien_QuaTrai
            // 
            this.btnThemNhanVien_QuaTrai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNhanVien_QuaTrai.Location = new System.Drawing.Point(3, 3);
            this.btnThemNhanVien_QuaTrai.Name = "btnThemNhanVien_QuaTrai";
            this.btnThemNhanVien_QuaTrai.Size = new System.Drawing.Size(75, 23);
            this.btnThemNhanVien_QuaTrai.TabIndex = 0;
            this.btnThemNhanVien_QuaTrai.Text = ">>";
            this.btnThemNhanVien_QuaTrai.Click += new System.EventHandler(this.btnThemNhanVien_QuaTrai_Click);
            // 
            // btnXoaNhanVienQuaPhai
            // 
            this.btnXoaNhanVienQuaPhai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaNhanVienQuaPhai.Location = new System.Drawing.Point(3, 32);
            this.btnXoaNhanVienQuaPhai.Name = "btnXoaNhanVienQuaPhai";
            this.btnXoaNhanVienQuaPhai.Size = new System.Drawing.Size(75, 23);
            this.btnXoaNhanVienQuaPhai.TabIndex = 1;
            this.btnXoaNhanVienQuaPhai.Text = "<<";
            this.btnXoaNhanVienQuaPhai.Click += new System.EventHandler(this.btnXoaNhanVienQuaPhai_Click);
            // 
            // dtHienThiNhanVienTheoMaNhomTableAdapter
            // 
            this.dtHienThiNhanVienTheoMaNhomTableAdapter.ClearBeforeFill = true;
            // 
            // phannhanvieN_VAONHOMQUYENTableAdapter
            // 
            this.phannhanvieN_VAONHOMQUYENTableAdapter.ClearBeforeFill = true;
            // 
            // frmPhanNhanVienVaoNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(939, 756);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPhanNhanVienVaoNhom";
            this.Text = "frmPhanNhanVienVaoNhom";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhanNhanVienVaoNhom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMQUYENSBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHienThiNhanVienTheoNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHienThiNhanVienTheoMaNhomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhanViens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DS_BanThietBiDienTu dS_BanThietBiDienTu;
        private System.Windows.Forms.BindingSource nHANVIENSBindingSource;
        private DS_BanThietBiDienTuTableAdapters.NHANVIENSTableAdapter nHANVIENSTableAdapter;
        private DS_BanThietBiDienTuTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource nHOMQUYENSBindingSource;
        private DS_BanThietBiDienTuTableAdapters.NHOMQUYENSTableAdapter nHOMQUYENSTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridViewNhanViens;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ComboBox cboxNhomQuyen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThemNhanVien_QuaTrai;
        private DevExpress.XtraEditors.SimpleButton btnXoaNhanVienQuaPhai;
        private System.Windows.Forms.BindingSource dtHienThiNhanVienTheoMaNhomBindingSource;
        private DS_BanThietBiDienTuTableAdapters.dtHienThiNhanVienTheoMaNhomTableAdapter dtHienThiNhanVienTheoMaNhomTableAdapter;
        private DevExpress.XtraGrid.GridControl gridViewHienThiNhanVienTheoNhom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DS_BanThietBiDienTuTableAdapters.PHANNHANVIEN_VAONHOMQUYENTableAdapter phannhanvieN_VAONHOMQUYENTableAdapter;
    }
}