using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASP_Trading_App_2.CommonComponent;
using ASP_Trading_App_2.DBComponent;
using ASP_Trading_App_2.DataObject.System;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DBComm.System
{
    public class ASPSysInfo_DBC
    {
        private ASPQuery aspQuery;
        private const string TABLENAME = "ASPSysInfo";
        private const string FIELDNAME = "IdSysInfo, AppVersion, LocalLicenseCode, GlobalLicenseCode, TrialLicenseCode, TrialDateLimit";

        public ASPSysInfo_DBC()
        {
            aspQuery = new ASPQuery(TABLENAME);
        }

        public bool SelectById(int Id, ref ASPSysInfo_DO SysInfo)
        {
            bool Result = true;
            string condition = " WHERE IdSysInfo = " + ASPCast.SQLIntToStr(Id);
            string query = "SELECT " + FIELDNAME + " FROM " + TABLENAME + condition;
            MySqlDataReader data = null;

            if (aspQuery.Select(query, ref data))
            {
                CopyToObject(ref SysInfo, data);
            }
            else
            {
                Result = false;
            }

            return Result;
        }

        public ASPSysInfo_DO Clear()
        {
            ASPSysInfo_DO SysInfo = new ASPSysInfo_DO();
            SysInfo.IdSysInfo = 0;
            SysInfo.AppVersion = "";
            SysInfo.LocalLicenseCode = "";
            SysInfo.GlobalLicenseCode = "";
            SysInfo.TrialLicenseCode = "";
            SysInfo.TrialDateLimit = new MySqlDateTime();

            return SysInfo;
        }

        public void CopyToObject(ref ASPSysInfo_DO SysInfo, MySqlDataReader data)
        {
            try
            {
                //if (data.Read())
                //{
                //    SysInfo.IdSysInfo = data.GetInt16("IdSysInfo");
                //    SysInfo.AppVersion = data.GetString("AppVersion");
                //    SysInfo.LocalLicenseCode = data.GetString("LocalLicenseCode");
                //    SysInfo.GlobalLicenseCode = data.GetString("GlobalLicenseCode");
                //    SysInfo.TrialLicenseCode = data.("TrialLicenseCode");
                //    SysInfo.TrialDateLimit = data.GetMySqlDateTime("TrialDateLimit");
                //}
            }
            catch (MySqlException ex)
            {
                ASPMsgCmp.WarningMessage(ex.Message);
            }
        }
    }
}
