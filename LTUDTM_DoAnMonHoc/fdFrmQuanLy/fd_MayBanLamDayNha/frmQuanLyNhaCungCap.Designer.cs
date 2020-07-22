namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fd_MayBanLamDayNha
{
    partial class frmQuanLyNhaCungCap
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.gv_NhaCC = new DevExpress.XtraGrid.GridControl();
            this.gridNhaCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbNhaCC = new System.Windows.Forms.ComboBox();
            this.txtTenNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.lblTenNCC = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNCC = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhaCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhaCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 6.89F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 53.11F)});
            this.tablePanel1.Controls.Add(this.btnClear);
            this.tablePanel1.Controls.Add(this.gv_NhaCC);
            this.tablePanel1.Controls.Add(this.stackPanel1);
            this.tablePanel1.Controls.Add(this.panel1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 166.0003F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(942, 636);
            this.tablePanel1.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.tablePanel1.SetColumn(this.btnClear, 0);
            this.btnClear.Location = new System.Drawing.Point(10, 19);
            this.btnClear.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.tablePanel1.SetRow(this.btnClear, 0);
            this.btnClear.Size = new System.Drawing.Size(88, 128);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gv_NhaCC
            // 
            this.tablePanel1.SetColumn(this.gv_NhaCC, 1);
            this.gv_NhaCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_NhaCC.Location = new System.Drawing.Point(111, 169);
            this.gv_NhaCC.MainView = this.gridNhaCC;
            this.gv_NhaCC.Name = "gv_NhaCC";
            this.tablePanel1.SetRow(this.gv_NhaCC, 1);
            this.gv_NhaCC.Size = new System.Drawing.Size(828, 464);
            this.gv_NhaCC.TabIndex = 3;
            this.gv_NhaCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridNhaCC});
            // 
            // gridNhaCC
            // 
            this.gridNhaCC.GridControl = this.gv_NhaCC;
            this.gridNhaCC.Name = "gridNhaCC";
            this.gridNhaCC.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridNhaCC_RowCellClick);
            this.gridNhaCC.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridNhaCC_CellValueChanged);
            // 
            // stackPanel1
            // 
            this.tablePanel1.SetColumn(this.stackPanel1, 0);
            this.stackPanel1.Controls.Add(this.btnThem);
            this.stackPanel1.Controls.Add(this.btnXoa);
            this.stackPanel1.Controls.Add(this.btnSua);
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            this.stackPanel1.Location = new System.Drawing.Point(3, 246);
            this.stackPanel1.Margin = new System.Windows.Forms.Padding(3, 80, 3, 3);
            this.stackPanel1.Name = "stackPanel1";
            this.tablePanel1.SetRow(this.stackPanel1, 1);
            this.stackPanel1.Size = new System.Drawing.Size(102, 387);
            this.stackPanel1.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.SvgImage = global::LTUDTM_DoAnMonHoc.Properties.Resources.actions_addcircled;
            this.btnThem.Location = new System.Drawing.Point(4, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 64);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageOptions.SvgImage = global::LTUDTM_DoAnMonHoc.Properties.Resources.actions_deletecircled;
            this.btnXoa.Location = new System.Drawing.Point(4, 73);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 64);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.ImageOptions.SvgImage = global::LTUDTM_DoAnMonHoc.Properties.Resources.actions_edit;
            this.btnSua.Location = new System.Drawing.Point(4, 143);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(94, 64);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // panel1
            // 
            this.tablePanel1.SetColumn(this.panel1, 1);
            this.panel1.Controls.Add(this.cbNhaCC);
            this.panel1.Controls.Add(this.txtTenNCC);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.lblDiaChi);
            this.panel1.Controls.Add(this.lblTenNCC);
            this.panel1.Controls.Add(this.lblMaNCC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(111, 3);
            this.panel1.Name = "panel1";
            this.tablePanel1.SetRow(this.panel1, 0);
            this.panel1.Size = new System.Drawing.Size(828, 160);
            this.panel1.TabIndex = 0;
            // 
            // cbNhaCC
            // 
            this.cbNhaCC.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhaCC.FormattingEnabled = true;
            this.cbNhaCC.Location = new System.Drawing.Point(203, 29);
            this.cbNhaCC.Name = "cbNhaCC";
            this.cbNhaCC.Size = new System.Drawing.Size(225, 29);
            this.cbNhaCC.TabIndex = 7;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(203, 87);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNCC.Properties.Appearance.Options.UseFont = true;
            this.txtTenNCC.Size = new System.Drawing.Size(225, 28);
            this.txtTenNCC.TabIndex = 5;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(546, 30);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Size = new System.Drawing.Size(236, 28);
            this.txtDiaChi.TabIndex = 4;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Appearance.Options.UseFont = true;
            this.lblDiaChi.Location = new System.Drawing.Point(466, 36);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(58, 21);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNCC.Appearance.Options.UseFont = true;
            this.lblTenNCC.Location = new System.Drawing.Point(40, 90);
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(150, 21);
            this.lblTenNCC.TabIndex = 1;
            this.lblTenNCC.Text = "Tên nhà cung cấp";
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNCC.Appearance.Options.UseFont = true;
            this.lblMaNCC.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.lblMaNCC.LineVisible = true;
            this.lblMaNCC.Location = new System.Drawing.Point(40, 32);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(144, 21);
            this.lblMaNCC.TabIndex = 0;
            this.lblMaNCC.Text = "Mã nhà cung cấp";
            // 
            // frmQuanLyNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 636);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmQuanLyNhaCungCap";
            this.Text = "frmQuanLyNhaCungCung";
            this.Load += new System.EventHandler(this.frmQuanLyNhaCungCung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhaCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhaCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtTenNCC;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
        private DevExpress.XtraEditors.LabelControl lblTenNCC;
        private DevExpress.XtraEditors.LabelControl lblMaNCC;
        private System.Windows.Forms.ComboBox cbNhaCC;
        private DevExpress.XtraGrid.GridControl gv_NhaCC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridNhaCC;
        private DevExpress.XtraEditors.SimpleButton btnClear;
    }
}