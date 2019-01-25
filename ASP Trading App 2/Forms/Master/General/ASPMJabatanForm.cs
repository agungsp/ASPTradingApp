using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ASP_Trading_App_2.CommonComponent;
using ASP_Trading_App_2.DataObject.Master.General;
using ASP_Trading_App_2.DBComm.Master.General;
using MySql.Data.MySqlClient;

namespace ASP_Trading_App_2.Forms.Master.General
{
    public partial class ASPMJabatanForm : ASP_Trading_App_2.BaseForms.MasterForm
    {
        private ASPMJabatan_DO GMJabatan;
        private ASPMJabatan_DBC GDBMJabatan;
        private int rowIndex = 0;


        public ASPMJabatanForm() : base()
        {
            InitializeComponent();
            Create();
            Initialize();
        }

        protected override void Create() 
        {
            base.Create();
            GMJabatan = new ASPMJabatan_DO();
            GDBMJabatan = new ASPMJabatan_DBC();
        }

        protected override void Initialize()
        {
            GTitleForm = "Master Jabatan";
            GMJabatan = GDBMJabatan.Clear();
            ShowData();
            GenerateComboColumn();
            GetTable();
            SetMode(ASPConstant.ModeBrowse);
            dataGridView.Focus();

            base.Initialize();
        }

        protected override void SetMode(int mode)
        {
            base.SetMode(mode);
            if (GMode == ASPConstant.ModeBrowse)
            {
                EditKdMJabatan.Enabled = false;
                EditNmMJabatan.Enabled = false;
                CbAktif.Enabled = false;
            }
            else if (GMode == ASPConstant.ModeNew)
            {
                EditKdMJabatan.Enabled = false;
                EditNmMJabatan.Enabled = true;
                CbAktif.Enabled = true;
            }
            else if (GMode == ASPConstant.ModeEdit)
            {
                EditKdMJabatan.Enabled = false;
                EditNmMJabatan.Enabled = true;
                CbAktif.Enabled = true;
            }
            else if (GMode == ASPConstant.ModeDelete)
            {
                EditKdMJabatan.Enabled = false;
                EditNmMJabatan.Enabled = false;
                CbAktif.Enabled = false;
            }
        }

        private void GenerateComboColumn()
        {
            ASPComboboxItem.GenerateComboboxColumn(ref CbColumns, ref dataGridView);
            CbOrder.SelectedItem = "ASC";
        }

        private List<KeyValuePair<string, string>> GetCondition()
        {
            List<KeyValuePair<string, string>> Result = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>) CbColumns.SelectedItem;

            if (!EditSearch.Text.Trim().Equals(""))
            {
                Result.Add(new KeyValuePair<string, string>(
                    "`" + selectedItem.Key + "`",
                    ASPCast.SQLStr("%"+EditSearch.Text.Trim()+"%")
                ));
            }

            Result.Add(new KeyValuePair<string, string>(
                   "`"+selectedItem.Key+"`",
                   CbOrder.SelectedItem.ToString()
            ));

            return Result;
        }

