using MarketSatis.VeriTabani.Kodlar;
using MarketSatis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketSatis
{

    public partial class Form1 : Form
    {


        SorguIslem sorgu;
        FormPersonel formPersonel;
        FormYonetici formYonetici;
        bool kntrltc = false;
        bool kntrlsifre = false;


        public Form1()
        {
            InitializeComponent();

            sorgu = new SorguIslem();


            if (!sorgu.baglan())
            {
                DialogResult dialogResult=
                MessageBox.Show("Veritabani Bağlantısı Sağlanamadı. \nLütfen bağlantıyı kontrol edinip tekrar deneyiniz.", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0); /*this.Close(); Main bloğunda nesne hatası verdittirdiği ve kimi zamanda
                program arka tarafta açık kaldığı için bu fonksiyonu kullandım*/
            }
            //kontrol amaçlı
            //else
            //{
            //    MessageBox.Show("Veritabani Bağlantısı Sağlandı", "Evet",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            //}
            sorgu.baglantiKes();
        }

        ~Form1()
        {
            sorgu.baglantiKes();
        }

        private void buttonHakkinda_Click(object sender, EventArgs e)
        {
            FormHakkinda frm = new FormHakkinda();
            frm.ShowDialog();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSifre.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
        private void sifreHover(object sender, EventArgs e)
        {
            if (kntrlsifre == false)
            {
                textBoxSifre.Text = "";
                kntrlsifre = true;
                textBoxSifre.PasswordChar = '*';
                checkBox1.Checked = false;
            }
        }
        private void sifreHover()
        {
            if (kntrlsifre == false)
            {
                textBoxSifre.Text = "";
                kntrlsifre = true;
                textBoxSifre.PasswordChar = '*';
                checkBox1.Checked = false;
            }
        }
        private void tcHover(object sender, EventArgs e)
        {
            if (kntrltc == false)
            {
                textBoxTc.Text = "";
                kntrltc = true;
            }
        }
        private void tcHover()
        {
            if (kntrltc == false)
            {
                textBoxTc.Text = "";
                kntrltc = true;
            }
        }

        private void textBoxTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            String sifre = "";
            String tc = "";
            TemelVeri temelVeri;
            if (this.textBoxTc.Text.Length != 11 || this.textBoxTc.Text == "")
            {
                MessageBox.Show("TC kimlik numarası 11 haneli olmalıdır.", "Dikkat",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tcHover();
            sifreHover();

            tc = this.textBoxTc.Text.Trim();
            sifre = this.textBoxSifre.Text.Trim();

            if (sorgu.girisTc(tc)==true)
            {

                if (sorgu.girisSifre(sifre))
                {
                    // temel veri alma ve oluşturma
                    temelVeri = sorgu.temelVeriAl(tc);


                    if (temelVeri.Yetki && !sorgu.silDurum())
                    {
                        formYonetici = new FormYonetici(temelVeri);
                        formYonetici.ShowDialog();

                    }
                    else if(!sorgu.silDurum())
                    {
                        formPersonel = new FormPersonel(temelVeri);
                        formPersonel.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("İşten çıkarıldığınız için giriş yapamazsınız.", "Dikkat",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Yanlış Şifre girdiniz.\nLütfen kontrol ediniz.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            else
            {
                MessageBox.Show("Aranan kullanıcı sistemde kayıtlı değildir", "Dikkat",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

    }
}
