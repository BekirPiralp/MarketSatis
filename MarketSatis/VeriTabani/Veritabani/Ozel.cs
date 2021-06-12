using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Veritabani
{
    public class Ozel
    {
        public int id { get; set; }
        public String ad { get; set; }
        public Ozel()
        {

        }
        public Ozel(int id, String ad)
        {
            this.id = id;
            this.ad = ad;
        }
    }
}
