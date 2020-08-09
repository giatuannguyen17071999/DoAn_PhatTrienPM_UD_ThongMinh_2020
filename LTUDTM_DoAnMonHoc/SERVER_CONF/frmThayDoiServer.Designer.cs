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
            this.progressBar.Location = new System.Drawing.Point(35, 268);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(279, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.Location = new System.Drawing.Point(321, 268);
            this.lbLoading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(71, 17);
            this.lbLoading.TabIndex = 12;
            this.lbLoading.Text = "Loading...";
            this.lbLoading.Visible = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(260, 212);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 28);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Luu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(120, 212);
            this.btnTestConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(132, 28);
            this.btnTestConnect.TabIndex = 9;
            this.btnTestConnect.Text = "Kiểm Tra Kết Nối";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click_1);
            // 
            // cboxDatabase
            // 
            this.cboxDatabase.FormattingEnabled = true;
            this.cboxDatabase.Location = new System.Drawing.Point(120, 174);
            this.cboxDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxDatabase.Name = "cboxDatabase";
            this.cboxDatabase.Size = new System.Drawing.Size(236, 24);
            this.cboxDatabase.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Database";
            // 
            // cboxServer
            // 
            this.cboxServer.FormattingEnabled = true;
            this.cboxServer.Location = new System.Drawing.Point(120, 15);
            this.cboxServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxServer.Name = "cboxServer";
            this.cboxServer.Size = new System.Drawing.Size(236, 24);
            this.cboxServer.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(120, 133);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(236, 22);
            this.tbPassword.TabIndex = 6;
            // 
            // tbUserID
            // 
            this.tbUserID.Location = new System.Drawing.Point(120, 89);
            this.tbUserID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(236, 22);
            this.tbUserID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // ckQuyenWindows
            // 
            this.ckQuyenWindows.AutoSize = true;
            this.ckQuyenWindows.Location = new System.Drawing.Point(120, 54);
            this.ckQuyenWindows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckQuyenWindows.Name = "ckQuyenWindows";
            this.ckQuyenWindows.Size = new System.Drawing.Size(196, 21);
            this.ckQuyenWindows.TabIndex = 2;
            this.ckQuyenWindows.Text = "Xác Thực Quyền Windows";
            this.ckQuyenWindows.UseVisualStyleBackColor = true;
            this.ckQuyenWindows.CheckedChanged += new System.EventHandler(this.cboxQuyenWindows_CheckedChanged);
            // 
            // frmThayDoiServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 305);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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