using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.VeriTabani.Veritabani
{
    public class Fis
    {
        public int id { get; set; }
        public int personel { get; set; }
        public float toplamFiyat { get; set; }
        public DateTime tarihSaat { get; set; }
        public String fisKod { get; set; }//15 hane

        public Fis()
        {

        }

        public Fis(int personel)
        {
            this.personel = personel;
        }

        public Fis(String fisKod, int personel)
        {
            this.fisKod = fisKod;
            this.personel = personel;
        }

        public Fis(int id, int personel, DateTime tarihSaat, String fisKod)
        { 
            this.id = id;
            this.personel = personel;
            this.tarihSaat = tarihSaat;
            this.fisKod = fisKod;
        }
                        
    }
}
