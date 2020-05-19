using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    class Racun
    {
        public string stevilkaRacuna;
        public string pinKoda;
        public double znesek;

        public Racun(string stevilkaRacuna, string pinKoda, double znesek)
        {
            this.stevilkaRacuna = stevilkaRacuna;
            this.pinKoda = pinKoda;
            this.znesek = znesek;
        }

        public Racun()
        {
            Random r = new Random();
            stevilkaRacuna = Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9));
            while (!je_veljaven_pin(stevilkaRacuna))
            {
                stevilkaRacuna = Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9));
            }
            pinKoda = Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9)) + Convert.ToString(r.Next(9));
            znesek = 0;
        }

        bool je_veljaven_pin(string pin)
        {
            using (StreamReader sr = new StreamReader(@"E:\bancni_racuni.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] racun = sr.ReadLine().Split(':');
                    if (pin == racun[0])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
