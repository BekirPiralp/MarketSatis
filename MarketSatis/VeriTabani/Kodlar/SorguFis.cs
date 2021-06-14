using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSatis.VeriTabani.Veritabani;

namespace MarketSatis.VeriTabani.Kodlar
{
    public class SorguFis :SorguIslem
    {
        DateTime dateTime = DateTime.Now;
        //DateTime dt = new DateTime();
        DateTime aldt; //,fark;
        public SorguFis() : base()
        {
            aldt = DateTime.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorguKomut: "Select getdate();").ToString());
            //fark = dt.Subtract(dateTime - aldt);
        }

        public bool Ekle(Fis fis)
        {
            if (fis.fisKod != "" && fis.personel>0)
            {
                // tarihsaat veri tabanında default tanımlı olduğu için eklenmemiştir.
                // bu sayede her nerden bağlanılırsa bağlanılsın kayıtlar veri tabanına göre olacak
                // cihazın tarihi bozuk olsa bile getirmede ona göre hesap yapılıp zaman farkı eklenecek
                // veya farklı ülke konumlarda olsa bile sürekli net bir zaman elde edilmiş olacaktır.
                String[] sutunlar = {sorguPersonel,sorguToplamFiyat,sorguKod};
                String[] degerler = { fis.personel.ToString(), ((float)fis.toplamFiyat).ToString(), fis.fisKod };
                return veriTabani.sonucDondurmeyenSorguKomutIsle(
                    sorguKomut:ekle(
                        tablo:tabloFis,
                        sutunlar: sutunlar,
                        degerler: degerler
                        ));
            }
            return false;
        }


        public Fis Getir(int id)
        {
            if (id > 0)
            {
                Fis fis = new Fis();
                //id
                fis.id = id;
                if (veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(sutunlar: sorguId, tablo: tabloFis, sart: sorguId+" = "+ fis.id)).ToString()!="")
                {
                    // Personel
                    fis.personel = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                        sutunlar: sorguPersonel, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString() != "" ?
                        int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguPersonel, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString()) : -1;
                    // Toplam Fiyat
                    fis.toplamFiyat = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguToplamFiyat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString()!=""?
                            float.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguToplamFiyat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString()):-1;
                    // tarih saat satış
                    fis.tarihSaat = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguTarihSaat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString() != "" ?
                            DateTime.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguTarihSaat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString()) :
                            DateTime.Now;
                    // Kod
                    fis.fisKod = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguKod, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString();

                    return fis;
                }
            }
            return null;
        }
        public Fis Getir (String fisKod)
        {
            if(fisKod != "" && fisKod.Length == 15)
            {
                Fis fis = new Fis();
                //id
                fis.id = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguId, tablo: tabloFis, sart: sorguKod + " = " + fisKod + " order by " + tabloFis + "." + sorguId + " desc")).ToString() != "" ?
                            int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguId, tablo: tabloFis, sart: sorguKod + " = " + fisKod +" order by "+tabloFis+"."+sorguId +" desc")).ToString()) : -1;
                /*Fiş kod kullanmadan personel id ilede aynı şekilde getirilebilirdi...*/
                if (fis.id > 0)
                {
                    // Personel
                    fis.personel = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                        sutunlar: sorguPersonel, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString() != "" ?
                        int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguPersonel, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString()) : -1;
                    // Toplam Fiyat
                    fis.toplamFiyat = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguToplamFiyat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString() != "" ?
                            float.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguToplamFiyat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString()) : -1;
                    // tarih saat satış
                    fis.tarihSaat = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguTarihSaat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString() != "" ?
                            DateTime.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(sorgu(
                            sutunlar: sorguTarihSaat, tablo: tabloFis, sart: sorguId + " = " + fis.id)).ToString()) :
                            DateTime.Now;
                    // Kod
                    fis.fisKod = fisKod;

                    return fis;
                }
            }
            return null;
        }

    }
}
