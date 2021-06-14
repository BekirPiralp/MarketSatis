using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            sorguKod = "kod", sorguToplamFiyat = "toplamFiyat",sorguSatis="satış",sorguUlke="ülke",sorguil="il",sorguilce= "ilçe",
            sorguTarif="tarif";
        public String tabloPersonel = "Personel", tabloSil = "PersonelSil", tabloSifre = "Şifre",tabloEkBilgi = "EkBilgi",tabloFotograf = "Fotograf",
            tabloUrun = "Ürün",tabloFis= "Fis",tabloSatis= "Satış",tabloDefo="Defo",tabloIade="İade",tabloUlke="Ülke",
            tabloil="İl",tabloilçe="İlçe",tabloAdres="Adres",tabloPersonelSil="PersonelSil";


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
        /// Sutun ve degerlerini girerken, degerleri
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
            MessageBox.Show(rsm[0] + "     " + rsm[0].ToString());
            MemoryStream ms = new MemoryStream(rsm);
            Image resim = Image.FromStream(ms);
            ms.Dispose();
            return resim;
        }



        /// <summary>
        /// Aldığı Image nesnesini byte dizisine dönüştürür
        /// genelde veritabanına resim yüklemek için yardımcı kullanılır
        /// </summary>
        /// <param name="rsm"></param>
        /// <returns></returns>
        public byte[] cevirImageByteArray(Image rsm)
        {
            MemoryStream ms = new MemoryStream();
            
            rsm.Save(ms,ImageFormat.Jpeg);
            return ms.ToArray();
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
                            String[] dgr = { temelVeri.Id.ToString(),"?"};
                            veriTabani.komutAl(komut: ekleSonResim(
                                tablo: tabloFotograf,
                                sutunlar: stn,
                                degerler: dgr
                                ));

                            veriTabaniResimParmetreAl(
                                veriTabani: veriTabani,
                                image: temelVeri.fotograf,
                                paremetreAdi:"image");
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
                        String[] stnAdrs = { sorguUlke, sorguil, sorguilce, sorguTarif,sorguPersonel};
                        String[] dgrAdrs = {temelVeri.Ulke.ToString(),temelVeri.il.ToString(),
                        temelVeri.ilce.ToString(),temelVeri.Adres.Trim(),temelVeri.Id.ToString()};
                        veriTabani.sonucDondurmeyenSorguKomutIsle(
                            sorguKomut: ekle(
                                tablo: tabloAdres,
                                sutunlar: stnAdrs,
                                degerler: dgrAdrs
                                )
                            );

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

        public bool temelVeriCikar(TemelVeri temelVeri, String aciklama)
        {
            
            if (temelVeri != null&& temelVeri.Id >= 1)
            {
                try
                {
                    String[] stnPsil = { sorguPersonel, sorguAciklama };
                    String[] dgrPsil = { temelVeri.Id.ToString(), aciklama.Trim() };
                    veriTabani.sonucDondurmeyenSorguKomutIsle(sorguKomut:
                        ekle(
                            tablo:tabloPersonelSil,
                            sutunlar:stnPsil,
                            degerler:dgrPsil));
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
            return false;
        }

        public bool temelVeriGuncelle(TemelVeri ana, TemelVeri guncel)
        {
            if (
                String.Compare(ana.Ad,guncel.Ad)!=0 ||
                String.Compare(ana.Soyad, guncel.Soyad) != 0 ||
                ana.Yetki != guncel.Yetki ||
                String.Compare(ana.Ekbilgi.Trim().ToLower(), guncel.Ekbilgi.Trim().ToLower()) != 0||
                String.Compare(ana.Adres.Trim().ToLower(), guncel.Adres.Trim().ToLower()) != 0
                ) 
            {
                try
                {
                    /*personel tablosu kısmı*/
                    veriTabani.sonucDondurmeyenSorguKomutIsle(
                        sorguKomut: guncelle(
                            tablo: tabloPersonel,
                            sutunVeDegerleri:
                            sorguAd + " = '" + guncel.Ad.Trim() + "'," +
                            sorguSoyad + " = '" + guncel.Soyad.Trim() + "'," +
                            sorguYetki + " = '" + guncel.Yetki.ToString() + "',",
                            sart: sorguId + " = '" + ana.Id.ToString() + "'"
                            )
                        );

                    /*Ek bilgi tablosu*/
                    veriTabani.sonucDondurmeyenSorguKomutIsle(
                            sorguKomut: guncelle(
                                tablo: tabloEkBilgi,
                                sutunVeDegerleri:
                                sorguAciklama + " = '" + guncel.Ekbilgi.Trim() + "'",
                                sart: sorguPersonel + " = '" + ana.Id.ToString() + "'"
                                )
                            );

                    /*Adres tablos*/
                    veriTabani.sonucDondurmeyenSorguKomutIsle(
                            sorguKomut: guncelle(
                                tablo: tabloAdres,
                                sutunVeDegerleri:
                                sorguTarif + " = '" + guncel.Adres.Trim() + "'," +
                                sorguil + " = '" + guncel.il.ToString() + "'," +
                                sorguilce + " = '" + guncel.ilce.ToString() + "'," +
                                sorguUlke + " = '" + guncel.Ulke.ToString() + "'",
                                sart: sorguPersonel + " = '" + ana.Id.ToString() + "'"
                                )
                            );

                    /*Fotograf tablosu*/
                    veriTabani.baglan();
                    veriTabani.komutAl(
                        komut: guncelle(
                               tablo: tabloEkBilgi,
                               sutunVeDegerleri:
                               sorguFotograf + " = ?",
                               sart: sorguPersonel + " = '" + ana.Id.ToString() + "'"
                               ));
                    veriTabaniResimParmetreAl(
                                   veriTabani: veriTabani,
                                   image: guncel.fotograf,
                                   paremetreAdi: "image");
                    veriTabani.sonucDondurmeyenSorguKomutIsle();
                }
                catch 
                {
                    return false;
                }
                finally
                {
                    veriTabani.baglantiKes();
                }
            }
            return false;
        }

        public bool temelVeriKopyala  (TemelVeri kaynak, TemelVeri hedef)
        {
            
            if(kaynak != null)
            {
                try
                {
                    hedef.Ad = kaynak.Ad;
                    hedef.Adres = kaynak.Adres;
                    hedef.Cinsiyet = kaynak.Cinsiyet;
                    hedef.Ekbilgi = kaynak.Ekbilgi;
                    hedef.fotograf = kaynak.fotograf;
                    hedef.Id = kaynak.Id;
                    hedef.il = kaynak.il;
                    hedef.ilce = kaynak.ilce;
                    hedef.Sifre = kaynak.Sifre;
                    hedef.Soyad = kaynak.Soyad;
                    hedef.Tc = kaynak.Tc;
                    hedef.Ulke = kaynak.Ulke;
                    hedef.Yetki = kaynak.Yetki;
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
            return false;
        }

        public bool temelVeriSifreGuncelle(int id,String sifre)
        {
            try
            {
                return veriTabani.sonucDondurmeyenSorguKomutIsle(
                        sorguKomut: guncelle(
                            tablo: tabloSifre,
                            sutunVeDegerleri: sorguSifre + " = '" + sifre + "'",
                            sart: sorguId + " = '" + id.ToString() + "'"
                            ));
            }
            catch 
            {
                return false;
            }
             
        }

        protected bool veriTabaniResimParmetreAl(ClassVeriTabaniTemel veriTabani,Image image,String paremetreAdi)
        {
            try
            {
                veriTabani.baglan();
                
                byte[] foto = cevirImageByteArray(image);
                //tring denemeson = System.Text.Encoding.UTF8.GetString(foto);
                veriTabani.veriTabaniKomut.Parameters.Add(paremetreAdi,System.Data.OleDb.OleDbType.VarBinary,foto.Length).Value=foto;
                //veriTabani.veriParametre.OleDbType = SqlDbType.Image;//(veriTabani.veriParametre);
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

        public List<float> satislar()
        {
            veriTabani.komutAl(
                komut: sorgu(
                    tablo: tabloFis,
                    sutunlar: "SUM(" + sorguToplamFiyat + ")",
                    sart: "year(" + sorguTarihSaat + ") = year(getdate()) group by month(" + sorguTarihSaat + ");")
                );
            List<float> vs = new List<float>();
            try
            {
                veriTabani.baglan();
                veriTabani.veriTabaniOkuyucu = veriTabani.veriTabaniKomut.ExecuteReader();
                while (veriTabani.veriTabaniOkuyucu.Read())
                {
                    vs.Add(float.Parse(veriTabani.veriTabaniOkuyucu[0].ToString()));
                }
                veriTabani.baglantiKes();
                return vs;
            }
            catch 
            {
                MessageBox.Show("hata");
                return null;
            }

        }
        bool knt = false;
        public void Chartgoster (Chart chart,String series)
        {
            if (!knt)
            {
                chart.Titles.Add("Bu seneki aya göre satışlar");
                knt = true;
            }
            chart.Series[series].Points.Clear();
            List<float> vs = satislar();
            if (vs != null)
            {
                for (int i = 0; i < vs.Count; i++)
                {
                    chart.Series[series].Points.AddXY(i+1,double.Parse(vs[i].ToString()));
                }
               
            }
            
        }


        ~SorguIslem()
        {
            GC.Collect();// ne olur ne olmaz
        }
    }
}
