using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarketSatis.Properties.Resources;

namespace MarketSatis.VeriTabani.Kodlar
{
    class SorguIslem
    {
        private String baglantiBilgi = "Provider=SQLOLEDB;Data Source=LAPTOP-SQM1KN33\\ISIMSIZ;Initial Catalog=Market2;User ID=sa;Password=kizilelma";

        private String Tc, Sifre;
        private int id;

        //veritabanı sorgu  değişkenleri
        private String sorguTc = "tc", sorguId = "id", sorguYetki = "yetki", sorguSifre = "şifre", sorguPersonel = "personel";
        private String sorguAd = "ad", sorguSoyad = "soyad", sorguCinsiyet = "cinsiyet", sorguAciklama = "açıklama", sorguTarihSaat = "tarihSaat";
        private String sorguFotograf = "fotograf";
        private String tabloPersonel = "Personel", tabloSil = "PersonelSil", tabloSifre = "Şifre",tabloEkBilgi = "EkBilgi",tabloFotograf = "Fotograf";


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

        private string sorgu( String sutunlar, String tablo, string sart = "")
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
                sorgu(sorguId, tabloPersonel, sorguTc + "=" + this.Tc)) ;

            
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
                sorgu("*", tabloSil, sorguPersonel + "=" + this.id+"")
                ).ToString() != "")
            {
                return true;
            }
            return false;
        }

        public TemelVeri temelVeriAl(String Tc)
        {
            TemelVeri temelVeri = new TemelVeri();
            temelVeri.Tc = Tc.Trim();
            // id
            temelVeri.Id = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu(sutunlar:sorguId
                ,tablo:tabloPersonel
                ,sart:sorguTc+" = "+temelVeri.Tc)).ToString() != "" ? 
                int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorgu(sutunlar: sorguId, tablo: tabloPersonel, sart: sorguTc + " = " + temelVeri.Tc)).ToString()):
                    -1;
            //ad
            temelVeri.Ad = (String)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu(
                    sutunlar:sorguAd, tablo:tabloPersonel,
                    sart:sorguTc+" = " + temelVeri.Tc));

            //soyad
            temelVeri.Soyad = (String)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut:sorgu(
                    sutunlar: sorguSoyad, tablo: tabloPersonel,
                    sart: sorguTc + " = " + temelVeri.Tc));

            //Yetki
            temelVeri.Yetki = (veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu(
                    sutunlar: sorguYetki, tablo: tabloPersonel,
                    sart: sorguTc + " = " + temelVeri.Tc))).ToString() != "" ?
                              (bool)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu(
                    sutunlar: sorguYetki, tablo: tabloPersonel,
                    sart: sorguTc + " = " + temelVeri.Tc))
                              : false;
            //Cinsiyet
            temelVeri.Cinsiyet = (String)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut:sorgu(
                    sutunlar:sorguCinsiyet, tablo: tabloPersonel,
                    sart: sorguTc + " = " + temelVeri.Tc));

            //Şifre
            temelVeri.Sifre = (String)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu (
                    sutunlar: sorguSifre, 
                    tablo: tabloSifre+" join "+tabloPersonel +" on "+ tabloSifre + "."+sorguPersonel+" = "+ tabloPersonel+"."+sorguId,
                    sart: sorguTc + " = " + temelVeri.Tc));

            //Fotograf

            temelVeri.fotograf = (string)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu(
                    sutunlar: sorguFotograf,
                    tablo: tabloFotograf + " , " + tabloPersonel,
                    sart: tabloFotograf + "." + sorguPersonel + " = " + tabloPersonel + "." + sorguId + " and " + tabloPersonel + "." + sorguTc + " =" + temelVeri.Tc)) != "" ?
                                (Image)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu(
                    sutunlar: sorguFotograf,
                    tablo: tabloFotograf + " , " + tabloPersonel,
                    sart: tabloFotograf + "." + sorguPersonel + " = " + tabloPersonel + "." + sorguId + " and " + tabloPersonel + "." + sorguTc + " =" + temelVeri.Tc)) :
                                   Image.FromFile(@"C:\Users\piral\Desktop\ders notları\2020-2021_Bahar_Ders_Notları\3301654_MÜHENDİSLİK_TASARIMI\Proje\MarketSatis\MarketSatis\Resim\boskullanici.jpg");

            //Adres
            //çoklu veri alma ayarlanınca almak lazım
            temelVeri.Adres = (String)veriTabani.adresAl(temelVeri.Tc);

            //EkBilgi
            temelVeri.Ekbilgi = (String)veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu(
                    sutunlar: sorguAciklama,
                    tablo: tabloEkBilgi + " join " + tabloPersonel + " on "+ tabloEkBilgi+"."+sorguPersonel+" = "+tabloPersonel+"."+sorguId,
                    sart: tabloPersonel+"."+sorguTc + " = " + temelVeri.Tc+
                    " order by "+tabloPersonel+"."+sorguId+" , "+ tabloEkBilgi+"."+sorguTarihSaat+" DESC"));

            return temelVeri;
        }
    }
}
