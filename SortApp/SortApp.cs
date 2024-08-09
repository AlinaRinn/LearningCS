using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortApp
{
    class Program
    {
        private static void BubleLengthSort(string inputfile, string outfile)
        {
            string[] lines = File.ReadAllLines(inputfile);
            for (int j = 0; j < lines.Length; j++)
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    if (lines[i].Length > lines[i + 1].Length)
                    {
                        string tmp = lines[i];
                        lines[i] = lines[i + 1];
                        lines[i + 1] = tmp;
                    }
                }
            }
            File.WriteAllLines(outfile, lines);
        }

        private static void BubleFirstLetterSort(string inputfile, string outfile)
        {
            string[] lines = File.ReadAllLines(inputfile);
            //Array.Sort(lines);
            for (int j = 0; j < lines.Length; j++)
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    char c0 = lines[i].FirstOrDefault();
                    char c1 = lines[i + 1].FirstOrDefault();
                    if (c1 < c0)
                    {
                        string tmp = lines[i];
                        lines[i] = lines[i + 1];
                        lines[i + 1] = tmp;
                    }
                }
            }
            File.WriteAllLines(outfile, lines);
        }

        private static void SubStringsSort(string inputfile, string outfile)
        {
            string[] lines = File.ReadAllLines(inputfile);
            int amount = 0;
            Console.WriteLine("\nEnter substring to search (SubStringsSort):\n");
            string subline = Console.ReadLine();
            for (int i = 0; i < lines.Length; i++)
            {
                bool Check = lines[i].Contains(subline);
                if (Check)
                {
                    string tmp = lines[amount];
                    lines[amount] = lines[i];
                    lines[i] = tmp;
                    amount++;
                }
            }
            if (amount == 0)
            {
                Console.WriteLine("\nSubstring not found, output (SubStringsSort) will be empty");
            }
            //String.CompareTo //String.IndexOf //String.Equals //String.Compare //String.Contains //String.Replace
            File.WriteAllLines(outfile, lines);
        }

        static void Main(string[] args)
        {
            BubleLengthSort("input.txt", "output_length.txt");
            BubleFirstLetterSort("input.txt", "output_letters.txt");
            SubStringsSort("input.txt", "output_SubStrings.txt");
            Console.WriteLine("\nSorted\n\nPress any key to exit\n");
            Console.ReadKey();                                           
        }
    }
}