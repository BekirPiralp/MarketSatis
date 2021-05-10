using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarketSatis.VeriTabani.Kodlar
{
    class ClassVeriTabaniTemel : InterfaceVeriTabaniTemel
    {
        public OleDbConnection veriTabani { get; set; }
        public OleDbCommand veriTabaniKomut { get ; set ; }
        public OleDbDataReader veriTabaniOkuyucu { get ; set ; }
        public ClassVeriTabaniTemel()
        {
            
            this.veriTabani = new OleDbConnection();
            this.veriTabaniKomut = new OleDbCommand();
            //this.veriTabaniOkuyucu = new OleDbDataReader();
        }
        private bool komutIsle()
        {
            bool kntrl = true;
            try
            {
                baglan();
                this.veriTabaniKomut.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata - Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kntrl = false;
            }
            finally
            {
                baglantiKes();
            }
            return kntrl;
        }

        public bool baglan()
        {
            try
            {
                veriTabani.Open();
                return true;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata - Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public object Baglan(string BaglantiBilgileri)
        {
            return baglantiBilgileriGir(BaglantiBilgileri: BaglantiBilgileri) && baglan();
        }

        public bool baglantiBilgileriGir(string BaglantiBilgileri)
        {
            if (BaglantiBilgileri!="")
            {
                try
                {
                    this.veriTabani.ConnectionString= BaglantiBilgileri;
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString(), "Hata - Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool baglantiKes()
        {
            try
            {
                this.veriTabani.Close();
                return true;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata - Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool degistir(string veriTabani)
        {
            if(veriTabani != "")
            {
                try
                {
                    this.veriTabani.ChangeDatabase(veriTabani);
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString(), "Hata - Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool guncelle()
        {
            return komutIsle();
        }

        public bool guncelle(string updateKomutu)
        {
            return komutAl(komut:updateKomutu) && guncelle();
        }

        public bool guncelle(string updateKomutu, OleDbConnection veriTabani)
        {
            return komutAl(komut:updateKomutu,veriTabani:veriTabani) && guncelle();
        }

        public bool komutAl(string komut)
        {
            if (komut != "")
            {
                try
                {
                    this.veriTabaniKomut.CommandText = komut;
                    this.veriTabaniKomut.Connection = veriTabani;
                    
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString(), "Hata - Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool komutAl(string komut, OleDbConnection veriTabani)
        {
            komutAl(komut: komut);
            if(veriTabani != null)
            {
                this.veriTabani = veriTabani;
                return true;
            }
            return false;
        }

        public object kumeDondurenSorguKomutlarIsle()
        {
            throw new NotImplementedException();
            //object obj;
            //try
            //{
            //    veritabanibaglan();
            //    veritabaniokuyucu = veritabanikomut.executereader();
            //    while (veritabaniokuyucu.read())
            //    {
            //        obj = veritabaniokuyucu[];
            //    }
            //}
            //catch (exception)
            //{

            //    throw;
            //}
        }

        public object kumeDondurenSorguKomutlarIsle(string sorguKomut)
        {
            throw new NotImplementedException();
        }

        public object kumeDondurenSorguKomutlarIsle(string sorguKomut, OleDbConnection veriTabani)
        {
            throw new NotImplementedException();
        }

        public object kumeDondurenSorguKomutlarIsle(string tabloAdi, string kolonAdi)
        {
            throw new NotImplementedException();
        }

        public object kumeDondurenSorguKomutlarIsle(string tabloAdi, string kolonAdi, OleDbConnection veriTabani)
        {
            throw new NotImplementedException();
        }

        public bool sonucDondurmeyenSorguKomutIsle()
        {
            return komutIsle();
        }

        public bool sonucDondurmeyenSorguKomutIsle(string sorguKomut)
        {
            return komutAl(komut: sorguKomut) && komutIsle();
        }

        public bool sonucDondurmeyenSorguKomutIsle(string sorguKomut, OleDbConnection veriTabani)
        {
            return komutAl(komut: sorguKomut,veriTabani:veriTabani) && komutIsle();
        }

        public object tekAlanlikVeriDondurenSorguKomutlarIsle()
        {
            object obj;
            try
            {
                baglan();
                obj = this.veriTabaniKomut.ExecuteScalar();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Hata - Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                baglantiKes();
            }
            return obj;
        }

        public object tekAlanlikVeriDondurenSorguKomutlarIsle(string sorguKomut)
        {
            komutAl(komut:sorguKomut);
            return tekAlanlikVeriDondurenSorguKomutlarIsle();
        }

        public object tekAlanlikVeriDondurenSorguKomutlarIsle(string sorguKomut, OleDbConnection veriTabani)
        {
            komutAl(komut: sorguKomut,veriTabani:veriTabani);
            return tekAlanlikVeriDondurenSorguKomutlarIsle();
        }
    }
}
