using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Data;
using System.Diagnostics;
// using System.Drawing;
// using System.Linq;
// using System.Text;
using System.Windows.Forms;

namespace Program
{
    public partial class form_utama : UserControl
    {
        private string pesan = "Program ini menjelaskan :";

        public form_utama()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            method.tampilkan_button();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Program ini dibuat dan dipersembahkan untuk Bank BPD Bali. \n\nLanjutkan?? [Memerlukan koneksi ke internet]",
                                pesan, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                try
                {
                    Process.Start("msedge.exe", @"http://www.bpdbali.co.id");
                }
                catch
                {
                    Process.Start("firefox.exe", @"http://www.bpdbali.co.id");
                }
            else
                return;
        }
    }
}
