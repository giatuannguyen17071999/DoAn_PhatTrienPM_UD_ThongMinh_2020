namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy
{
    partial class frmQuanLyQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyQuyen));
            this.dS_BanThietBiDienTu = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTu();
            this.qUYENSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qUYENSTableAdapter = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.QUYENSTableAdapter();
            this.tableAdapterManager = new LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.TableAdapterManager();
            this.qUYENSBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.qUYENSBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.qUYENSGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUYENSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUYENSBindingNavigator)).BeginInit();
            this.qUYENSBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qUYENSGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dS_BanThietBiDienTu
            // 
            this.dS_BanThietBiDienTu.DataSetName = "DS_BanThietBiDienTu";
            this.dS_BanThietBiDienTu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qUYENSBindingSource
            // 
            this.qUYENSBindingSource.DataMember = "QUYENS";
            this.qUYENSBindingSource.DataSource = this.dS_BanThietBiDienTu;
            // 
            // qUYENSTableAdapter
            // 
            this.qUYENSTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.NHOMQUYENSTableAdapter = null;
            this.tableAdapterManager.PHANNHANVIEN_VAONHOMQUYENTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHIEU_NHAPTableAdapter = null;
            this.tableAdapterManager.QUYENSTableAdapter = this.qUYENSTableAdapter;
            this.tableAdapterManager.SanPhamTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = LTUDTM_DoAnMonHoc.DS_BanThietBiDienTuTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // qUYENSBindingNavigator
            // 
            this.qUYENSBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.qUYENSBindingNavigator.BindingSource = this.qUYENSBindingSource;
            this.qUYENSBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.qUYENSBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.qUYENSBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.qUYENSBindingNavigatorSaveItem});
            this.qUYENSBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.qUYENSBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.qUYENSBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.qUYENSBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.qUYENSBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.qUYENSBindingNavigator.Name = "qUYENSBindingNavigator";
            this.qUYENSBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.qUYENSBindingNavigator.Size = new System.Drawing.Size(630, 25);
            this.qUYENSBindingNavigator.TabIndex = 0;
            this.qUYENSBindingNavigator.Text = "bindingNavigator1";
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
            // qUYENSBindingNavigatorSaveItem
            // 
            this.qUYENSBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("qUYENSBindingNavigatorSaveItem.Image")));
            this.qUYENSBindingNavigatorSaveItem.Name = "qUYENSBindingNavigatorSaveItem";
            this.qUYENSBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.qUYENSBindingNavigatorSaveItem.Text = "Save Data";
            this.qUYENSBindingNavigatorSaveItem.Click += new System.EventHandler(this.qUYENSBindingNavigatorSaveItem_Click);
            // 
            // qUYENSGridControl
            // 
            this.qUYENSGridControl.DataSource = this.qUYENSBindingSource;
            this.qUYENSGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qUYENSGridControl.Location = new System.Drawing.Point(0, 25);
            this.qUYENSGridControl.MainView = this.gridView1;
            this.qUYENSGridControl.Name = "qUYENSGridControl";
            this.qUYENSGridControl.Size = new System.Drawing.Size(630, 297);
            this.qUYENSGridControl.TabIndex = 1;
            this.qUYENSGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.qUYENSGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // frmQuanLyQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 322);
            this.Controls.Add(this.qUYENSGridControl);
            this.Controls.Add(this.qUYENSBindingNavigator);
            this.Name = "frmQuanLyQuyen";
            this.Text = "frmQuanLyQuyen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLyQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_BanThietBiDienTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUYENSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUYENSBindingNavigator)).EndInit();
            this.qUYENSBindingNavigator.ResumeLayout(false);
            this.qUYENSBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qUYENSGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DS_BanThietBiDienTu dS_BanThietBiDienTu;
        private System.Windows.Forms.BindingSource qUYENSBindingSource;
        private DS_BanThietBiDienTuTableAdapters.QUYENSTableAdapter qUYENSTableAdapter;
        private DS_BanThietBiDienTuTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator qUYENSBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton qUYENSBindingNavigatorSaveItem;
        private DevExpress.XtraGrid.GridControl qUYENSGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}