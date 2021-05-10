using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MarketSatis.VeriTabani.Kodlar
{
    interface InterfaceVeriTabaniTemel
    {
        OleDbConnection veriTabani { get; set; }
        OleDbCommand veriTabaniKomut { get; set; }
        OleDbDataReader veriTabaniOkuyucu { get; set; }

        bool baglantiBilgileriGir(String BaglantiBilgileri);
        bool baglan();
        /// <summary>
        /// duruma göre geri dönderdiği nesne veri tabani connection nesnesidir.
        /// örnek OleDBConnection gibi
        /// </summary>
        /// <param name="BaglantiBilgileri"></param>
        /// <returns></returns>
        object Baglan(String BaglantiBilgileri);
        bool baglantiKes();
        bool degistir(String veriTabani);

        bool komutAl(String komut);
        bool komutAl(String komut, OleDbConnection veriTabani);

        bool sonucDondurmeyenSorguKomutIsle();
        bool sonucDondurmeyenSorguKomutIsle(String sorguKomut);
        bool sonucDondurmeyenSorguKomutIsle(String sorguKomut, OleDbConnection veriTabani);

        bool guncelle();
        bool guncelle(String updateKomutu);
        bool guncelle(String updateKomutu, OleDbConnection veriTabani);

        object tekAlanlikVeriDondurenSorguKomutlarIsle();
        object tekAlanlikVeriDondurenSorguKomutlarIsle(String sorguKomut);
        object tekAlanlikVeriDondurenSorguKomutlarIsle(String sorguKomut, OleDbConnection veriTabani);

        object kumeDondurenSorguKomutlarIsle();
        object kumeDondurenSorguKomutlarIsle(String sorguKomut);
        object kumeDondurenSorguKomutlarIsle(String sorguKomut, OleDbConnection veriTabani);
        object kumeDondurenSorguKomutlarIsle(String tabloAdi,String kolonAdi);
        object kumeDondurenSorguKomutlarIsle(String tabloAdi, String kolonAdi, OleDbConnection veriTabani);
    }
}
