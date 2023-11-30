using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace vize2
{
    public partial class Form1 : Form
    {
        public class Urun
        {
            public string Isim { get; set; }
            public double Fiyat { get; set; }
            public int Adet { get; set; }

            public double ToplamFiyat()
            {
                return Fiyat * Adet;
            }

            public override string ToString()
            {
                return $"{Isim}\t{Fiyat:N2} TL\t{Adet}";
            }
        }

        private BindingList<Urun> alisverisListesi = new BindingList<Urun>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string urunIsim = textBox1.Text;
            double urunFiyat;

            if (!double.TryParse(textBox2.Text, out urunFiyat))
            {
                MessageBox.Show("fiyat giriniz.");
                return;
            }

            int urunAdet;

            if (!int.TryParse(textBox3.Text, out urunAdet))
            {
                MessageBox.Show("adet giriniz.");
                return;
            }

            Urun yeniUrun = new Urun { Isim = urunIsim, Fiyat = urunFiyat, Adet = urunAdet };
            alisverisListesi.Add(yeniUrun);

            listBox1.DataSource = null;
            listBox1.DataSource = alisverisListesi;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alisverisListesi.Clear();
            listBox1.DataSource = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double toplamFiyat = 0;

            foreach (Urun urun in alisverisListesi)
            {
                toplamFiyat += urun.ToplamFiyat();
            }

            if (radioButton1.Checked)
            {
                toplamFiyat *= 0.85;
            }
            else if (radioButton2.Checked)
            {
                toplamFiyat *= 0.9;
            }

            textBox4.Text = toplamFiyat.ToString("N2") + " TL";
        }
    }
}
