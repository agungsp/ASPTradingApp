using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DataObject.Master.General
{
    public class ASPMUser_DO
    {
        private int _IdMUser;
        private string _Username;
        private string _Password;
        private int _IdMKaryawan;
        private bool _Aktif;
        private int _IdMUserCreate;
        private MySqlDateTime _TglCreate;
        private int _IdMUserUpdate;
        private MySqlDateTime _TglUpdate;
        private bool _Hapus;

        public int IdMUser { get => _IdMUser; set => _IdMUser = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
        public int IdMKaryawan { get => _IdMKaryawan; set => _IdMKaryawan = value; }
        public bool Aktif { get => _Aktif; set => _Aktif = value; }
        public int IdMUserCreate { get => _IdMUserCreate; set => _IdMUserCreate = value; }
        public MySqlDateTime TglCreate { get => _TglCreate; set => _TglCreate = value; }
        public int IdMUserUpdate { get => _IdMUserUpdate; set => _IdMUserUpdate = value; }
        public MySqlDateTime TglUpdate { get => _TglUpdate; set => _TglUpdate = value; }
        public bool Hapus { get => _Hapus; set => _Hapus = value; }
    }
}
