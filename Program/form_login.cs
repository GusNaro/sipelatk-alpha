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
    public partial class form_login : Form
    {
        public form_login()
        {
            InitializeComponent();
        }

        private void form_login_Load(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtPW.Text = string.Empty;

            txtID.Focus();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty || txtPW.Text != string.Empty)
            {
                var data = koneksi.login(txtID.Text);
                if (data[0] == txtID.Text && data[2] == txtPW.Text)
                {
                    global.id = txtID.Text;
                    global.id_nama = data[1];
                    global.id_type = int.Parse(data[3]);
                    method.tampilkan_button();
                    form_app.app.buka_form_utama();
                }
                else
                {
                    MessageBox.Show("USER DAN PASSWORD SALAH !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtID.Text == string.Empty) { txtID.Focus(); }
                else if (txtPW.Text == string.Empty) { txtPW.Focus(); }
                else { btn_login_Click(this, new EventArgs()); }
            }
        }

    }
}
