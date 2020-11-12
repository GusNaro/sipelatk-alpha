using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace Program
{
    class koneksi
    {
        public static string str()
        {
            //string str = @"Data Source=AIKA;User ID=drakorea;Password=lol123!;Initial Catalog=barang";
            //SqlConnection conn = new SqlConnection(str);
            //try
            //{
            //    conn.Open();
            //    conn.Close();
            //    return "data berhasil dibuka";
            //}
            //catch (Exception ex)
            //{ return "Gagal karena " + ex.Message; }

            string str = @"Driver={MySQL ODBC 3.51 Driver};UID=drakorea;PWD=lol123!;database=barang;server=localhost";
            OdbcConnection conn = new OdbcConnection(str);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                conn.Close();
                return "data berhasil dibuka";
            }
            catch (Exception ex)
            { return "Gagal karena " + ex.Message; }
        }
    }
}
