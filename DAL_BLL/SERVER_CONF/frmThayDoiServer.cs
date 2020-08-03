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

namespace DAL_BLL.SERVER_CONF
{
    public partial class frmThayDoiServer : Form
    {
        private string strConn;
        private BackgroundWorker bwk;
        private DataTable dtServerName;
        private DataTable dtDatabase;
        Configuration conf;
        string key;

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
            strConn = Properties.Settings.Default.QL_MUABAN_TBDTConnectionString;
            bwk = new BackgroundWorker();
            bwk.WorkerReportsProgress = true;
            bwk.DoWork += Bwk_DoWork;
            bwk.ProgressChanged += Bwk_ProgressChanged;
            bwk.RunWorkerCompleted += Bwk_RunWorkerCompleted;
            btnTestConnect.Click += BtnTestConnect_Click;
            btnLuu.Click += BtnLuu_Click;
            cboxServer.DropDown += CboxServer_DropDown;
            cboxDatabase.DropDown += CboxDatabase_DropDown;

            string assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var exePath = new ExeConfigurationFileMap { ExeConfigFilename = assemblyPath+ ".config" };
            conf = ConfigurationManager.OpenMappedExeConfiguration(exePath, ConfigurationUserLevel.None);
            key = "DAL_BLL.Properties.Settings.QL_MUABAN_TBDTConnectionString";

            dtServerName = null;
            dtDatabase = null;
        }

        private void CboxDatabase_DropDown(object sender, EventArgs e)
        {
            if (dtDatabase == null)
            {
                string userID = tbUserID.Text,
                    pass = tbPassword.Text;
                if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(pass))
                    MessageBox.Show("Fill UserID and Pass");
                else
                {
                    strConn = string.Format("Server= {0}; User ID= {1}; pwd= {2}", cboxServer.Text, tbUserID.Text, tbPassword.Text);
                    try
                    {
                        MessageBox.Show(strConn);
                        string query = "SELECT name FROM SYS.DATABASEs";
                        dtDatabase = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(query, strConn);
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
            Properties.Settings.Default.PropertyValues["QL_MUABAN_TBDTConnectionString"].PropertyValue = "viet";
            Properties.Settings.Default.Save();

            //string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", cboxServer.Text, cboxDatabase.Text, tbUserID.Text, tbPassword.Text);
            //string key = "DAL_BLL.Properties.Settings.QL_MUABAN_TBDTConnectionString";
            //conf.ConnectionStrings.ConnectionStrings[key].ConnectionString = connectionString;
            //conf.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            //conf.Save(ConfigurationSaveMode.Modified);

            //FunctionStatic.hienThiThongBaoThanhCong("Lưu Thành Công!");
            //Close();
        }

        private void BtnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string s = conf.ConnectionStrings.ConnectionStrings[key].ConnectionString;
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                FunctionStatic.hienThiThongBaoThanhCong("Kiểm Tra kết nối thành công!");
            }
            catch
            {
                FunctionStatic.hienThiThongBaoLoi("Kiểm Tra kết nối thất bại!");
            }
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
    }
}
