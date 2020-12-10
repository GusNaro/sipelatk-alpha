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
    public partial class form_transaksi : UserControl
    {
        public form_transaksi()
        {
            InitializeComponent();
<<<<<<< Updated upstream
=======

            data_barang = new DataTable();
            data_transaksi = new DataTable();
        }

        private void form_transaksi_Load(object sender, EventArgs e)
        {
            update_tabel();
            status_button_simpan = global.StatusButtonSimpan.simpan;
        }

        #region METHOD
        private void update_tabel()
        {
            var cmmd = "SELECT b.id AS ID, b.nama AS NAMA_BARANG, b.satuan AS SATUAN, ISNULL(d.qty_b, 0) - ISNULL(t.qty_t, 0) AS JUMLAH FROM db_barang AS b LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS qty_b FROM db_barang_dt GROUP BY id_barang) AS d ON b.id = d.id_barang LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS qty_t FROM db_transaksi GROUP BY id_barang) AS t ON b.id = t.id_barang";
            data_barang = koneksi.dtb_command(cmmd);
            if (global.id_type == global.id_type_admin)
            {
                data_transaksi = koneksi.dtb_command("SELECT * FROM db_transaksi");
                dgvTransaksi.DataSource = koneksi.dtb_command("SELECT t.id AS ID, u.nama AS PENGGUNA, b.nama AS NAMA_BARANG, t.tgl AS TANGGAL, t.qty AS JUMLAH, b.satuan AS SATUAN, t.ket AS KETERANGAN FROM db_transaksi AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id LEFT OUTER JOIN db_user AS u ON t.id_user = u.id");
            }
            else if (global.id_type == global.id_type_barang || global.id_type == global.id_type_inventaris)
            {
                data_transaksi = koneksi.dtb_command_id("SELECT * FROM db_transaksi WHERE id_user=(@id_user)", global.id);
                dgvTransaksi.DataSource = koneksi.dtb_command_id("SELECT t.id AS ID, b.nama AS NAMA_BARANG, t.tgl AS TANGGAL, t.qty AS JUMLAH, b.satuan AS SATUAN, t.ket AS KETERANGAN FROM db_transaksi AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id WHERE t.id_user=(@id_user)", global.id);
            }

            #region DATA GRID VIEW WIDTH
            dgvTransaksi.Columns["ID"].Width = dgvTransaksi.Width * 10 / 100;
            dgvTransaksi.Columns["Nama_Barang"].Width = dgvTransaksi.Width * 25 / 100;
            dgvTransaksi.Columns["Tanggal"].Width = dgvTransaksi.Width * 11 / 100;
            dgvTransaksi.Columns["Jumlah"].Width = dgvTransaksi.Width * 7 / 100;
            dgvTransaksi.Columns["Satuan"].Width = dgvTransaksi.Width * 12 / 100;
            if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
            {
                dgvTransaksi.Columns["Pengguna"].Width = dgvTransaksi.Width * 15 / 100;
                dgvTransaksi.Columns["Keterangan"].Width = dgvTransaksi.Width * 15 / 100;
            }
            else
            { dgvTransaksi.Columns["Keterangan"].Width = dgvTransaksi.Width * 30 / 100; }
            #endregion

            #region DATA GRID VIEW ORDER
            dgvTransaksi.Columns["ID"].DisplayIndex = 0;
            if (global.id_type == global.id_type_admin || global.id_type == global.id_type_laporan)
            {
                dgvTransaksi.Columns["Pengguna"].DisplayIndex = 1;
                dgvTransaksi.Columns["Nama_Barang"].DisplayIndex = 2;
                dgvTransaksi.Columns["Tanggal"].DisplayIndex = 3;
                dgvTransaksi.Columns["Jumlah"].DisplayIndex = 4;
                dgvTransaksi.Columns["Satuan"].DisplayIndex = 5;
                dgvTransaksi.Columns["Keterangan"].DisplayIndex = 6;
            }
            else
            {
                dgvTransaksi.Columns["Nama_Barang"].DisplayIndex = 1;
                dgvTransaksi.Columns["Tanggal"].DisplayIndex = 2;
                dgvTransaksi.Columns["Jumlah"].DisplayIndex = 3;
                dgvTransaksi.Columns["Satuan"].DisplayIndex = 4;
                dgvTransaksi.Columns["Keterangan"].DisplayIndex = 5;
            }
            #endregion

            //dgvBarang.Columns[0].Visible = false;

            cmbBarang.Items.Clear();
            foreach (DataRow row in data_barang.Rows)
            { cmbBarang.Items.Add(row["Nama_Barang"]); }

            clear();
        }

        private void clear()
        {
            lblID.Text = "[ ID Barang ]";
            cmbBarang.SelectedIndex = 0;
            dtpBarang.Value = DateTime.Today;
            txtQty.Text = string.Empty;
            txtKet.Text = string.Empty;
        }

        private global.StatusButtonSimpan status_button_simpan
        {
            set
            {
                sts_btn_simpan = value;
                switch (status_button_simpan)
                { 
                    case global.StatusButtonSimpan.simpan:
                        btnSimpan.Text = "SIMPAN";
                        btnSimpan.Image = global::Program.Properties.Resources.save;
                        btnUpdate.Enabled = false;
                        btnHapus.Enabled = false;
                        break;
                    case global.StatusButtonSimpan.tambah:
                        btnSimpan.Text = "TAMBAH";
                        btnSimpan.Image = global::Program.Properties.Resources.tambah;
                        btnUpdate.Enabled = true;
                        btnHapus.Enabled = true;
                        break;
                }
            }
            get { return sts_btn_simpan; }
        }

        private bool notnull
        {
            get
            {
                if (txtQty.Text == string.Empty && txtKet.Text == string.Empty)
                {
                    MessageBox.Show("ISI DATA DENGAN LENGKAP !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                int i;
                if (!int.TryParse(txtQty.Text, out i))
                {
                    MessageBox.Show("ISI DATA DENGAN BENAR !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (int.Parse(txtQty.Text) > int.Parse(lblJumlah.Text))
                {
                    MessageBox.Show("JUMLAH PENGAMBILAN LEBIH DARI STOK BARANG !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region EVENT ARGS
        private void cmbBarang_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            lblJumlah.Text = data_barang.Rows[cmbBarang.SelectedIndex]["Jumlah"].ToString();
            lblSatuan.Text = data_barang.Rows[cmbBarang.SelectedIndex]["Satuan"].ToString();
        }

        private void dgvTransaksi_Click(object sender, DataGridViewCellEventArgs e)
        {
            status_button_simpan = global.StatusButtonSimpan.tambah;
            if (e.RowIndex != -1)
            {
                lblID.Text = data_transaksi.Rows[e.RowIndex]["id"].ToString();
                for (int i = 0; i < cmbBarang.Items.Count; i++)
                {
                    if (data_barang.Rows[i]["ID"].ToString().Trim() == data_transaksi.Rows[e.RowIndex]["id_barang"].ToString().Trim())
                    { cmbBarang.SelectedIndex = i; break; }
                }
                dtpBarang.Value = DateTime.Parse(data_transaksi.Rows[e.RowIndex]["tgl"].ToString());
                txtQty.Text = data_transaksi.Rows[e.RowIndex]["qty"].ToString();
                txtKet.Text = data_transaksi.Rows[e.RowIndex]["ket"].ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(data_transaksi.Rows[0]["tgl"]);
            switch (status_button_simpan)
            {
                case global.StatusButtonSimpan.tambah:
                    status_button_simpan = global.StatusButtonSimpan.simpan;
                    clear();
                    break;
                case global.StatusButtonSimpan.simpan:
                    if (notnull)
                    {
                        if (MessageBox.Show("APAKAH ANDA INGIN MENYIMPAN DATA ?", "SIMPAN DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int _id = 1;
                            var _jml_transaksi = koneksi.dtb_command("SELECT id FROM db_transaksi");
                            if (_jml_transaksi.Rows.Count > 0)
                            {
                                _jml_transaksi = koneksi.dtb_command("SELECT MAX(id) as max_id FROM db_transaksi");
                                _id = int.Parse(_jml_transaksi.Rows[0]["max_id"].ToString()) + 1;
                            }
                            _jml_transaksi.Dispose();
                            var _id_brg = data_barang.Rows[cmbBarang.SelectedIndex]["id"].ToString();
                            var _id_usr = global.id;
                            var _tgl = dtpBarang.Value;
                            var _qty = int.Parse(txtQty.Text);
                            var _ket = txtKet.Text;
                            if (koneksi.query_transaksi("INSERT", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                            {
                                update_tabel();
                                MessageBox.Show("DATA BERHASIL DISIMPAN !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (notnull)
            {
                if (MessageBox.Show("APAKAH ANDA INGIN MENGUBAH DATA ?", "UPDATE DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var _id = int.Parse(lblID.Text);
                    var _id_brg = data_barang.Rows[cmbBarang.SelectedIndex]["id"].ToString();
                    var _id_usr = global.id;
                    var _tgl = dtpBarang.Value;
                    var _qty = int.Parse(txtQty.Text);
                    var _ket = txtKet.Text;
                    if (koneksi.query_transaksi("UPDATE", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                    {
                        update_tabel();
                        status_button_simpan = global.StatusButtonSimpan.simpan;
                        MessageBox.Show("DATA BERHASIL DIRUBAH !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "[ ID Barang ]")
            {
                if (MessageBox.Show("APAKAH ANDA INGIN MENGHAPUS DATA ?", "HAPUS DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var _id = int.Parse(lblID.Text);
                    var _id_brg = data_barang.Rows[cmbBarang.SelectedIndex]["id"].ToString();
                    var _id_usr = global.id;
                    var _tgl = dtpBarang.Value;
                    var _qty = int.Parse(txtQty.Text);
                    var _ket = txtKet.Text;
                    if (koneksi.query_transaksi("DELETE", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                    {
                        update_tabel();
                        status_button_simpan = global.StatusButtonSimpan.simpan;
                        MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
>>>>>>> Stashed changes
        }
    }
}
