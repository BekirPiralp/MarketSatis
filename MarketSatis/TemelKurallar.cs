using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketSatis
{
    public  static class TemelKurallar
    {
       
        public static void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(!char.IsDigit(e.KeyChar) )&& !char.IsControl(e.KeyChar))
            //char.IsControl(e.KeyChar)!=true olmaz is silme gibi kontrol işlemleri olmaz
            if (char.IsDigit(e.KeyChar) != true && char.IsControl(e.KeyChar) != true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void textBox_KeyPressHarf(object sender, KeyPressEventArgs e)
        {
            //if(!char.IsDigit(e.KeyChar) )&& !char.IsControl(e.KeyChar))
            //char.IsControl(e.KeyChar)!=true olmaz is silme gibi kontrol işlemleri olmaz
            if (char.IsLetter(e.KeyChar) != true && char.IsControl(e.KeyChar) != true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
