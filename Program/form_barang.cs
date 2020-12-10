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
<<<<<<< Updated upstream
=======
        private const string query_data_batang = "SELECT id AS ID_BARANG, nama AS NAMA_BARANG, satuan AS SATUAN, harga AS HARGA FROM db_barang";
        private const string query_data_batang_dt_a = "SELECT d.id AS ID, b.nama AS NAMA_BARANG, d.tgl AS TANGGAL, d.qty AS JUMLAH, b.satuan AS SATUAN, u.nama AS PENGGUNA, d.ket AS KETERANGAN FROM db_barang_dt AS d LEFT JOIN db_barang AS b ON d.id_barang = b.id LEFT JOIN db_user AS u ON d.id_user = u.id";
        private const string query_data_batang_dt_b = "SELECT d.id AS ID, b.nama AS NAMA_BARANG, d.tgl AS TANGGAL, d.qty AS JUMLAH, b.satuan AS SATUAN, d.ket AS KETERANGAN FROM db_barang_dt AS d LEFT JOIN db_barang AS b ON d.id_barang = b.id WHERE d.id_user=(@id_user)";

        private DataTable data_barang, data_barang_dt;
        private global.StatusBarang sts_brg;
        private global.StatusButtonSimpan sts_btn_simpan;
        
>>>>>>> Stashed changes
        public form_barang()
        {
            InitializeComponent();
        }
