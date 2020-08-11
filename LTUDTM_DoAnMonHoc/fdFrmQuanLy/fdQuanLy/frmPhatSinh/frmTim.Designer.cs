namespace LTUDTM_DoAnMonHoc.fdFrmQuanLy.fdQuanLy.frmPhatSinh
{
    partial class frmTim
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
            this.dgvTim = new DevExpress.XtraGrid.GridControl();
            this.gvTim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTim)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTim
            // 
            this.dgvTim.Location = new System.Drawing.Point(23, 13);
            this.dgvTim.MainView = this.gvTim;
            this.dgvTim.Name = "dgvTim";
            this.dgvTim.Size = new System.Drawing.Size(548, 250);
            this.dgvTim.TabIndex = 0;
            this.dgvTim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTim});
            // 
            // gvTim
            // 
            this.gvTim.GridControl = this.dgvTim;
            this.gvTim.Name = "gvTim";
            this.gvTim.OptionsBehavior.Editable = false;
            this.gvTim.OptionsBehavior.ReadOnly = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(84, 269);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(107, 38);
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(229, 269);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 38);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmTim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 316);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dgvTim);
            this.MaximizeBox = false;
            this.Name = "frmTim";
            this.Text = "Màn Hình Tìm";
            this.Load += new System.EventHandler(this.frmTim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvTim;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTim;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}