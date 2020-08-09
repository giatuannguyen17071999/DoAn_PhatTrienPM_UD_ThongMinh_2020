using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTUDTM_DoAnMonHoc.SERVER_CONF
{
    public partial class frmThayDoiServer : Form
    {
        private string strConn;
        private BackgroundWorker bwk;
        private DataTable dtServerName;
        private DataTable dtDatabase;
        Configuration conf;
        string key;
        string connectionString;

        public string GetStrConn
        {
            get { return conf.ConnectionStrings.ConnectionStrings[key].ConnectionString; }
        }

        public frmThayDoiServer()
        {
            InitializeComponent();
        }

        private void frmThayDoiServer_Load(object sender, EventArgs e)
        {
            bwk = new BackgroundWorker();
            bwk.WorkerReportsProgress = true;
            bwk.DoWork += Bwk_DoWork;
            bwk.ProgressChanged += Bwk_ProgressChanged;
            bwk.RunWorkerCompleted += Bwk_RunWorkerCompleted;
            btnTestConnect.Click += BtnTestConnect_Click;
            btnLuu.Click += BtnLuu_Click;
            cboxServer.DropDown += CboxServer_DropDown;
            cboxDatabase.DropDown += CboxDatabase_DropDown;
            btnLuu.Enabled = false;

            conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            key = "DAL_BLL.Properties.Settings.QL_MUABAN_TBDTConnectionString";

            dtServerName = null;
            dtDatabase = null;
        }

        private void initConnection()
        {
            string server = cboxServer.Text,
                database = cboxDatabase.Text,
                userID = tbUserID.Text,
                pwd = tbPassword.Text;

            if (ckQuyenWindows.Checked)
                connectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true", server, database);
            else
                connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server, database, userID, pwd);
        }

        private void CboxDatabase_DropDown(object sender, EventArgs e)
        {
            initConnection();
            if (dtDatabase == null || dtDatabase.Rows.Count == 0)
            {
                string userID = tbUserID.Text,
                    pass = tbPassword.Text;
                if ((string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(pass)) && !ckQuyenWindows.Checked)
                    MessageBox.Show("Fill UserID and Pass");
                else
                {
                    try
                    {
                        MessageBox.Show(connectionString);
                        string query = "SELECT name FROM SYS.DATABASEs";
                        dtDatabase = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
                        da.Fill(dtDatabase);
                        cboxDatabase.DataSource = dtDatabase;
                        cboxDatabase.DisplayMember = "Name";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Username Or Password Is Incorrect! (ErrorCode: " + ex.Message + ")");
                    }
                }
            }
        }

        private void CboxServer_DropDown(object sender, EventArgs e)
        {
            if (bwk.IsBusy)
                MessageBox.Show("Please wait while process!");
            else if (dtServerName == null)
                bwk.RunWorkerAsync();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            initConnection();
            conf.ConnectionStrings.ConnectionStrings[key].ConnectionString = connectionString;
            conf.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            conf.Save(ConfigurationSaveMode.Modified);

            FunctionStatic.hienThiThongBaoThanhCong("Lưu Thành Công! Ứng dụng sẽ thoát, vui lòng khởi động lại");
            
            Close();
        }

        private void BtnTestConnect_Click(object sender, EventArgs e)
        {
            initConnection();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                FunctionStatic.hienThiThongBaoThanhCong("Kiểm Tra kết nối thành công!");
                btnLuu.Enabled = true;
            }
            catch
            {
                FunctionStatic.hienThiThongBaoLoi("Kiểm Tra kết nối thất bại!");
                btnLuu.Enabled = false;
            }

            FunctionStatic.hienThiCauHoiYesNo(connectionString);
        }

        private void Bwk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dtServerName.Rows.Add(new string[] { "VIETSACLO-PC\\SQLEXPRESS", "VIETSACLO-PC\\SQLEXPRESS", "true", "1" });
            cboxServer.DataSource = dtServerName;
            cboxServer.DisplayMember = "ServerName";
            lbLoading.Visible = progressBar.Visible = false;

            strConn = string.Format("Server= {0}; Initial Catalog= master; User ID= {1}; pwd= {2}", cboxServer.Text, tbUserID.Text, tbPassword.Text);
        }

        private void Bwk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                lbLoading.Visible = progressBar.Visible = true;
            }
        }

        private void Bwk_DoWork(object sender, DoWorkEventArgs e)
        {
            bwk.ReportProgress(0);
            dtServerName = SqlDataSourceEnumerator.Instance.GetDataSources();
        }

        private void cboxQuyenWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (ckQuyenWindows.Checked)
                tbUserID.ReadOnly = tbPassword.ReadOnly = true;
            else
                tbUserID.ReadOnly = tbPassword.ReadOnly = false;
        }

        private void btnTestConnect_Click_1(object sender, EventArgs e)
        {

        }
    }
}
