using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ASP_Trading_App_2.CommonComponent;

namespace ASP_Trading_App_2.DBComponent
{
    public class DBConnection
    {
        public MySqlConnection connection;
        private bool isOpen;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private DatabaseSetting dbSettingForm;
        private INIFile iniFile;

        public bool IsOpen { get => isOpen; set => isOpen = value; }

        public DBConnection()
        {
            dbSettingForm = new DatabaseSetting();
            iniFile = new INIFile(System.IO.Directory.GetCurrentDirectory()+ "\\dbConfig.ini");
            Initialize();
        }

        public bool CekKoneksi()
        {
            return (connection != null);
        }

        private void Initialize()
        {
            LoadFile();
        }

        private void LoadFile()
        {
            //server = iniFile.Read("dbConfig", "Host");
            //database = iniFile.Read("dbConfig", "DBName");
            //user = iniFile.Read("dbConfig", "UserId");
            //password = iniFile.Read("dbConfig", "Password");
            //port = iniFile.Read("dbConfig", "Port");
            server = "localhost";
            database = "asp_trading";
            user = "root";
            password = "";
            port = "3306";
            IsOpen = false;

            string connectionStr;
            connectionStr = "SERVER=" + server + ";PORT=" + port + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + password + ";Allow User Variables=True;Convert Zero Datetime=True;";
            connection = new MySqlConnection(connectionStr);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                IsOpen = true;
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        if (ASPMsgCmp.QuestionMessage("Tidak bisa terhubung dengan Server. Lakukan pengaturan database?") == DialogResult.Yes)
                        {
                            dbSettingForm.ShowDialog();
                            if (dbSettingForm.Save)
                            {
                                LoadFile();
                                OpenConnection();
                            }
                        }
                        else
                        {
                            Application.Exit();
                        }
                        break;

                    case 1042:
                        if (ASPMsgCmp.QuestionMessage("Tidak bisa terhubung dengan Server. Lakukan pengaturan database?") == DialogResult.Yes)
                        {
                            dbSettingForm.ShowDialog();
                            if (dbSettingForm.Save)
                            {
                                LoadFile();
                                OpenConnection();
                            }
                        }
                        else
                        {
                            Application.Exit();
                        }
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                IsOpen = false;
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
