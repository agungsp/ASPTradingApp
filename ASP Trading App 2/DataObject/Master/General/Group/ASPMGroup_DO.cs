using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DataObject.Master.General.Group
{
    public class ASPMGroupD_DO
    {
        private int _IdMGroupD;
        private int _IdMGroup;
        private int _IdMAnggota;

        public int IdMGroupD { get => _IdMGroupD; set => _IdMGroupD = value; }
        public int IdMGroup { get => _IdMGroup; set => _IdMGroup = value; }
        public int IdMAnggota { get => _IdMAnggota; set => _IdMAnggota = value; }
    }

    public class ASPMGroup_DO
    {
        private int _IdMGroup;
        private string _KdMGroup;
        private string _NmMGroup;
        private int _IdMManager;
        private bool _Aktif;
        private int _IdMUserCreate;
        private MySqlDateTime _TglCreate;
        private int _IdMUserUpdate;
        private MySqlDateTime _TglUpdate;
        private bool _Hapus;

        public int IdMGroup { get => _IdMGroup; set => _IdMGroup = value; }
        public string KdMGroup { get => _KdMGroup; set => _KdMGroup = value; }
        public string NmMGroup { get => _NmMGroup; set => _NmMGroup = value; }
        public int IdMManager { get => _IdMManager; set => _IdMManager = value; }
        public bool Aktif { get => _Aktif; set => _Aktif = value; }
        public int IdMUserCreate { get => _IdMUserCreate; set => _IdMUserCreate = value; }
        public MySqlDateTime TglCreate { get => _TglCreate; set => _TglCreate = value; }
        public int IdMUserUpdate { get => _IdMUserUpdate; set => _IdMUserUpdate = value; }
        public MySqlDateTime TglUpdate { get => _TglUpdate; set => _TglUpdate = value; }
        public bool Hapus { get => _Hapus; set => _Hapus = value; }
    }
}
