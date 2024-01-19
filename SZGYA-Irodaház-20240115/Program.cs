using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SZGYA_Irodahaz_20240115
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Iroda> irodak = new List<Iroda>();

            StreamReader sr = new StreamReader("../../../src/irodahaz.txt", Encoding.UTF8);

            for (int i = 1; !sr.EndOfStream; i++)
            {
                irodak.Add(new Iroda(i, sr.ReadLine()));
            }
            sr.Close();
  

            Console.WriteLine($"{"SORSZÁM",7} {"KÓD", -15} {"KEZDET", 6} Létszámadatok");

            for (int i = 0; i < irodak.Count; i++)
            {
                Console.WriteLine($"{i + 1,6} {irodak[i]}");
            }

            //8.feladat
            Console.WriteLine("\n8.feladat");
            Console.WriteLine($"A következő emeleten vannak a legtöbben: {irodak.MaxBy(i => i.LetszamAdat.Sum()).Sorszam}");

            //9.feladat
            Console.WriteLine("\n9.feladat");
            Iroda kilencFo = irodak.FirstOrDefault(i => i.LetszamAdat.Contains(9));
            if (kilencFo == null) Console.WriteLine("[HIBA] Nincs ilyen");
            else Console.WriteLine(kilencFo);

            //10.feladat
            Console.WriteLine("\n10.feladat");
            Console.WriteLine(irodak.Sum(i => i.LetszamAdat.Where(i => i > 5).Count()));

            //11.feladat
            Console.WriteLine("\n11.feladat");
            StreamWriter sw = new StreamWriter("../../../otnelKevesebb.txt", false, Encoding.UTF8);
            foreach (var i in irodak.Where(i => i.LetszamAdat.Contains(0)))
            {
                sw.WriteLine($"{i.Kod} {string.Join(' ', i.LetszamAdat)}");
            }
            
        }
    }
}
