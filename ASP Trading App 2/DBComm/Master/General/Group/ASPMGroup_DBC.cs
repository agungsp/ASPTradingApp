using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using ASP_Trading_App_2.DBComponent;
using ASP_Trading_App_2.CommonComponent;
using ASP_Trading_App_2.CommonComponent;
using ASP_Trading_App_2.CommonComponent.ASPBrowse;
using ASP_Trading_App_2.DBComm.Master.General;
using ASP_Trading_App_2.DataObject.Master.General;
using ASP_Trading_App_2.DBComm.Master.General.Group;
using ASP_Trading_App_2.DataObject.Master.General.Group;

namespace ASP_Trading_App_2.DBComm.Master.General.Group
{
    class ASPMGroupD_DBC
    {
        private ASPQuery aspQueryD;
        private const string TABLENAMED = "ASPMGroupD";
        private const string FIELDNAMED = "IdMGroupD, IdMGroup, IdMAnggota";

        public ASPMGroupD_DBC()
        {
            aspQueryD = new ASPQuery(TABLENAMED);
        }

        public int GetNewIdD()
        {
            return aspQueryD.GetNewId("IdMGroupD");
        }

        public ASPMGroupD_DO Clear()
        {
            ASPMGroupD_DO MGroupD = new ASPMGroupD_DO();

            MGroupD.IdMGroupD = 0;
            MGroupD.IdMGroup = 0;
            MGroupD.IdMAnggota = 0;

            return MGroupD;
        }

        private void CreateValues(ref string values, List<ASPMGroupD_DO> MGroupD)
        {
            values = values + "(";
            for (int i = 0; i < MGroupD.Count; i++)
            {
                values = values + ASPCast.SQLIntToStr(MGroupD[i].IdMGroupD)
                         + ", " + ASPCast.SQLIntToStr(MGroupD[i].IdMGroup)
                         + ", " + ASPCast.SQLIntToStr(MGroupD[i].IdMAnggota);
                if (i != MGroupD.Count -1)
                {
                    values = values + "), (";
                }
            }
            values = values + ")";
        }

        public bool Insert(List<ASPMGroupD_DO> MGroupD)
        {
            string Values = "";

            CreateValues(ref Values, MGroupD);
            string Query = "INSERT INTO " + TABLENAMED + " (" + FIELDNAMED + ") VALUES " + Values;

            return aspQueryD.ExecCUD(Query);
        }

        public bool Delete(int Id)
        {
            string Query = "DELETE FROM " + TABLENAMED + " WHERE IdMGroup = " + ASPCast.SQLIntToStr(Id);
            return aspQueryD.ExecCUD(Query);
        }
    }

    public class ASPMGroup_DBC
    {
        public ASPQuery aspQuery;
        private const string TABLENAME = "ASPMGroup";
        private const string FIELDNAME = "IdMGroup, KdMGroup, NmMGroup, IdMManager, Aktif, IdMUserCreate, TglCreate, IdMUserUpdate, TglUpdate, Hapus";
        private const string HEADER = "GRP";
        private const int LENGTH = 3;
        public ASPBrowseForm BrowseForm;
        private ASPMGroupD_DBC GGroupD_DBC;

        public ASPMGroup_DBC()
        {
            aspQuery = new ASPQuery(TABLENAME);
            GGroupD_DBC = new ASPMGroupD_DBC();
        }

        public int GetNewId()
        {
            return aspQuery.GetNewId("IdMGroup");
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
            string condition = "IdMGroup = " + ASPCast.SQLIntToStr(Id);
            return aspQuery.Find(condition);
        }

        public bool FindByKode(String Kode)
        {
            String Condition = "KdMGroup = " + ASPCast.SQLStr(Kode);
            return aspQuery.Find(Condition);
        }

