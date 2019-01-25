using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;

namespace ASP_Trading_App_2.DataObject.Master.General
{
    public class ASPMKaryawan_DO
    {
        private int _IdMKaryawan;
        private string _KdMKaryawan;
        private string _NmMKaryawan;
        private string _Alamat;
        private string _NoHP;
        private int _IdMJabatan;
        private bool _Aktif;
        private int _IdMUserCreate;
        private MySqlDateTime _TglCreate;
        private int _IdMUserUpdate;
        private MySqlDateTime _TglUpdate;
        private bool _Hapus;

        public int IdMKaryawan { get => _IdMKaryawan; set => _IdMKaryawan = value; }
        public string KdMKaryawan { get => _KdMKaryawan; set => _KdMKaryawan = value; }
        public string NmMKaryawan { get => _NmMKaryawan; set => _NmMKaryawan = value; }
        public string Alamat { get => _Alamat; set => _Alamat = value; }
        public string NoHP { get => _NoHP; set => _NoHP = value; }
        public int IdMJabatan { get => _IdMJabatan; set => _IdMJabatan = value; }
        public bool Aktif { get => _Aktif; set => _Aktif = value; }
        public int IdMUserCreate { get => _IdMUserCreate; set => _IdMUserCreate = value; }
        public MySqlDateTime TglCreate { get => _TglCreate; set => _TglCreate = value; }
        public int IdMUserUpdate { get => _IdMUserUpdate; set => _IdMUserUpdate = value; }
        public MySqlDateTime TglUpdate { get => _TglUpdate; set => _TglUpdate = value; }
        public bool Hapus { get => _Hapus; set => _Hapus = value; }
    }
}
