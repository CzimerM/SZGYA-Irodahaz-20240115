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

            foreach (var i in irodak)
            {
                Console.WriteLine($"{i.Sorszam,7} {i}");
            }

            //8.feladat
            Console.WriteLine("\n8.feladat");
            Console.WriteLine($"A következő emeleten vannak a legtöbben: {irodak.MaxBy(i => i.LetszamAdat.Sum()).Sorszam}");

            //9.feladat
            Console.WriteLine("\n9.feladat");
            Iroda kilencFo = irodak.FirstOrDefault(i => i.LetszamAdat.Contains(9));
            if (kilencFo == null) Console.WriteLine("[HIBA] Nincs ilyen");
            else Console.WriteLine("Van ilyen iroda");

            //10.feladat
            Console.WriteLine("\n10.feladat");
            Console.WriteLine(irodak.Sum(i => i.LetszamAdat.Where(i => i > 5).Count()));

            //11.feladat
            Console.WriteLine("\n11.feladat");
            StreamWriter sw = new StreamWriter("../../../otnelKevesebb.txt", false, Encoding.UTF8);

            irodak.Where(i => i.LetszamAdat.Contains(0)).ToList().ForEach(i => sw.WriteLine($"{i.Kod} {string.Join('/', i.LetszamAdat.Select((item, index) => (item, index)).Where(i => i.item == 0).Select(i => i.index + 1))}"));
       
            //12.feladat
            Console.WriteLine($"\n12.feladat: LOGMEIN átlag dolgozószáma egy irodában: {Math.Round(irodak.Where(i => i.Kod == "LOGMEIN").First().LetszamAdat.Average())}");

            //13.feladat
            Console.WriteLine("\n13.feladat");
            sw.WriteLine("EMELET SORSZÁMA | DOLGOZÓK SZÁMA");
            irodak.ForEach(i => sw.WriteLine($"{i.Sorszam, 15} | {i.LetszamAdat.Sum()}"));

            sw.Close();

            //14.feladat
            Console.WriteLine($"\n14.feladat: {irodak.Sum(i => i.LetszamAdat.Sum())} ember dolgozik összesen az irodaházban.");

            //15.feladat
            Console.WriteLine($"\n15.feladat: {irodak.Min(i => i.Kezdet)}");

            //16.feladat
            Console.WriteLine($"\n16.feladat: {DateTime.Now.Year - irodak.Max(i => i.Kezdet)}");
        }
    }
}
