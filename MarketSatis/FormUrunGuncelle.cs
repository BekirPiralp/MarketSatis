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
    public partial class FormUrunGuncelle : Form
    {
        public Boolean YoneticiKontrol { get; set; }
        
        public FormUrunGuncelle(Boolean YoneticiKontrol = false)
        {
            this.YoneticiKontrol=YoneticiKontrol;
            InitializeComponent();
            checkBoxIndirimGuncelle.Checked = false;
            checkBoxIndirimGuncelle.Enabled = this.YoneticiKontrol;
            numericUpDownIndirim.Enabled = this.YoneticiKontrol;
        }
        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult=MessageBox.Show("Değişikliklerden emin misiniz?", "Dikkat", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(dialogResult== DialogResult.OK)
            {
                //değişiklikler uygulanacak
                if (YoneticiKontrol == true)
                {
                    // yöneticide
                }else if (YoneticiKontrol == false)
                {
                    //personel de
                }
            }
            if (dialogResult == DialogResult.Cancel)
            {
                //bişey yapmayacak
            }
        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }
    }
}
