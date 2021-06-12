using MarketSatis.VeriTabani.Kodlar;
using MarketSatis.VeriTabani.Veritabani;
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
    public partial class FormPersonelEkle : Form
    {
        SorguIslem sorguIslem = new SorguIslem();
        List<Ozel> ulke,ilce,il;
        bool kntrl = false;

        // personelin telefon ve email bilgisini bilerek kaldırdım
        // yönetici piskopat olabilir( bu yüzden tel.i kaldırdım) veya çalışanına illa email isteye bilir
        // bir market çalışanı yönünden email ne kadar gereke bilir ?
        // Çok gereken bir mevzu ise ekbilgi de ala bilir;
        // Lakin ufak bir güncelleme ile bu değişiklikler geri getirile bilir
        public FormPersonelEkle()
        {
            InitializeComponent();
        }

        private void buttonGozat_Click(object sender, EventArgs e)
        {
            openFileDialogResim.Filter = "sadece jpg png tif jpeg ico|*.jpg; *.png; *.tif; *.jpeg; *.ico";
            openFileDialogResim.FileName = "Resim seçin";
            this.openFileDialogResim.ShowDialog();

            textBoxResim.Text = openFileDialogResim.FileName;

            try
            {
                pictureBox1.Image = Image.FromFile(textBoxResim.Text);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Lütfen resim seçin", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxResim.Text = "";
            }
            finally
            {
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image =  global::MarketSatis.Properties.Resources.boskullanici;
                }
            }
        }

        private void textBoxTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender:sender,e:e);
        }

        private void textBoxAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPressHarf(sender: sender, e: e);
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTamam_Click(object sender, EventArgs e)
        {
            // gerekli denetlemeler 
            // ve daha öce silinmiş biri ise işlem yapılmaz
            /*burada kaldım*/

        }

        private void comboBoxUlke_MouseHover(object sender, EventArgs e)
        {
            comboBoxil.Items.Clear();
            comboBoxilçe.Items.Clear();
            comboBoxUlke.Items.Clear();

            ulke=
            sorguIslem.ComboBoxVeriEkle(tablo: sorguIslem.tabloUlke, comboBox: (ComboBox)sender);          
        }

        private void comboBoxUlke_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxilçe.Items.Clear();
            comboBoxil.Items.Clear();

            il = sorguIslem.ComboBoxVeriEkle(
                tablo: sorguIslem.tabloil,
                comboBox: comboBoxil,
                sart: sorguIslem.sorguUlke + " = " + ulke[comboBoxUlke.SelectedIndex].id);
        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxilçe.Items.Clear();

            ilce = sorguIslem.ComboBoxVeriEkle(
                tablo: sorguIslem.tabloilçe,
                comboBox: comboBoxilçe,
                sart: sorguIslem.sorguUlke + " = " + ulke[comboBoxUlke.SelectedIndex].id+
                " and "+sorguIslem.sorguil+" = "+ il[comboBoxUlke.SelectedIndex].id);
            kntrl = true;//buraya kadar gelsiyse zaten ...
        }

        private void comboBoxilçe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // şuan için gerek görmüyorum ama seçimi sağlamam lazım
            // peki otomatik gelen değer işine yararsa?
        }
    }
}
