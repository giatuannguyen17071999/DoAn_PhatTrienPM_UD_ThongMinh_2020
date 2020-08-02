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
            this.btnThemNhanVien_QuaPhai = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboxNhomQuyen = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXoaNhanVienQuaTrai = new DevExpress.XtraEditors.SimpleButton();
            this.dgvNhanViens = new DevExpress.XtraGrid.GridControl();
            this.gvNhanViens = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgvPhanNhanVienVaoNhoms = new DevExpress.XtraGrid.GridControl();
            this.gvPhanNhanVienVaoNhomQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanViens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanViens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanNhanVienVaoNhoms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhanNhanVienVaoNhomQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemNhanVien_QuaPhai
            // 
            this.btnThemNhanVien_QuaPhai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNhanVien_QuaPhai.Location = new System.Drawing.Point(3, 3);
            this.btnThemNhanVien_QuaPhai.Name = "btnThemNhanVien_QuaPhai";
            this.btnThemNhanVien_QuaPhai.Size = new System.Drawing.Size(75, 23);
            this.btnThemNhanVien_QuaPhai.TabIndex = 0;
            this.btnThemNhanVien_QuaPhai.Text = ">>";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.cboxNhomQuyen, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvNhanViens, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvPhanNhanVienVaoNhoms, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 470);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cboxNhomQuyen
            // 
            this.cboxNhomQuyen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cboxNhomQuyen.FormattingEnabled = true;
            this.cboxNhomQuyen.Location = new System.Drawing.Point(484, 23);
            this.cboxNhomQuyen.Name = "cboxNhomQuyen";
            this.cboxNhomQuyen.Size = new System.Drawing.Size(390, 21);
            this.cboxNhomQuyen.TabIndex = 0;
            this.cboxNhomQuyen.SelectedIndexChanged += new System.EventHandler(this.cboxNhomQuyen_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnThemNhanVien_QuaPhai);
            this.flowLayoutPanel1.Controls.Add(this.btnXoaNhanVienQuaTrai);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(397, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(81, 417);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnXoaNhanVienQuaTrai
            // 
            this.btnXoaNhanVienQuaTrai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaNhanVienQuaTrai.Location = new System.Drawing.Point(3, 32);
            this.btnXoaNhanVienQuaTrai.Name = "btnXoaNhanVienQuaTrai";
            this.btnXoaNhanVienQuaTrai.Size = new System.Drawing.Size(75, 23);
            this.btnXoaNhanVienQuaTrai.TabIndex = 1;
            this.btnXoaNhanVienQuaTrai.Text = "<<";
            // 
            // dgvNhanViens
            // 
            this.dgvNhanViens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanViens.Location = new System.Drawing.Point(3, 50);
            this.dgvNhanViens.MainView = this.gvNhanViens;
            this.dgvNhanViens.Name = "dgvNhanViens";
            this.dgvNhanViens.Size = new System.Drawing.Size(388, 417);
            this.dgvNhanViens.TabIndex = 4;
            this.dgvNhanViens.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhanViens});
            // 
            // gvNhanViens
            // 
            this.gvNhanViens.GridControl = this.dgvNhanViens;
            this.gvNhanViens.Name = "gvNhanViens";
            this.gvNhanViens.OptionsBehavior.Editable = false;
            this.gvNhanViens.OptionsBehavior.ReadOnly = true;
            // 
            // dgvPhanNhanVienVaoNhoms
            // 
            this.dgvPhanNhanVienVaoNhoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanNhanVienVaoNhoms.Location = new System.Drawing.Point(484, 50);
            this.dgvPhanNhanVienVaoNhoms.MainView = this.gvPhanNhanVienVaoNhomQuyen;
            this.dgvPhanNhanVienVaoNhoms.Name = "dgvPhanNhanVienVaoNhoms";
            this.dgvPhanNhanVienVaoNhoms.Size = new System.Drawing.Size(390, 417);
            this.dgvPhanNhanVienVaoNhoms.TabIndex = 5;
            this.dgvPhanNhanVienVaoNhoms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPhanNhanVienVaoNhomQuyen});
            // 
            // gvPhanNhanVienVaoNhomQuyen
            // 
            this.gvPhanNhanVienVaoNhomQuyen.GridControl = this.dgvPhanNhanVienVaoNhoms;
            this.gvPhanNhanVienVaoNhomQuyen.Name = "gvPhanNhanVienVaoNhomQuyen";
            this.gvPhanNhanVienVaoNhomQuyen.OptionsBehavior.Editable = false;
            this.gvPhanNhanVienVaoNhomQuyen.OptionsBehavior.ReadOnly = true;
            // 
            // frmPhanNhanVienVaoNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPhanNhanVienVaoNhom";
            this.Text = "Màn hình phân nhân viên vào nhóm";
            this.Load += new System.EventHandler(this.frmPhanNhanVienVaoNhom_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanViens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanViens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanNhanVienVaoNhoms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhanNhanVienVaoNhomQuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnThemNhanVien_QuaPhai;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboxNhomQuyen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnXoaNhanVienQuaTrai;
        private DevExpress.XtraGrid.GridControl dgvNhanViens;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNhanViens;
        private DevExpress.XtraGrid.GridControl dgvPhanNhanVienVaoNhoms;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPhanNhanVienVaoNhomQuyen;
    }
}