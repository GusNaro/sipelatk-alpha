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
    public partial class form_utama : Form
    {
        public form_utama()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lblDate.Text = time.ToLongDateString();
            lblTime.Text = time.ToShortTimeString();
            lblTimeSec.Text = time.Second.ToString("D2");
        }

        private void form_utama_Load(object sender, EventArgs e)
        {
        }
    }
}
