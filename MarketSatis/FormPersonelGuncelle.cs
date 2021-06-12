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
    public partial class FormPersonelGuncelle : Form
    {
        public FormPersonelGuncelle()
        {
            InitializeComponent();
        }

        

        private void buttonGozat_Click(object sender, EventArgs e)
        {
            openFileDialogResim.Filter= "sadece jpg png tif jpeg ico|*.jpg; *.png; *.tif; *.jpeg; *.ico";
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
        }

        private void textBoxTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender: sender, e: e);
        }

        private void textBoxAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPressHarf(sender:sender,e:e);
        }
        private int ayar(object checkbox, string textbox, ref string strng)
        {
            CheckBox checkBox = (CheckBox)checkbox;
            
            if (checkBox.Checked == true && textbox.Length > 0)
            {
                strng += textbox;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void buttonTamam_Click(object sender, EventArgs e)
        {
            int kontrol = 0;
            String guncelle = "";
            if(textBoxTc.Text != "" && textBoxTc.Text.Length == 11)
            {
                //veri tabanı bulma ver ekleme kodu yazılacak
                guncelle += textBoxTc.Text;
                kontrol += ayar(checkBoxAd, textBoxAd.Text, ref guncelle);
                kontrol += ayar(checkBoxSoyad, textBoxSoyad.Text, ref guncelle);
                kontrol += ayar(checkBoxAdres,textBoxAdres.Text , ref guncelle);
                kontrol += ayar(checkBoxEkbilgi,textBoxEkbilgi.Text, ref guncelle);
                kontrol += ayar(checkBoxResim, textBoxResim.Text, ref guncelle);
                if (radioButtonYonetici.Checked == true)
                {
                    kontrol += ayar(checkBoxDurum, "true", ref guncelle);
                }
                else
                {
                    kontrol += ayar(checkBoxDurum, "false", ref guncelle);
                }

                if ( kontrol >=1)
                {
                    // veri tabanına yükle
                    MessageBox.Show(guncelle);
                }
                else
                {
                    MessageBox.Show("En az bir güncellem yapmalısınız...","Dikkat",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istedğiniz kişinin 11 haneli TC kimlik numarasını giriniz.!","Dikkat",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
