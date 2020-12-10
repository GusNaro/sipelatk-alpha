using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Program
{
    class method
    {
        public static void tampilkan_button()
        {
            bool[] value = { true, true, false, false, false, true };
            string[] nama = { "BERANDA", "LOGIN", "", "", "", "KELUAR" };

            switch (global.id_type)
            {
                case global.id_type_admin:
                    value = new bool[] { true, true, true, true, true, true };
                    nama = new string[] { "BERANDA", "USER", "BARANG", "INVENTARIS", "LAPORAN", "KELUAR" };
                    break;
                case global.id_type_barang:
                    value = new bool[] { true, true, true, true, false, true };
                    nama = new string[] { "BERANDA", "BARANG", "INVENTARIS", "LAPORAN", "", "KELUAR" };
                    break;
                case global.id_type_inventaris:
                    value = new bool[] { true, true, true, false, false, true };
                    nama = new string[] { "BERANDA", "INVENTARIS", "LAPORAN", "", "", "KELUAR" };
                    break;
                case global.id_type_laporan:
                    value = new bool[] { true, true, false, false, false, true };
                    nama = new string[] { "BERANDA", "LAPORAN", "", "", "", "KELUAR" };
                    break;
            }

            form_app.app.button(value, nama);
        }

        #region XML SERVER

        private static XmlSerializer xs = new XmlSerializer(typeof(List<server>));

        public static string xml_server_load()
        {
            FileStream fs = new FileStream("server.dat", FileMode.Open, FileAccess.Read);
            List<server> ls_server = (List<server>)xs.Deserialize(fs);
            string cmd = @"server=" + ls_server[0].sql_svr + ";port=" + ls_server[0].sql_prt + ";database=" + ls_server[0].sql_db + ";user=" + ls_server[0].sql_id + ";password=" + ls_server[0].sql_pw;
            fs.Close();
            return cmd;
        }

        public static void xml_server_write(string server, string port, string db, string user, string pass)
        {
            FileStream fs = new FileStream("server.dat", FileMode.Create, FileAccess.Write);
            server dt_server = new server { sql_svr = server, sql_prt = port, sql_db = db, sql_id = user, sql_pw = pass };
            List<server> ls_server = new List<server>();
            ls_server.Add(dt_server);
            xs.Serialize(fs, ls_server);
            fs.Close();
        }

        #endregion



        #region ICON DOWNLOAD
        //https://icons8.com/icon/set/change/fluent-systems-filled
        #endregion
    }
}
