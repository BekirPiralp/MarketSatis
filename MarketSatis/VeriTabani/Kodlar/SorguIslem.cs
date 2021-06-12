﻿using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using static MarketSatis.Properties.Resources;

namespace MarketSatis.VeriTabani.Kodlar
{
    public class SorguIslem
    {
        protected String baglantiBilgi = "Provider=SQLOLEDB;Data Source=LAPTOP-SQM1KN33\\ISIMSIZ;Initial Catalog=Market2;User ID=sa;Password=kizilelma";

        protected String Tc, Sifre,SilAciklamasi="";
        protected int id;

        //veritabanı sorgu  değişkenleri
        public String sorguTc = "tc", sorguId = "id", sorguYetki = "yetki", sorguSifre = "şifre", sorguPersonel = "personel",
            sorguAd = "ad", sorguSoyad = "soyad", sorguCinsiyet = "cinsiyet", sorguAciklama = "açıklama", sorguTarihSaat = "tarihSaat",
            sorguFotograf = "fotograf",sorguBarkod="barkod",sorguUrunAciklama= "acıklama",sorguMarka="marka",sorguUretimYeri= "üretimYeri",
            sorguFiyat = "fiyat",sorguIndirim= "indirim",sorguResim= "resim",sorguAdet= "adet",sorguUrun="ürün",sorguFis= "fiş",
            sorguKod = "kod", sorguToplamFiyat = "toplamFiyat",sorguSatis="satış",sorguUlke="ülke",sorguil="il";
        public String tabloPersonel = "Personel", tabloSil = "PersonelSil", tabloSifre = "Şifre",tabloEkBilgi = "EkBilgi",tabloFotograf = "Fotograf",
            tabloUrun = "Ürün",tabloFis= "Fis",tabloSatis= "Satış",tabloDefo="Defo",tabloIade="İade",tabloUlke="Ülke",
            tabloil="İl",tabloilçe="İlçe";


        protected ClassVeriTabaniTemel veriTabani;

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

        protected string sorgu( String sutunlar, String tablo, string sart = "")
        {
            if(sart == "")
            {
                return "Select " + sutunlar + " from " + tablo;
            }
            return "Select " + sutunlar + " from " + tablo + " Where " + sart;
        }
        /// <summary>
        /// Sutun ve degerlerini girerken
        /// 'abc' şekli ile ' ' => arasında girilmelidir.
        /// </summary>
        /// <param name="tablo"></param>
        /// <param name="sutunVeDegerleri"></param>
        /// <param name="sart"></param>
        /// <returns></returns>
        protected string guncelle(String tablo, String sutunVeDegerleri,string sart = "")
        {
            return "update " + tablo + " set " + sutunVeDegerleri + " where " + sart;
        }
        /// <summary>
        /// Sutun ve değerlerin sıraları aynı tutularak girilmelidir yoksa hata ile karşılaşılabilir.
        /// 
        /// </summary>
        /// <param name="tablo"></param>
        /// <param name="sutunlar"></param>
        /// <param name="degerler"></param>
        /// <returns></returns>
        protected string ekle(String tablo, String[] sutunlar, String[] degerler)
        {
            String sutun=" ";
            for(int i = 0; i < sutunlar.Length; i++)
            {
                if (i == sutunlar.Length - 1)
                {
                    sutun += sutunlar[i].Trim();
                }
                else
                {
                    sutun += sutunlar[i].Trim() + " , ";
                }
                
            }
            String deger = " ";
            for (int i = 0; i < degerler.Length; i++)
            {
                if(i == degerler.Length - 1)
                {
                    deger += "'" + degerler[i].Trim() + "'";
                }
                else
                {
                    deger += "'" + degerler[i].Trim() + "'" + " , ";
                }
                
            }

            return "insert into " + tablo + " (" + sutun + " ) values ( " + deger + " )";
        }

