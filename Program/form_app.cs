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

        public void buka_form_utama()
        {
            buka_form(new form_utama());
            reset_button_image();
            button1.Image = button_image_click("BERANDA");
            lbl_user.Text = global.id_nama;
        }

        #endregion

        private Form form_aktif = null;

        public form_app()
        {
            InitializeComponent();
            lbl_user.Text = "[ USER ]";
        }

        private void form_app_Load(object sender, EventArgs e)
        {
            aplikasi = this;
            global.id = string.Empty;
            
            method.tampilkan_button();
            button1.Image = button_image_click("BERANDA");

            buka_form(new form_utama());
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
            if (global.id == string.Empty) { this.Close(); }
            else
            {
                tampilkan(button6.Text);
                method.tampilkan_button();
                button1.Image = button_image_click("BERANDA");
            }
        }

        private void tampilkan(string nama_form)
        {
            switch (nama_form)
            {
                case "LOGIN":
                    buka_form(new form_login());
                    break;
                case "USER":
                    buka_form(new form_user());
                    break;
                case "BARANG MASUK":
                    buka_form(new form_barang());
                    break;
                case "BARANG KELUAR":
                    buka_form(new form_transaksi());
                    break;
                case "LAPORAN":
                    buka_form(new form_laporan());
                    break;
                case "BERANDA":
                    buka_form(new form_utama());
                    break;
                case "KELUAR":
                    global.id = string.Empty;
                    global.id_nama = string.Empty;
                    global.id_type = 0;
                    lbl_user.Text = "[ USER ]";
                    buka_form(new form_utama());
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
                case "BARANG MASUK":
                    o = Resources.ResourceManager.GetObject("barang_a");
                    return (Image)o;
                case "BARANG KELUAR":
                    o = Resources.ResourceManager.GetObject("inventaris_a");
                    return (Image)o;
                case "LAPORAN":
                    o = Resources.ResourceManager.GetObject("laporan_a");
                    return (Image)o;
                case "BERANDA":
                    o = Resources.ResourceManager.GetObject("beranda_a");
                    return (Image)o;
                case "KELUAR":
                    if (global.id == string.Empty) { o = Resources.ResourceManager.GetObject("quit"); }
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
                case "BARANG MASUK":
                    o = Resources.ResourceManager.GetObject("barang_b");
                    return (Image)o;
                case "BARANG KELUAR":
                    o = Resources.ResourceManager.GetObject("inventaris_b");
                    return (Image)o;
                case "LAPORAN":
                    o = Resources.ResourceManager.GetObject("laporan_b");
                    return (Image)o;
                case "BERANDA":
                    o = Resources.ResourceManager.GetObject("beranda_b");
                    return (Image)o;
            }
            return null;
        }

        private void buka_form(Form anak_form)
        {
            if (form_aktif != null) { form_aktif.Close(); }
            form_aktif = anak_form;
            anak_form.TopLevel = false;
            anak_form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            anak_form.Dock = DockStyle.Fill;
            pnl_utama.Controls.Add(anak_form);
            pnl_utama.Tag = anak_form;
            anak_form.BringToFront();
            anak_form.Show();
        }
    }
}
