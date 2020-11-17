using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//using System.Data.Odbc;

namespace Program
{
    class koneksi
    {
        private static MySqlConnection conn = new MySqlConnection(global.conn_string);

        public static string str()
        {

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                return "data berhasil dibuka";
            }
            catch (MySqlException ex)
            { return "Gagal karena " + ex.Message; }

            //string str = @"Driver={MySQL ODBC 3.51 Driver};UID=drakorea;PWD=lol123!;database=barang;server=localhost";
            //OdbcConnection conn = new OdbcConnection(str);
            //try
            //{
            //    if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            //    conn.Close();
            //    return "data berhasil dibuka";
            //}
            //catch (Exception ex)
            //{ return "Gagal karena " + ex.Message; }
        }

        public static string[] login(string ID)
        {
            string[] data = null;
            var cmd = new MySqlCommand("SELECT nama, pass, type FROM pengguna WHERE id=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { data = new string[] { reader.GetString(0), reader.GetString(1), reader.GetInt32(2).ToString() }; }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            { MessageBox.Show(ex.Message); conn.Close(); }

            return data;
        }
    }
}
