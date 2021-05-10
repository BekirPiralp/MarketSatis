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
    public partial class FormPersonelCikar : Form
    {
        private String Tc;
        public FormPersonelCikar(String TcAl)
        {
            Tc = TcAl;
            InitializeComponent();
        }
        

        private void textBoxTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender:sender,e:e);
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTamam_Click(object sender, EventArgs e)
        {
            if (textBoxTC.Text.Length == 11)
            {
                DialogResult dialogResult =
                MessageBox.Show("Eminisiniz ?", "Dikkat", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    if (string.Compare(Tc, textBoxTC.Text) == 0)
                    {
                        MessageBox.Show("Kendinizi silemezsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Yapılacak işlemler
                        //ek bilgi de güncelleme yapılacak
                    }
                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarası 11 hanelidir.!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
