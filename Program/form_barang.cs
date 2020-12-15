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
    public partial class form_barang : UserControl
    {
        enum StatusBarang { edit_barang, edit_detail_barang }

        private DataTable data_barang;
        private bool sts_brg;
        private bool sts_btn_simpan;

        public form_barang()
        {
            InitializeComponent();
            data_barang = new DataTable();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            //var x = koneksi.dtb_command("SELECT MAX(id) FROM db_barang_dt").Rows[0][0];
            //MessageBox.Show(id_barang_dt.ToString());
            update_tabel();
            status_barang = true;
            status_button_simpan = true;

            base.OnVisibleChanged(e);
        }

        #region METHOD 
        private void update_tabel()
        {
            data_barang = koneksi.dtb_command("SELECT * FROM db_barang");
            switch (status_barang)
            {
                case true:
                    cmbNamaBarang.Items.Clear();
                    foreach (DataRow row in data_barang.Rows)
                    { cmbNamaBarang.Items.Add(row["nama"]); }

                    lblID.Text = "[ ID Barang ]";
                    cmbNamaBarang.SelectedIndex = 0;
                    lblSatuan.Text = data_barang.Rows[cmbNamaBarang.SelectedIndex]["satuan"].ToString();
                    dtpTanggal.Value = DateTime.Today;
                    txtQty.Text = string.Empty;
                    txtKet.Text = string.Empty;

                    if (global.id_type == global.id_type_admin)
                    { dgvBarang.DataSource = koneksi.dtb_command("SELECT d.id AS ID, b.nama AS Nama_Barang, d.tgl AS Tanggal, d.qty AS Jumlah, b.satuan AS Satuan, d.ket AS Keterangan, u.nama AS Pengguna FROM db_barang_dt AS d LEFT JOIN db_barang AS b ON d.id_barang = b.id LEFT JOIN db_user AS u ON d.id_user = u.id"); }
                    else if (global.id_type == global.id_type_barang || global.id_type == global.id_type_inventaris)
                    { dgvBarang.DataSource = koneksi.dtb_command_id("SELECT d.id AS ID, b.nama AS Nama_Barang, d.tgl AS Tanggal, d.qty AS Jumlah, b.satuan AS Satuan, d.ket AS Keterangan FROM db_barang_dt AS d LEFT JOIN db_barang AS b ON d.id_barang = b.id WHERE d.id_user=(@id_user)", global.id); }
                    break;
                case false:
                    dgvBarang.DataSource = koneksi.dtb_command("SELECT id AS ID_Barang, nama AS Nama_Barang, satuan AS Satuan FROM db_barang");
                    txtIdB.Text = string.Empty;
                    txtNamaB.Text = string.Empty;
                    txtSatuanB.Text = string.Empty;
                    break;
            }
        }

        private bool status_barang
        {
            set
            {
                sts_brg = value;
                switch (value)
                {
                    case true:
                        cmbNamaBarang.Enabled = true;
                        dtpTanggal.Enabled = true;
                        txtQty.Enabled = true;
                        txtKet.Enabled = true;
                        txtIdB.Enabled = false;
                        txtNamaB.Enabled = false;
                        txtSatuanB.Enabled = false;
                        break;
                    case false:
                        cmbNamaBarang.Enabled = false;
                        dtpTanggal.Enabled = false;
                        txtQty.Enabled = false;
                        txtKet.Enabled = false;
                        txtIdB.Enabled = true;
                        txtNamaB.Enabled = true;
                        txtSatuanB.Enabled = true;
                        break;
                }
                update_tabel();
            }
            get { return sts_brg; }
        }

        private bool status_button_simpan
        {
            set
            {
                sts_btn_simpan = value;
                switch (status_button_simpan)
                {
                    case true:
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
                switch (status_barang)
                {
                    case true:
                        return txtQty.Text != "" && txtKet.Text != "";
                    case false:
                        return txtIdB.Text != "" && txtNamaB.Text != "" && txtSatuanB.Text != "";
                }
                return false;
            }
        }
        #endregion

        #region EVENT ARGS
        private void cmbNamaBarang_SelectedIndexChanged(object sender, System.EventArgs e)
        { lblSatuan.Text = data_barang.Rows[cmbNamaBarang.SelectedIndex]["satuan"].ToString(); }

        private void dgvUser_Click(object sender, DataGridViewCellEventArgs e)
        {
            status_button_simpan = false;
            if (e.RowIndex != -1)
            {
                var dgv_row = dgvBarang.Rows[e.RowIndex];
                switch (status_barang)
                {
                    case true:
                        lblID.Text = dgv_row.Cells[0].Value.ToString();
                        for (int i = 0; i < cmbNamaBarang.Items.Count; i++)
                        {
                            if (cmbNamaBarang.Items[i].ToString() == dgv_row.Cells[1].Value.ToString())
                            { cmbNamaBarang.SelectedIndex = i; break; }
                        }
                        dtpTanggal.Value = DateTime.Parse(dgv_row.Cells[2].Value.ToString());
                        txtQty.Text = dgv_row.Cells[3].Value.ToString();
                        lblSatuan.Text = dgv_row.Cells[4].Value.ToString();
                        txtKet.Text = dgv_row.Cells[5].Value.ToString();
                        break;
                    case false:
                        txtIdB.Text = dgv_row.Cells[0].Value.ToString();
                        txtNamaB.Text = dgv_row.Cells[1].Value.ToString();
                        txtSatuanB.Text = dgv_row.Cells[2].Value.ToString();
                        break;
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            switch (btnSimpan.Text)
            {
                case "TAMBAH":
                    update_tabel();
                    status_button_simpan = true;
                    btnSimpan.Text = "SIMPAN";
                    break;
                default:
                    switch (status_barang)
                    {
                        case true:
                            if (notnull)
                            {
                                if (MessageBox.Show("APAKAH ANDA INGIN MENYIMPAN DATA ?", "SIMPAN DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    var _id_max = koneksi.dtb_command("SELECT MAX(id) FROM db_barang_dt").Rows[0][0];
                                    var _id = int.Parse(_id_max.ToString()) + 1;
                                    var _id_brg = data_barang.Rows[cmbNamaBarang.SelectedIndex]["id"].ToString();
                                    var _id_usr = global.id;
                                    var _tgl = dtpTanggal.Value;
                                    var _qty = int.Parse(txtQty.Text);
                                    var _ket = txtKet.Text;
                                    if (koneksi.query_barang_dt("INSERT", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                                    {
                                        update_tabel();
                                        MessageBox.Show("DATA BERHASIL DISIMPAN !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            { MessageBox.Show("ISI DATA DENGAN LENGKAP !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            break;
                        case false:
                            if (notnull)
                            {
                                bool _status_brg = true;
                                foreach (DataRow row in data_barang.Rows)
                                {
                                    if (row["id"].ToString() == txtIdB.Text.Trim() || row["nama"].ToString().ToLower() == txtNamaB.Text.ToLower())
                                    { _status_brg = false; break; }
                                }
                                if (_status_brg)
                                {
                                    if (MessageBox.Show("APAKAH ANDA INGIN MENYIMPAN DATA ?", "SIMPAN DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        if (koneksi.query_barang("INSERT", txtIdB.Text, txtNamaB.Text, txtSatuanB.Text))
                                        {
                                            update_tabel();
                                            MessageBox.Show("DATA BERHASIL DISIMPAN !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                else
                                { MessageBox.Show("ID / NAMA BARANG SUDAH TERDAFTAR !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else
                            { MessageBox.Show("ISI DATA DENGAN LENGKAP !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            break;
                    }
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (status_barang)
            {
                case true:
                    if (notnull && koneksi.status_id_barang_dt(int.Parse(lblID.Text)))
                    {
                        if (MessageBox.Show("APAKAH ANDA INGIN MENGUBAH DATA ?", "UPDATE DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var _id = int.Parse(lblID.Text);
                            var _id_brg = data_barang.Rows[cmbNamaBarang.SelectedIndex]["id"].ToString();
                            var _id_usr = global.id;
                            var _tgl = dtpTanggal.Value;
                            var _qty = int.Parse(txtQty.Text);
                            var _ket = txtKet.Text;
                            if (koneksi.query_barang_dt("UPDATE", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                            {
                                update_tabel();
                                MessageBox.Show("DATA BERHASIL DIRUBAH !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    { MessageBox.Show("PILIH DATA YANG INGIN DIRUBAH !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
                case false:
                    if (notnull)
                    {
                        if (MessageBox.Show("APAKAH ANDA INGIN MENGUBAH DATA ?", "UPDATE DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (koneksi.query_barang("UPDATE", txtIdB.Text, txtNamaB.Text, txtSatuanB.Text))
                            {
                                update_tabel();
                                MessageBox.Show("DATA BERHASIL DIRUBAH !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    { MessageBox.Show("ISI DATA DENGAN LENGKAP !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
            }
            
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            switch (status_barang)
            {
                case true:
                    if (notnull && koneksi.status_id_barang_dt(int.Parse(lblID.Text)))
                    {
                        if (!koneksi.status_id_barang_transaksi(data_barang.Rows[cmbNamaBarang.SelectedIndex]["id"].ToString()))
                        {
                            if (MessageBox.Show("APAKAH ANDA INGIN MENGHAPUS DATA ?", "HAPUS DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                var _id = int.Parse(lblID.Text);
                                var _id_brg = data_barang.Rows[cmbNamaBarang.SelectedIndex]["id"].ToString();
                                var _id_usr = global.id;
                                var _tgl = dtpTanggal.Value;
                                var _qty = int.Parse(txtQty.Text);
                                var _ket = txtKet.Text;
                                if (koneksi.query_barang_dt("DELETE", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                                {
                                    update_tabel();
                                    MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        { MessageBox.Show("HAPUS DATA PADA TRANSAKSI TERLEBIH DAHULU !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    { MessageBox.Show("PILIH DATA YANG INGIN DIHAPUS !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
                case false:
                    if (notnull)
                    {
                        if (!koneksi.status_id_barang(txtIdB.Text))
                        {
                            if (MessageBox.Show("APAKAH ANDA INGIN MENGHAPUS DATA ?", "HAPUS DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (koneksi.query_barang("DELETE", txtIdB.Text, txtNamaB.Text, txtSatuanB.Text))
                                {
                                    update_tabel();
                                    MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        { MessageBox.Show("HAPUS DATA PADA BARANG TERLEBIH DAHULU !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    { MessageBox.Show("ISI DATA DENGAN LENGKAP !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
            }
            
        }

        private void btnPindah_Click(object sender, EventArgs e)
        {
            status_barang = !status_barang;
            switch (status_barang)
            { 
                case true:
                    btnPindah.Text = ">>>";
                    break;
                case false:
                    btnPindah.Text = "<<<";
                    break;
            }
        }
        #endregion
    }
}