        /*Sonunda resim bulunması şartı ile*/
        protected string ekleSonResim(String tablo, String[] sutunlar, String[] degerler)
        {
            String sutun = " ";
            for (int i = 0; i < sutunlar.Length; i++)
            {
                if (i == sutunlar.Length - 1)
                {
                    sutun += sutunlar[i].Trim();
                }
                else
                {
                    sutun += sutunlar[i].Trim() + " , ";
                }

            }
            String deger = " ";
            for (int i = 0; i < degerler.Length; i++)
            {
                if (i == degerler.Length - 1)
                {
                    deger += " " + degerler[i].Trim() + " ";
                }
                else
                {
                    deger += "'" + degerler[i].Trim() + "'" + " , ";
                }

            }

            return "insert into " + tablo + " (" + sutun + " ) values ( " + deger + " )";
        }
        /// <summary>
        /// Aldığı byte dizisini Image nesnesine dönüştürür
        /// genelde veritabanından resim çekmede yardımcı olarak kullanılır
        /// </summary>
        /// <param name="rsm"></param>
        /// <returns></returns>
        /// 
        public Image cevirByteArrayImage(byte[] rsm)
        {
            //System.IO.MemoryStream memoryStream = new MemoryStream(rsm);
            //Stream stream = memoryStream;
            //Image a = System.Drawing.Bitmap.FromStream(memoryStream);
            if(rsm != null && rsm.Length != 0)
            {
                using (MemoryStream stream = new MemoryStream(rsm))
                {
                    return Image.FromStream(stream);
                }

            }
            else
            {
                return null;
            }
        }

        

        /// <summary>
        /// Aldığı Image nesnesini byte dizisine dönüştürür
        /// genelde veritabanına resim yüklemek için yardımcı kullanılır
        /// </summary>
        /// <param name="rsm"></param>
        /// <returns></returns>
        public byte[] cevirImageByteArray(Image rsm)
        {
            MemoryStream memoryStream = new MemoryStream();
            rsm.Save(memoryStream, ImageFormat.Jpeg);

            //return memoryStream.ToArray();
            byte[] data;
            data = new byte[memoryStream.Length];
            memoryStream.Write(data, 0, data.Length);
            return data; 
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
                this.SilAciklamasi = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorgu(sorguAciklama, tabloSil, sorguPersonel + "=" + this.id + "")
                ).ToString();
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
                                cevirByteArrayImage((byte[])veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                sorguKomut: sorgu(
                    sutunlar: sorguFotograf,
                    tablo: tabloFotograf + " , " + tabloPersonel,
                    sart: tabloFotograf + "." + sorguPersonel + " = " + tabloPersonel + "." + sorguId + " and " + tabloPersonel + "." + sorguTc + " =" + temelVeri.Tc))) :
                    global::MarketSatis.Properties.Resources.boskullanici;
            //Image.FromFile(@"C:\Users\piral\Desktop\ders notları\2020-2021_Bahar_Ders_Notları\3301654_MÜHENDİSLİK_TASARIMI\Proje\MarketSatis\MarketSatis\Resim\boskullanici.jpg");

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

        public bool temelVeriEkle(TemelVeri temelVeri )
        {
            if(temelVeri != null)
            {
                String[] sutunlar = { sorguAd, sorguSoyad, sorguTc, sorguYetki, sorguCinsiyet };
                String[] degerler = {temelVeri.Ad.Trim(),temelVeri.Soyad.Trim(),temelVeri.Tc.Trim(),
                temelVeri.Yetki.ToString(),temelVeri.Cinsiyet};
                // sistemde kayıtlı ise
                if (this.girisTc(temelVeri.Tc.Trim()))
                {
                    MessageBox.Show("Eklemek istediğiniz kullanıcı sistemde kayıtlı olduğundan dolayı ekleyemiyoruz.");
                    try
                    {
                        temelVeri = temelVeriAl(temelVeri.Tc);
                        if(temelVeri== null)
                        {
                            throw new NullReferenceException();
                        }
                        else
                        {
                            this.id = temelVeri.Id;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Kayıtlı halde bulana kişi veri tananından geri çekilirken hata ile kaşılaşıldı");
                        
                    }
                    if (silDurum())
                    {
                        MessageBox.Show("Aradığınız kişi Silinme sebebi: \n" + this.SilAciklamasi);
                        MessageBox.Show("Kişi tekrar dan eklemek istiyorsanız veri tabanı yöneticiniz ile iletişime geçiniz.");
                        //bilerek geri ekleme yapmadım olki sisteme kendisini dışarıdan yönetici olarak atamış olabilir veya
                        //bu işlemi yapmya çalışan silinmiş kişi olabilir...
                             
                    }
                    return false;
                }
                else
                {
                    /*Sistemde kayıtlı değil ise*/
                    try
                    {

                        /*Personel tablosuna eklenecekler*/
                        veriTabani.sonucDondurmeyenSorguKomutIsle(
                            sorguKomut: ekle(tablo: tabloPersonel,
                            sutunlar: sutunlar,
                            degerler: degerler
                                            )
                            );
                        /*ileriki işlemler için id çekme*/
                        temelVeri.Id = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            tablo: tabloPersonel,
                            sutunlar: sorguId,
                            sart: sorguTc + " = '" + temelVeri.Tc + "'")).ToString() !=""? int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            tablo: tabloPersonel,
                            sutunlar: sorguId,
                            sart: sorguTc + " = '" + temelVeri.Tc + "'")).ToString()):0;

