using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASP_Trading_App_2.DataObject.Master.General;
using ASP_Trading_App_2.DBComm.Master.General;
using ASP_Trading_App_2.CommonComponent;

namespace ASP_Trading_App_2
{
    public partial class LoginForm : Form
    {
        private ASPMUser_DO _FMCurrUser;
        private ASPMUser_DBC FDBMUser;
        private string Username;
        private string Password;

        public LoginForm()
        {
            InitializeComponent();

            Create();
            Initialize();
        }

        public ASPMUser_DO FMCurrUser { get => _FMCurrUser; set => _FMCurrUser = value; }

        private void Create()
        {
            FMCurrUser = new ASPMUser_DO();
            FDBMUser = new ASPMUser_DBC();
        }

        private void Initialize()
        {
            FMCurrUser = FDBMUser.Clear();
            Username = "";
            Password = "";
        }

        private void Autentication()
        {
            Username = EditUserName.Text;
            Password = EditPassword.Text;

            if (FDBMUser.FindByUsername(Username))
            {
                FMCurrUser = FDBMUser.SelectByUsername(Username);
                if (FMCurrUser.Username.Equals(Username))
                {
                    if (FMCurrUser.Password.Equals(Password))
                    {
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show(null, String.Format(ASPMessage.wm_ISWRONG, "Password"), ASPMessage.tm_ErrLogin, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(null, String.Format(ASPMessage.wm_ISWRONG, "Username"), ASPMessage.tm_ErrLogin, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(null, String.Format(ASPMessage.wm_NOTEXIST, "Username"), ASPMessage.tm_ErrLogin, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormValidate()
        {
            bool Result = true;

            if (Result)
            {
                if (EditUserName.Text.Trim().Equals(""))
                {
                    MessageBox.Show(null, String.Format(ASPMessage.wm_CANNOTNULL, "Username"), ASPMessage.tm_FormValidation, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Result = false;
                }
            }

            if (Result)
            {
                if (EditPassword.Text.Trim().Equals(""))
                {
                    MessageBox.Show(null, String.Format(ASPMessage.wm_CANNOTNULL, "Password"), ASPMessage.tm_FormValidation, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Result = false;
                }
            }

            if (Result)
            {
                Autentication();
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            FormValidate();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = EditUserName;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormValidate();
            }
        }
    }
}
