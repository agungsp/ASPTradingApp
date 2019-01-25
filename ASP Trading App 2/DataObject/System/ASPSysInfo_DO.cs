using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DataObject.System
{
    public class ASPSysInfo_DO
    {
        private int _IdSysInfo;
        private string _AppVersion;
        private string _LocalLicenseCode;
        private string _GlobalLicenseCode;
        private string _TrialLicenseCode;
        private MySqlDateTime _TrialDateLimit;

        public int IdSysInfo { get => _IdSysInfo; set => _IdSysInfo = value; }
        public string AppVersion { get => _AppVersion; set => _AppVersion = value; }
        public string LocalLicenseCode { get => _LocalLicenseCode; set => _LocalLicenseCode = value; }
        public string GlobalLicenseCode { get => _GlobalLicenseCode; set => _GlobalLicenseCode = value; }
        public string TrialLicenseCode { get => _TrialLicenseCode; set => _TrialLicenseCode = value; }
        public MySqlDateTime TrialDateLimit { get => _TrialDateLimit; set => _TrialDateLimit = value; }
    }
}
