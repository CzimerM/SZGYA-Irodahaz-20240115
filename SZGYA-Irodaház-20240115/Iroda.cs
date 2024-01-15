using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_Irodahaz_20240115
{
    internal class Iroda
    {
        public string Kod { get; set; }
        public int Kezdet { get; set; }
        List<int> LetszamAdat { get; set; }

        public Iroda(string sor) 
        {
            this.LetszamAdat = new List<int>(); 
            string[] adatok = sor.Split(' ');
            this.Kod = adatok[0];
            this.Kezdet = int.Parse(adatok[1]);
            for (int i = 2; i < adatok.Length; i++)
            {
                this.LetszamAdat.Add(int.Parse(adatok[i]));
            }
        }

        public override string ToString()
        {
            return $"{this.Kod, -15} {this.Kezdet, 6} {string.Join(' ', this.LetszamAdat)}";
        }
    }
}
