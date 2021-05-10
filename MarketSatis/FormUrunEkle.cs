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
    public partial class FormUrunEkle : Form
    {
        public FormUrunEkle()
        {
            InitializeComponent();
        }

        private void resimEkle(String al)
        {
            textBoxResim.Text = al;
            try
            {
                pictureBoxUrunResim.Image = Image.FromFile(textBoxResim.Text);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Lütfen resim seçin", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxResim.Text = "";
            }
        }

        private void buttonGozat_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "sadece jpg png tif jpeg ico|*.jpg; *.png; *.tif; *.jpeg; *.ico";
            openFileDialog1.FileName = "Resim seçin";
            openFileDialog1.ShowDialog();
            resimEkle(openFileDialog1.FileName);
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Ürünü Eklemek İstediğinizden Emin misiniz ?", "Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                // hiçbir işlem yaptırmıyorum
            }
            if (sonuc == DialogResult.Yes)
            {
                //indirim yüzdesini sıfır yapmayı unutma
                //Onu Yönetici Belirliyecek
                //işlemler ve tanımlamalar
            }

        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }
    }
}
