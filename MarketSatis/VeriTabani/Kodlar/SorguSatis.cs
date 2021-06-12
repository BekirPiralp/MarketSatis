using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Kodlar
{
    public class SorguSatis:SorguIslem
    {
        public SorguSatis() : base() 
        { }


        public bool Ekle(Satis satis )
        {
            if (satis.fis > 0 && satis.adet > 0)
            {
                String[] sutunlar = {sorguUrun,sorguAdet,sorguFis};
                String[] degerler = { satis.urun.ToString(), satis.adet.ToString(), satis.fis.ToString() };

                return veriTabani.sonucDondurmeyenSorguKomutIsle(sorguKomut: ekle(tablo: tabloSatis,
                    sutunlar: sutunlar,
                    degerler: degerler)
                    );
            }

            return false;
        }
        // Guncellesi suan için 
        //programda kullanılmayacağı için yazılmamıştır
        // her satis dosyası satış onayladıktan sonra gelmektedir hal böyle olunca da
        // güncellenecek bir sey bulunamamış çünkü veriler düzenli gelmektedir
        public Satis Getir(int id)
        {
            if(id > 0)
            {
                Satis satis = new Satis();
                //id
                satis.id = id;
                // fiş
                satis.fis = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguFis,
                        tablo: tabloSatis,
                        sart: sorguId + " = '" + id.ToString() + "'"
                        )).ToString() != "" ?
                        int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguFis,
                        tablo: tabloSatis,
                        sart: sorguId + " = '" + id.ToString() + "'"
                        )).ToString())
                        : -1;
                // Ürün 
                satis.urun= veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguUrun,
                        tablo: tabloSatis,
                        sart: sorguId + " = '" + id.ToString() + "'"
                        )).ToString() != "" ?
                        int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguUrun,
                        tablo: tabloSatis,
                        sart: sorguId + " = '" + id.ToString() + "'"
                        )).ToString())
                        : -1;
                // Adet
                satis.adet = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguAdet,
                        tablo: tabloSatis,
                        sart: sorguId + " = '" + id.ToString() + "'"
                        )).ToString() != "" ?
                        int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                    sorguKomut: sorgu(
                        sutunlar: sorguAdet,
                        tablo: tabloSatis,
                        sart: sorguId + " = '" + id.ToString() + "'"
                        )).ToString())
                        : -1;

                return satis;
            }
            
            return null;

        }
        public Satis Getir (int fis, int urun)
        {
            if(fis > 0 && urun > 0)
            {
                Satis satis = new Satis();
                //id
                satis.id= veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                        sorguKomut: sorgu(
                            sutunlar: sorguAdet,
                            tablo: tabloSatis,
                            sart: sorguFis + " = '" + fis.ToString() + "' and "+ sorguUrun+" = '"+urun.ToString()+"'"
                            )).ToString() != "" ?
                            int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                        sorguKomut: sorgu(
                            sutunlar: sorguAdet,
                            tablo: tabloSatis,
                            sart: sorguFis + " = '" + fis.ToString() + "' and " + sorguUrun + " = '" + urun.ToString() + "'"
                            )).ToString())
                            : -1;
                if (satis.id >0)
                {
                    //fis
                    satis.fis = fis;
                    //Ürün
                    satis.urun = urun;
                    // Adet
                    satis.adet = veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                        sorguKomut: sorgu(
                            sutunlar: sorguAdet,
                            tablo: tabloSatis,
                            sart: sorguId + " = '" + id.ToString() + "'"
                            )).ToString() != "" ?
                            int.Parse(veriTabani.tekAlanlikVeriDondurenSorguKomutlarIsle(
                        sorguKomut: sorgu(
                            sutunlar: sorguAdet,
                            tablo: tabloSatis,
                            sart: sorguId + " = '" + id.ToString() + "'"
                            )).ToString())
                            : -1;
                    return satis;
                }

            }
            return null;
        }
    }
}
