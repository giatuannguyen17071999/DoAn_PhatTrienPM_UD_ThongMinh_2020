namespace MyLibrary.fdPopup
{
    partial class frmThemGhiChu
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
            this.btnHuyBo = new DevExpress.XtraEditors.SimpleButton();
            this.btnChapNhan = new DevExpress.XtraEditors.SimpleButton();
            this.tbThemGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(199, 166);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 5;
            this.btnHuyBo.Text = "Hủy Bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnChapNhan
            // 
            this.btnChapNhan.Location = new System.Drawing.Point(23, 166);
            this.btnChapNhan.Name = "btnChapNhan";
            this.btnChapNhan.Size = new System.Drawing.Size(75, 23);
            this.btnChapNhan.TabIndex = 6;
            this.btnChapNhan.Text = "Chấp Nhận";
            this.btnChapNhan.Click += new System.EventHandler(this.btnChapNhan_Click);
            // 
            // tbThemGhiChu
            // 
            this.tbThemGhiChu.Location = new System.Drawing.Point(23, 50);
            this.tbThemGhiChu.Multiline = true;
            this.tbThemGhiChu.Name = "tbThemGhiChu";
            this.tbThemGhiChu.Size = new System.Drawing.Size(251, 98);
            this.tbThemGhiChu.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thêm ghi chú cho nhân viên khi thêm vào nhóm này";
            // 
            // frmThemGhiChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 211);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnChapNhan);
            this.Controls.Add(this.tbThemGhiChu);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmThemGhiChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThemGhiChu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnHuyBo;
        private DevExpress.XtraEditors.SimpleButton btnChapNhan;
        private System.Windows.Forms.TextBox tbThemGhiChu;
        private System.Windows.Forms.Label label1;
    }
}