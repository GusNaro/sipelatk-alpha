using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Program
{
    class koneksi
    {
        public static SqlConnection conn = new SqlConnection(global.conn_string);

        public static DataTable dtb_command(string command)
        {
            var dt = new DataTable();
            var cmd = new SqlCommand(command, conn);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return dt;
        }

        #region LOGIN
        public static string[] login(string ID)
        {
            string[] data = new string[] { "", "", "" };
            var cmd = new SqlCommand("SELECT nama, pass, type FROM db_user WHERE (id=@ID)", conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                { data = new string[] { dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString() }; }
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return data;
        }
        #endregion

        #region USER
        public static bool user_ins_upd(string cmmd, string id, string nama, string pass, int type)
        {
            string command = "";
            if (cmmd == "INSERT")
            { command = "INSERT INTO db_user VALUES (@id, @nama, @pass, @type)"; }
            else if (cmmd == "UPDATE")
            { command = "UPDATE db_user SET nama=(@nama), pass=(@pass), type=(@type) WHERE  ID = (@id)"; }
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@type", type);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }

        public static bool user_delete(string id)
        {
            var command = "DELETE FROM db_user WHERE ID = (@id)";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }

        #endregion



        #region MY SQL DATA
        //private static MySqlConnection connt = new MySqlConnection(global.conn_string);

        //private static string str()
        //{

        //    try
        //    {
        //        if (conn.State == System.Data.ConnectionState.Closed) { connt.Open(); }
        //        return "data berhasil dibuka";
        //    }
        //    catch (MySqlException ex)
        //    { return "Gagal karena " + ex.Message; }

        //    string str = @"Driver={MySQL ODBC 3.51 Driver};UID=drakorea;PWD=lol123!;database=barang;server=localhost";
        //    OdbcConnection conn = new OdbcConnection(str);
        //    try
        //    {
        //        if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
        //        conn.Close();
        //        return "data berhasil dibuka";
        //    }
        //    catch (Exception ex)
        //    { return "Gagal karena " + ex.Message; }
        //}

        //private static string[] login_x(string ID)
        //{
        //    string[] data = new string[] { "", "", "" };
        //    var cmd = new MySqlCommand("SELECT nama, pass, type FROM db_user WHERE (id='@ID')", connt);
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    try
        //    {
        //        if (connt.State == System.Data.ConnectionState.Closed) { conn.Open(); }
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        { data = new string[] { reader.GetString(0), reader.GetString(1), reader.GetInt32(2).ToString() }; }
        //        reader.Close();
        //        connt.Close();
        //    }
        //    catch (MySqlException ex)
        //    { MessageBox.Show(ex.Message); connt.Close(); }

        //    return data;
        //}
        #endregion
    }
}
