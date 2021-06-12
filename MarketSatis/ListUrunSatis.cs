using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis
{
    public class ListUrunSatis
    {
        public Urun urun { get; set; }
        public Satis satis { get; set; }

        override public string ToString()
        {
            return urun.marka + " " + urun.ad + " %18 kdv fiyat: " + urun.fiyat + " *  adet: " + satis.adet + " = " + (urun.fiyat * satis.adet).ToString();
        }

        public float fiyatGetir()
        {
            return urun.fiyat * satis.adet - (urun.fiyat *satis.adet*urun.indrim);
        }
    }
}
