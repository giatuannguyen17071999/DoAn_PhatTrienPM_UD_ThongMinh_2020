﻿namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    partial class frmQuanLyNhomQuyen
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
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMaNhom = new System.Windows.Forms.ComboBox();
            this.txtTenNhom = new DevExpress.XtraEditors.TextEdit();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.lblTenNhom = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNhom = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.gv_NhomQuyen = new DevExpress.XtraGrid.GridControl();
            this.gridNhomQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhomQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhomQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 6.89F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 53.11F)});
            this.tablePanel1.Controls.Add(this.gv_NhomQuyen);
            this.tablePanel1.Controls.Add(this.btnClear);
            this.tablePanel1.Controls.Add(this.stackPanel1);
            this.tablePanel1.Controls.Add(this.panel1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 166.0003F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(967, 608);
            this.tablePanel1.TabIndex = 0;
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
            this.stackPanel1.Size = new System.Drawing.Size(105, 359);
            this.stackPanel1.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(5, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 64);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(5, 73);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 64);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(5, 143);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(94, 64);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // panel1
            // 
            this.tablePanel1.SetColumn(this.panel1, 1);
            this.panel1.Controls.Add(this.cbMaNhom);
            this.panel1.Controls.Add(this.txtTenNhom);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.lblGhiChu);
            this.panel1.Controls.Add(this.lblTenNhom);
            this.panel1.Controls.Add(this.lblMaNhom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(114, 3);
            this.panel1.Name = "panel1";
            this.tablePanel1.SetRow(this.panel1, 0);
            this.panel1.Size = new System.Drawing.Size(850, 160);
            this.panel1.TabIndex = 0;
            // 
            // cbMaNhom
            // 
            this.cbMaNhom.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaNhom.FormattingEnabled = true;
            this.cbMaNhom.Location = new System.Drawing.Point(149, 32);
            this.cbMaNhom.Name = "cbMaNhom";
            this.cbMaNhom.Size = new System.Drawing.Size(194, 29);
            this.cbMaNhom.TabIndex = 6;
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Location = new System.Drawing.Point(149, 87);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhom.Properties.Appearance.Options.UseFont = true;
            this.txtTenNhom.Size = new System.Drawing.Size(194, 28);
            this.txtTenNhom.TabIndex = 5;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(470, 31);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(343, 105);
            this.txtGhiChu.TabIndex = 3;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Appearance.Options.UseFont = true;
            this.lblGhiChu.Location = new System.Drawing.Point(385, 31);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(65, 21);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // lblTenNhom
            // 
            this.lblTenNhom.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhom.Appearance.Options.UseFont = true;
            this.lblTenNhom.Location = new System.Drawing.Point(40, 90);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(85, 21);
            this.lblTenNhom.TabIndex = 1;
            this.lblTenNhom.Text = "Ten nhóm";
            // 
            // lblMaNhom
            // 
            this.lblMaNhom.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNhom.Appearance.Options.UseFont = true;
            this.lblMaNhom.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.lblMaNhom.LineVisible = true;
            this.lblMaNhom.Location = new System.Drawing.Point(40, 32);
            this.lblMaNhom.Name = "lblMaNhom";
            this.lblMaNhom.Size = new System.Drawing.Size(79, 21);
            this.lblMaNhom.TabIndex = 0;
            this.lblMaNhom.Text = "Mã nhóm";
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.Tomato;
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.tablePanel1.SetColumn(this.btnClear, 0);
            this.btnClear.Location = new System.Drawing.Point(3, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.tablePanel1.SetRow(this.btnClear, 0);
            this.btnClear.Size = new System.Drawing.Size(105, 129);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gv_NhomQuyen
            // 
            this.tablePanel1.SetColumn(this.gv_NhomQuyen, 1);
            this.gv_NhomQuyen.Location = new System.Drawing.Point(114, 287);
            this.gv_NhomQuyen.MainView = this.gridNhomQuyen;
            this.gv_NhomQuyen.Name = "gv_NhomQuyen";
            this.tablePanel1.SetRow(this.gv_NhomQuyen, 1);
            this.gv_NhomQuyen.Size = new System.Drawing.Size(850, 200);
            this.gv_NhomQuyen.TabIndex = 6;
            this.gv_NhomQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridNhomQuyen});
            // 
            // gridNhomQuyen
            // 
            this.gridNhomQuyen.GridControl = this.gv_NhomQuyen;
            this.gridNhomQuyen.Name = "gridNhomQuyen";
            this.gridNhomQuyen.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridNhomQuyen_RowCellClick);
            this.gridNhomQuyen.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridNhomQuyen_CellValueChanged);
            // 
            // frmQuanLyNhomQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 608);
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmQuanLyNhomQuyen";
            this.Text = "frmQuanLyNhomQuyen";
            this.Load += new System.EventHandler(this.frmQuanLyNhomQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhomQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhomQuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.LabelControl lblTenNhom;
        private DevExpress.XtraEditors.LabelControl lblMaNhom;
        private DevExpress.XtraEditors.TextEdit txtTenNhom;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private System.Windows.Forms.ComboBox cbMaNhom;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraGrid.GridControl gv_NhomQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridNhomQuyen;
    }
}