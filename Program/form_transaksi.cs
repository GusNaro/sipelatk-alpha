﻿using System;
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
        private DataTable data_barang, data_transaksi;
        private bool sts_btn_simpan;

        public form_transaksi()
        {
            InitializeComponent();

            data_barang = new DataTable();
            data_transaksi = new DataTable();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            update_tabel();
            status_button_simpan = true;

            base.OnVisibleChanged(e);
        }

        #region METHOD
        private void update_tabel()
        {
            var cmmd = "SELECT b.id AS ID, b.nama AS Nama_Barang, b.satuan AS Satuan, ISNULL(d.qty_b, 0) - ISNULL(t.qty_t, 0) AS Jumlah FROM db_barang AS b LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS qty_b FROM db_barang_dt GROUP BY id_barang) AS d ON b.id = d.id_barang LEFT OUTER JOIN (SELECT id_barang, SUM(qty) AS qty_t FROM db_transaksi GROUP BY id_barang) AS t ON b.id = t.id_barang";
            data_barang = koneksi.dtb_command(cmmd);
            if (global.id_type == global.id_type_admin)
            {
                data_transaksi = koneksi.dtb_command("SELECT * FROM db_transaksi");
                dgvTransaksi.DataSource = koneksi.dtb_command("SELECT t.id AS ID, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan, u.nama AS Pengguna FROM db_transaksi AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id LEFT OUTER JOIN db_user AS u ON t.id_user = u.id");
            }
            else if (global.id_type == global.id_type_barang || global.id_type == global.id_type_inventaris)
            {
                data_transaksi = koneksi.dtb_command_id("SELECT * FROM db_transaksi WHERE id_user=(@id_user)", global.id);
                dgvTransaksi.DataSource = koneksi.dtb_command_id("SELECT t.id AS ID, b.nama AS Nama_Barang, t.tgl AS Tanggal, t.qty AS Jumlah, b.satuan AS Satuan, t.ket AS Keterangan FROM db_transaksi AS t LEFT OUTER JOIN db_barang AS b ON t.id_barang = b.id WHERE t.id_user=(@id_user)", global.id);
            }

            cmbBarang.Items.Clear();
            foreach (DataRow row in data_barang.Rows)
            { cmbBarang.Items.Add(row["Nama_Barang"]); }

            lblID.Text = "[ ID Barang ]";
            cmbBarang.SelectedIndex = 0;
            dtpBarang.Value = DateTime.Today;
            txtQty.Text = string.Empty;
            txtKet.Text = string.Empty;
        }

        private bool status_button_simpan
        {
            set
            {
                sts_btn_simpan = value;
                switch (status_button_simpan)
                { 
                    case true:
                        btnSimpan.Text = "SIMPAN";
                        btnUpdate.Enabled = false;
                        btnHapus.Enabled = false;
                        break;
                    case false:
                        btnSimpan.Text = "TAMBAH";
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
            lblJumlah.Text = data_barang.Rows[cmbBarang.SelectedIndex]["jumlah"].ToString();
            lblSatuan.Text = data_barang.Rows[cmbBarang.SelectedIndex]["Satuan"].ToString();
        }

        private void dgvTransaksi_Click(object sender, DataGridViewCellEventArgs e)
        {
            status_button_simpan = false;
            if (e.RowIndex != -1)
            {
                lblID.Text = data_transaksi.Rows[e.RowIndex]["id"].ToString();
                for (int i = 0; i < cmbBarang.Items.Count; i++)
                {
                    if (data_barang.Rows[i]["ID"].ToString() == data_transaksi.Rows[e.RowIndex]["id_barang"].ToString())
                    { cmbBarang.SelectedIndex = i; break; }
                }
                dtpBarang.Value = DateTime.Parse(data_transaksi.Rows[0]["tgl"].ToString());
                txtQty.Text = data_transaksi.Rows[0]["qty"].ToString();
                txtKet.Text = data_transaksi.Rows[0]["ket"].ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            switch (status_button_simpan)
            {
                case true:
                    if (notnull)
                    {
                        var _id_max = koneksi.dtb_command("SELECT MAX(id) FROM db_transaksi").Rows[0][0];
                        var _id = 1;
                        if (_id_max != "") { _id = int.Parse(_id_max.ToString()) + 1; }
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
                    break;
                case false:
                    status_button_simpan = true;
                    update_tabel();
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (notnull)
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
                    MessageBox.Show("DATA BERHASIL DIRUBAH !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (notnull)
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
                    MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}
