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
    public partial class form_user : Form
    {
        private global.StatusButtonSimpan sbs;

        public form_user()
        {
            InitializeComponent();
        }

        private void form_user_Load(object sender, EventArgs e)
        {
            load_user();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            switch (sts_btn_simpan)
            {
                case global.StatusButtonSimpan.simpan:
                    if (notnull)
                    {
                        if (MessageBox.Show("APAKAH ANDA INGIN MENYIMPAN DATA ?", "SIMPAN DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var berhasil = koneksi.user_query("INSERT", txtNRK.Text, txtNama.Text, txtPass1.Text, cmbHak.SelectedIndex + 1, cmbCabang.Items[cmbCabang.SelectedIndex].ToString());
                            if (berhasil)
                            {
                                MessageBox.Show("DATA BERHASIL DISIMPAN !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                load_user();
                            }
                        }
                    }
                    break;
                case global.StatusButtonSimpan.tambah:
                    sts_btn_simpan = global.StatusButtonSimpan.simpan;
                    clear();
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (notnull)
            {
                if (MessageBox.Show("APAKAH ANDA INGIN MENGUBAH DATA ?", "UBAH DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var berhasil = koneksi.user_query("UPDATE", txtNRK.Text, txtNama.Text, txtPass1.Text, cmbHak.SelectedIndex + 1, cmbCabang.Items[cmbCabang.SelectedIndex].ToString());
                    if (berhasil)
                    {
                        MessageBox.Show("DATA BERHASIL DIUPDATE !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_user();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtNRK.Text != string.Empty)
            {
                if (MessageBox.Show("APAKAH ANDA INGIN MENGUBAH DATA ?", "UBAH DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var berhasil = koneksi.user_query("DELETE", txtNRK.Text, txtNama.Text, txtPass1.Text, cmbHak.SelectedIndex + 1, cmbCabang.Items[cmbCabang.SelectedIndex].ToString());
                    if (berhasil)
                    {
                        MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_user();
                    }
                }
            }
            else
            { MessageBox.Show("PILIH DATA YANG INGIN DIHAPUS !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvUser_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sts_btn_simpan = global.StatusButtonSimpan.tambah;
                var dgv_row = dgvUser.Rows[e.RowIndex];
                txtNRK.Text = dgv_row.Cells[0].Value.ToString();
                txtNama.Text = dgv_row.Cells[1].Value.ToString();
                txtPass1.Text = dgv_row.Cells[2].Value.ToString();
                txtPass2.Text = string.Empty;
                #region HAK AKSES
                switch (dgv_row.Cells[3].Value.ToString())
                {
                    case "Admin":
                        cmbHak.SelectedIndex = 0;
                        break;
                    case "Barang":
                        cmbHak.SelectedIndex = 1;
                        break;
                    case "Inventaris":
                        cmbHak.SelectedIndex = 2;
                        break;
                    case "Laporan":
                        cmbHak.SelectedIndex = 3;
                        break;
                }
                #endregion
                #region CABANG
                switch (dgv_row.Cells[4].Value.ToString())
                {
                    case "Renon":
                        cmbCabang.SelectedIndex = 0;
                        break;
                    case "Denpasar":
                        cmbCabang.SelectedIndex = 1;
                        break;
                    case "Badung":
                        cmbCabang.SelectedIndex = 2;
                        break;
                    case "Mangupura":
                        cmbCabang.SelectedIndex = 3;
                        break;
                    case "Tabanan":
                        cmbCabang.SelectedIndex = 4;
                        break;
                    case "Singaraja":
                        cmbCabang.SelectedIndex = 5;
                        break;
                    case "Seririt":
                        cmbCabang.SelectedIndex = 6;
                        break;
                    case "Negara":
                        cmbCabang.SelectedIndex = 7;
                        break;
                    case "Gianyar":
                        cmbCabang.SelectedIndex = 8;
                        break;
                    case "Ubud":
                        cmbCabang.SelectedIndex = 9;
                        break;
                    case "Klungkung":
                        cmbCabang.SelectedIndex = 10;
                        break;
                    case "Bangli":
                        cmbCabang.SelectedIndex = 11;
                        break;
                    case "Karangasem":
                        cmbCabang.SelectedIndex = 12;
                        break;
                    case "Mataram":
                        cmbCabang.SelectedIndex = 13;
                        break;
                }
                #endregion
            }
        }

        private void load_user()
        {
            sts_btn_simpan = global.StatusButtonSimpan.simpan;
            clear();
            var _data_user = koneksi.dtb_command("SELECT id AS ID_USER, nama AS NAMA, pass AS PASSOWRD,  CASE type WHEN 1 THEN 'Admin' WHEN 2 THEN 'Barang' WHEN 3 THEN 'Inventaris' WHEN 4 THEN 'Laporan' END AS TYPE_USER, cabang AS CABANG FROM db_user");
            dgvUser.DataSource = _data_user;
            dgvUser.Columns[0].Width = dgvUser.Width * 15 / 100;
            dgvUser.Columns[1].Width = dgvUser.Width * 25 / 100;
            dgvUser.Columns[2].Width = dgvUser.Width * 20 / 100;
            dgvUser.Columns[3].Width = dgvUser.Width * 15 / 100;
            dgvUser.Columns[4].Width = dgvUser.Width * 20 / 100;
        }

        private void clear()
        {
            txtNRK.Text = string.Empty;
            txtNama.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;
            cmbHak.SelectedIndex = 0;
            cmbCabang.SelectedIndex = 0;
        }

        private bool notnull
        {
            get
            {
                if (txtNRK.Text == "" || txtNama.Text == "" || txtPass1.Text == "" || txtPass1.Text != txtPass2.Text)
                {
                    MessageBox.Show("ISI DATA DENGAN BENAR !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
        }

        private global.StatusButtonSimpan sts_btn_simpan
        {
            set
            {
                switch (value)
                {
                    case global.StatusButtonSimpan.simpan:
                        btnSimpan.Text = "SIMPAN";
                        btnSimpan.Image = global::Program.Properties.Resources.save;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        txtNRK.Enabled = true;
                        break;
                    case global.StatusButtonSimpan.tambah:
                        btnSimpan.Text = "TAMBAH";
                        btnSimpan.Image = global::Program.Properties.Resources.tambah;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        txtNRK.Enabled = false;
                        break;
                }
                sbs = value;
            }
            get { return sbs; }
        }

    }
}
