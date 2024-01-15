using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_Irodahaz_20240115
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Iroda> irodak = new List<Iroda>();

            StreamReader sr = new StreamReader("../../../src/irodahaz.txt", Encoding.UTF8);

            while(!sr.EndOfStream)
            {
                irodak.Add(new Iroda(sr.ReadLine()));
            }

            Console.WriteLine($"{"SORSZÁM",7} {"KÓD", -15} {"KEZDET", 6} Létszámadatok");

            for (int i = 0; i < irodak.Count; i++)
            {
                Console.WriteLine($"{i + 1,6} {irodak[i]}");
            }

            //8.feladat
            Console.WriteLine($"{irodak.MaxBy(i => i.LetszamAdat.)}");
        }
    }
}
