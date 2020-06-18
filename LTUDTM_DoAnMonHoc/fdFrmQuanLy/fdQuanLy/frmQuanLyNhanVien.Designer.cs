namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    partial class frmQuanLyNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyNhanVien));
            this.dS_BanThietBiDienTu = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTu();
            this.nHANVIENSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIENSTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.NHANVIENSTableAdapter();
            this.tableAdapterManager = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.TableAdapterManager();
            this.nHANVIENSBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.nHANVIENSBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.nHANVIENSGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSBindingNavigator)).BeginInit();
            this.nHANVIENSBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            // nHANVIENSBindingNavigator
            // 
            this.nHANVIENSBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.nHANVIENSBindingNavigator.BindingSource = this.nHANVIENSBindingSource;
            this.nHANVIENSBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.nHANVIENSBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.nHANVIENSBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.nHANVIENSBindingNavigatorSaveItem});
            this.nHANVIENSBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.nHANVIENSBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nHANVIENSBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nHANVIENSBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nHANVIENSBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nHANVIENSBindingNavigator.Name = "nHANVIENSBindingNavigator";
            this.nHANVIENSBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.nHANVIENSBindingNavigator.Size = new System.Drawing.Size(540, 25);
            this.nHANVIENSBindingNavigator.TabIndex = 0;
            this.nHANVIENSBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(74, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(60, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // nHANVIENSBindingNavigatorSaveItem
            // 
            this.nHANVIENSBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("nHANVIENSBindingNavigatorSaveItem.Image")));
            this.nHANVIENSBindingNavigatorSaveItem.Name = "nHANVIENSBindingNavigatorSaveItem";
            this.nHANVIENSBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.nHANVIENSBindingNavigatorSaveItem.Text = "Save Data";
            this.nHANVIENSBindingNavigatorSaveItem.Click += new System.EventHandler(this.nHANVIENSBindingNavigatorSaveItem_Click);
            // 
            // nHANVIENSGridControl
            // 
            this.nHANVIENSGridControl.DataSource = this.nHANVIENSBindingSource;
            this.nHANVIENSGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nHANVIENSGridControl.Location = new System.Drawing.Point(0, 25);
            this.nHANVIENSGridControl.MainView = this.gridView1;
            this.nHANVIENSGridControl.Name = "nHANVIENSGridControl";
            this.nHANVIENSGridControl.Size = new System.Drawing.Size(540, 299);
            this.nHANVIENSGridControl.TabIndex = 1;
            this.nHANVIENSGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.nHANVIENSGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // frmQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 324);
            this.Controls.Add(this.nHANVIENSGridControl);
            this.Controls.Add(this.nHANVIENSBindingNavigator);
            this.Name = "frmQuanLyNhanVien";
            this.Text = "frmQuanLyNhanVien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLyNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSBindingNavigator)).EndInit();
            this.nHANVIENSBindingNavigator.ResumeLayout(false);
            this.nHANVIENSBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENSGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DS_BanThietBiDienTu dS_BanThietBiDienTu;
        private System.Windows.Forms.BindingSource nHANVIENSBindingSource;
        private DS_BanThietBiDienTuTableAdapters.NHANVIENSTableAdapter nHANVIENSTableAdapter;
        private DS_BanThietBiDienTuTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator nHANVIENSBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton nHANVIENSBindingNavigatorSaveItem;
        private DevExpress.XtraGrid.GridControl nHANVIENSGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}