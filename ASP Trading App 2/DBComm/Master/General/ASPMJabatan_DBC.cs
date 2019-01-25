using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASP_Trading_App_2.CommonComponent;
using ASP_Trading_App_2.CommonComponent.ASPBrowse;
using ASP_Trading_App_2.DBComponent;
using ASP_Trading_App_2.DataObject.Master.General;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DBComm.Master.General
{
    public class ASPMJabatan_DBC
    {
        public ASPQuery aspQuery;
        private const string TABLENAME = "ASPMJabatan";
        private const string FIELDNAME = "IdMJabatan, KdMJabatan, NmMJabatan, Aktif, IdMUserCreate, TglCreate, IdMUserUpdate, TglUpdate, Hapus";
        private const string HEADER = "JBT";
        private const int LENGTH = 3;
        public ASPBrowseForm BrowseForm;

        public ASPMJabatan_DBC()
        {
            aspQuery = new ASPQuery(TABLENAME);
        }

        public int GetNewId()
        {
            return aspQuery.GetNewId("IdMJabatan");
        }

        public string GetNewKode()
        {
            return ASPCommon.GenerateNewKode(HEADER, LENGTH, GetNewId());
        }

        public MySqlDateTime GetNow()
        {
            return aspQuery.DbDateNow();
        }

        public bool FindById(int Id)
        {
            string condition = "IdMJabatan = " + ASPCast.SQLIntToStr(Id);
            return aspQuery.Find(condition);
        }

        public bool FindByKode(String Kode)
        {
            String Condition = "KdMJabatan = " + ASPCast.SQLStr(Kode);
            return aspQuery.Find(Condition);
        }

        public bool SelectById(int Id, ref ASPMJabatan_DO MJabatan)
        {
            bool Result = false;
            string condition = " WHERE IdMJabatan = " + ASPCast.SQLIntToStr(Id);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MJabatan, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool SelectByKode(string Kode, ref ASPMJabatan_DO MJabatan)
        {
            bool Result = false;
            string condition = " WHERE KdMJabatan = " + ASPCast.SQLStr(Kode);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MJabatan, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool SelectByNama(string Nama, ref ASPMJabatan_DO MJabatan)
        {
            bool Result = false;
            string condition = " WHERE NmMJabatan = " + ASPCast.SQLStr(Nama);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MJabatan, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool Insert(ASPMJabatan_DO MJabatan)
        {
            string Values = ASPCast.SQLIntToStr(GetNewId()) + ", " +
                            ASPCast.SQLStr(MJabatan.KdMJabatan) + ", " +
                            ASPCast.SQLStr(MJabatan.NmMJabatan) + ", " +
                            ASPCast.SQLBoolToStr(MJabatan.Aktif) + ", " +
                            ASPCast.SQLIntToStr(MJabatan.IdMUserCreate) + ", " +
                            ASPCast.SQLDateTimeToStr(MJabatan.TglCreate) + ", " +
                            ASPCast.SQLIntToStr(MJabatan.IdMUserUpdate) + ", " +
                            ASPCast.SQLDateTimeToStr(MJabatan.TglUpdate) + ", " +
                            ASPCast.SQLBoolToStr(MJabatan.Hapus);

            string query = "INSERT INTO " + TABLENAME + " (" + FIELDNAME + ") VALUES (" + Values + ")";

            return aspQuery.ExecCUD(query);
        }

        public bool Update(ASPMJabatan_DO MJabatan)
        {
            string Values = "  KdMJabatan = " + ASPCast.SQLStr(MJabatan.KdMJabatan)
                            + ", NmMJabatan = " + ASPCast.SQLStr(MJabatan.NmMJabatan)
                            + ", Aktif = " + ASPCast.SQLBoolToStr(MJabatan.Aktif)
                            + ", IdMUserCreate = " + ASPCast.SQLIntToStr(MJabatan.IdMUserCreate)
                            + ", TglCreate = " + ASPCast.SQLDateTimeToStr(MJabatan.TglCreate)
                            + ", IdMUserUpdate = " + ASPCast.SQLIntToStr(MJabatan.IdMUserUpdate)
                            + ", TglUpdate = " + ASPCast.SQLDateTimeToStr(MJabatan.TglUpdate);

            string condition = " WHERE IdMJabatan = " + ASPCast.SQLIntToStr(MJabatan.IdMJabatan);

            string query = "UPDATE " + TABLENAME + " SET " + Values + condition;

            return aspQuery.ExecCUD(query);
        }

        public bool Delete(ASPMJabatan_DO MJabatan)
        {
            string Values = "IdMUserUpdate = " + MJabatan.IdMUserUpdate
                            + ", TglUpdate = " + MJabatan.TglUpdate
                            + ", Hapus = " + MJabatan.Hapus;

            string Condition = " WHERE IdMJabatan = " + ASPCast.SQLIntToStr(MJabatan.IdMJabatan);

            string Query = "UPDATE " + TABLENAME + " SET " + Values + Condition;

            return aspQuery.ExecCUD(Query);
        }

        public ASPMJabatan_DO Clear()
        {
            ASPMJabatan_DO MJabatan = new ASPMJabatan_DO();
            MJabatan.IdMJabatan = 0;
            MJabatan.KdMJabatan = "";
            MJabatan.NmMJabatan = "";
            MJabatan.Aktif = false;
            MJabatan.IdMUserCreate = 0;
            MJabatan.TglCreate = new MySqlDateTime();
            MJabatan.IdMUserUpdate = 0;
            MJabatan.TglUpdate = new MySqlDateTime();
            MJabatan.Hapus = false;

            return MJabatan;
        }

        public void CopyToObject(ref ASPMJabatan_DO MJabatan, MySqlDataReader data)
        {
            try
            {
                if (data.Read())
                {
                    MJabatan.IdMJabatan = data.GetInt16("IdMJabatan");
                    MJabatan.KdMJabatan = data.GetString("KdMJabatan");
                    MJabatan.NmMJabatan = data.GetString("NmMJabatan");
                    MJabatan.Aktif = ASPCast.IntToBool(data.GetInt16("Aktif"));
                    MJabatan.IdMUserCreate = data.GetInt16("IdMUserCreate");
                    MJabatan.TglCreate = data.GetMySqlDateTime("TglCreate");
                    MJabatan.IdMUserUpdate = data.GetInt16("IdMUserUpdate");
                    MJabatan.TglUpdate = data.GetMySqlDateTime("TglUpdate");
                    MJabatan.Hapus = ASPCast.IntToBool(data.GetInt16("Hapus"));
                }
            }
            catch (MySqlException ex)
            {
                ASPMsgCmp.WarningMessage(ex.Message);
            }
        }

        public MySqlDataReader GetTable(List<KeyValuePair<string, string>> condition)
        {
            MySqlDataReader data = null;
            string Condition = "";
            if (condition.Count > 1)
            {
                Condition = Condition + " AND " + condition[0].Key + " LIKE " + condition[0].Value;
                Condition = Condition + " ORDER BY " + condition[1].Key + " " + condition[1].Value;
            }
            else
            {
                Condition = Condition + " ORDER BY " + condition[0].Key + " " + condition[0].Value;
            }

            string Query = "SELECT * FROM (\n" +
                           "   SELECT (@NoUrut := @NoUrut+1) AS `No`, Tbl.* FROM (\n" + 
                           "      SELECT " + FIELDNAME + " FROM " + TABLENAME + "\n" + 
                           "   ) Tbl CROSS JOIN (SELECT @NoUrut:=0)testing\n" +
                           ") TblLuar WHERE `Hapus` = 0 " + Condition;
            if (!aspQuery.Select(Query, ref data))
            {
                ASPMsgCmp.ErrorMessage("Fail to read get data from Master Jabatan!");
            }
            return data;
        }

        public void InitBrowse(string columnSearch, string valueSearch)
        {
            BrowseForm = new ASPBrowseForm(TABLENAME);

            BrowseForm.ColumnSearch = columnSearch;
            BrowseForm.ValueSearch = valueSearch;
            BrowseForm.Query = "SELECT * FROM ASPMJabatan";

            BrowseForm.AddColumn("IdMJabatan", "IdMJabatan", -1, typeof(int), false);
            BrowseForm.AddColumn("KdMJabatan", "Kode", 50, typeof(string));
            BrowseForm.AddColumn("NmMJabatan", "Nama", 100, typeof(string));

            BrowseForm.FieldResult = "IdMJabatan";
            BrowseForm.FieldResult2 = "KdMJabatan";
            BrowseForm.FieldResult3 = "NmMJabatan";
        }
    }
}