<<<<<<< Updated upstream
=======

        private void form_barang_Load(object sender, EventArgs e)
        {
            data_barang = koneksi.dtb_command(query_data_batang);
            data_barang_dt = new DataTable();

            status_barang = global.StatusBarang.edit_detail_barang;
            status_button_simpan = global.StatusButtonSimpan.simpan;
            update_tabel();
            clear();
        }

        #region METHOD 
        private void update_tabel()
        {
            switch (status_barang)
            {
                case global.StatusBarang.edit_detail_barang:
                    cmbNamaBarang.Items.Clear();
                    foreach (DataRow row in data_barang.Rows)
                    { cmbNamaBarang.Items.Add(row["Nama_Barang"]); }

                    if (global.id_type == global.id_type_admin)
                    { data_barang_dt = koneksi.dtb_command(query_data_batang_dt_a); }
                    else if (global.id_type == global.id_type_barang || global.id_type == global.id_type_inventaris)
                    { data_barang_dt = koneksi.dtb_command_id(query_data_batang_dt_b, global.id); }
                    
                    dgvBarang.DataSource = data_barang_dt;

                    #region DATA GRID VIEW WIDTH
                    dgvBarang.Columns["ID"].Width = dgvBarang.Width * 8 / 100;
                    dgvBarang.Columns["Nama_Barang"].Width = dgvBarang.Width * 22 / 100;
                    dgvBarang.Columns["Tanggal"].Width = dgvBarang.Width * 12 / 100;
                    dgvBarang.Columns["Jumlah"].Width = dgvBarang.Width * 8 / 100;
                    dgvBarang.Columns["SATUAN"].Width = dgvBarang.Width * 15 / 100;
                    if (global.id_type == global.id_type_admin)
                    {
                        dgvBarang.Columns["PENGGUNA"].Width = dgvBarang.Width * 15 / 100;
                        dgvBarang.Columns["KETERANGAN"].Width = dgvBarang.Width * 15 / 100;
                    }
                    else { dgvBarang.Columns["KETERANGAN"].Width = dgvBarang.Width * 30 / 100; }
                    #endregion

                    #region DATA GRID VIEW ORDER
                    dgvBarang.Columns["ID"].DisplayIndex = 0;
                    if (global.id_type == global.id_type_admin)
                    {
                        dgvBarang.Columns["PENGGUNA"].DisplayIndex = 1;
                        dgvBarang.Columns["NAMA_BARANG"].DisplayIndex = 2;
                        dgvBarang.Columns["TANGGAL"].DisplayIndex = 3;
                        dgvBarang.Columns["JUMLAH"].DisplayIndex = 4;
                        dgvBarang.Columns["SATUAN"].DisplayIndex = 5;
                        dgvBarang.Columns["KETERANGAN"].DisplayIndex = 6;
                    }
                    else
                    {
                        dgvBarang.Columns["NAMA_BARANG"].DisplayIndex = 1;
                        dgvBarang.Columns["TANGGAL"].DisplayIndex = 2;
                        dgvBarang.Columns["JUMLAH"].DisplayIndex = 3;
                        dgvBarang.Columns["SATUAN"].DisplayIndex = 4;
                        dgvBarang.Columns["KETERANGAN"].DisplayIndex = 5;
                    }
                    #endregion
                    break;
                case global.StatusBarang.edit_barang:
                    data_barang = koneksi.dtb_command(query_data_batang);
                    dgvBarang.DataSource = data_barang;

                    #region DATA GRID VIEW WIDTH
                    dgvBarang.Columns["ID_BARANG"].Width = dgvBarang.Width * 10 / 100;
                    dgvBarang.Columns["NAMA_BARANG"].Width = dgvBarang.Width * 35 / 100;
                    dgvBarang.Columns["SATUAN"].Width = dgvBarang.Width * 20 / 100;
                    dgvBarang.Columns["HARGA"].Width = dgvBarang.Width * 20 / 100;
                    dgvBarang.Columns["HARGA"].DefaultCellStyle.Format = "C";
                    #endregion

                    #region DATA GRID VIEW ORDER
                    dgvBarang.Columns["ID_BARANG"].DisplayIndex = 0;
                    dgvBarang.Columns["NAMA_BARANG"].DisplayIndex = 1;
                    dgvBarang.Columns["SATUAN"].DisplayIndex = 2;
                    dgvBarang.Columns["HARGA"].DisplayIndex = 3;
                    #endregion

                    //dgvBarang.Columns[0].Visible = false;
                    break;
            }
        }

        private global.StatusBarang status_barang
        {
            set
            {
                sts_brg = value;
                switch (value)
                {
                    case global.StatusBarang.edit_detail_barang:
                        cmbNamaBarang.Enabled = true;
                        dtpTanggal.Enabled = true;
                        txtQty.Enabled = true;
                        txtKet.Enabled = true;
                        grbDetail.BackColor = System.Drawing.Color.Silver;
                        txtIdB.Enabled = false;
                        txtNamaB.Enabled = false;
                        txtSatuanB.Enabled = false;
                        txtHargaB.Enabled = false;
                        grbBarang.BackColor = System.Drawing.Color.WhiteSmoke;
                        break;
                    case global.StatusBarang.edit_barang:
                        cmbNamaBarang.Enabled = false;
                        dtpTanggal.Enabled = false;
                        txtQty.Enabled = false;
                        txtKet.Enabled = false;
                        grbDetail.BackColor = System.Drawing.Color.WhiteSmoke;
                        txtIdB.Enabled = true;
                        txtNamaB.Enabled = true;
                        txtSatuanB.Enabled = true;
                        txtHargaB.Enabled = true;
                        grbBarang.BackColor = System.Drawing.Color.Silver;
                        break;
                }
            }
            get { return sts_brg; }
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
                int _i;
                switch (status_barang)
                {
                    case global.StatusBarang.edit_barang:
                        if (txtIdB.Text == string.Empty || txtNamaB.Text == string.Empty || txtSatuanB.Text == string.Empty || txtHargaB.Text == string.Empty)
                        {
                            MessageBox.Show("ISI DATA DENGAN LENGKAP !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else if (!int.TryParse(txtHargaB.Text, out _i))
                        {
                            MessageBox.Show("ISI DATA DENGAN BENAR !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        foreach (DataRow row in data_barang.Rows)
                        {
                            if (row["ID_Barang"].ToString().Trim() == txtIdB.Text.Trim() || row["Nama_Barang"].ToString().ToLower().Trim() == txtNamaB.Text.ToLower().Trim())
                            {
                                MessageBox.Show("ID / NAMA BARANG SUDAH TERDAFTAR !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        break;
                    case global.StatusBarang.edit_detail_barang:
                        if (txtQty.Text == string.Empty || txtKet.Text == string.Empty)
                        {
                            MessageBox.Show("ISI DATA DENGAN LENGKAP !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else if (!int.TryParse(txtQty.Text, out _i))
                        {
                            MessageBox.Show("ISI DATA DENGAN BENAR !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        break;
                }
                return true;
            }
        }

        private void clear()
        {
            lblID.Text = "[ ID Barang ]";
            cmbNamaBarang.SelectedIndex = 0;
            lblSatuan.Text = data_barang.Rows[cmbNamaBarang.SelectedIndex]["Satuan"].ToString();
            dtpTanggal.Value = DateTime.Today;
            txtQty.Text = string.Empty;
            txtKet.Text = string.Empty;
            txtIdB.Text = string.Empty;
            txtNamaB.Text = string.Empty;
            txtSatuanB.Text = string.Empty;
            txtHargaB.Text = string.Empty;
        }
        #endregion

        #region EVENT ARGS
        private void cmbNamaBarang_SelectedIndexChanged(object sender, System.EventArgs e)
        { lblSatuan.Text = data_barang.Rows[cmbNamaBarang.SelectedIndex]["Satuan"].ToString(); }

        private void dgvUser_Click(object sender, DataGridViewCellEventArgs e)
        {
            status_button_simpan = global.StatusButtonSimpan.tambah;
            if (e.RowIndex != -1)
            {
                var dgv_row = dgvBarang.Rows[e.RowIndex];
                switch (status_barang)
                {
                    case global.StatusBarang.edit_barang:
                        txtIdB.Text = dgv_row.Cells["ID_Barang"].Value.ToString();
                        txtIdB.Enabled = false;
                        txtNamaB.Text = dgv_row.Cells["Nama_Barang"].Value.ToString();
                        txtSatuanB.Text = dgv_row.Cells["Satuan"].Value.ToString();
                        txtHargaB.Text = dgv_row.Cells["Harga"].Value.ToString();
                        break;
                    case global.StatusBarang.edit_detail_barang:
                        lblID.Text = dgv_row.Cells["ID"].Value.ToString();
                        for (int i = 0; i < cmbNamaBarang.Items.Count; i++)
                        {
                            if (cmbNamaBarang.Items[i].ToString() == dgv_row.Cells["Nama_Barang"].Value.ToString())
                            {
                                cmbNamaBarang.SelectedIndex = i; 
                                break;
                            }
                        }
                        dtpTanggal.Value = DateTime.Parse(dgv_row.Cells["Tanggal"].Value.ToString());
                        txtQty.Text = dgv_row.Cells["Jumlah"].Value.ToString();
                        lblSatuan.Text = dgv_row.Cells["Satuan"].Value.ToString();
                        txtKet.Text = dgv_row.Cells["Keterangan"].Value.ToString();
                        break;
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            switch (status_button_simpan)
            {
                case global.StatusButtonSimpan.tambah:
                    clear();
                    if (status_barang == global.StatusBarang.edit_barang)
                    { txtIdB.Enabled = true; }
                    status_button_simpan = global.StatusButtonSimpan.simpan;
                    break;
                case global.StatusButtonSimpan.simpan:
                    switch (status_barang)
                    {
                        case global.StatusBarang.edit_barang:
                            if (notnull)
                            {
                                if (MessageBox.Show("APAKAH ANDA INGIN MENYIMPAN DATA ?", "SIMPAN DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if (koneksi.query_barang("INSERT", txtIdB.Text, txtNamaB.Text, txtSatuanB.Text, int.Parse(txtHargaB.Text)))
                                    {
                                        update_tabel();
                                        clear();
                                        MessageBox.Show("DATA BERHASIL DISIMPAN !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            break;
                        case global.StatusBarang.edit_detail_barang:
                            if (notnull)
                            {
                                if (MessageBox.Show("APAKAH ANDA INGIN MENYIMPAN DATA ?", "SIMPAN DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    int _id = 1;
                                    var _jml_barang = koneksi.dtb_command("SELECT id FROM db_barang_dt");
                                    if (_jml_barang.Rows.Count > 0)
                                    {
                                        _jml_barang = koneksi.dtb_command("SELECT MAX(id) AS max_id FROM db_barang_dt");
                                        _id = int.Parse(_jml_barang.Rows[0]["max_id"].ToString()) + 1;
                                    }
                                    _jml_barang.Dispose();
                                    var _id_brg = data_barang.Rows[cmbNamaBarang.SelectedIndex]["ID_Barang"].ToString();
                                    var _id_usr = global.id;
                                    var _tgl = dtpTanggal.Value;
                                    var _qty = int.Parse(txtQty.Text);
                                    var _ket = txtKet.Text;
                                    if (koneksi.query_barang_dt("INSERT", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                                    {
                                        update_tabel();
                                        clear();
                                        MessageBox.Show("DATA BERHASIL DISIMPAN !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            break;
                    }
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (status_barang)
            {
                case global.StatusBarang.edit_barang:
                    if (notnull)
                    {
                        if (MessageBox.Show("APAKAH ANDA INGIN MENGUBAH DATA ?", "UPDATE DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (koneksi.query_barang("UPDATE", txtIdB.Text, txtNamaB.Text, txtSatuanB.Text, int.Parse(txtHargaB.Text)))
                            {
                                update_tabel();
                                clear();
                                status_button_simpan = global.StatusButtonSimpan.simpan;
                                MessageBox.Show("DATA BERHASIL DIRUBAH !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
                case global.StatusBarang.edit_detail_barang:
                    if (notnull)
                    {
                        if (MessageBox.Show("APAKAH ANDA INGIN MENGUBAH DATA ?", "UPDATE DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var _id = int.Parse(lblID.Text);
                            var _id_brg = data_barang.Rows[cmbNamaBarang.SelectedIndex]["ID_Barang"].ToString();
                            var _id_usr = global.id;
                            var _tgl = dtpTanggal.Value;
                            var _qty = int.Parse(txtQty.Text);
                            var _ket = txtKet.Text;
                            if (koneksi.query_barang_dt("UPDATE", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                            {
                                update_tabel();
                                clear();
                                status_button_simpan = global.StatusButtonSimpan.simpan;
                                MessageBox.Show("DATA BERHASIL DIRUBAH !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    break;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            switch (status_barang)
            {
                case global.StatusBarang.edit_barang:
                    if (txtIdB.Text != string.Empty)
                    {
                        if (!koneksi.status_id_barang_dt(txtIdB.Text.Trim()) && !koneksi.status_id_barang_transaksi(txtIdB.Text.Trim()))
                        {
                            if (MessageBox.Show("APAKAH ANDA INGIN MENGHAPUS DATA ?", "HAPUS DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (koneksi.query_barang("DELETE", txtIdB.Text, txtNamaB.Text, txtSatuanB.Text, int.Parse(txtHargaB.Text)))
                                {
                                    update_tabel();
                                    clear();
                                    status_button_simpan = global.StatusButtonSimpan.simpan;
                                    MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        { MessageBox.Show("HAPUS DATA PADA INPUT BARANG DAN INVENTARIS TERLEBIH DAHULU !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    { MessageBox.Show("PILIH DATA YANG INGIN DIHAPUS !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
                case global.StatusBarang.edit_detail_barang:
                    if (lblID.Text != "[ ID Barang ]")
                    {
                        if (MessageBox.Show("APAKAH ANDA INGIN MENGHAPUS DATA ?", "HAPUS DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var _id = int.Parse(lblID.Text);
                            var _id_brg = data_barang.Rows[cmbNamaBarang.SelectedIndex]["ID_Barang"].ToString();
                            var _id_usr = global.id;
                            var _tgl = dtpTanggal.Value;
                            var _qty = int.Parse(txtQty.Text);
                            var _ket = txtKet.Text;
                            if (koneksi.query_barang_dt("DELETE", _id, _id_brg, _id_usr, _tgl, _qty, _ket))
                            {
                                update_tabel();
                                clear();
                                status_button_simpan = global.StatusButtonSimpan.simpan;
                                MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    { MessageBox.Show("PILIH DATA YANG INGIN DIHAPUS !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
            }
            
        }

        private void btnPindah_Click(object sender, EventArgs e)
        {
            switch (status_barang)
            { 
                case global.StatusBarang.edit_barang:
                    status_barang = global.StatusBarang.edit_detail_barang;
                    btnPindah.Text = ">>>";
                    txtQty.Focus();
                    break;
                case global.StatusBarang.edit_detail_barang:
                    status_barang = global.StatusBarang.edit_barang;
                    btnPindah.Text = "<<<";
                    txtIdB.Focus();
                    break;
            }
            update_tabel();
            clear();
            status_button_simpan = global.StatusButtonSimpan.simpan;
        }
        #endregion
>>>>>>> Stashed changes
    }
}
