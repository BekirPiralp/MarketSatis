using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis
{
    public class TemelVeri
    {
        public int Id { get; set; }
        public String Tc { get; set; }
        public String Ad { get; set; }
        public String Soyad { get; set; }
        public bool Yetki { get; set; }
        public String Cinsiyet { get; set; } // sorguda kendimiz insert into Personel (..... 'Cinsiyet' )values ("....,'"+ Cinsiyet+"') şekli yani values tek string yollandıgı için...
        public String Sifre { get; set; }
        public String Adres { get; set; }
        public String Ekbilgi { get; set; }
        public Image fotograf { get; set; } // detaylı araştırma lazım ...

    }
}
