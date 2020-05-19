using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Form1 : Form
    {
        izpis izpis_stanja = new izpis();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "9";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (preveri_funkcijo())
                label5.Text += "0";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Racun[] racuni = seznam_racunov();
            bool najdenRacun = false;
            if (label6.Text == "Vnesi 4 mestno številko računa" || label6.Text == "Račun ne obstaja. Poskusi znova")
            {
                foreach (Racun racun in racuni)
                {
                    if (racun.stevilkaRacuna == label5.Text)
                    {
                        label1.Text = "Račun: " + label5.Text;
                        vnos_pinkode();
                        najdenRacun = true;

                    }
                }
            
                if (!najdenRacun)
                {
                    label6.Text = "Račun ne obstaja. Poskusi znova";
                }
            }
            if (label6.Text == "Vnesi pin kodo")
            {
                foreach (Racun racun in racuni)
                {
                    if (racun.stevilkaRacuna == label1.Text.Split(' ')[1])
                    {
                        if (racun.pinKoda == label5.Text)
                        {
                            prijava();
                        }
                        else if (racun.pinKoda != label5.Text && label5.Text != "")
                        {
                            label2.Text = "Napačna pin koda";
                        }
                        
                    }
                }
            }
            if (label6.Text == "Podatki o novem računu:")
            {
                label6.Text = "Vnesi 4 mestno številko računa";
            }
            if (label6.Text == "Vpiši željeno količino denarja:")
            {
                Racun[] vsiRacuni = seznam_racunov();
                foreach (Racun racun in vsiRacuni)
                {
                    string[] profil = label1.Text.Split(' ');
                    if (racun.stevilkaRacuna == profil[1])
                    {
                        if (racun.znesek > int.Parse(label5.Text) && int.Parse(label5.Text) >= 10 && int.Parse(label5.Text) % 10 == 0)
                        {
                            string vrstica = null;
                            string trenutni_racun = racun.stevilkaRacuna + ":" + racun.pinKoda + ":" + Convert.ToString(racun.znesek);
                            using (StreamReader sr = new StreamReader(@"E:\bancni_racuni.txt"))
                            using (StreamWriter sw = new StreamWriter(@"E:\spremenjeni_bancni_racuni.txt"))
                            {
                                while ((vrstica = sr.ReadLine()) != null)
                                {
                                    if (String.Compare(vrstica, trenutni_racun) == 0)
                                    {
                                        sw.WriteLine(racun.stevilkaRacuna + ":" + racun.pinKoda + ":" + Convert.ToString(racun.znesek - int.Parse(label5.Text)));
                                        continue;
                                    }

                                    sw.WriteLine(vrstica);
                                }
                            }
                            using (StreamReader sr = new StreamReader(@"E:\spremenjeni_bancni_racuni.txt"))
                            using (StreamWriter sw = new StreamWriter(@"E:\bancni_racuni.txt"))
                            {
                                while (sr.Peek() >= 0)
                                {
                                    sw.WriteLine(sr.ReadLine());
                                }
                            }
                            label2.Text = "Denar uspešno dvignjen";

                        }
                    }
                }
            }
        }
        public void vnos_pinkode()
        {
            label6.Text = "Vnesi pin kodo";
            button17.Text = "";
            label5.Text = "";
        }
        public void prijava()
        {
            label6.Text = "Pritisni željeno funkcijo";
            button17.Text = "";
            label5.Text = "";
            label2.Text = "";
            button17.Text = "Stanje računa";
            button18.Text = "Dvigni vsoto";
            button19.Text = "Izpis stanja";
            button20.Text = "Končaj";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.Text == "Novi račun")
            {
                Racun noviRacun = new Racun();
                using (StreamWriter sw = new StreamWriter(@"E:\bancni_racuni.txt", true))
                {
                    sw.WriteLine("{0}:{1}:{2}", noviRacun.stevilkaRacuna, noviRacun.pinKoda, noviRacun.znesek);
                }
                label6.Text = "Podatki o novem računu:";
                label1.Text = "Številka računa: " + noviRacun.stevilkaRacuna;
                label2.Text = "Pin koda: " + noviRacun.pinKoda;
                button17.Text = "";
            }
            else if (label6.Text == "Pritisni željeno funkcijo" || label6.Text == "Vpiši željeno količino denarja:")
            {
                label2.Text = "";
                Racun[] racuni = seznam_racunov();
                foreach (Racun racun in racuni)
                {
                    string[] profil = label1.Text.Split(' ');
                    if (racun.stevilkaRacuna == profil[1])
                    {
                        label6.Text = "Stanje na vašem računu:";
                        label5.Text = Convert.ToString(racun.znesek) + "€";
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        Racun[] seznam_racunov()
        {
            Racun[] racuni;
            int stRacunov = 0;
            using (StreamReader sr = new StreamReader(@"E:\bancni_racuni.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    sr.ReadLine();
                    stRacunov++;
                }
            }
            racuni = new Racun[stRacunov];
            using (StreamReader sr = new StreamReader(@"E:\bancni_racuni.txt"))
            {
                for (int i = 0; i < stRacunov; i++)
                {
                    string[] racun = sr.ReadLine().Split(':');
                    racuni[i] = new Racun(racun[0], racun[1], double.Parse(racun[2]));

                }
            }
            return racuni;
        }

        bool preveri_funkcijo()
        {
            if (label6.Text == "Vnesi 4 mestno številko računa" || label6.Text == "Vnesi pin kodo" || label6.Text == "Vnesi željeno vrednost")
                return true;
            else if (label6.Text == "Račun ne obstaja. Poskusi znova" || label6.Text == "Vpiši željeno količino denarja:")
                return true;
            else
                return false;
        }

        void zacetni_zaslon()
        {
            label6.Text = "Vnesi 4 mestno številko računa";
            label1.Text = "";
            button17.Text = "Novi račun";
            button18.Text = "";
            button19.Text = "";
            button20.Text = "";
            label5.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.Text == "Končaj")
            {
                zacetni_zaslon();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.Text == "Dvigni vsoto")
            {
                label6.Text = "Vpiši željeno količino denarja:";
                label5.Text = "";
                
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Racun[] racuni = seznam_racunov();
            if (button19.Text == "Izpis stanja")
            {
                izpis_stanja.st_racuna = label1.Text.Split(' ')[1];
                foreach (Racun racun in racuni)
                    if (racun.stevilkaRacuna == label1.Text.Split(' ')[1])
                        izpis_stanja.znesek_racuna = Convert.ToString(racun.znesek) + "€";
                izpis_stanja.ShowDialog();               
            }
        }
    }
}
