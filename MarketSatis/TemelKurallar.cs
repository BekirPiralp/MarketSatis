using MarketSatis.VeriTabani.Kodlar;
using MarketSatis.VeriTabani.Veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketSatis
{
    public  static class TemelKurallar
    {
       
        public static void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(!char.IsDigit(e.KeyChar) )&& !char.IsControl(e.KeyChar))
            //char.IsControl(e.KeyChar)!=true olmaz is silme gibi kontrol işlemleri olmaz
            if (char.IsDigit(e.KeyChar) != true && char.IsControl(e.KeyChar) != true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void textBox_KeyPressHarf(object sender, KeyPressEventArgs e)
        {
            //if(!char.IsDigit(e.KeyChar) )&& !char.IsControl(e.KeyChar))
            //char.IsControl(e.KeyChar)!=true olmaz is silme gibi kontrol işlemleri olmaz
            if (char.IsLetter(e.KeyChar) != true && char.IsControl(e.KeyChar) != true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public static Urun araUrun(object sender, EventArgs e)
        {
            Urun urun;
            TextBox textBox = (TextBox)sender;
            SorguUrun sorguUrun = new SorguUrun(); 
            if(textBox.Text != "")
            {
                urun = sorguUrun.Getir(textBox.Text.Trim());
                if(urun!= null)
                    return urun;
            }
            return null;
        }

        public static bool urunEkleCikar(Urun urun, Satis satis, List<ListUrunSatis> lists)
        {
            if (urun != null)
            {
                if (satis.adet > 0)
                {
                    ListUrunSatis urunSatis;
                    if (lists.Count == 0)
                    {
                        urunSatis = new ListUrunSatis();
                        urunSatis.urun = urun;
                        urunSatis.satis = satis;
                        lists.Add(urunSatis);
                        return true;
                    }
                    else
                    {
                        for (int i = 0; i < lists.Count; i++)
                        {
                            if (lists[i].urun.id == urun.id)
                            {
                                lists[i].satis.adet += satis.adet;
                                return true;
                            }
                        }

                        urunSatis = new ListUrunSatis();
                        urunSatis.urun = urun;
                        urunSatis.satis = satis;
                        lists.Add(urunSatis);
                        return true;

                    }
                }
                else if (satis.adet < 0)
                {
                    if (lists.Count > 0)
                    {
                        for (int i = 0; i < lists.Count; i++)
                        {
                            if (lists[i].urun.id == urun.id && lists[i].satis.adet >= -1 * satis.adet)//adet sayısı pozitif yapılıp büyüklükleri değerlendirildi
                            {
                                //bu sayede gelenin listedeki üründen fazla olup olmadığı kontrol edildi
                                // çıkarma işlemi burda yapılacak
                                lists[i].satis.adet += satis.adet;
                                if (lists[i].satis.adet == 0)
                                {
                                    lists.RemoveAt(i);
                                    // adeti sıfır olan ürün çıkar.........
                                }
                                return true;
                            }
                        }
                    }
                    MessageBox.Show("Urununuz listede mevcut değil veyahut \n" +
                        "siz listedeki değerden fazla bir ürün çıkarmaya çalışıyorsunuz...");
                    return false;
                }
                else
                {       // adet sıfır olursa
                    MessageBox.Show("Urunun adetini sıfır girdiniz bu yüzden listeye eklenmemiştir. " +
                        "\nUrunun fiyat kontrolü yaptığınız tespit edilmiştir.");
                    return false;
                }
            }

            MessageBox.Show("Aradıgınız urun bulunamadı lütfen kontrol ediniz");
            return false;
        }

        //veri tabanına onaylanmış olan satışı ayarlı ve formatlı fbr şekilde yükler
        public static bool fisYukle(Fis fis, List<ListUrunSatis> lists)
        {

            SorguFis sorguFis = new SorguFis();
            SorguSatis sorguSatis = new SorguSatis();
            SorguUrun sorguUrun = new SorguUrun();
            Urun yeni;
            for (int i = 0; i < lists.Count; i++)
            {
                if(lists[i].satis.adet> lists[i].urun.adet)
                {
                    MessageBox.Show(
                        "Depoda "+ lists[i].urun.barkod+" 'lu üründen "+ lists[i].urun.adet+" adet kalmış olup,\n"+
                        lists[i].satis.adet+" adet satmaya kaltığınızdan dolayı işleminiz iptal olmuştur.\n"+
                        "Lütfen düzeltip tekrar deneyiniz."
                        , "Az ürün", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (sorguFis.Ekle(fis))
            {
                fis = sorguFis.Getir(fis.fisKod);
                for (int i = 0; i < lists.Count; i++)
                {
                    lists[i].satis.fis = fis.id;
                    lists[i].satis.urun = lists[i].urun.id;
                    yeni = sorguUrun.kopyaOlustur(lists[i].urun);
                    yeni.adet -= lists[i].satis.adet;
                    if (sorguSatis.Ekle(lists[i].satis) && sorguUrun.Guncelle(lists[i].urun, yeni))
                    {
                        MessageBox.Show("İşlem başarıyla gerçekleşti");
                        return true;
                    }

                }
            }
            return false;
        }
    }
}
