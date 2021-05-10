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
    public partial class FormSatis : Form
    {
        String Tc;
        public String TcGet()
        {
            return Tc;
        }
        public void TcSet(String Tc)
        {
            this.Tc = Tc;
        }
        public FormSatis()
        {
            InitializeComponent();
        }
        public FormSatis(String TcAl)
        {
            TcSet(TcAl);
            InitializeComponent();
        }


        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender,e);
        }
    }
}
