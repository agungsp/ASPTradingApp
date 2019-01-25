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
    public partial class ASPMKaryawanForm : ASP_Trading_App_2.BaseForms.MasterForm
    {
        private ASPMKaryawan_DO GMKaryawan;
        private ASPMKaryawan_DBC GDBMKaryawan;
        private ASPMJabatan_DO GMJabatan;
        private ASPMJabatan_DBC GDBMJabatan;

        public ASPMKaryawanForm() : base()
        {
            InitializeComponent();
            Create();
            Initialize();
        }

        protected override void Create()
        {
            base.Create();
            GMKaryawan = new ASPMKaryawan_DO();
            GDBMKaryawan = new ASPMKaryawan_DBC();
            GMJabatan = new ASPMJabatan_DO();
            GDBMJabatan = new ASPMJabatan_DBC();
        }

        protected override void Initialize()
        {
            GTitleForm = "Master Karyawan";
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
                EditKdMKaryawan.Enabled = false;
                EditNmMKaryawan.Enabled = false;
                EditAlamat.Enabled = false;
                EditNoHP.Enabled = false;
                EditKdMJabatan.Enabled = false;
                EditNmMJabatan.Enabled = false;
                BtnBrowseJabatan.Enabled = false;
                CbAktif.Enabled = false;
            }
            else if (GMode == ASPConstant.ModeNew)
            {
                EditKdMKaryawan.Enabled = false;
                EditNmMKaryawan.Enabled = true;
                EditAlamat.Enabled = true;
                EditNoHP.Enabled = true;
                EditKdMJabatan.Enabled = true;
                EditNmMJabatan.Enabled = true;
                BtnBrowseJabatan.Enabled = true;
                CbAktif.Enabled = true;
            }
            else if (GMode == ASPConstant.ModeEdit)
            {
                EditKdMKaryawan.Enabled = false;
                EditNmMKaryawan.Enabled = true;
                EditAlamat.Enabled = true;
                EditNoHP.Enabled = true;
                EditKdMJabatan.Enabled = true;
                EditNmMJabatan.Enabled = true;
                BtnBrowseJabatan.Enabled = true;
                CbAktif.Enabled = true;
            }
            else if (GMode == ASPConstant.ModeDelete)
            {
                EditKdMKaryawan.Enabled = false;
                EditNmMKaryawan.Enabled = false;
                EditAlamat.Enabled = false;
                EditNoHP.Enabled = false;
                EditKdMJabatan.Enabled = false;
                EditNmMJabatan.Enabled = false;
                BtnBrowseJabatan.Enabled = false;
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

        protected void ShowData()
        {
            if (GMode == ASPConstant.ModeNew)
            {
                GMKaryawan.KdMKaryawan = GDBMKaryawan.GetNewKode();
                GMKaryawan.Aktif = true;
            }

            EditKdMKaryawan.Text = GMKaryawan.KdMKaryawan;
            EditNmMKaryawan.Text = GMKaryawan.NmMKaryawan;
            EditAlamat.Text = GMKaryawan.Alamat;
            EditNoHP.Text = GMKaryawan.NoHP;

            if (!GDBMJabatan.SelectById(GMKaryawan.IdMJabatan, ref GMJabatan))
            {
                GMJabatan = GDBMJabatan.Clear();
            }
            ShowMJabatan(GMJabatan);

            CbAktif.Checked = GMKaryawan.Aktif;
        }

        private void ShowMJabatan(ASPMJabatan_DO MJabatan)
        {
            EditKdMJabatan.Text = MJabatan.KdMJabatan;
            EditNmMJabatan.Text = MJabatan.NmMJabatan;
        }

        protected override void LoadData()
        {
            if (GMode == ASPConstant.ModeNew)
            {
                GMKaryawan.IdMKaryawan = GDBMKaryawan.GetNewId();
                GMKaryawan.IdMUserCreate = MainForm.FMCurrUser.IdMKaryawan;
                GMKaryawan.TglCreate = GDBMJabatan.GetNow();
            }

            GMKaryawan.KdMKaryawan = EditKdMKaryawan.Text;
            GMKaryawan.NmMKaryawan = EditNmMKaryawan.Text;
            GMKaryawan.Alamat = EditAlamat.Text;
            GMKaryawan.NoHP = EditNoHP.Text;

            if (!GDBMJabatan.SelectByKode(EditKdMJabatan.Text.Trim(), ref GMJabatan))
            {
                GMJabatan = GDBMJabatan.Clear();
            }
            GMKaryawan.IdMJabatan = GMJabatan.IdMJabatan;

            GMKaryawan.Aktif = CbAktif.Checked;
            GMKaryawan.IdMUserUpdate = MainForm.FMCurrUser.IdMKaryawan;
            GMKaryawan.TglUpdate = GDBMJabatan.GetNow();
        }

        protected override void NewRecord()
        {
            base.NewRecord();
            EditNmMKaryawan.Focus();
            ShowData();
        }

        protected override void EditRecord()
        {
            if (GMode == ASPConstant.ModeBrowse && dataGridView.SelectedRows.Count > 0)
            {
                base.EditRecord();
                DataGridViewRow row = dataGridView.SelectedRows[0];
                if (!GDBMKaryawan.SelectById(int.Parse(row.Cells["IdMKaryawan"].Value.ToString()), ref GMKaryawan))
                {
                    GMKaryawan = GDBMKaryawan.Clear();
                }
                ShowData();
            }
            EditNmMKaryawan.Focus();
        }

        protected override void DeleteRecord()
        {
            bool CanDelete = true;
            if (GMode == ASPConstant.ModeBrowse && dataGridView.SelectedRows.Count > 0)
            {
                base.DeleteRecord();
                DataGridViewRow row = dataGridView.SelectedRows[0];
                if (!GDBMKaryawan.SelectById(int.Parse(row.Cells["IdMKaryawan"].Value.ToString()), ref GMKaryawan))
                {
                    GMKaryawan = GDBMKaryawan.Clear();
                    CanDelete = false;
                }

                if (CanDelete)
                {
                    if (ASPMsgCmp.QuestionMessage("Yakin ingin menghapus " + GMKaryawan.NmMKaryawan + "?") == DialogResult.Yes)
                    {
                        GMKaryawan.IdMUserUpdate = MainForm.FMCurrUser.IdMKaryawan;
                        GMKaryawan.TglUpdate = GDBMJabatan.GetNow();
                        GMKaryawan.Hapus = true;

                        if (GDBMKaryawan.Delete(GMKaryawan))
                        {
                            ASPMsgCmp.InfoMessage("Data berhasil dihapus.");
                        }
                        else
                        {
                            ASPMsgCmp.ErrorMessage("Data gagal dihapus.");
                        }
                    }
                }

                GMKaryawan = GDBMKaryawan.Clear();
                ShowData();
                SetMode(ASPConstant.ModeBrowse);
                GetTable();
            }
        }

        protected override void Cancel()
        {
            base.Cancel();
            GMKaryawan = GDBMKaryawan.Clear();
            ShowData();
            SetMode(ASPConstant.ModeBrowse);
        }

        protected override bool CekValidate()
        {
            bool Result = base.CekValidate();

            if (Result)
            {
                if (EditNmMKaryawan.Text.Trim().Equals(""))
                {
                    ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_CANNOTNULL, "Nama Karyawan"));
                    Result = false;
                }
            }

            if (Result)
            {
                if (EditAlamat.Text.Trim().Equals(""))
                {
                    ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_CANNOTNULL, "Alamat"));
                    Result = false;
                }
            }

            if (Result)
            {
                if (EditNoHP.Text.Trim().Equals(""))
                {
                    ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_CANNOTNULL, "No. HP"));
                    Result = false;
                }
            }

            if (Result)
            {
                if (GMJabatan.IdMJabatan == 0)
                {
                    ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_CANNOTNULL, "Jabatan"));
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
                if (GDBMKaryawan.Insert(GMKaryawan))
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
                if (GDBMKaryawan.Update(GMKaryawan))
                {
                    ASPMsgCmp.InfoMessage("Data berhasil disimpan.");
                }
                else
                {
                    ASPMsgCmp.ErrorMessage("Data gagal disimpan.");
                }
            }
            GMKaryawan = GDBMKaryawan.Clear();
            ShowData();
            SetMode(ASPConstant.ModeBrowse);
            GetTable();
            dataGridView.Focus();
        }

        protected override void Browse()
        {
            if (EditKdMJabatan.Focused)
            {
                FColumnSearch = "KdMJabatan";
                FValueSearch = EditKdMJabatan.Text.Trim();
                BrowseMJabatan();
            }
            else if (EditNmMJabatan.Focused)
            {
                FColumnSearch = "NmMJabatan";
                FValueSearch = EditNmMJabatan.Text.Trim();
                BrowseMJabatan();
            }
        }

        private void BrowseMJabatan()
        {
            GDBMJabatan.InitBrowse(FColumnSearch, FValueSearch);
            GDBMJabatan.BrowseForm.ShowDialog(this);
            if (GDBMJabatan.BrowseForm.Select)
            {
                if (!GDBMJabatan.SelectById(int.Parse(GDBMJabatan.BrowseForm.Result), ref GMJabatan))
                {
                    GMJabatan = GDBMJabatan.Clear();
                }
                ShowMJabatan(GMJabatan);
            }
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

        private void ASPMKaryawanForm_KeyDown(object sender, KeyEventArgs e)
        {
            base.EventNavigation(e);
        }

        private void EditKdMJabatan_Leave(object sender, EventArgs e)
        {
            if (!EditKdMJabatan.Text.Trim().Equals(""))
            {
                if (GMJabatan.IdMJabatan != 0)
                {
                    if (!GMJabatan.KdMJabatan.Equals(EditKdMJabatan.Text.Trim()))
                    {
                        if (!GDBMJabatan.SelectByKode(EditKdMJabatan.Text.Trim(), ref GMJabatan))
                        {
                            ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_NOTEXIST, "Kode Jabatan: ", EditKdMJabatan.Text.Trim()));
                            GMJabatan = GDBMJabatan.Clear();
                        }
                        ShowMJabatan(GMJabatan);
                    }
                }
                else
                {
                    if (!GDBMJabatan.SelectByKode(EditKdMJabatan.Text.Trim(), ref GMJabatan))
                    {
                        ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_NOTEXIST, "Kode Jabatan: ", EditKdMJabatan.Text.Trim()));
                        GMJabatan = GDBMJabatan.Clear();
                    }
                    ShowMJabatan(GMJabatan);
                }
            }
        }

        private void BtnBrowseJabatan_Click(object sender, EventArgs e)
        {
            FColumnSearch = "KdMJabatan";
            FValueSearch = "";
            BrowseMJabatan();
        }

        private void EditNmMJabatan_Leave(object sender, EventArgs e)
        {
            if (!EditNmMJabatan.Text.Trim().Equals(""))
            {
                if (GMJabatan.IdMJabatan != 0)
                {
                    if (!GMJabatan.NmMJabatan.Equals(EditNmMJabatan.Text.Trim()))
                    {
                        if (!GDBMJabatan.SelectByNama(EditNmMJabatan.Text.Trim(), ref GMJabatan))
                        {
                            ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_NOTEXIST, "Nama Jabatan: ", EditNmMJabatan.Text.Trim()));
                            GMJabatan = GDBMJabatan.Clear();
                        }
                        ShowMJabatan(GMJabatan);
                    }
                }
                else
                {
                    if (!GDBMJabatan.SelectByNama(EditNmMJabatan.Text.Trim(), ref GMJabatan))
                    {
                        ASPMsgCmp.WarningMessage(string.Format(ASPMessage.wm_NOTEXIST, "Nama Jabatan: ", EditNmMJabatan.Text.Trim()));
                        GMJabatan = GDBMJabatan.Clear();
                    }
                    ShowMJabatan(GMJabatan);
                }
            }
        }
    }
}
