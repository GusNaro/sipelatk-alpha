using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.Properties;

namespace Program
{
    public partial class form_app : Form
    {
        #region PUBLIC VARIABLE

        private static form_app aplikasi;

        public static form_app app
        {
            get
            {
                if (aplikasi == null) { aplikasi = new form_app(); }
                return aplikasi;
            }
        }

        public void button(bool[] value, string[] nama)
        {
            button1.Visible = value[0];
            button1.Enabled = value[0];
            button1.Text = nama[0];
            button2.Visible = value[1];
            button2.Enabled = value[1];
            button2.Text = nama[1];
            button3.Visible = value[2];
            button3.Enabled = value[2];
            button3.Text = nama[2];
            button4.Visible = value[3];
            button4.Enabled = value[3];
            button4.Text = nama[3];
            button5.Visible = value[4];
            button5.Enabled = value[4];
            button5.Text = nama[4];
            button6.Visible = value[5];
            button6.Enabled = value[5];
            button6.Text = nama[5];
            reset_button_image();
        }

        public Panel panel_utama
        {
            set { pnl_utama = value; }
            get { return pnl_utama; }
        }

        public void panel_button_top(string lokasi)
        {
            if (lokasi == "BERANDA")
            {
                reset_button_image();
                button1.Image = button_image_click("BERANDA");
                lbl_user.Text = global.id_nama;
            }
            else if (lokasi == "LOGIN")
            {
                reset_button_image();
                button2.Image = button_image_click("LOGIN");
                lbl_user.Text = "[ USER ]";
            }
        }

        #endregion

        public form_app()
        {
            InitializeComponent();
            lbl_user.Text = "[ USER ]";
        }

