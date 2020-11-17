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

        public static void tampilkan_button()
        {
            bool[] value = { true, true, false, false, false, true };
            string[] nama = { "BERANDA", "LOGIN", "", "", "", "KELUAR" };

            switch (global.id_type)
            {
                case global.id_type_admin:
                    value = new bool[] { true, true, true, true, true, true };
                    nama = new string[] { "BERANDA", "USER", "BARANG", "INVENTARIS", "LAPORAN", "KELUAR" };
                    break;
                case global.id_type_barang:
                    value = new bool[] { true, true, false, false, false, true };
                    nama = new string[] { "BERANDA", "BARANG", "", "", "", "KELUAR" };
                    break;
                case global.id_type_inventaris:
                    value = new bool[] { true, true, true, false, false, true };
                    nama = new string[] { "BERANDA", "INVENTARIS", "LAPORAN", "", "", "KELUAR" };
                    break;
                case global.id_type_laporan:
                    value = new bool[] { true, true, false, false, false, true };
                    nama = new string[] { "BERANDA", "LAPORAN", "", "", "", "KELUAR" };
                    break;
            }

            form_app.app.button(value, nama);
        }
    }
}
