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
                    cmbList.Items.AddRange(global.unit_kerja);
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
                    cmbList.Items.AddRange(global.unit_kerja);
                    break;
            }
            dtpDari.Value = DateTime.Today;
            dtpSampai.Value = DateTime.Today;
            if (cmbList.Items.Count > 0) { cmbList.SelectedIndex = 0; }
        }

        private DataTable dtb_laporan(global.JenisLaporan jl)
        {
            var sql_cmmd = string.Empty;
            var unit_kerja = string.Empty;
            switch (jl)
            {
                case global.JenisLaporan.stok:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY b.id) AS NO, b.nama AS NAMA_BARANG, ISNULL(d.jml, 0) - ISNULL(t.jml, 0) AS STOK, b.satuan AS SATUAN FROM db_barang AS b";
                    sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_barang_dt WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS d ON b.id=d.id_barang";
                    sql_cmmd += " LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS jml FROM db_transaksi WHERE tgl>=(@tgl_d) AND tgl<=(@tgl_s) GROUP BY id_barang) AS t ON b.id=t.id_barang";
                    return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengadaan:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS NO, u.nama AS PENGGUNA, b.nama AS NAMA_BARANG, t.tgl AS TANGGAL, t.qty AS JUMLAH, b.satuan AS SATUAN, t.ket AS KETERANGAN";
                    sql_cmmd += " FROM db_barang_dt AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id LEFT OUTER JOIN db_user AS u ON t.id_user = u.id";
                    sql_cmmd += " WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengadaan_id:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS NO, b.nama AS NAMA_BARANG, t.tgl AS TANGGAL, t.qty AS JUMLAH, b.satuan AS SATUAN, t.ket AS KETERANGAN";
                    sql_cmmd += " FROM db_barang_dt AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id WHERE";
                    sql_cmmd += " t.id_user = (@id_user) AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_id_time(sql_cmmd, global.id, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengeluaran:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS NO, u.nama AS PENGGUNA, b.nama AS NAMA_BARANG, t.tgl AS TANGGAL, t.qty AS JUMLAH, b.satuan AS SATUAN, t.ket AS KETERANGAN FROM db_transaksi AS t ";
                    sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                    sql_cmmd += "LEFT OUTER JOIN db_user AS u ON t.id_user = u.id ";
                    sql_cmmd += "WHERE t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.pengeluaran_id:
                    sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS NO, b.nama AS NAMA_BARANG, t.tgl AS TANGGAL, t.qty AS JUMLAH, b.satuan AS SATUAN, t.ket AS KETERANGAN FROM db_transaksi AS t ";
                    sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                    sql_cmmd += "WHERE t.id_user = (@id_user) AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                    return koneksi.dtb_command_id_time(sql_cmmd, global.id, dtpDari.Value, dtpSampai.Value);
                case global.JenisLaporan.divisi_umum_dan_kesekretariatan:
                    unit_kerja = "'Divisi Umum dan Kesekretariatan'";
                    break;
                case global.JenisLaporan.divisi_kepatuhan:
                    unit_kerja = "'Divisi Kepatuhan'";
                    break;
                case global.JenisLaporan.divisi_manajemen_risiko:
                    unit_kerja = "'Divisi Manajemen Risiko'";
                    break;
                case global.JenisLaporan.divisi_perencanaan_strategis:
                    unit_kerja = "'Divisi Perencanaan Strategis'";
                    break;
                case global.JenisLaporan.divisi_sumber_daya_manusia:
                    unit_kerja = "'Divisi Sumber Daya Manusia'";
                    break;
                case global.JenisLaporan.divisi_treasury:
                    unit_kerja = "'Divisi Treasury'";
                    break;
                case global.JenisLaporan.divisi_dana_dan_jasa:
                    unit_kerja = "'Divisi Dana dan Jasa'";
                    break;
                case global.JenisLaporan.divisi_teknologi_akuntansi:
                    unit_kerja = "'Divisi Teknologi & Akuntansi'";
                    break;
                case global.JenisLaporan.divisi_kredit:
                    unit_kerja = "'Divisi Kredit'";
                    break;
                case global.JenisLaporan.skai_anti_fraud:
                    unit_kerja = "'SKAI & Anti Fraud'";
                    break;
                case global.JenisLaporan.cabang_renon:
                    unit_kerja = "'Cabang Renon'";
                    break;
                case global.JenisLaporan.cabang_denpasar:
                    unit_kerja = "'Cabang Denpasar'";
                    break;
                case global.JenisLaporan.cabang_badung:
                    unit_kerja = "'Cabang Badung'";
                    break;
                case global.JenisLaporan.cabang_mangupura:
                    unit_kerja = "'Cabang Mangupura'";
                    break;
                case global.JenisLaporan.cabang_tabanan:
                    unit_kerja = "'Cabang Tabanan'";
                    break;
                case global.JenisLaporan.cabang_singaraja:
                    unit_kerja = "'Cabang Singaraja'";
                    break;
                case global.JenisLaporan.cabang_seririt:
                    unit_kerja = "'Cabang Seririt'";
                    break;
                case global.JenisLaporan.cabang_negara:
                    unit_kerja = "'Cabang Negara'";
                    break;
                case global.JenisLaporan.cabang_gianyar:
                    unit_kerja = "'Cabang Gianyar'";
                    break;
                case global.JenisLaporan.cabang_ubud:
                    unit_kerja = "'Cabang Ubud'";
                    break;
                case global.JenisLaporan.cabang_klungkung:
                    unit_kerja = "'Cabang Klungkung'";
                    break;
                case global.JenisLaporan.cabang_bangli:
                    unit_kerja = "'Cabang Bangli'";
                    break;
                case global.JenisLaporan.cabang_karangasem:
                    unit_kerja = "'Cabang Karangasem'";
                    break;
                case global.JenisLaporan.cabang_mataram:
                    unit_kerja = "'Cabang Mataram'";
                    break;
            }
            if (jl != global.JenisLaporan.stok || jl != global.JenisLaporan.pengadaan || jl != global.JenisLaporan.pengadaan_id || jl != global.JenisLaporan.pengeluaran || jl != global.JenisLaporan.pengeluaran_id)
            {
                sql_cmmd = "SELECT ROW_NUMBER() OVER (ORDER BY t.tgl) AS NO, u.nama AS PENGGUNA, b.nama AS NAMA_BARANG, t.tgl AS TANGGAL, t.qty AS JUMLAH, b.satuan AS SATUAN, b.harga AS HARGA, t.qty * b.harga AS TOTAL, t.ket AS KETERANGAN ";
                sql_cmmd += "FROM db_transaksi AS t ";
                sql_cmmd += "LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id ";
                sql_cmmd += "LEFT OUTER JOIN db_user AS u ON t.id_user = u.id ";
                sql_cmmd += "WHERE u.uk=(" + unit_kerja + ") AND t.tgl >= (@tgl_d) AND t.tgl <= (@tgl_s)";
                return koneksi.dtb_command_time(sql_cmmd, dtpDari.Value, dtpSampai.Value);
            }

            return new DataTable();
        }

        private void set_dtb_column_width(string jenis_laporan)
        {
            if (jenis_laporan == "Stok Barang")
            {
                #region DATA GRID VIEW WIDTH
                dgvLaporan.Columns["NO"].Width = dgvLaporan.Width * 5 / 100;
                dgvLaporan.Columns["NAMA_BARANG"].Width = dgvLaporan.Width * 50 / 100;
                dgvLaporan.Columns["STOK"].Width = dgvLaporan.Width * 10 / 100;
                dgvLaporan.Columns["SATUAN"].Width = dgvLaporan.Width * 15 / 100;
                #endregion

                #region DATA GRID VIEW ORDER
                dgvLaporan.Columns["NO"].DisplayIndex = 0;
                dgvLaporan.Columns["NAMA_BARANG"].DisplayIndex = 1;
                dgvLaporan.Columns["STOK"].DisplayIndex = 2;
                dgvLaporan.Columns["SATUAN"].DisplayIndex = 3;
                #endregion
            }
            else if (jenis_laporan == "Pengadaan Barang" || jenis_laporan == "Pengeluaran Barang")
            {
                #region DATA GRID VIEW WIDTH
                dgvLaporan.Columns["NO"].Width = dgvLaporan.Width * 5 / 100;
                dgvLaporan.Columns["NAMA_BARANG"].Width = dgvLaporan.Width * 30 / 100;
                dgvLaporan.Columns["TANGGAL"].Width = dgvLaporan.Width * 11 / 100;
                dgvLaporan.Columns["JUMLAH"].Width = dgvLaporan.Width * 7 / 100;
                dgvLaporan.Columns["SATUAN"].Width = dgvLaporan.Width * 12 / 100;
                if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
                {
                    dgvLaporan.Columns["PENGGUNA"].Width = dgvLaporan.Width * 15 / 100;
                    dgvLaporan.Columns["KETERANGAN"].Width = dgvLaporan.Width * 15 / 100;
                }
                else
                { dgvLaporan.Columns["KETERANGAN"].Width = dgvLaporan.Width * 30 / 100; }
                #endregion

                #region DATA GRID VIEW ORDER
                dgvLaporan.Columns["NO"].DisplayIndex = 0;
                if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
                {
                    dgvLaporan.Columns["PENGGUNA"].DisplayIndex = 1;
                    dgvLaporan.Columns["NAMA_BARANG"].DisplayIndex = 2;
                    dgvLaporan.Columns["TANGGAL"].DisplayIndex = 3;
                    dgvLaporan.Columns["JUMLAH"].DisplayIndex = 4;
                    dgvLaporan.Columns["SATUAN"].DisplayIndex = 5;
                    dgvLaporan.Columns["KETERANGAN"].DisplayIndex = 6;
                }
                else
                {
                    dgvLaporan.Columns["NAMA_BARANG"].DisplayIndex = 1;
                    dgvLaporan.Columns["TANGGAL"].DisplayIndex = 2;
                    dgvLaporan.Columns["JUMLAH"].DisplayIndex = 3;
                    dgvLaporan.Columns["SATUAN"].DisplayIndex = 4;
                    dgvLaporan.Columns["KETERANGAN"].DisplayIndex = 5;
                }
                #endregion
            }
            else
            {
                #region DATA GRID VIEW WIDTH
                dgvLaporan.Columns["NO"].Width = dgvLaporan.Width * 5 / 100;
                dgvLaporan.Columns["NAMA_BARANG"].Width = dgvLaporan.Width * 23 / 100;
                dgvLaporan.Columns["PENGGUNA"].Width = dgvLaporan.Width * 11 / 100;
                dgvLaporan.Columns["TANGGAL"].Width = dgvLaporan.Width * 8 / 100;
                dgvLaporan.Columns["JUMLAH"].Width = dgvLaporan.Width * 7 / 100;
                dgvLaporan.Columns["SATUAN"].Width = dgvLaporan.Width * 8 / 100;
                dgvLaporan.Columns["HARGA"].Width = dgvLaporan.Width * 9 / 100;
                dgvLaporan.Columns["HARGA"].DefaultCellStyle.Format = "C";
                dgvLaporan.Columns["TOTAL"].Width = dgvLaporan.Width * 11 / 100;
                dgvLaporan.Columns["TOTAL"].DefaultCellStyle.Format = "C";
                dgvLaporan.Columns["KETERANGAN"].Width = dgvLaporan.Width * 13 / 100;
                #endregion

                #region DATA GRID VIEW ORDER
                dgvLaporan.Columns["NO"].DisplayIndex = 0;
                dgvLaporan.Columns["NAMA_BARANG"].DisplayIndex = 1;
                dgvLaporan.Columns["PENGGUNA"].DisplayIndex = 2;
                dgvLaporan.Columns["TANGGAL"].DisplayIndex = 3;
                dgvLaporan.Columns["JUMLAH"].DisplayIndex = 4;
                dgvLaporan.Columns["SATUAN"].DisplayIndex = 5;
                dgvLaporan.Columns["HARGA"].DisplayIndex = 6;
                dgvLaporan.Columns["TOTAL"].DisplayIndex = 7;
                dgvLaporan.Columns["KETERANGAN"].DisplayIndex = 8;
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
                case "Divisi Umum dan Kesekretariatan":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_umum_dan_kesekretariatan);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Kepatuhan":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_kepatuhan);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Manajemen Risiko":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_manajemen_risiko);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Perencanaan Strategis":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_perencanaan_strategis);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Sumber Daya Manusia":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_sumber_daya_manusia);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Treasury":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_treasury);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Dana dan Jasa":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_dana_dan_jasa);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Teknologi & Akuntansi":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_teknologi_akuntansi);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Divisi Kredit":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.divisi_kredit);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "SKAI & Anti Fraud":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.skai_anti_fraud);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Renon":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_renon);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Denpasar":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_denpasar);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Badung":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_badung);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Mangupura":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_mangupura);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Tabanan":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_tabanan);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Singaraja":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_singaraja);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Seririt":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_seririt);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Negara":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_negara);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Gianyar":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_gianyar);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Ubud":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_ubud);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Klungkung":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_klungkung);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Bangli":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_bangli);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Karangasem":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_karangasem);
                    lblTotalKeseluruhan.Text = "TOTAL : Rp." + total_keseluruhan.ToString("#,##0.00", new System.Globalization.CultureInfo("id-ID"));
                    break;
                case "Cabang Mataram":
                    dgvLaporan.DataSource = dtb_laporan(global.JenisLaporan.cabang_mataram);
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
                    { _total += double.Parse(dgvLaporan.Rows[i].Cells["TOTAL"].Value.ToString()); }
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
