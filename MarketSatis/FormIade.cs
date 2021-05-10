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
    public partial class FormIade : Form
    {
        private String Tc; 
        public FormIade()
        {
            InitializeComponent();
        }

        public FormIade(String TcAl)
        {
            TcSet(TcAl);
            InitializeComponent();
        }

        public void TcSet(String Tc)
        {
            this.Tc = Tc;
        }
        public String TcGet()
        {
            return Tc;
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTamam_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Emin misiniz?", "Dikkat!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {

            }
            else if (dialogResult == DialogResult.Cancel)
            {

            }
        }

        private void textBoxFisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }
    }
}
