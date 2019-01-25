using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DataObject.Master.General
{
    public class ASPMJabatan_DO
    {
        private int _IdMJabatan;
        private string _KdMJabatan;
        private string _NmMJabatan;
        private bool _Aktif;
        private int _IdMUserCreate;
        private MySqlDateTime _TglCreate;
        private int _IdMUserUpdate;
        private MySqlDateTime _TglUpdate;
        private bool _Hapus;

        public int IdMJabatan { get => _IdMJabatan; set => _IdMJabatan = value; }
        public string KdMJabatan { get => _KdMJabatan; set => _KdMJabatan = value; }
        public string NmMJabatan { get => _NmMJabatan; set => _NmMJabatan = value; }
        public bool Aktif { get => _Aktif; set => _Aktif = value; }
        public int IdMUserCreate { get => _IdMUserCreate; set => _IdMUserCreate = value; }
        public MySqlDateTime TglCreate { get => _TglCreate; set => _TglCreate = value; }
        public int IdMUserUpdate { get => _IdMUserUpdate; set => _IdMUserUpdate = value; }
        public MySqlDateTime TglUpdate { get => _TglUpdate; set => _TglUpdate = value; }
        public bool Hapus { get => _Hapus; set => _Hapus = value; }
    }
}
