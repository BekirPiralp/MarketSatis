using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Kodlar
{
    public class SorguDefo:SorguIslem
    {

        public bool Ekle(Defo defo )
        {
            if(defo!=null && defo.urun>0 && defo.personel>0 && defo.adet > 0)
            {
                String[] sutunlar = { sorguUrun, sorguAdet, sorguPersonel, sorguAciklama };
                String[] degerler = 
                    { defo.urun.ToString(),defo.adet.ToString(),defo.personel.ToString(),defo.aciklama };
                veriTabani.komutAl(komut:
                        this.ekle(
                            tablo: tabloDefo,
                            sutunlar: sutunlar,
                            degerler: degerler
                            ));
                return veriTabani.sonucDondurmeyenSorguKomutIsle();
            }
            return false;
        } 
    }
}
