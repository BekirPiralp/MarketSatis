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
    public partial class FormProfil : Form
    {
        //public string Tc { get => Tc; set => Tc = value; }
        //Yukarıdakinde garip şekilde stack over flow hatası aldım
        private string Tc;
        public string TcGet()
        {
            return Tc;
        }
        public void TcSet(string value)
        {
            this.Tc = value.ToUpper();
            this.labelTc.Text = value;
        }

        public FormProfil()
        {
            InitializeComponent();

        }

       
    }
}
