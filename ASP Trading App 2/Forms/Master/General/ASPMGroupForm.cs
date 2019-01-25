using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ASP_Trading_App_2.CommonComponent;
using ASP_Trading_App_2.DataObject.Master.General;
using ASP_Trading_App_2.DBComm.Master.General;
using ASP_Trading_App_2.DataObject.Master.General.Group;
using ASP_Trading_App_2.DBComm.Master.General.Group;

namespace ASP_Trading_App_2.Forms.Master.General
{
    public partial class ASPMGroupForm : ASP_Trading_App_2.BaseForms.MasterBlankForm
    {
        private ASPMKaryawan_DO GMManager;
        private ASPMKaryawan_DO GMAnggota;
        private ASPMKaryawan_DBC GDBMKaryawan;
        private ASPMGroup_DO GMGroup;
        private ASPMGroup_DBC GDBMGroup;

        public ASPMGroupForm()
        {
            InitializeComponent();
            Create();
            Initialize();
        }

        protected override void Create()
        {
            base.Create();
            GMManager = new ASPMKaryawan_DO();
            GMAnggota = new ASPMKaryawan_DO();
            GDBMKaryawan = new ASPMKaryawan_DBC();
            GMGroup = new ASPMGroup_DO();
            GDBMGroup = new ASPMGroup_DBC();
        }

        protected override void Initialize()
        {
            GTitleForm = "Master Group";
            GMManager = GDBMKaryawan.Clear();
            GMAnggota = GDBMKaryawan.Clear();
            GMGroup = GDBMGroup.Clear();
            tabControl1.TabIndex = 1;
            ShowData();
            GenerateComboColumn();
            GetTable();
            SetMode(ASPConstant.ModeBrowse);
            dataGridViewInput.Focus();

            base.Initialize();
        }

        protected override void SetMode(int mode)
        {
            base.SetMode(mode);
            if (GMode == ASPConstant.ModeBrowse)
            {
                EditKdMGroup.Enabled = false;
                EditNmMGroup.Enabled = false;
                EditKdMManager.Enabled = false;
                EditNmMManager.Enabled = false;
                BtnBrowseManager.Enabled = false;
                CbAktif.Enabled = false;
                BtnNewAnggota.Enabled = false;
                BtnDeleteAnggota.Enabled = false;
            }
            else if (GMode == ASPConstant.ModeNew)
            {
                EditKdMGroup.Enabled = false;
                EditNmMGroup.Enabled = true;
                EditKdMManager.Enabled = true;
                EditNmMManager.Enabled = true;
                BtnBrowseManager.Enabled = true;
                CbAktif.Enabled = true;
                BtnNewAnggota.Enabled = true;
                BtnDeleteAnggota.Enabled = true;
            }
            else if (GMode == ASPConstant.ModeEdit)
            {
                EditKdMGroup.Enabled = false;
                EditNmMGroup.Enabled = true;
                EditKdMManager.Enabled = true;
                EditNmMManager.Enabled = true;
                BtnBrowseManager.Enabled = true;
                CbAktif.Enabled = true;
                BtnNewAnggota.Enabled = true;
                BtnDeleteAnggota.Enabled = true;
            }
            else if (GMode == ASPConstant.ModeDelete)
            {
                EditKdMGroup.Enabled = false;
                EditNmMGroup.Enabled = false;
                EditKdMManager.Enabled = false;
                EditNmMManager.Enabled = false;
                BtnBrowseManager.Enabled = false;
                CbAktif.Enabled = false;
                BtnNewAnggota.Enabled = false;
                BtnDeleteAnggota.Enabled = false;
            }
        }

        private void GenerateComboColumn()
        {
            ASPComboboxItem.GenerateComboboxColumn(ref CbColumns, ref dataGridViewInput);
            CbOrder.Items.Add("ASC");
            CbOrder.Items.Add("DESC");
            CbOrder.SelectedItem = "ASC";
        }

        private List<KeyValuePair<string, string>> GetCondition()
        {
            List<KeyValuePair<string, string>> Result = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)CbColumns.SelectedItem;

            if (!EditSearch.Text.Trim().Equals(""))
            {
                Result.Add(new KeyValuePair<string, string>(
                    "`" + selectedItem.Key + "`",
                    ASPCast.SQLStr("%" + EditSearch.Text.Trim() + "%")
                ));
            }

            Result.Add(new KeyValuePair<string, string>(
                   "`" + selectedItem.Key + "`",
                   CbOrder.SelectedItem.ToString()
            ));

            return Result;
        }

        private void GetTableGroup()
        {
            dataGridViewGroup.Rows.Clear();
            dataGridViewGroup.Refresh();
            string order = "ASC";
            List<KeyValuePair<string, string>> condition = new List<KeyValuePair<string, string>>();
            condition.Add(new KeyValuePair<string, string>("NmMGroup", "ASC"));
            MySqlDataReader dataReader = GDBMGroup.GetTable(condition);
            while (dataReader.Read())
            {
                dataGridViewGroup.Rows.Add(
                        dataReader.GetInt16("IdMKaryawan").ToString(),
                        dataReader.GetInt16("No").ToString(),
                        dataReader.GetString("KdMKaryawan"),
                        dataReader.GetString("NmMKaryawan"),
                        dataReader.GetInt16("IdMJabatan").ToString(),
                        dataReader.GetString("NmMJabatan"),
                        dataReader.GetString("Alamat"),
                        dataReader.GetString("NoHP"),
                        ASPCast.IntToBool(dataReader.GetInt16("Aktif"))
                );
            }
            GDBMKaryawan.aspQuery.MySqlConnect.CloseConnection();
        }

        private void GetTable()
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            MySqlDataReader dataReader = GDBMKaryawan.GetTable(GetCondition());
            while (dataReader.Read())
            {
                dataGridView.Rows.Add(
                        dataReader.GetInt16("IdMKaryawan").ToString(),
                        dataReader.GetInt16("No").ToString(),
                        dataReader.GetString("KdMKaryawan"),
                        dataReader.GetString("NmMKaryawan"),
                        dataReader.GetInt16("IdMJabatan").ToString(),
                        dataReader.GetString("NmMJabatan"),
                        dataReader.GetString("Alamat"),
                        dataReader.GetString("NoHP"),
                        ASPCast.IntToBool(dataReader.GetInt16("Aktif"))
                );
            }
            GDBMKaryawan.aspQuery.MySqlConnect.CloseConnection();
        }

        private void ASPMGroupForm_KeyDown(object sender, KeyEventArgs e)
        {
            base.EventNavigation(e);
        }
    }
}
