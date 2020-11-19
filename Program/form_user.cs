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
    public partial class form_user : UserControl
    {
        public form_user()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            cmbHak.SelectedIndex = 0;
            load_user();
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var berhasil = koneksi.user_ins_upd("INSERT", txtNRK.Text, txtNama.Text, txtPass1.Text, cmbHak.SelectedIndex + 1);
            if (berhasil && notnull)
            {
                MessageBox.Show("DATA BERHASIL DISIMPAN !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_user();
            }
            else
            { MessageBox.Show("ISI DATA DENGAN BENAR !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var berhasil = koneksi.user_ins_upd("UPDATE", txtNRK.Text, txtNama.Text, txtPass1.Text, cmbHak.SelectedIndex + 1);
            if (berhasil && notnull)
            {
                MessageBox.Show("DATA BERHASIL DIUPDATE !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_user();
            } else
            { MessageBox.Show("ISI DATA DENGAN BENAR !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var berhasil = koneksi.user_delete(txtNRK.Text);
            if (berhasil && notnull)
            {
                MessageBox.Show("DATA BERHASIL DIHAPUS !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_user();
            }
            else
            { MessageBox.Show("ISI DATA DENGAN BENAR !!!", "INFORMASI", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void dgvUser_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var dgv_row = dgvUser.Rows[e.RowIndex];
                txtNRK.Text = dgv_row.Cells[0].Value.ToString();
                txtNama.Text = dgv_row.Cells[1].Value.ToString();
                txtPass1.Text = dgv_row.Cells[2].Value.ToString();
                txtPass2.Text = "";
                cmbHak.SelectedIndex = int.Parse(dgv_row.Cells[3].Value.ToString());
            }
        }

        private void load_user()
        {
            txtNRK.Text = "";
            txtNama.Text = "";
            txtPass1.Text = "";
            txtPass2.Text = "";
            cmbHak.SelectedIndex = 0;
            dgvUser.DataSource = koneksi.dtb_command("SELECT id AS ID_USER, nama AS NAMA, pass AS PASSOWRD, type AS TYPE_USER FROM db_user");
        }

        private bool notnull
        {
            get
            {
                if (txtNRK.Text != "" || txtNama.Text != "" || txtPass1.Text != "" || txtPass1.Text != txtPass2.Text)
                { return true; }
                return false;
            }
        }

    }
}
