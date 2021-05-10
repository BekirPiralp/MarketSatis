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
            // ve daha öce silinmiş biri ise bile ona göre işlem 
            // lakin aktif kayıtlı hariç herkeste yapılabilir
            // ek olarak eski işten çıkarılmış kişinin Çıkarılma sebebine eklenir...

        }
    }
}
