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
    public partial class FormYonetici : Form
    {
        private TemelVeri temelVeri;
        String TC;
        public String TCGet()
        {
            return TC;
        }
        public void TCSet(String value)
        {
            TC = value;
        }

        public FormYonetici()
        {
            InitializeComponent();
        }
        public FormYonetici(TemelVeri temelVeri)
        {
            this.temelVeri = temelVeri;
            this.TC = temelVeri.Tc.Trim();
            InitializeComponent();
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult=
            MessageBox.Show("Çıkmak üzeresiniz, Emin misiniz?", "Dikkat", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult== DialogResult.OK)
            {
                this.Close();
            }else if (dialogResult == DialogResult.Cancel)
            {
                // çıkışa hayır deyince neler yapılacaksa...
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHakkinda formHakkinda = new FormHakkinda();
            formHakkinda.ShowDialog();
        }

        private void personelGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonelGoruntule formPersonelGoruntule = new FormPersonelGoruntule();
            formPersonelGoruntule.ShowDialog();
        }

        private void personelGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonelGuncelle formPersonelGuncelle = new FormPersonelGuncelle();
            formPersonelGuncelle.ShowDialog();
        }

        private void personelÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonelCikar formPersonelCikar = new FormPersonelCikar(TCGet());
            formPersonelCikar.ShowDialog();
        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonelEkle formPersonelEkle = new FormPersonelEkle();
            formPersonelEkle.ShowDialog();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUrunEkle formUrunEkle = new FormUrunEkle();
            formUrunEkle.ShowDialog();
        }

        private void ürünGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUrunGuncelle formUrunGuncelle = new FormUrunGuncelle(true);
            formUrunGuncelle.ShowDialog();
        }

        private void ürünDefoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefo formDefo = new FormDefo(temelVeri);
            formDefo.ShowDialog();
        }

        private void iadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIade formIade = new FormIade(temelVeri);
            formIade.ShowDialog();
        }

        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSatis formSatis = new FormSatis(temelVeri);
            formSatis.ShowDialog();
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSifreDegistir formSifreDegistir = new FormSifreDegistir(temelVeri);
            formSifreDegistir.ShowDialog();
        }
    }
}
