using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Program
{
    class global
    {
<<<<<<< Updated upstream
=======
        public enum StatusBarang { edit_barang, edit_detail_barang }
        public enum StatusButtonSimpan { simpan, tambah }
        public enum JenisLaporan { stok, pengadaan, pengadaan_id, pengeluaran, pengeluaran_id, divisi_umum_dan_kesekretariatan, divisi_kepatuhan, divisi_manajemen_risiko, divisi_perencanaan_strategis, divisi_sumber_daya_manusia, divisi_treasury, divisi_dana_dan_jasa, divisi_teknologi_akuntansi, divisi_kredit, skai_anti_fraud, cabang_renon, cabang_denpasar, cabang_badung, cabang_mangupura, cabang_tabanan, cabang_singaraja, cabang_seririt, cabang_negara, cabang_gianyar, cabang_ubud, cabang_klungkung, cabang_bangli, cabang_karangasem, cabang_mataram }
        
>>>>>>> Stashed changes
        public const int id_type_admin = 1;
        public const int id_type_barang = 2;
        public const int id_type_inventaris = 3;
        public const int id_type_laporan = 4;

        public static string[] unit_kerja
        {
            set { }
            get { return new string[] { "Divisi Umum dan Kesekretariatan", "Divisi Kepatuhan", "Divisi Manajemen Risiko", "Divisi Perencanaan Strategis", "Divisi Sumber Daya Manusia", "Divisi Treasury", "Divisi Dana dan Jasa", "Divisi Teknologi & Akuntansi", "Divisi Kredit", "SKAI & Anti Fraud", "Cabang Renon", "Cabang Denpasar", "Cabang Badung", "Cabang Mangupura", "Cabang Tabanan", "Cabang Singaraja", "Cabang Seririt", "Cabang Negara", "Cabang Gianyar", "Cabang Ubud", "Cabang Klungkung", "Cabang Bangli", "Cabang Karangasem", "Cabang Mataram" }; }
        }

        public static string id;
        public static string id_nama;
        public static int id_type;

        //public static string conn_string = method.xml_server_load();
        public static string conn_string = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\data.mdf;Integrated Security=True;User Instance=True";
    }
}
