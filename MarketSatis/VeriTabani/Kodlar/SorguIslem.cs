using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Kodlar
{
    class SorguIslem
    {
        private String baglantiBilgi = "Provider=SQLOLEDB;Data Source=LAPTOP-SQM1KN33\\ISIMSIZ;Initial Catalog=Market2;User ID=sa;Password=kizilelma";

        private String Tc, Sifre;
        private int id;

        //veritabanı sorgu  değişkenleri
        private String sorguTc = "tc", sorguId = "id", sorguYetki = "yetki", sorguSifre = "şifre", sorguPersonel = "Personel";
        private String tabloPersonel = "Personel", tabloSil = "PersonelSil", tabloSifre = "Şifre";


        ClassVeriTabaniTemel veriTabani;

        public SorguIslem()
        {
            veriTabani = new ClassVeriTabaniTemel();
            veriTabani.baglantiBilgileriGir(baglantiBilgi);
        }

        public bool baglan()
        {
            return veriTabani.baglan();
        }

        public void baglantiKes()
        {
            veriTabani.baglantiKes();
        }

        private string sorgu(String sutunlar, String tablo, string sart = "")
        {
            return "Select " + sutunlar + " from " + tablo + " Where " + sart;
        }

        public bool girisTc(String Tc)
        {
            String kntrl = "";
            this.Tc = Tc.Trim();
            kntrl = (String)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu(sorguTc, tabloPersonel, sorguTc + "=" + this.Tc)
                );
            
            if (kntrl != "" && kntrl != null)
            {
                return true;
            }
            return false;
        }

        public bool girisSifre(String sifre)
        {
            String kntrl = "";
            this.Sifre = sifre;
            this.id = (int)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu(sorguId, tabloPersonel, sorguTc + "=" + this.Tc)
                ) ;

            
            kntrl = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu(sorguSifre, tabloSifre, sorguPersonel + "=" + this.id.ToString() + "and " + sorguSifre + "='" + sifre+"'")
                )!=null? (String)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu(sorguSifre, tabloSifre, sorguPersonel + "=" + this.id.ToString() + "and " + sorguSifre + "='" + sifre+"'")
                ) : "";

            if (kntrl != "")
            {
                return true;
            }

            return false;
        }

        public bool girisYetki()
        {

            return (bool)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu(sorguYetki, tabloPersonel, sorguId + "=" + this.id.ToString())
                );
        }

        public bool silDurum()
        {
            if (veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu("*", tabloSil, sorguPersonel + "='" + this.id.ToString().Trim()+"'")
                ) != null)
            {
                return true;
            }
            return false;
        }
    }
}
