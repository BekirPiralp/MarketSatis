using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarketSatis;
namespace MarketSatis
{
    public partial class FormPersonel : Form
    {
        TemelVeri temelVeri;
        public FormPersonel()
        {
            InitializeComponent();
        }

        public FormPersonel(TemelVeri temelVeri)
        {
            this.temelVeri = temelVeri;
            InitializeComponent();
        }
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHakkinda frm = new FormHakkinda();
            frm.ShowDialog();
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProfil formProfil = new FormProfil();
            formProfil.ShowDialog();
        }

        private void profilDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSifreDegistir formSifreDegistir = new FormSifreDegistir();
            formSifreDegistir.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close(); // ilgili form dan çıkar.
            //Application.Exit(); // hepsinden çıkar.

            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                //MessageBox.Show("");// hiçbir işlem yaptırmıyorum
            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUrunEkle formUrunEkle = new FormUrunEkle();
            formUrunEkle.ShowDialog();
        }

        private void buttoniptal_Click(object sender, EventArgs e)
        {

        }

        private void ürünGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUrunGuncelle formUrunGuncelle = new FormUrunGuncelle(false);
            formUrunGuncelle.ShowDialog();
        }

        private void defoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefo formDefo = new FormDefo();
            formDefo.ShowDialog();
        }

        private void iadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIade formIade = new FormIade();
            formIade.ShowDialog();
        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            TemelKurallar.textBox_KeyPress(sender, e);
        }
    }
}
