using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ASP_Trading_App_2.CommonComponent;

namespace ASP_Trading_App_2.BaseForms
{
    public partial class MasterForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Private


        //Protected
        protected string GTitleForm = "Master Form";
        protected int GMode;
        protected string FQuery;
        protected string FColumnSearch = "";
        protected string FValueSearch = "";

        //Public


        public MasterForm()
        {
            InitializeComponent();
            //Create();
            //Initialize();
        }

        protected virtual void Create()
        {
            
            
        }

        protected virtual void Initialize()
        {
            GMode = ASPConstant.ModeBrowse;
            TitleForm.Text = GTitleForm;
            this.Text = GTitleForm;
        }

        private void HideButton(ref Button btn)
        {
            btn.Visible = btn.Enabled;
        }


        protected virtual void SetMode(int mode)
        {
            GMode = mode;
            if (GMode == ASPConstant.ModeBrowse)
            {
                BtnNew.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnExit.Enabled = true;
            }
            else if (GMode == ASPConstant.ModeNew)
            {
                BtnNew.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnExit.Enabled = false;
            }
            else if (GMode == ASPConstant.ModeEdit)
            {
                BtnNew.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnExit.Enabled = false;
            }
            else if (GMode == ASPConstant.ModeDelete)
            {
                BtnNew.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnExit.Enabled = false;
            }
            HideButton(ref BtnNew);
            HideButton(ref BtnEdit);
            HideButton(ref BtnDelete);
            HideButton(ref BtnSave);
            HideButton(ref BtnCancel);
            HideButton(ref BtnExit);
        }

        protected virtual void NewRecord()
        {
            SetMode(ASPConstant.ModeNew);
        }

        protected virtual void EditRecord()
        {
            SetMode(ASPConstant.ModeEdit);
        }

        protected virtual void DeleteRecord()
        {
            SetMode(ASPConstant.ModeDelete);
        }

        protected virtual void Cancel()
        {
            SetMode(ASPConstant.ModeBrowse);
        }

        protected virtual void Exit()
        {
            this.Close();
        }

        protected virtual void Save()
        {
            
        }

        protected virtual void LoadData()
        {
            
        }

        protected virtual bool CekValidate()
        {
            return true;
        }

        protected virtual void ShowData()
        {

        }

        protected virtual void Browse()
        {

        }
        
        protected virtual void EventNavigation(KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                if (GMode == ASPConstant.ModeBrowse)
                {
                    NewRecord();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                if (GMode == ASPConstant.ModeBrowse)
                {
                    EditRecord();
                }
            }
            if (e.KeyData == (Keys.Delete))
            {
                if (GMode == ASPConstant.ModeBrowse)
                {
                    DeleteRecord();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (GMode != ASPConstant.ModeBrowse && GMode != ASPConstant.ModeDelete)
                {
                    if (CekValidate())
                    {
                        Save();
                    }
                }
            }
            if (e.KeyData == (Keys.Escape))
            {
                if (GMode == ASPConstant.ModeBrowse)
                {
                    Exit();
                }
                else
                {
                    Cancel();
                }
            }
            if (e.KeyData == (Keys.Enter))
            {
                if (GMode != ASPConstant.ModeBrowse)
                {
                    Browse();
                }
            }
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {

        }

        private void MasterForm_KeyDown(object sender, KeyEventArgs e)
        {
            EventNavigation(e);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (GMode == ASPConstant.ModeBrowse)
            {
                NewRecord();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (GMode == ASPConstant.ModeBrowse)
            {
                EditRecord();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (GMode == ASPConstant.ModeBrowse)
            {
                DeleteRecord();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (GMode != ASPConstant.ModeBrowse && GMode != ASPConstant.ModeDelete)
            {
                if (CekValidate())
                {
                    Save();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (GMode != ASPConstant.ModeBrowse)
            {
                Cancel();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (GMode == ASPConstant.ModeBrowse)
            {
                Exit();
            }
        }

        private void TitleForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}