        private void GetTable()
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            MySqlDataReader dataReader = GDBMJabatan.GetTable(GetCondition());
            while (dataReader.Read())
            {
                dataGridView.Rows.Add(
                        dataReader.GetInt16("IdMJabatan").ToString(),
                        dataReader.GetInt16("No").ToString(),
                        dataReader.GetString("KdMJabatan"),
                        dataReader.GetString("NmMJabatan"),
                        ASPCast.IntToBool(dataReader.GetInt16("Aktif"))
                );
            }
            GDBMJabatan.aspQuery.MySqlConnect.CloseConnection();
        }

        protected void ShowData()
        {
            if (GMode == ASPConstant.ModeNew)
            {
                GMJabatan.KdMJabatan = GDBMJabatan.GetNewKode();
                GMJabatan.Aktif = true;
            }

            EditKdMJabatan.Text = GMJabatan.KdMJabatan;
            EditNmMJabatan.Text = GMJabatan.NmMJabatan;
            CbAktif.Checked = GMJabatan.Aktif;
        }

        protected override void LoadData()
        {
            if (GMode == ASPConstant.ModeNew)
            {
                GMJabatan.IdMJabatan = GDBMJabatan.GetNewId();
                GMJabatan.IdMUserCreate = MainForm.FMCurrUser.IdMKaryawan;
                GMJabatan.TglCreate = GDBMJabatan.GetNow();
            }

            GMJabatan.KdMJabatan = EditKdMJabatan.Text;
            GMJabatan.NmMJabatan = EditNmMJabatan.Text;
            GMJabatan.Aktif = CbAktif.Checked;
            GMJabatan.IdMUserUpdate = MainForm.FMCurrUser.IdMKaryawan;
            GMJabatan.TglUpdate = GDBMJabatan.GetNow();
        }

        protected override void NewRecord()
        {
            base.NewRecord();
            EditNmMJabatan.Focus();
            ShowData();
        }

        protected override void EditRecord()
        {
            if (GMode == ASPConstant.ModeBrowse && dataGridView.SelectedRows.Count > 0)
            {
                base.EditRecord();
                DataGridViewRow row = dataGridView.SelectedRows[0];
                if (!GDBMJabatan.SelectById(int.Parse(row.Cells["IdMJabatan"].Value.ToString()), ref GMJabatan))
                {
                    GMJabatan = GDBMJabatan.Clear();
                }
                ShowData();                
            }
            EditNmMJabatan.Focus();
        }

        protected override void DeleteRecord()
        {
            bool CanDelete = true;
            if (GMode == ASPConstant.ModeBrowse && dataGridView.SelectedRows.Count > 0)
            {
                base.DeleteRecord();
                DataGridViewRow row = dataGridView.SelectedRows[0];
                if (!GDBMJabatan.SelectById(int.Parse(row.Cells["IdMJabatan"].Value.ToString()), ref GMJabatan))
                {
                    GMJabatan = GDBMJabatan.Clear();
                    CanDelete = false;
                }

                if (CanDelete)
                {
                    if (ASPMsgCmp.QuestionMessage("Yakin ingin menghapus " + GMJabatan.NmMJabatan + "?") == DialogResult.Yes)
                    {
                        GMJabatan.IdMUserUpdate = MainForm.FMCurrUser.IdMKaryawan;
                        GMJabatan.TglUpdate = GDBMJabatan.GetNow();
                        GMJabatan.Hapus = true;

                        if (GDBMJabatan.Delete(GMJabatan))
                        {
                            ASPMsgCmp.InfoMessage("Data berhasil dihapus.");
                        }
                        else
                        {
                            ASPMsgCmp.ErrorMessage("Data gagal dihapus.");
                        }
                    }
                }

                GMJabatan = GDBMJabatan.Clear();
                ShowData();
                SetMode(ASPConstant.ModeBrowse);
                GetTable();
            } 
        }

        protected override void Cancel()
        {
            base.Cancel();
            GMJabatan = GDBMJabatan.Clear();
            ShowData();
            SetMode(ASPConstant.ModeBrowse);
        }

        protected override bool CekValidate()
        {
            bool Result = base.CekValidate();

            if (Result)
            {
                if (EditNmMJabatan.Text.Trim().Equals(""))
                {
                    ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_CANNOTNULL, "Nama Jabatan"));
                    Result = false;
                }
            }

            if (Result)
            {
                Result = (ASPMsgCmp.QuestionMessage(ASPMessage.cm_SAVE) == DialogResult.Yes);               
            }

            return Result;
        }

        protected override void Save()
        {
            LoadData();
            if (GMode == ASPConstant.ModeNew)
            {
                if (GDBMJabatan.Insert(GMJabatan))
                {
                    ASPMsgCmp.InfoMessage("Data berhasil disimpan.");
                }
                else
                {
                    ASPMsgCmp.ErrorMessage("Data gagal disimpan.");
                }
            }
            else if (GMode == ASPConstant.ModeEdit)
            {
                if (GDBMJabatan.Update(GMJabatan))
                {
                    ASPMsgCmp.InfoMessage("Data berhasil disimpan.");
                }
                else
                {
                    ASPMsgCmp.ErrorMessage("Data gagal disimpan.");
                }
            }
            GMJabatan = GDBMJabatan.Clear();
            ShowData();
            SetMode(ASPConstant.ModeBrowse);
            GetTable();
            dataGridView.Focus();
        }

        private void EditSearch_TextChanged(object sender, EventArgs e)
        {
            GetTable();
        }

        private void CbColumns_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTable();
        }

        private void CbOrder_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTable();
        }

        private void ASPMJabatanForm_KeyDown(object sender, KeyEventArgs e)
        {
            base.EventNavigation(e);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
    }
}
