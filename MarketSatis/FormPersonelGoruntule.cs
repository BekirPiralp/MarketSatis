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
    public partial class FormPersonelGoruntule:Form
    {
        public FormPersonelGoruntule()
        {
            InitializeComponent();
           
        }

        private void buttonGor_Click(object sender, EventArgs e)
        {
            if(textBoxTc.TextLength==11)
            {
                FormProfil formProfil = new FormProfil();
                formProfil.TcSet(textBoxTc.Text);

                formProfil.ShowDialog();
            }
            else
            {
                
                MessageBox.Show("TC kimlik no 11 haneli olmalıdır.","Dikkat",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                
            }
            
        }

        private void textBoxTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender,e);
        }





        // list box ta personeller Tc ve ad-soyadları listenecektir
    }
   
}
