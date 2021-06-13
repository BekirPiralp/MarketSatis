using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketSatis.VeriTabani.Kodlar
{
    public class SorguUrun : SorguIslem
    {
        public SorguUrun():base()
        {
            
        }
        
        public Urun Getir (String Barkod)
        {
            if (Barkod != "")
            {
                Urun urun = new Urun();
                Barkod = Barkod.Trim();
                urun.barkod = Barkod;
                //id;
                urun.id = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguId,
                        tablo: tabloUrun,
                        sart: sorguBarkod + " = " + Barkod
                    )).ToString()!=""?
                    Convert.ToInt32(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguId,
                        tablo: tabloUrun,
                        sart: sorguBarkod + " = " + Barkod
                    )))
                    :0;

                //aciklama
                urun.aciklama = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguUrunAciklama,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                        )).ToString();
                //ad
                urun.ad= veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguAd,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                        )).ToString();
                //Marka
                urun.marka= veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguMarka,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                        )).ToString();
                //Üretim yeri
                urun.uretimYeri= veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguUretimYeri,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                        )).ToString();
                //Fiyat
                urun.fiyat = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguFiyat,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                    )).ToString() != "" ?
                    float.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguFiyat,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                    )).ToString())
                    : -1;
                //indirim
                urun.indrim = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguIndirim,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                    )).ToString() != "" ?
                    float.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguIndirim,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                    )).ToString())
                    : -1;
                //resim
                urun.resim  = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguResim,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                    )).ToString() != "" ?
                    cevirByteArrayImage(
                        rsm:(byte[]) veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: this.sorgu(
                        sutunlar: sorguResim,
                        tablo: tabloUrun,
                        sart: sorguId + " = " + urun.id
                    )))
                    : global::MarketSatis.Properties.Resources.urun;
                //adet
                urun.id = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                   sorguKomut: this.sorgu(
                       sutunlar: sorguAdet,
                       tablo: tabloUrun,
                       sart: sorguId + " = " + urun.id
                   )).ToString() != "" ?
                   int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                   sorguKomut: this.sorgu(
                       sutunlar: sorguAdet,
                       tablo: tabloUrun,
                       sart: sorguId + " = " + urun.id
                   )).ToString())
                   : 0;

                if (urun.id >0)
                {
                    return urun;
                }
            }
            
            return null;
            
        }

        public bool Guncelle(Urun ana, Urun guncel)
        {
            if (ana.id == guncel.id && String.Compare(ana.barkod,guncel.barkod)==0)
            {
                if (ana.fiyat != guncel.fiyat || ana.indrim != guncel.indrim || ana.adet != guncel.adet)
                {
                    return veriTabani.guncelle(
                        updateKomutu:guncelle(tablo: tabloUrun,
                        sutunVeDegerleri: sorguFiyat + " = '" + guncel.fiyat.ToString() + "' , "
                        + sorguIndirim + " = '" + guncel.indrim.ToString() + "' , " +
                        sorguAdet + " = '" + guncel.adet.ToString()+"'"
                        , sart: sorguId + " = " + ana.id));
                }
            }
            return false;
        }

        public bool Ekle(Urun ekle)
        {
            String[] sutunlar = { sorguAd, sorguBarkod, sorguAdet, sorguMarka, sorguUrunAciklama, sorguUretimYeri, sorguFiyat, sorguIndirim, sorguResim };
            String[] degerler = {ekle.ad.Trim(),ekle.barkod.Trim(),ekle.adet.ToString(),ekle.marka,ekle.aciklama,ekle.uretimYeri,ekle.fiyat.ToString(),
            ekle.indrim.ToString(),"@image"};

            MessageBox.Show(ekle.barkod);
            Urun kntrl = Getir(ekle.barkod);
            if (kntrl==null)//urun geliyorsa zaten sistemde ekli demektir ;D
            {
                if (ekle.barkod != "")
                {
                    veriTabani.komutAl(komut:
                        this.ekle(
                            tablo: tabloUrun,
                            sutunlar: sutunlar,
                            degerler: degerler
                            ));

                    /*FileStream fs = new FileStream(ekle.resim_yolu, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    rsm = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();*/
                    veriTabaniResimParmetreAl(
                               veriTabani: veriTabani,
                               image: ekle.resim,
                               paremetreAdi: "@image"
                               );

                    return veriTabani.sonucDondurmeyenSorguKomutIsle();
                    veriTabani.baglantiKes();
                }
            }
            return false;
        }

        public Urun kopyaOlustur(Urun urun)
        {
            if (urun != null)
            {
                Urun yeni = new Urun();
                yeni.id = urun.id;
                yeni.ad = urun.ad;
                yeni.adet = urun.adet;
                yeni.aciklama = urun.aciklama;
                yeni.barkod = urun.barkod;
                yeni.fiyat = urun.fiyat;
                yeni.indrim = urun.indrim;
                yeni.marka = urun.marka;
                yeni.resim = urun.resim;
                yeni.uretimYeri = urun.uretimYeri;

                return yeni;
            }
            return null;

        }

    }
}
