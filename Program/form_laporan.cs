using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public partial class form_laporan : UserControl
    {
        public form_laporan()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            cmb_reset();

            base.OnVisibleChanged(e);
        }

        #region METHOD
        private void cmb_reset()
        {
            switch (global.id_type)
            {
                case global.id_type_admin:
                    cmbList.Items.Clear();
                    cmbList.Items.Add("Stok Barang");
                    cmbList.Items.Add("Pengadaan Barang");
                    cmbList.Items.Add("Pengeluaran Barang");
                    break;
                case global.id_type_barang:
                    cmbList.Items.Clear();
                    cmbList.Items.Add("Stok Barang");
                    cmbList.Items.Add("Pengadaan Barang");
                    cmbList.Items.Add("Pengeluaran Barang");
                    break;
                case global.id_type_inventaris:
                    cmbList.Items.Clear();
                    cmbList.Items.Add("Stok Barang");
                    cmbList.Items.Add("Pengeluaran Barang");
                    break;
                case global.id_type_laporan:
                    cmbList.Items.Clear();
                    cmbList.Items.Add("Stok Barang");
                    cmbList.Items.Add("Pengadaan Barang");
                    cmbList.Items.Add("Pengeluaran Barang");
                    break;
            }
            if (cmbList.Items.Count > 0) { cmbList.SelectedIndex = 0; }
            dtpDari.Value = DateTime.Today;
            dtpSampai.Value = DateTime.Today;
        }
        #endregion

        #region EVENT ARGS
        private void cmbList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!dtpDari.Enabled) { dtpDari.Enabled = true; }
            switch (cmbList.SelectedIndex)
            {   
                case 0:
                    dtpDari.Enabled = false;
                    break;
            }
        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            var sql_cmmd = string.Empty;
            var dt = new DataTable();

            switch (global.id_type)
            {
                case global.id_type_admin:
                    switch (cmbList.SelectedIndex)
                    {
                        case 0:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY b.id) AS No, b.nama AS Nama_Barang, ISNULL(d.jml, 0) - ISNULL(t.jml, 0) AS Stok FROM db_barang AS b";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_barang_dt WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS d ON b.id=d.id_barang";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_transaksi WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS t ON b.id=t.id_barang";
                            dt = koneksi.dtb_command_time(sql_cmmd, new DateTime(dtpSampai.Value.Year, 1, 1), dtpSampai.Value);
                            break;
                        case 1:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, u.nama AS Pengguna, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan";
                            sql_cmmd += " FROM db_barang_dt AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id LEFT OUTER JOIN db_user AS u ON t.id_user = u.id";
                            sql_cmmd += " WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                            dt = koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                            break;
                        case 2:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, u.nama AS Pengguna, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan FROM db_transaksi AS t ";
                            sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                            sql_cmmd += "LEFT OUTER JOIN db_user AS u ON t.id_user = u.id ";
                            sql_cmmd += "WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                            dt = koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                            break;
                    }
                    break;
                case global.id_type_barang:
                    switch (cmbList.SelectedIndex)
                    {
                        case 0:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY b.id) AS No, b.nama AS Nama_Barang, ISNULL(d.jml, 0) - ISNULL(t.jml, 0) AS Stok FROM db_barang AS b";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_barang_dt WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS d ON b.id=d.id_barang";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_transaksi WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS t ON b.id=t.id_barang";
                            dt = koneksi.dtb_command_time(sql_cmmd, new DateTime(dtpSampai.Value.Year, 1, 1), dtpSampai.Value);
                            break;
                        case 1:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan";
                            sql_cmmd += " FROM db_barang_dt AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id WHERE";
                            sql_cmmd += " t.id_user = (@id_user) AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                            dt = koneksi.dtb_command_id_time(sql_cmmd, global.id, dtpDari.Value, dtpSampai.Value);
                            break;
                        case 2:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan FROM db_transaksi AS t ";
                            sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                            sql_cmmd += "WHERE t.id_user = (@id_user) AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                            dt = koneksi.dtb_command_id_time(sql_cmmd, global.id, dtpDari.Value, dtpSampai.Value);
                            break;
                    }
                    break;
                case global.id_type_inventaris:
                    switch (cmbList.SelectedIndex)
                    {
                        case 0:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY b.id) AS No, b.nama AS Nama_Barang, ISNULL(d.jml, 0) - ISNULL(t.jml, 0) AS Stok FROM db_barang AS b";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_barang_dt WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS d ON b.id=d.id_barang";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_transaksi WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS t ON b.id=t.id_barang";
                            dt = koneksi.dtb_command_time(sql_cmmd, new DateTime(dtpSampai.Value.Year, 1, 1), dtpSampai.Value);
                            break;
                        case 1:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan FROM db_transaksi AS t ";
                            sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                            sql_cmmd += "WHERE t.id_user = (@id_user) AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                            dt = koneksi.dtb_command_id_time(sql_cmmd, global.id, dtpDari.Value, dtpSampai.Value);
                            break;
                    }
                    break;
                case global.id_type_laporan:
                    switch (cmbList.SelectedIndex)
                    {
                        case 0:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY b.id) AS No, b.nama AS Nama_Barang, ISNULL(d.jml, 0) - ISNULL(t.jml, 0) AS Stok FROM db_barang AS b";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_barang_dt WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS d ON b.id=d.id_barang";
                            sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_transaksi WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS t ON b.id=t.id_barang";
                            dt = koneksi.dtb_command_time(sql_cmmd, new DateTime(dtpSampai.Value.Year, 1, 1), dtpSampai.Value);
                            break;
                        case 1:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, u.nama AS Pengguna, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan";
                            sql_cmmd += " FROM db_barang_dt AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id LEFT OUTER JOIN db_user AS u ON t.id_user = u.id";
                            sql_cmmd += " WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                            dt = koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                            break;
                        case 2:
                            sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, u.nama AS Pengguna, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan FROM db_transaksi AS t ";
                            sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                            sql_cmmd += "LEFT OUTER JOIN db_user AS u ON t.id_user = u.id ";
                            sql_cmmd += "WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                            dt = koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                            break;
                    }
                    break;
            }
            dgvLaporan.DataSource = dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
        }
        #endregion

    }
}
