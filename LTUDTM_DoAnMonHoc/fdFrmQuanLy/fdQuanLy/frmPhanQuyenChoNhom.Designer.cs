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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvNhomQuyens = new DevExpress.XtraGrid.GridControl();
            this.gvNhomQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemQuyenChoNhom = new System.Windows.Forms.Button();
            this.btnBoQuyenChoNhom = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvQuenNhomCo = new DevExpress.XtraGrid.GridControl();
            this.gvQuyenNhomCo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvQuyenNhomChuaCo = new DevExpress.XtraGrid.GridControl();
            this.gvQuyenNhomChuaCo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomQuyens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhomQuyen)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuenNhomCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuyenNhomCo)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyenNhomChuaCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuyenNhomChuaCo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(672, 538);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvNhomQuyens);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 532);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tất Cả Nhóm Quyền";
            // 
            // dgvNhomQuyens
            // 
            this.dgvNhomQuyens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhomQuyens.Location = new System.Drawing.Point(3, 17);
            this.dgvNhomQuyens.MainView = this.gvNhomQuyen;
            this.dgvNhomQuyens.Name = "dgvNhomQuyens";
            this.dgvNhomQuyens.Size = new System.Drawing.Size(324, 512);
            this.dgvNhomQuyens.TabIndex = 0;
            this.dgvNhomQuyens.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhomQuyen});
            // 
            // gvNhomQuyen
            // 
            this.gvNhomQuyen.GridControl = this.dgvNhomQuyens;
            this.gvNhomQuyen.Name = "gvNhomQuyen";
            this.gvNhomQuyen.OptionsBehavior.Editable = false;
            this.gvNhomQuyen.OptionsBehavior.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(339, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 532);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 47);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tác Vụ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnThemQuyenChoNhom);
            this.flowLayoutPanel1.Controls.Add(this.btnBoQuyenChoNhom);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(318, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnThemQuyenChoNhom
            // 
            this.btnThemQuyenChoNhom.Location = new System.Drawing.Point(3, 3);
            this.btnThemQuyenChoNhom.Name = "btnThemQuyenChoNhom";
            this.btnThemQuyenChoNhom.Size = new System.Drawing.Size(114, 23);
            this.btnThemQuyenChoNhom.TabIndex = 0;
            this.btnThemQuyenChoNhom.Text = "Thêm Quyền";
            this.btnThemQuyenChoNhom.UseVisualStyleBackColor = true;
            // 
            // btnBoQuyenChoNhom
            // 
            this.btnBoQuyenChoNhom.Location = new System.Drawing.Point(123, 3);
            this.btnBoQuyenChoNhom.Name = "btnBoQuyenChoNhom";
            this.btnBoQuyenChoNhom.Size = new System.Drawing.Size(105, 23);
            this.btnBoQuyenChoNhom.TabIndex = 1;
            this.btnBoQuyenChoNhom.Text = "Bỏ Quyền";
            this.btnBoQuyenChoNhom.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvQuenNhomCo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 233);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quyền Nhóm Đã Có";
            // 
            // dgvQuenNhomCo
            // 
            this.dgvQuenNhomCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuenNhomCo.Location = new System.Drawing.Point(3, 17);
            this.dgvQuenNhomCo.MainView = this.gvQuyenNhomCo;
            this.dgvQuenNhomCo.Name = "dgvQuenNhomCo";
            this.dgvQuenNhomCo.Size = new System.Drawing.Size(318, 213);
            this.dgvQuenNhomCo.TabIndex = 2;
            this.dgvQuenNhomCo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQuyenNhomCo});
            // 
            // gvQuyenNhomCo
            // 
            this.gvQuyenNhomCo.GridControl = this.dgvQuenNhomCo;
            this.gvQuyenNhomCo.Name = "gvQuyenNhomCo";
            this.gvQuyenNhomCo.OptionsBehavior.Editable = false;
            this.gvQuyenNhomCo.OptionsBehavior.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvQuyenNhomChuaCo);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 234);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quyền Nhóm Chưa Có";
            // 
            // dgvQuyenNhomChuaCo
            // 
            this.dgvQuyenNhomChuaCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuyenNhomChuaCo.Location = new System.Drawing.Point(3, 17);
            this.dgvQuyenNhomChuaCo.MainView = this.gvQuyenNhomChuaCo;
            this.dgvQuyenNhomChuaCo.Name = "dgvQuyenNhomChuaCo";
            this.dgvQuyenNhomChuaCo.Size = new System.Drawing.Size(318, 214);
            this.dgvQuyenNhomChuaCo.TabIndex = 3;
            this.dgvQuyenNhomChuaCo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQuyenNhomChuaCo});
            // 
            // gvQuyenNhomChuaCo
            // 
            this.gvQuyenNhomChuaCo.GridControl = this.dgvQuyenNhomChuaCo;
            this.gvQuyenNhomChuaCo.Name = "gvQuyenNhomChuaCo";
            this.gvQuyenNhomChuaCo.OptionsBehavior.Editable = false;
            this.gvQuyenNhomChuaCo.OptionsBehavior.ReadOnly = true;
            // 
            // frmPhanQuyenChoNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 538);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPhanQuyenChoNhom";
            this.Text = "Màn hình phân quyền cho nhóm";
            this.Load += new System.EventHandler(this.frmPhanQuyenChoNhom_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomQuyens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhomQuyen)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuenNhomCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuyenNhomCo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyenNhomChuaCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuyenNhomChuaCo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnThemQuyenChoNhom;
        private System.Windows.Forms.Button btnBoQuyenChoNhom;
        private DevExpress.XtraGrid.GridControl dgvNhomQuyens;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNhomQuyen;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraGrid.GridControl dgvQuenNhomCo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQuyenNhomCo;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraGrid.GridControl dgvQuyenNhomChuaCo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQuyenNhomChuaCo;
    }
}