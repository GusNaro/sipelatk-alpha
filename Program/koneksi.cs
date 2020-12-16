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

        #region LOGIN
        public static string[] login(string ID)
        {
            string[] data = new string[] { "", "", "", "" };
            var cmd = new SqlCommand("SELECT * FROM db_user WHERE (id=@ID)", conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                { data = new string[] { dt.Rows[0][0].ToString().Trim(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString() }; }
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return data;
        }
        #endregion

        #region USER
        public static bool user_query(string cmmd, string id, string nama, string pass, int type, string uk)
        {
            string command = "";
            switch (cmmd)
            {
                case "INSERT":
                    command = "INSERT INTO db_user VALUES (@id, @nama, @pass, @type, @uk)";
                    break;
                case "UPDATE":
                    command = "UPDATE db_user SET nama=(@nama), pass=(@pass), type=(@type), uk=(@uk) WHERE  ID = (@id)";
                    break;
                case "DELETE":
                    command = "DELETE FROM db_user WHERE ID = (@id)";
                    break;
            }
            var cmd = new SqlCommand(command, conn);
            if (cmmd == "INSERT" || cmmd == "UPDATE")
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@uk", uk);
            }
            else if (cmmd == "DELETE")
            { cmd.Parameters.AddWithValue("@id", id); }

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }
        #endregion

        #region BARANG
        public static bool status_id_barang_dt(string id)
        {
            var cmd = new SqlCommand("SELECT id FROM db_barang_dt WHERE (id_barang=@ID)", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0) { return true; }
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }

        public static bool status_id_barang_transaksi(string id)
        {
            var cmd = new SqlCommand("SELECT id FROM db_transaksi WHERE (id_barang=@ID)", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0) { return true; }
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }

        public static bool query_barang_dt(string cmmd, int id, string id_brg, string id_usr, DateTime tgl, int qty, string ket)
        {
            string command = "";
            switch (cmmd)
            {
                case "INSERT":
                    command = "INSERT INTO db_barang_dt VALUES (@id, @id_barang, @id_user, @tgl, @qty, @ket)";
                    break;
                case "UPDATE":
                    command = "UPDATE db_barang_dt SET id_barang=(@id_barang), id_user=(@id_user), tgl=(@tgl), qty=(@qty), ket=(@ket) WHERE  id = (@id)";
                    break;
                case "DELETE":
                    command = "DELETE FROM db_barang_dt WHERE id = (@id)";
                    break;
            }
            var cmd = new SqlCommand(command, conn);
            if (cmmd == "HAPUS")
            { cmd.Parameters.AddWithValue("@id", id); }
            else
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@id_barang", id_brg);
                cmd.Parameters.AddWithValue("@id_user", id_usr);
                cmd.Parameters.AddWithValue("@tgl", tgl);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@ket", ket);
            }
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                return true;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }

        public static bool query_barang(string cmmd, string id, string nama, string satuan, float harga, string penyedia)
        {
            string command = "";
            switch (cmmd)
            {
                case "INSERT":
                    command = "INSERT INTO db_barang VALUES (@id, @nama, @satuan, @harga, @penyedia)";
                    break;
                case "UPDATE":
                    command = "UPDATE db_barang SET nama=(@nama), satuan=(@satuan), harga=(@harga), penyedia=(@penyedia) WHERE id = (@id)";
                    break;
                case "DELETE":
                    command = "DELETE FROM db_barang WHERE id = (@id)";
                    break;
            }
            var cmd = new SqlCommand(command, conn);
            if (cmmd == "HAPUS")
            { cmd.Parameters.AddWithValue("@id", id); }
            else
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@satuan", satuan);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@penyedia", penyedia);
            }
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                return true;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }
        #endregion

        #region TRANSAKSI
        public static bool query_transaksi(string cmmd, int id, string id_brg, string id_usr, DateTime tgl, int qty, string ket)
        {
            string command = string.Empty;
            switch (cmmd)
            {
                case "INSERT":
                    command = "INSERT INTO db_transaksi VALUES (@id, @id_brg, @id_usr, @tgl, @qty, @ket)";
                    break;
                case "UPDATE":
                    command = "UPDATE db_transaksi SET id_barang=(@id_brg), id_user=(@id_usr), tgl=(@tgl), qty=(@qty), ket=(@ket) WHERE  id = (@id)";
                    break;
                case "DELETE":
                    command = "DELETE FROM db_transaksi WHERE id = (@id)";
                    break;
            }
            var cmd = new SqlCommand(command, conn);
            if (cmmd == "HAPUS")
            { cmd.Parameters.AddWithValue("@id", id); }
            else
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@id_brg", id_brg);
                cmd.Parameters.AddWithValue("@id_usr", id_usr);
                cmd.Parameters.AddWithValue("@tgl", tgl);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@ket", ket);
            }
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                return true;
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return false;
        }
        #endregion

        #region DATA TABLE
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
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return dt;
        }
        
        public static DataTable dtb_command_id(string command, string id_user)
        {
            var dt = new DataTable();
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@id_user", id_user);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return dt;
        }

        public static DataTable dtb_command_time(string command, DateTime tgl_dari, DateTime tgl_sampai)
        {
            var dt = new DataTable();
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@tgl_d", tgl_dari);
            cmd.Parameters.AddWithValue("@tgl_s", tgl_sampai);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return dt;
        }

        public static DataTable dtb_command_id_time(string command, string id_user, DateTime tgl_dari, DateTime tgl_sampai)
        {
            var dt = new DataTable();
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@id_user", id_user);
            cmd.Parameters.AddWithValue("@tgl_d", tgl_dari);
            cmd.Parameters.AddWithValue("@tgl_s", tgl_sampai);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            catch (SqlException ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            return dt;
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
