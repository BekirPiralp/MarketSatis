using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSatis.HataTanimlamalari
{
    // 23:05:2021 02:37 şuana kadar daha denenmedi sonra denenmiş olabilir....
    class ClassBosVeri:ApplicationException
    {
        public string hataKaynagi{
            get;
            set;
        }

        public ClassBosVeri(string hataKaynagi )
        {
            this.hataKaynagi = hataKaynagi;
        }

        public override string ToString()
        {
            return this.hataKaynagi;
        }
    }
}
