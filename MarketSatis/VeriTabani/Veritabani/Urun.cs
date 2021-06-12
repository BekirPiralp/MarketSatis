using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Veritabani
{
    public class Urun
    {
        public int id { get; set; }
        public String barkod { get; set; }
        public String ad { get; set; }
        public String marka { get; set; }
        public String uretimYeri { get; set; }
        public float fiyat { get; set; }
        public float indrim { get; set; }
        public int adet { get; set; }
        public String aciklama { get; set; }
        public Image resim { get; set; }

        public Urun(int id, string barkod, string ad, string marka, string uretimYeri, float fiyat, float indrim, int adet,string aciklama, Image resim)
        {
            this.id = id;
            this.barkod = barkod;
            this.ad = ad;
            this.marka = marka;
            this.uretimYeri = uretimYeri;
            this.fiyat = fiyat;
            this.indrim = indrim;
            this.adet = adet;
            this.aciklama = aciklama;
            this.resim = resim;
        }

        public Urun(string barkod)
        {
            this.barkod = barkod;
        }

        public Urun(int id)
        {
            this.id=id;
        }

        public Urun()
        {

        }
    }
}
