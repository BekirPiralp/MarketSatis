using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Veritabani
{
    public class Satis
    {
        public int id { set; get; } // pek kullanılmayacak ssadece guncellemelerde vs...
        public int fis { set; get; }
        public int adet { set; get; }
        public int urun { set; get; }

        public Satis()
        {

        }

        public Satis(int id)
        {
            this.id = id;
        }

        public Satis(int fis, int adet, int urun)
        {
            this.fis = fis;
            this.adet = adet;
            this.urun = urun;
        }

        public Satis(int id,int fis,int adet,int urun)
        {
            this.id = id;
            this.fis = fis;
            this.adet = adet;
            this.urun = urun;
        }
    }
}
