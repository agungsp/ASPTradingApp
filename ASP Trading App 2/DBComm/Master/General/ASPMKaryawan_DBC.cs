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
    public class ASPMKaryawan_DBC
    {
        public ASPQuery aspQuery;
        private const string TABLENAME = "ASPMKaryawan";
        private const string FIELDNAME = "IdMKaryawan, KdMKaryawan, NmMKaryawan, Alamat, NoHP, IdMJabatan, Aktif, IdMUserCreate, TglCreate, IdMUserUpdate, TglUpdate, Hapus";
        private const string HEADER = "KRY";
        private const int LENGTH = 7;

        public ASPMKaryawan_DBC()
        {
            aspQuery = new ASPQuery(TABLENAME);
        }

        public int GetNewId()
        {
            return aspQuery.GetNewId("IdMKaryawan");
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
            string condition = "IdMKaryawan = " + ASPCast.SQLIntToStr(Id);
            return aspQuery.Find(condition);
        }

        public bool FindByKode(String Kode)
        {
            String Condition = "KdMKaryawan = " + ASPCast.SQLStr(Kode);
            return aspQuery.Find(Condition);
        }

        public bool SelectById(int Id, ref ASPMKaryawan_DO MKaryawan)
        {
            bool Result = false;
            string condition = " WHERE IdMKaryawan = " + ASPCast.SQLIntToStr(Id);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MKaryawan, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool SelectByKode(string Kode, ref ASPMKaryawan_DO MKaryawan)
        {
            bool Result = false;
            string condition = " WHERE KdMKaryawan = " + ASPCast.SQLStr(Kode);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                if (data.HasRows)
                {
                    CopyToObject(ref MKaryawan, data);
                    Result = true;
                }
            }
            aspQuery.MySqlConnect.CloseConnection();
            return Result;
        }

        public bool Insert(ASPMKaryawan_DO MKaryawan)
        {
            string Values = ASPCast.SQLIntToStr(GetNewId()) + ", " +
                            ASPCast.SQLStr(MKaryawan.KdMKaryawan) + ", " +
                            ASPCast.SQLStr(MKaryawan.NmMKaryawan) + ", " +
                            ASPCast.SQLStr(MKaryawan.Alamat) + ", " +
                            ASPCast.SQLStr(MKaryawan.NoHP) + ", " +
                            ASPCast.SQLIntToStr(MKaryawan.IdMJabatan) + ", " +
                            ASPCast.SQLBoolToStr(MKaryawan.Aktif) + ", " +
                            ASPCast.SQLIntToStr(MKaryawan.IdMUserCreate) + ", " +
                            ASPCast.SQLDateTimeToStr(MKaryawan.TglCreate) + ", " +
                            ASPCast.SQLIntToStr(MKaryawan.IdMUserUpdate) + ", " +
                            ASPCast.SQLDateTimeToStr(MKaryawan.TglUpdate) + ", " +
                            ASPCast.SQLBoolToStr(MKaryawan.Hapus);

            string query = "INSERT INTO " + TABLENAME + " (" + FIELDNAME + ") VALUES (" + Values + ")";

            return aspQuery.ExecCUD(query);
        }

        public bool Update(ASPMKaryawan_DO MKaryawan)
        {
            string Values = "  KdMKaryawan = " + ASPCast.SQLStr(MKaryawan.KdMKaryawan)
                            + ", NmMKaryawan = " + ASPCast.SQLStr(MKaryawan.NmMKaryawan)
                            + ", Alamat = " + ASPCast.SQLStr(MKaryawan.Alamat)
                            + ", NoHP = " + ASPCast.SQLStr(MKaryawan.NoHP)
                            + ", IdMJabatan = " + ASPCast.SQLIntToStr(MKaryawan.IdMJabatan)
                            + ", Aktif = " + ASPCast.SQLBoolToStr(MKaryawan.Aktif)
                            + ", IdMUserCreate = " + ASPCast.SQLIntToStr(MKaryawan.IdMUserCreate)
                            + ", TglCreate = " + ASPCast.SQLDateTimeToStr(MKaryawan.TglCreate)
                            + ", IdMUserUpdate = " + ASPCast.SQLIntToStr(MKaryawan.IdMUserUpdate)
                            + ", TglUpdate = " + ASPCast.SQLDateTimeToStr(MKaryawan.TglUpdate);

            string condition = " WHERE IdMKaryawan = " + ASPCast.SQLIntToStr(MKaryawan.IdMKaryawan);

            string query = "UPDATE " + TABLENAME + " SET " + Values + condition;

            return aspQuery.ExecCUD(query);
        }

        public bool Delete(ASPMKaryawan_DO MKaryawan)
        {
            string Values = "IdMUserUpdate = " + ASPCast.SQLIntToStr(MKaryawan.IdMUserUpdate)
                            + ", TglUpdate = " + ASPCast.SQLDateTimeToStr(MKaryawan.TglUpdate)
                            + ", Hapus = " + ASPCast.SQLBoolToStr(MKaryawan.Hapus);

            string Condition = " WHERE IdMKaryawan = " + ASPCast.SQLIntToStr(MKaryawan.IdMKaryawan);

            string Query = "UPDATE " + TABLENAME + " SET " + Values + Condition;

            return aspQuery.ExecCUD(Query);
        }

        public ASPMKaryawan_DO Clear()
        {
            ASPMKaryawan_DO MKaryawan = new ASPMKaryawan_DO();
            MKaryawan.IdMKaryawan = 0;
            MKaryawan.KdMKaryawan = "";
            MKaryawan.NmMKaryawan = "";
            MKaryawan.Alamat = "";
            MKaryawan.NoHP = "";
            MKaryawan.IdMJabatan = 0;
            MKaryawan.Aktif = false;
            MKaryawan.IdMUserCreate = 0;
            MKaryawan.TglCreate = new MySqlDateTime();
            MKaryawan.IdMUserUpdate = 0;
            MKaryawan.TglUpdate = new MySqlDateTime();
            MKaryawan.Hapus = false;

            return MKaryawan;
        }

        public void CopyToObject(ref ASPMKaryawan_DO MKaryawan, MySqlDataReader data)
        {
            try
            {
                if (data.Read())
                {
                    MKaryawan.IdMKaryawan = data.GetInt16("IdMKaryawan");
                    MKaryawan.KdMKaryawan = data.GetString("KdMKaryawan");
                    MKaryawan.NmMKaryawan = data.GetString("NmMKaryawan");
                    MKaryawan.Alamat = data.GetString("Alamat");
                    MKaryawan.NoHP = data.GetString("NoHP");
                    MKaryawan.IdMJabatan = data.GetInt16("IdMJabatan");
                    MKaryawan.Aktif = ASPCast.IntToBool(data.GetInt16("Aktif"));
                    MKaryawan.IdMUserCreate = data.GetInt16("IdMUserCreate");
                    MKaryawan.TglCreate = data.GetMySqlDateTime("TglCreate");
                    MKaryawan.IdMUserUpdate = data.GetInt16("IdMUserUpdate");
                    MKaryawan.TglUpdate = data.GetMySqlDateTime("TglUpdate");
                    MKaryawan.Hapus = ASPCast.IntToBool(data.GetInt16("Hapus"));
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
                           "      SELECT m.*, mJabatan.NmMJabatan FROM " + TABLENAME + " m\n" +
                           "      LEFT OUTER JOIN ASPMJabatan mJabatan ON (m.IdMJabatan = mJabatan.IdMJabatan)\n" + 
                           "   ) Tbl CROSS JOIN (SELECT @NoUrut:=0)testing\n" +
                           ") TblLuar WHERE `Hapus` = 0 " + Condition;
            if (!aspQuery.Select(Query, ref data))
            {
                ASPMsgCmp.ErrorMessage("Fail to read get data from Master Karyawan!");
            }
            return data;
        }
    }
}
