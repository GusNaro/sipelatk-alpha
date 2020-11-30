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
    public partial class form_utama : UserControl
    {
        public form_utama()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lblDate.Text = time.ToLongDateString();
            lblTime.Text = time.ToShortTimeString();
            lblTimeSec.Text = time.Second.ToString();
        }
    }
}