                        /*Şifre kayıt*/
                        String[] stnlr={sorguPersonel,sorguSifre};
                        String[] dgrlr = { temelVeri.Id.ToString(), temelVeri.Sifre.Trim() };
                        while (!veriTabani.sonucDondurmeyenSorguKomutIsle(
                            sorguKomut:ekle(
                                tablo:tabloSifre,
                                sutunlar: stnlr,
                                degerler: dgrlr
                                            )
                            )); // şifre tablosuna kayıt başarısız olduğu sürece tekrarlıyacak ;)

                        /*Fotograf kayıt*/
                        if(temelVeri.fotograf!= null)
                        {
                            String[] stn = { sorguPersonel, sorguFotograf };
                            String[] dgr = { temelVeri.Id.ToString(),"@foto"};
                            veriTabani.komutAl(komut: ekle(
                                tablo: tabloFotograf,
                                sutunlar: stn,
                                degerler: dgr
                                ));

                            veriTabaniResimParmetreAl(
                                veriTabani: veriTabani,
                                image: temelVeri.fotograf,
                                paremetreAdi:"@foto");
                            veriTabani.sonucDondurmeyenSorguKomutIsle();
                        }

                        /*Ek bilgi*/
                        String[] stnEk = { sorguPersonel, sorguAciklama };
                        String[] dgrEk = { temelVeri.Id.ToString(), temelVeri.Ekbilgi.Trim() };
                        veriTabani.sonucDondurmeyenSorguKomutIsle(
                            sorguKomut:ekle(
                                tablo:tabloEkBilgi,
                                sutunlar:stnEk,
                                degerler:dgrEk
                                )
                            );

                        /*Adres*/
                        // int ülke, int il, int ilçe
                    }
                    catch 
                    {

                        MessageBox.Show("Kayıt esnasında bir hata oluştu");
                        return false;
                    }

                }
            }
            return false;
        }

        protected bool veriTabaniResimParmetreAl(ClassVeriTabaniTemel veriTabani,Image image,String paremetreAdi)
        {
            try
            {
                byte[] foto = cevirImageByteArray(image);
                veriTabani.veriParametre = new System.Data.OleDb.OleDbParameter(
                    paremetreAdi, System.Data.OleDb.OleDbType.Binary);
                veriTabani.veriParametre.Value = foto;
                veriTabani.veriTabaniKomut.Parameters.Add(veriTabani.veriParametre);
            }
            catch
            {
                return false;
            }
            
            return true;

        }

        /*Özellikle adres deki ülek ile ilçe çekmek için özel oluşturulmuştur.*/
        public List<Ozel> KumeAl(String tablo, String Sart)
        {
            List<Ozel>  keyValues = new List<Ozel>();
            veriTabani.komutAl(sorgu(
                sutunlar: sorguId + "," + sorguAd,
                tablo: tablo,
                sart: Sart
                ));
            Ozel ozel;
            try
            {
                veriTabani.baglan();
                veriTabani.veriTabaniOkuyucu = veriTabani.veriTabaniKomut.ExecuteReader();
                while (veriTabani.veriTabaniOkuyucu.Read())
                {
                    ozel = new Ozel(Convert.ToInt32(veriTabani.veriTabaniOkuyucu[0]),
                        veriTabani.veriTabaniOkuyucu[1].ToString());

                    keyValues.Add(ozel);
                }
                veriTabani.baglantiKes();
                return keyValues;
            }
            catch
            {
                return null;
            }
            finally
            {
                veriTabani.baglantiKes();
            }
           
        }

        public List<Ozel> ComboBoxVeriEkle(ComboBox comboBox,String tablo,String sart="")
        {
            List<Ozel> al =
            KumeAl(tablo: tablo, Sart:sart);
            if (al != null)
            {
                try
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        comboBox.Items.Add(al[i].ad);
                    }
                }
                catch 
                {
                    return null;
                }
                return al;
            }
            else
            {
                return null;
            }
        }


    }
}
