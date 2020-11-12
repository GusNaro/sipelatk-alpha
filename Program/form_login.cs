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
    public partial class form_login : UserControl
    {
        public form_login()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            txtID.Text = null;
            txtPW.Text = null;
            method.tampilkan_button("LOGIN");
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtID.Text != null || txtPW.Text != null)
            {
                if (txtID.Text == "satu" && txtPW.Text == "123")
                {
                    global.id = txtID.Text;
                    global.id_type = 1;
                    form_app.app.panel_utama.Controls["form_login"].Hide();
                    form_app.app.panel_utama.Controls["form_utama"].Show();
                }
                else if (txtID.Text == "dua" && txtPW.Text == "123")
                {
                    global.id = txtID.Text;
                    global.id_type = 2;
                    form_app.app.panel_utama.Controls["form_login"].Hide();
                    form_app.app.panel_utama.Controls["form_utama"].Show();
                }
                else if (txtID.Text == "tiga" && txtPW.Text == "123")
                {
                    global.id = txtID.Text;
                    global.id_type = 3;
                    form_app.app.panel_utama.Controls["form_login"].Hide();
                    form_app.app.panel_utama.Controls["form_utama"].Show();
                }
                else if (txtID.Text == "empat" && txtPW.Text == "123")
                {
                    global.id = txtID.Text;
                    global.id_type = 4;
                    form_app.app.panel_utama.Controls["form_login"].Hide();
                    form_app.app.panel_utama.Controls["form_utama"].Show();
                }
                else
                { MessageBox.Show("user dan password salah !!!!"); }
            }
        }

    }
}
