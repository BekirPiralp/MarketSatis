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
    public partial class FormSifreDegistir : Form
    {
        public FormSifreDegistir()
        {
            InitializeComponent();
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult=MessageBox.Show("Eminmisiniz...!","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(dialogResult== DialogResult.OK)
            {
                // yapılacak işlem ve kontroller
            }
            else if(dialogResult== DialogResult.No)
            {
                this.Close();
            }
        }

        private void textBoxTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }
    }
}
