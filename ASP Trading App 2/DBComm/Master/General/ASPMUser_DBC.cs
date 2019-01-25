using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASP_Trading_App_2.CommonComponent;
using ASP_Trading_App_2.DBComponent;
using ASP_Trading_App_2.DataObject.Master.General;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DBComm.Master.General
{
    public class ASPMUser_DBC
    {
        private ASPQuery aspQuery;
        private const string TABLENAME = "ASPMUser";
        private const string FIELDNAME = "IdMUser, Username, Password, IdMKaryawan, Aktif, IdMUserCreate, TglCreate, IdMUserUpdate, TglUpdate, Hapus";

        public ASPMUser_DBC()
        {
            aspQuery = new ASPQuery(TABLENAME);
        }

        public int GetNewId()
        {
            return aspQuery.GetNewId("IdMUser");
        }

        public bool FindById(int Id)
        {
            string condition = "IdMUser = " + ASPCast.SQLIntToStr(Id);
            return aspQuery.Find(condition);
        }

        public bool FindByUsername(String Username)
        {
            String Condition = "Username = " + ASPCast.SQLStr(Username);
            return aspQuery.Find(Condition);
        }

        public ASPMUser_DO SelectById(int Id)
        {
            ASPMUser_DO MUser = new ASPMUser_DO();
            string condition = " WHERE IdMUser = " + ASPCast.SQLIntToStr(Id);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                CopyToObject(ref MUser, data);
            }

            return MUser;
        }

        public ASPMUser_DO SelectByUsername(string Username)
        {
            ASPMUser_DO MUser = new ASPMUser_DO();
            string condition = " WHERE Username = " + ASPCast.SQLStr(Username);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                CopyToObject(ref MUser, data);
            }
            aspQuery.MySqlConnect.CloseConnection();
            return MUser;
        }

        public bool Insert(ASPMUser_DO MUser)
        {
            string Values = GetNewId().ToString() + ", " +
                            MUser.Username + ", " +
                            MUser.Password + ", " +
                            MUser.IdMKaryawan + ", " +
                            MUser.Aktif + ", " +
                            MUser.IdMUserCreate + ", " +
                            MUser.TglCreate + ", " +
                            MUser.IdMUserUpdate + ", " +
                            MUser.TglUpdate + ", " +
                            MUser.Hapus;

            string query = "INSERT INTO " + TABLENAME + " (" + FIELDNAME + ") VALUES (" + Values + ")";

            return aspQuery.ExecCUD(query);
        }

        public bool Update(ASPMUser_DO MUser)
        {
            string Values = "  Username = " + MUser.Username
                            + ", Password = " + MUser.Password
                            + ", IdMKaryawan = " + MUser.IdMKaryawan
                            + ", Aktif = " + MUser.Aktif
                            + ", IdMUserCreate = " + MUser.IdMUserCreate
                            + ", TglCreate = " + MUser.TglCreate
                            + ", IdMUserUpdate = " + MUser.IdMUserUpdate
                            + ", TglUpdate = " + MUser.TglUpdate;

            string condition = " WHERE IdMUser = " + MUser.IdMUser;

            string query = "UPDATE " + TABLENAME + " SET " + Values + condition;

            return aspQuery.ExecCUD(query);
        }

        public bool Delete(ASPMUser_DO MUser)
        {
            string Values = "IdMUserUpdate = " + MUser.IdMUserUpdate
                            + ", TglUpdate = " + MUser.TglUpdate
                            + ", Hapus = " + MUser.Hapus;

            string Condition = " WHERE IdMUser = " + MUser.IdMUser;

            string Query = "UPDATE " + TABLENAME + " SET " + Values + Condition;

            return aspQuery.ExecCUD(Query);
        }

        public ASPMUser_DO Clear()
        {
            ASPMUser_DO MUser = new ASPMUser_DO();
            MUser.IdMUser = 0;
            MUser.Username = "";
            MUser.Password = "";
            MUser.IdMKaryawan = 0;
            MUser.Aktif = false;
            MUser.IdMUserCreate = 0;
            MUser.TglCreate = new MySqlDateTime();
            MUser.IdMUserUpdate = 0;
            MUser.TglUpdate = new MySqlDateTime();
            MUser.Hapus = false;

            return MUser;
        }

        public void CopyToObject(ref ASPMUser_DO MUser, MySqlDataReader data)
        {
            try
            {
                if (data.Read())
                {
                    MUser.IdMUser = data.GetInt16("IdMUser");
                    MUser.Username = data.GetString("Username");
                    MUser.Password = data.GetString("Password");
                    MUser.IdMKaryawan = data.GetInt16("IdMKaryawan");
                    MUser.Aktif = ASPCast.IntToBool(data.GetInt16("Aktif"));
                    MUser.IdMUserCreate = data.GetInt16("IdMUserCreate");
                    MUser.TglCreate = data.GetMySqlDateTime("TglCreate");
                    MUser.IdMUserUpdate = data.GetInt16("IdMUserUpdate");
                    MUser.TglUpdate = data.GetMySqlDateTime("TglUpdate");
                    MUser.Hapus = ASPCast.IntToBool(data.GetInt16("Hapus"));
                }
            }
            catch (MySqlException ex)
            {
                ASPMsgCmp.WarningMessage(ex.Message);
            }
        }
    }
}
