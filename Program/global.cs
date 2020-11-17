using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static string conn_string = "server=localhost;port=3306;database=barang;user=drakorea;password=lol123!";
    }
}
