using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Program
{
    public partial class form_laporan : Form
    {
        public form_laporan()
        { InitializeComponent();  }

        private void form_laporan_Load(object sender, EventArgs e)
        {
            cmb_reset();
            lblTotalKeseluruhan.Text = string.Empty;
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
                    cmbList.Items.Add("Cabang Renon");
                    cmbList.Items.Add("Cabang Denpasar");
                    cmbList.Items.Add("Cabang Badung");
                    cmbList.Items.Add("Cabang Mangupura");
                    cmbList.Items.Add("Cabang Tabanan");
                    cmbList.Items.Add("Cabang Singaraja");
                    cmbList.Items.Add("Cabang Seririt");
                    cmbList.Items.Add("Cabang Negara");
                    cmbList.Items.Add("Cabang Gianyar");
                    cmbList.Items.Add("Cabang Ubud");
                    cmbList.Items.Add("Cabang Klungkung");
                    cmbList.Items.Add("Cabang Bangli");
                    cmbList.Items.Add("Cabang Karangasem");
                    cmbList.Items.Add("Cabang Mataram");
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
                    cmbList.Items.Add("Cabang Renon");
                    cmbList.Items.Add("Cabang Denpasar");
                    cmbList.Items.Add("Cabang Badung");
                    cmbList.Items.Add("Cabang Mangupura");
                    cmbList.Items.Add("Cabang Tabanan");
                    cmbList.Items.Add("Cabang Singaraja");
                    cmbList.Items.Add("Cabang Seririt");
                    cmbList.Items.Add("Cabang Negara");
                    cmbList.Items.Add("Cabang Gianyar");
                    cmbList.Items.Add("Cabang Ubud");
                    cmbList.Items.Add("Cabang Klungkung");
                    cmbList.Items.Add("Cabang Bangli");
                    cmbList.Items.Add("Cabang Karangasem");
                    cmbList.Items.Add("Cabang Mataram");
                    break;
            }
            dtpDari.Value = DateTime.Today;
            dtpSampai.Value = DateTime.Today;
            if (cmbList.Items.Count > 0) { cmbList.SelectedIndex = 0; }
        }

        private DataTable dtb_laporan(global.JenisLaporan jl)
        {
            var sql_cmmd = string.Empty;
            var cabang = string.Empty;
            switch (jl)
            {
                case global.JenisLaporan.stok:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY b.id) AS No, b.nama AS Nama_Barang, ISNULL(d.jml, 0) - ISNULL(t.jml, 0) AS Stok, b.satuan AS Satuan FROM db_barang AS b";
                    sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_barang_dt WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS d ON b.id=d.id_barang";
                    sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_transaksi WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS t ON b.id=t.id_barang";
                    return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengadaan:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, u.nama AS Pengguna, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan";
                    sql_cmmd += " FROM db_barang_dt AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id LEFT OUTER JOIN db_user AS u ON t.id_user = u.id";
                    sql_cmmd += " WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengadaan_id:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan";
                    sql_cmmd += " FROM db_barang_dt AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id WHERE";
                    sql_cmmd += " t.id_user = (@id_user) AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_id_time(sql_cmmd, global.id, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengeluaran:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, u.nama AS Pengguna, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan FROM db_transaksi AS t ";
                    sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                    sql_cmmd += "LEFT OUTER JOIN db_user AS u ON t.id_user = u.id ";
                    sql_cmmd += "WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengeluaran_id:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan FROM db_transaksi AS t ";
                    sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                    sql_cmmd += "WHERE t.id_user = (@id_user) AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_id_time(sql_cmmd, global.id, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.renon:
                    cabang = "'Renon'";
                    break;
                case global.JenisLaporan.denpasar:
                    cabang = "'Denpasar'";
                    break;
                case global.JenisLaporan.badung:
                    cabang = "'Badung'";
                    break;
                case global.JenisLaporan.mangupura:
                    cabang = "'Mangupura'";
                    break;
                case global.JenisLaporan.tabanan:
                    cabang = "'Tabanan'";
                    break;
                case global.JenisLaporan.singaraja:
                    cabang = "'Singaraja'";
                    break;
                case global.JenisLaporan.seririt:
                    cabang = "'Seririt'";
                    break;
                case global.JenisLaporan.negara:
                    cabang = "'Negara'";
                    break;
                case global.JenisLaporan.gianyar:
                    cabang = "'Gianyar'";
                    break;
                case global.JenisLaporan.ubud:
                    cabang = "'Ubud'";
                    break;
                case global.JenisLaporan.klungkung:
                    cabang = "'Klungkung'";
                    break;
                case global.JenisLaporan.bangli:
                    cabang = "'Bangli'";
                    break;
                case global.JenisLaporan.karangasem:
                    cabang = "'Karangasem'";
                    break;
                case global.JenisLaporan.mataram:
                    cabang = "'Mataram'";
                    break;
            }
            if (jl == global.JenisLaporan.renon || jl == global.JenisLaporan.denpasar || jl == global.JenisLaporan.badung || jl == global.JenisLaporan.mangupura || jl == global.JenisLaporan.tabanan || jl == global.JenisLaporan.singaraja || jl == global.JenisLaporan.seririt || jl == global.JenisLaporan.negara || jl == global.JenisLaporan.gianyar || jl == global.JenisLaporan.ubud || jl == global.JenisLaporan.klungkung || jl == global.JenisLaporan.bangli || jl == global.JenisLaporan.karangasem || jl == global.JenisLaporan.mataram)
            {
                sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS No, u.nama AS Pengguna, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, b.harga AS Harga, t.qty * b.harga AS Total, t.ket AS Keterangan ";
                sql_cmmd += "FROM db_transaksi AS t ";
                sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                sql_cmmd += "LEFT OUTER JOIN db_user AS u ON t.id_user = u.id ";
                sql_cmmd += "WHERE u.cabang=(" + cabang + ") AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
            }

            return new DataTable();
        }

        private void set_dtb_column_width(string jenis_laporan)
        {
            if (jenis_laporan == "Stok Barang")
            {
                #region DATA GRID VIEW WIDTH
                dgvLaporan.Columns["No"].Width = dgvLaporan.Width * 5 / 100;
                dgvLaporan.Columns["Nama_Barang"].Width = dgvLaporan.Width * 50 / 100;
                dgvLaporan.Columns["Stok"].Width = dgvLaporan.Width * 10 / 100;
                dgvLaporan.Columns["Satuan"].Width = dgvLaporan.Width * 15 / 100;
                #endregion

                #region DATA GRID VIEW ORDER
                dgvLaporan.Columns["No"].DisplayIndex = 0;
                dgvLaporan.Columns["Nama_Barang"].DisplayIndex = 1;
                dgvLaporan.Columns["Stok"].DisplayIndex = 2;
                dgvLaporan.Columns["Satuan"].DisplayIndex = 3;
                #endregion
            }
            else if (jenis_laporan == "Pengadaan Barang" || jenis_laporan == "Pengeluaran Barang")
            {
                #region DATA GRID VIEW WIDTH
                dgvLaporan.Columns["No"].Width = dgvLaporan.Width * 5 / 100;
                dgvLaporan.Columns["Nama_Barang"].Width = dgvLaporan.Width * 30 / 100;
                dgvLaporan.Columns["Tanggal"].Width = dgvLaporan.Width * 11 / 100;
                dgvLaporan.Columns["Jumlah"].Width = dgvLaporan.Width * 7 / 100;
                dgvLaporan.Columns["Satuan"].Width = dgvLaporan.Width * 12 / 100;
                if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
                {
                    dgvLaporan.Columns["Pengguna"].Width = dgvLaporan.Width * 15 / 100;
                    dgvLaporan.Columns["Keterangan"].Width = dgvLaporan.Width * 15 / 100;
                }
                else
                { dgvLaporan.Columns["Keterangan"].Width = dgvLaporan.Width * 30 / 100; }
                #endregion

                #region DATA GRID VIEW ORDER
                dgvLaporan.Columns["No"].DisplayIndex = 0;
                if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
                {
                    dgvLaporan.Columns["Pengguna"].DisplayIndex = 1;
                    dgvLaporan.Columns["Nama_Barang"].DisplayIndex = 2;
                    dgvLaporan.Columns["Tanggal"].DisplayIndex = 3;
                    dgvLaporan.Columns["Jumlah"].DisplayIndex = 4;
                    dgvLaporan.Columns["Satuan"].DisplayIndex = 5;
                    dgvLaporan.Columns["Keterangan"].DisplayIndex = 6;
                }
                else
                {
                    dgvLaporan.Columns["Nama_Barang"].DisplayIndex = 1;
                    dgvLaporan.Columns["Tanggal"].DisplayIndex = 2;
                    dgvLaporan.Columns["Jumlah"].DisplayIndex = 3;
                    dgvLaporan.Columns["Satuan"].DisplayIndex = 4;
                    dgvLaporan.Columns["Keterangan"].DisplayIndex = 5;
                }
                #endregion
            }
            else if (jenis_laporan == "Cabang Renon" || jenis_laporan == "Cabang Denpasar" || jenis_laporan == "Cabang Badung" || jenis_laporan == "Cabang Mangupura" || jenis_laporan == "Cabang Tabanan" || jenis_laporan == "Cabang Singaraja" || jenis_laporan == "Cabang Seririt" || jenis_laporan == "Cabang Negara" || jenis_laporan == "Cabang Gianyar" || jenis_laporan == "Cabang Ubud" || jenis_laporan == "Cabang Klungkung" || jenis_laporan == "Cabang Bangli" || jenis_laporan == "Cabang Karangasem" || jenis_laporan == "Cabang Mataram")
            {
                #region DATA GRID VIEW WIDTH
                dgvLaporan.Columns["No"].Width = dgvLaporan.Width * 5 / 100;
                dgvLaporan.Columns["Nama_Barang"].Width = dgvLaporan.Width * 23 / 100;
                dgvLaporan.Columns["Pengguna"].Width = dgvLaporan.Width * 11 / 100;
                dgvLaporan.Columns["Tanggal"].Width = dgvLaporan.Width * 8 / 100;
                dgvLaporan.Columns["Jumlah"].Width = dgvLaporan.Width * 7 / 100;
                dgvLaporan.Columns["Satuan"].Width = dgvLaporan.Width * 8 / 100;
                dgvLaporan.Columns["Harga"].Width = dgvLaporan.Width * 9 / 100;
                dgvLaporan.Columns["Harga"].DefaultCellStyle.Format = "C";
                dgvLaporan.Columns["Total"].Width = dgvLaporan.Width * 11 / 100;
                dgvLaporan.Columns["Total"].DefaultCellStyle.Format = "C";
                dgvLaporan.Columns["Keterangan"].Width = dgvLaporan.Width * 13 / 100;
                #endregion

                #region DATA GRID VIEW ORDER
                dgvLaporan.Columns["No"].DisplayIndex = 0;
                dgvLaporan.Columns["Nama_Barang"].DisplayIndex = 1;
                dgvLaporan.Columns["Pengguna"].DisplayIndex = 2;
                dgvLaporan.Columns["Tanggal"].DisplayIndex = 3;
                dgvLaporan.Columns["Jumlah"].DisplayIndex = 4;
                dgvLaporan.Columns["Satuan"].DisplayIndex = 5;
                dgvLaporan.Columns["Harga"].DisplayIndex = 6;
                dgvLaporan.Columns["Total"].DisplayIndex = 7;
                dgvLaporan.Columns["Keterangan"].DisplayIndex = 8;
                #endregion
            }
            //dgvBarang.Columns[0].Visible = false;
        }
        #endregion

        #region EVENT ARGS
        private void cmbList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!dtpDari.Enabled)
            {
                if (dtpDari.Value != dtpSampai.Value) { dtpDari.Value = dtpSampai.Value; }
                dtpDari.Enabled = true;
            }
            switch (cmbList.SelectedIndex)
            {   
                case 0:
                    dtpDari.Value = new DateTime(dtpSampai.Value.Year, 1, 1);
                    dtpDari.Enabled = false;
                    break;
            }
        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            if (lblTotalKeseluruhan.Text != string.Empty) { lblTotalKeseluruhan.Text = string.Empty; }
            switch (cmbList.Text)
            {
                case "Stok Barang":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.stok);
                    break;
                case "Pengadaan Barang":
                    if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
                    { dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.pengadaan); }
                    else
                    { dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.pengadaan_id); }
                    break;
                case "Pengeluaran Barang":
                    if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
                    { dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.pengeluaran); }
                    else
                    { dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.pengeluaran_id); }
                    break;
                case "Cabang Renon":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.renon);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Denpasar":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.denpasar);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Badung":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.badung);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Mangupura":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.mangupura);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Tabanan":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.tabanan);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Singaraja":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.singaraja);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Seririt":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.seririt);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Negara":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.negara);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Gianyar":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.gianyar);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Ubud":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.ubud);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Klungkung":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.klungkung);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Bangli":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.bangli);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Karangasem":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.karangasem);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Mataram":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.mataram);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
            }
            set_dtb_column_width(cmbList.Text);
        }

        private double total_keseluruhan
        {
            get
            {
                double _total = 0;
                if (dgvLaporan.Rows.Count > 1)
                {
                    for (int i = 0; i < dgvLaporan.Rows.Count - 1; i++)
                    { _total += double.Parse(dgvLaporan.Rows[i].Cells["Total"].Value.ToString()); }
                }
                return _total;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvLaporan.Rows.Count > 1)
            {
                try
                {
                    Excel.Application _app = new Excel.Application();
                    _app.Application.Workbooks.Add(Type.Missing);
                    for (int i = 0; i < dgvLaporan.Columns.Count; i++)
                    { _app.Cells[1, i + 1] = dgvLaporan.Columns[i].HeaderText; }
                    for (int i = 0; i < dgvLaporan.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgvLaporan.Columns.Count; j++)
                        { _app.Cells[i + 2, j + 1] = dgvLaporan.Rows[i].Cells[j].Value.ToString(); }
                    }
                    _app.Columns.AutoFit();
                    _app.Visible = true;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("TIDAK ADA DATA !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

    }
}
