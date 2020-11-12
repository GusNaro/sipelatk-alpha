using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    class method
    {
        public static void tampilkan(string nama_form)
        {

        }

        public static void tampilkan_button(string type)
        {
            bool[] value = { true, false, false, false, false, false };
            string[] nama = { "LOGIN", "", "", "", "", "" };

            if (type == "LOGIN")
            {
                value = new bool[] { true, false, false, false, false, false };
                nama = new string[] { "BERANDA", "", "", "", "", "" };
            }

            switch (global.id_type)
            {
                case 1:
                    value = new bool[] { true, true, true, true, true, true };
                    nama = new string[] { "BERANDA", "USER", "BARANG", "INVENTARIS", "LAPORAN", "KELUAR" };
                    break;
                case 2:
                    value = new bool[] { true, true, false, false, false, true };
                    nama = new string[] { "BERANDA", "BARANG", "", "", "", "KELUAR" };
                    break;
                case 3:
                    value = new bool[] { true, true, true, false, false, true };
                    nama = new string[] { "BERANDA", "INVENTARIS", "LAPORAN", "", "", "KELUAR" };
                    break;
                case 4:
                    value = new bool[] { true, true, false, false, false, true };
                    nama = new string[] { "BERANDA", "LAPORAN", "", "", "", "KELUAR" };
                    break;
            }

            form_app.app.button(value, nama);
        }
    }
}
