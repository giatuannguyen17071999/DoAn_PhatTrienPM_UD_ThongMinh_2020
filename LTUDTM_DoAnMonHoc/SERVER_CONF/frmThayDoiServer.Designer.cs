namespace LTUDTM_DoAnMonHoc.SERVER_CONF
{
    partial class frmThayDoiServer
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbLoading = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.cboxDatabase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxServer = new System.Windows.Forms.ComboBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckQuyenWindows = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(26, 218);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(209, 13);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.Location = new System.Drawing.Point(241, 218);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(54, 13);
            this.lbLoading.TabIndex = 12;
            this.lbLoading.Text = "Loading...";
            this.lbLoading.Visible = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(195, 172);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Luu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(90, 172);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(99, 23);
            this.btnTestConnect.TabIndex = 9;
            this.btnTestConnect.Text = "Kiểm Tra Kết Nối";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            // 
            // cboxDatabase
            // 
            this.cboxDatabase.FormattingEnabled = true;
            this.cboxDatabase.Location = new System.Drawing.Point(90, 141);
            this.cboxDatabase.Name = "cboxDatabase";
            this.cboxDatabase.Size = new System.Drawing.Size(178, 21);
            this.cboxDatabase.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Database";
            // 
            // cboxServer
            // 
            this.cboxServer.FormattingEnabled = true;
            this.cboxServer.Location = new System.Drawing.Point(90, 12);
            this.cboxServer.Name = "cboxServer";
            this.cboxServer.Size = new System.Drawing.Size(178, 21);
            this.cboxServer.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(90, 108);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(178, 20);
            this.tbPassword.TabIndex = 6;
            // 
            // tbUserID
            // 
            this.tbUserID.Location = new System.Drawing.Point(90, 72);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(178, 20);
            this.tbUserID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // ckQuyenWindows
            // 
            this.ckQuyenWindows.AutoSize = true;
            this.ckQuyenWindows.Location = new System.Drawing.Point(90, 44);
            this.ckQuyenWindows.Name = "ckQuyenWindows";
            this.ckQuyenWindows.Size = new System.Drawing.Size(154, 17);
            this.ckQuyenWindows.TabIndex = 2;
            this.ckQuyenWindows.Text = "Xác Thực Quyền Windows";
            this.ckQuyenWindows.UseVisualStyleBackColor = true;
            this.ckQuyenWindows.CheckedChanged += new System.EventHandler(this.cboxQuyenWindows_CheckedChanged);
            // 
            // frmThayDoiServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 248);
            this.Controls.Add(this.ckQuyenWindows);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.cboxDatabase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxServer);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserID);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmThayDoiServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thây Đổi Server";
            this.Load += new System.EventHandler(this.frmThayDoiServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbLoading;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.ComboBox cboxDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxServer;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckQuyenWindows;
    }
}