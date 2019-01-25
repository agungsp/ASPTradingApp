using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using ASP_Trading_App_2.DataObject.Master.General;
using ASP_Trading_App_2.DBComm.Master.General;
using ASP_Trading_App_2.DataObject.System;
using ASP_Trading_App_2.DBComm.System;
using ASP_Trading_App_2.Forms.Master.General;


namespace ASP_Trading_App_2
{
    public partial class MainForm : Form
    {
        private DatabaseSetting DBSetting;
        private LoginForm loginForm;
        public static ASPMUser_DO FMCurrUser;
        private ASPMUser_DBC FDBMCurrUser;
        private ASPSysInfo_DO FSysInfo;
        private ASPSysInfo_DBC FDBSysInfo;

        ASPMJabatanForm FormMJabatan;
        ASPMKaryawanForm FormMKaryawan;
        ASPMGroupForm FormMGroup;

        public MainForm()
        {
            InitializeComponent();
            Create();
            Initialize();
        }

        private void Create()
        {
            loginForm = new LoginForm();
            FSysInfo = new ASPSysInfo_DO();
            FDBSysInfo = new ASPSysInfo_DBC();
            FMCurrUser = new ASPMUser_DO();
            FDBMCurrUser = new ASPMUser_DBC();
        }

        private void Initialize()
        {
            FMCurrUser = FDBMCurrUser.Clear();
            FSysInfo = FDBSysInfo.Clear();
        }

        private bool SystemCheck() {
            bool Result = true;

            if (Result)
            {
                Result = VersionCheck();
            }


            return Result;
        }

        private bool VersionCheck()
        {
            bool Result = true;
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            if (!FDBSysInfo.SelectById(1, ref FSysInfo))
            {
                FSysInfo = FDBSysInfo.Clear();
            }

            if (!fileVersion.FileVersion.Equals(FSysInfo.AppVersion))
            {
                Result = false;
            }
            return Result;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            
        }

        private void Main_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                MessageBox.Show(this, "WOW");
            }
        }

        private void financeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MasterForm master = new MasterForm();
            //master.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            if (FMCurrUser.IdMUser == 0)
            {
                loginForm.ShowDialog();
                if (!loginForm.Visible && loginForm.FMCurrUser.IdMUser != 0)
                {
                    FMCurrUser = loginForm.FMCurrUser;
                    loginForm.Dispose();
                    this.Visible = true;
                }
            }

            DateApp.Text = System.DateTime.Now.Date.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));
            UserLogin.Text = FMCurrUser.Username;
        }

        private void jabatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormMJabatan == null || FormMJabatan.IsDisposed)
            {
                FormMJabatan = new ASPMJabatanForm();
                FormMJabatan.Show(this);
            }
            else
            {
                FormMJabatan.Focus();
            }          
        }

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormMKaryawan == null || FormMKaryawan.IsDisposed)
            {
                FormMKaryawan = new ASPMKaryawanForm();
                FormMKaryawan.Show(this);
            }
            else
            {
                FormMKaryawan.Focus();
            }
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormMGroup == null || FormMGroup.IsDisposed)
            {
                FormMGroup = new ASPMGroupForm();
                FormMGroup.Show(this);
            }
            else
            {
                FormMGroup.Focus();
            }
        }
    }
}
