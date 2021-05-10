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
    public partial class FormDefo : Form
    {

        private String Tc;
        public String TcGet()
        {
            return Tc;
        }
        public void TcSet(String value)
        {
            Tc = value;
        }

        public FormDefo()
        {
            InitializeComponent();
        }
        public FormDefo(String al)
        {
            TcSet(al);
            InitializeComponent();
        }
               

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult=MessageBox.Show("Emin misiniz?", "Dikkat!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(dialogResult== DialogResult.OK)
            {

            }else if (dialogResult == DialogResult.Cancel)
            {

            }
        
        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }
    }
}