        public bool SelectById(int Id, ref ASPMGroup_DO MGroup)
        {
            bool Result = false;
            string condition = " WHERE IdMGroup = " + ASPCast.SQLIntToStr(Id);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MGroup, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool SelectByKode(string Kode, ref ASPMGroup_DO MGroup)
        {
            bool Result = false;
            string condition = " WHERE KdMGroup = " + ASPCast.SQLStr(Kode);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MGroup, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool SelectByNama(string Nama, ref ASPMGroup_DO MGroup)
        {
            bool Result = false;
            string condition = " WHERE NmMGroup = " + ASPCast.SQLStr(Nama);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MGroup, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool Insert(ASPMGroup_DO MGroup, List<ASPMGroupD_DO> MGroupD)
        {
            bool Result = true;
            string Values = ASPCast.SQLIntToStr(GetNewId()) + ", " +
                            ASPCast.SQLStr(MGroup.KdMGroup) + ", " +
                            ASPCast.SQLStr(MGroup.NmMGroup) + ", " +
                            ASPCast.SQLIntToStr(MGroup.IdMManager) + ", " +
                            ASPCast.SQLBoolToStr(MGroup.Aktif) + ", " +
                            ASPCast.SQLIntToStr(MGroup.IdMUserCreate) + ", " +
                            ASPCast.SQLDateTimeToStr(MGroup.TglCreate) + ", " +
                            ASPCast.SQLIntToStr(MGroup.IdMUserUpdate) + ", " +
                            ASPCast.SQLDateTimeToStr(MGroup.TglUpdate) + ", " +
                            ASPCast.SQLBoolToStr(MGroup.Hapus);

            string query = "INSERT INTO " + TABLENAME + " (" + FIELDNAME + ") VALUES (" + Values + ")";

            if (Result)
            {
                Result = GGroupD_DBC.Insert(MGroupD);
            }

            if (Result)
            {
                Result = aspQuery.ExecCUD(query);
            }

            return Result;
        }

        public bool Update(ASPMGroup_DO MGroup, List<ASPMGroupD_DO> MGroupD)
        {
            bool Result = true;
            string Values = "  KdMGroup = " + ASPCast.SQLStr(MGroup.KdMGroup)
                            + ", NmMGroup = " + ASPCast.SQLStr(MGroup.NmMGroup)
                            + ", IdMManager = " + ASPCast.SQLIntToStr(MGroup.IdMManager)
                            + ", Aktif = " + ASPCast.SQLBoolToStr(MGroup.Aktif)
                            + ", IdMUserCreate = " + ASPCast.SQLIntToStr(MGroup.IdMUserCreate)
                            + ", TglCreate = " + ASPCast.SQLDateTimeToStr(MGroup.TglCreate)
                            + ", IdMUserUpdate = " + ASPCast.SQLIntToStr(MGroup.IdMUserUpdate)
                            + ", TglUpdate = " + ASPCast.SQLDateTimeToStr(MGroup.TglUpdate);

            string condition = " WHERE IdMGroup = " + ASPCast.SQLIntToStr(MGroup.IdMGroup);

            string query = "UPDATE " + TABLENAME + " SET " + Values + condition;

            if (Result)
            {
                Result = GGroupD_DBC.Delete(MGroup.IdMGroup);
            }

            if (Result)
            {
                Result = GGroupD_DBC.Insert(MGroupD);
            }

            if (Result)
            {
                Result = aspQuery.ExecCUD(query);
            }

            return Result;
        }

        public bool Delete(ASPMGroup_DO MGroup)
        {
            string Values = "IdMUserUpdate = " + MGroup.IdMUserUpdate
                            + ", TglUpdate = " + MGroup.TglUpdate
                            + ", Hapus = " + MGroup.Hapus;

            string Condition = " WHERE IdMGroup = " + ASPCast.SQLIntToStr(MGroup.IdMGroup);

            string Query = "UPDATE " + TABLENAME + " SET " + Values + Condition;

            return aspQuery.ExecCUD(Query);
        }

        public ASPMGroup_DO Clear()
        {
            ASPMGroup_DO MGroup = new ASPMGroup_DO();
            MGroup.IdMGroup = 0;
            MGroup.KdMGroup = "";
            MGroup.NmMGroup = "";
            MGroup.IdMManager = 0;
            MGroup.Aktif = false;
            MGroup.IdMUserCreate = 0;
            MGroup.TglCreate = new MySqlDateTime();
            MGroup.IdMUserUpdate = 0;
            MGroup.TglUpdate = new MySqlDateTime();
            MGroup.Hapus = false;

            return MGroup;
        }

        public void CopyToObject(ref ASPMGroup_DO MGroup, MySqlDataReader data)
        {
            try
            {
                if (data.Read())
                {
                    MGroup.IdMGroup = data.GetInt16("IdMGroup");
                    MGroup.KdMGroup = data.GetString("KdMGroup");
                    MGroup.NmMGroup = data.GetString("NmMGroup");
                    MGroup.IdMManager = data.GetInt16("IdMManager");
                    MGroup.Aktif = ASPCast.IntToBool(data.GetInt16("Aktif"));
                    MGroup.IdMUserCreate = data.GetInt16("IdMUserCreate");
                    MGroup.TglCreate = data.GetMySqlDateTime("TglCreate");
                    MGroup.IdMUserUpdate = data.GetInt16("IdMUserUpdate");
                    MGroup.TglUpdate = data.GetMySqlDateTime("TglUpdate");
                    MGroup.Hapus = ASPCast.IntToBool(data.GetInt16("Hapus"));
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
                ASPMsgCmp.ErrorMessage("Fail to read get data from Master Group!");
            }
            return data;
        }

        public void InitBrowse(string columnSearch, string valueSearch)
        {
            BrowseForm = new ASPBrowseForm(TABLENAME);

            BrowseForm.ColumnSearch = columnSearch;
            BrowseForm.ValueSearch = valueSearch;
            BrowseForm.Query = "SELECT * FROM ASPMGroup";

            BrowseForm.AddColumn("IdMGroup", "IdMGroup", -1, typeof(int), false);
            BrowseForm.AddColumn("KdMGroup", "Kode", 50, typeof(string));
            BrowseForm.AddColumn("NmMGroup", "Nama", 100, typeof(string));

            BrowseForm.FieldResult = "IdMGroup";
            BrowseForm.FieldResult2 = "KdMGroup";
            BrowseForm.FieldResult3 = "NmMGroup";
        }
    }
}
