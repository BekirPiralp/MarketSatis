using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Kodlar
{
    public class SorguIade:SorguIslem
    {
        public bool Ekle(Iade iade)
        {
            if(iade != null)
            {
                String[] sutunlar = { sorguFis,sorguSatis,sorguPersonel, sorguAciklama };
                String[] degerler =
                    { iade.fis.ToString(),iade.satis.ToString(),iade.personel.ToString(),iade.aciklama};
                veriTabani.komutAl(komut:
                        this.ekle(
                            tablo: tabloIade,
                            sutunlar: sutunlar,
                            degerler: degerler
                            ));
                return veriTabani.sonucDondurmeyenSorguKomutIsle();
            }
            return false;
        } 
    }
}