        private void form_app_Load(object sender, EventArgs e)
        {
            aplikasi = this;

            form_utama fh = new form_utama();
            fh.Dock = DockStyle.Fill;
            pnl_utama.Controls.Add(fh);

            form_login fl = new form_login();
            fl.Dock = DockStyle.Fill;
            pnl_utama.Controls.Add(fl);

            form_user fu = new form_user();
            fu.Dock = DockStyle.Fill;
            pnl_utama.Controls.Add(fu);

            form_barang fb = new form_barang();
            fb.Dock = DockStyle.Fill;
            pnl_utama.Controls.Add(fb);

            form_transaksi ft = new form_transaksi();
            ft.Dock = DockStyle.Fill;
            pnl_utama.Controls.Add(ft);

            form_laporan flp = new form_laporan();
            flp.Dock = DockStyle.Fill;
            pnl_utama.Controls.Add(flp);

            method.tampilkan_button();
            button1.Image = button_image_click("BERANDA");

            app.panel_utama.Controls["form_user"].Hide();
            app.panel_utama.Controls["form_barang"].Hide();
            app.panel_utama.Controls["form_transaksi"].Hide();
            app.panel_utama.Controls["form_laporan"].Hide();
            app.panel_utama.Controls["form_login"].Hide();
            app.panel_utama.Controls["form_utama"].Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tampilkan(button1.Text);
            reset_button_image();
            button1.Image = button_image_click(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tampilkan(button2.Text);
            reset_button_image();
            button2.Image = button_image_click(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tampilkan(button3.Text);
            reset_button_image();
            button3.Image = button_image_click(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tampilkan(button4.Text);
            reset_button_image();
            button4.Image = button_image_click(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tampilkan(button5.Text);
            reset_button_image();
            button5.Image = button_image_click(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (global.id == null) { this.Close(); }
            else
            {
                tampilkan(button6.Text);
                method.tampilkan_button();
                panel_button_top("LOGIN");
            }
        }

        private void tampilkan(string nama_form)
        {
            switch (nama_form)
            {
                case "LOGIN":
                    app.panel_utama.Controls["form_user"].Hide();
                    app.panel_utama.Controls["form_barang"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Hide();
                    app.panel_utama.Controls["form_laporan"].Hide();
                    app.panel_utama.Controls["form_utama"].Hide();
                    app.panel_utama.Controls["form_login"].Show();
                    break;
                case "USER":
                    app.panel_utama.Controls["form_barang"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Hide();
                    app.panel_utama.Controls["form_laporan"].Hide();
                    app.panel_utama.Controls["form_login"].Hide();
                    app.panel_utama.Controls["form_utama"].Hide();
                    app.panel_utama.Controls["form_user"].Show();
                    break;
                case "BARANG":
                    app.panel_utama.Controls["form_user"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Hide();
                    app.panel_utama.Controls["form_laporan"].Hide();
                    app.panel_utama.Controls["form_login"].Hide();
                    app.panel_utama.Controls["form_utama"].Hide();
                    app.panel_utama.Controls["form_barang"].Show();
                    break;
                case "INVENTARIS":
                    app.panel_utama.Controls["form_user"].Hide();
                    app.panel_utama.Controls["form_barang"].Hide();
                    app.panel_utama.Controls["form_laporan"].Hide();
                    app.panel_utama.Controls["form_login"].Hide();
                    app.panel_utama.Controls["form_utama"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Show();
                    break;
                case "LAPORAN":
                    app.panel_utama.Controls["form_user"].Hide();
                    app.panel_utama.Controls["form_barang"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Hide();
                    app.panel_utama.Controls["form_login"].Hide();
                    app.panel_utama.Controls["form_utama"].Hide();
                    app.panel_utama.Controls["form_laporan"].Show();
                    break;
                case "BERANDA":
                    app.panel_utama.Controls["form_user"].Hide();
                    app.panel_utama.Controls["form_barang"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Hide();
                    app.panel_utama.Controls["form_laporan"].Hide();
                    app.panel_utama.Controls["form_login"].Hide();
                    app.panel_utama.Controls["form_utama"].Show();
                    break;
                case "KELUAR":
                    global.id = null;
                    global.id_nama = null;
                    global.id_type = 0;
                    app.panel_utama.Controls["form_user"].Hide();
                    app.panel_utama.Controls["form_barang"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Hide();
                    app.panel_utama.Controls["form_laporan"].Hide();
                    app.panel_utama.Controls["form_utama"].Hide();
                    app.panel_utama.Controls["form_login"].Show();
                    break;
                default:
                    app.panel_utama.Controls["form_user"].Hide();
                    app.panel_utama.Controls["form_barang"].Hide();
                    app.panel_utama.Controls["form_transaksi"].Hide();
                    app.panel_utama.Controls["form_laporan"].Hide();
                    app.panel_utama.Controls["form_login"].Hide();
                    app.panel_utama.Controls["form_utama"].Show();
                    break;
            }
        }

        private void reset_button_image()
        {
            button1.Image = button_image(button1.Text);
            button2.Image = button_image(button2.Text);
            button3.Image = button_image(button3.Text);
            button4.Image = button_image(button4.Text);
            button5.Image = button_image(button5.Text);
            button6.Image = button_image(button6.Text);
        }

        private Image button_image(string nama_form)
        {
            object o = null;
            switch (nama_form)
            {
                case "LOGIN":
                    o = Resources.ResourceManager.GetObject("login_a");
                    return (Image)o;
                case "USER":
                    o = Resources.ResourceManager.GetObject("user_a");
                    return (Image)o;
                case "BARANG":
                    o = Resources.ResourceManager.GetObject("barang_a");
                    return (Image)o;
                case "INVENTARIS":
                    o = Resources.ResourceManager.GetObject("inventaris_a");
                    return (Image)o;
                case "LAPORAN":
                    o = Resources.ResourceManager.GetObject("laporan_a");
                    return (Image)o;
                case "BERANDA":
                    o = Resources.ResourceManager.GetObject("beranda_a");
                    return (Image)o;
                case "KELUAR":
                    if (global.id == null) { o = Resources.ResourceManager.GetObject("quit"); }
                    else { o = Resources.ResourceManager.GetObject("keluar"); }
                    return (Image)o;
            }
            return null;
        }

        private Image button_image_click(string nama_form)
        {
            object o = null;
            switch (nama_form)
            {
                case "LOGIN":
                    o = Resources.ResourceManager.GetObject("login_b");
                    return (Image)o;
                case "USER":
                    o = Resources.ResourceManager.GetObject("user_b");
                    return (Image)o;
                case "BARANG":
                    o = Resources.ResourceManager.GetObject("barang_b");
                    return (Image)o;
                case "INVENTARIS":
                    o = Resources.ResourceManager.GetObject("inventaris_b");
                    return (Image)o;
                case "LAPORAN":
                    o = Resources.ResourceManager.GetObject("laporan_b");
                    return (Image)o;
                case "BERANDA":
                    o = Resources.ResourceManager.GetObject("beranda_b");
                    return (Image)o;
                case "KELUAR":
                    o = Resources.ResourceManager.GetObject("quit");
                    return (Image)o;
            }
            return null;
        }
    }
}
