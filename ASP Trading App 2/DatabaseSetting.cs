using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASP_Trading_App_2.CommonComponent;

namespace ASP_Trading_App_2
{
    public partial class DatabaseSetting : Form
    {
        private INIFile dbSettingFile;
        private string Dir;
        private bool save;

        public bool Save { get => save; set => save = value; }

        public DatabaseSetting()
        {
            InitializeComponent();
            Dir = System.IO.Directory.GetCurrentDirectory();
            dbSettingFile = new INIFile(Dir+"\\dbConfig.ini");
            save = false;
        }

        private void LoadFile()
        {
            EditHost.Text = dbSettingFile.Read("dbConfig", "Host");
            EditDBName.Text = dbSettingFile.Read("dbConfig", "DBName");
            EditUserId.Text = dbSettingFile.Read("dbConfig", "UserId");
            EditPassword.Text = dbSettingFile.Read("dbConfig", "Password");
            EditPort.Value = Decimal.Parse(dbSettingFile.Read("dbConfig", "Port"));
        }

        private void SaveFile()
        {
            dbSettingFile.Write("dbConfig", "Host", EditHost.Text.Trim());
            dbSettingFile.Write("dbConfig", "DBName", EditDBName.Text.Trim());
            dbSettingFile.Write("dbConfig", "UserId", EditUserId.Text.Trim());
            dbSettingFile.Write("dbConfig", "Password", EditPassword.Text);
            dbSettingFile.Write("dbConfig", "Port", EditPort.Value.ToString());
        }

        private void DatabaseSetting_Load(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
            save = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
