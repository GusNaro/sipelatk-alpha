using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Program
{
    class global
    {
        public const int id_type_admin = 1;
        public const int id_type_barang = 2;
        public const int id_type_inventaris = 3;
        public const int id_type_laporan = 4;

        public static string id;
        public static string id_nama;
        public static int id_type;

        //public static string conn_string = method.xml_server_load();
        public static string conn_string = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\data.mdf;Integrated Security=True;User Instance=True";
    }
}
