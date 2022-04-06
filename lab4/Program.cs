using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] paths = new string[]
            {
                @"C:\Downloads\матан\Задание1.pdf",
                @"C:\Downloads\матан\Задание2.pdf",
                @"C:\Downloads\матан\Лекция22.docx",
                @"C:\Downloads\матан\Задание3.pdf",
                @"C:\Downloads\матан\Лекция2.docx",
                @"C:\Downloads\матан\ЛЕКЦИЯ 4 ПРЕЗЕНТАЦИЯ.ppt",
                @"C:\Downloads\матан\Лекция3.docx",
                @"C:\Downloads\матан\Лекция11.docx",
                @"C:\Downloads\матан\Задание11.pdf",
                @"C:\Downloads\матан\Tablitsa_integralov_i_proizvodnykh.doc",
                @"C:\Downloads\матан\Задание12.pdf",
                @"C:\Downloads\матан\Задание13.pdf",
                @"C:\Downloads\матан\Задание13.pdf.zip",
                @"C:\Downloads\матан\Задание13.fb2"
            };

            List<string> appropriateFiles = new List<string>();
            Regex regexPdf = new Regex(@"\w*\d\d.pdf$", RegexOptions.IgnoreCase);
            Regex regexDocx = new Regex(@"\w*\d\d.docx$", RegexOptions.IgnoreCase);
            foreach (var path in paths)
            {
                Match match = regexPdf.Match(path);
                if (match.Success)
                {
                    appropriateFiles.Add(path);
                    continue;
                }
                                    
                match = regexDocx.Match(path);
                if (match.Success)
                    appropriateFiles.Add(path);
            }

            foreach (var file in appropriateFiles)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine();

            string[] names = new string[appropriateFiles.Count];
            for (int i = 0; i < appropriateFiles.Count; i++)
            {
                string[] dividedPath = appropriateFiles[i].Split('\\');
                int length = dividedPath.Length;
                int count = 0;
                foreach (var item in dividedPath[length - 1])
                {
                    if (Char.IsDigit(item))
                        break;
                    count++;
                }
                names[i] = dividedPath[length - 1].Remove(count);
                dividedPath[length - 1] = dividedPath[length - 1].Remove(0, count);
                appropriateFiles[i] = dividedPath[length - 1];
                Console.WriteLine(appropriateFiles[i]);
                Console.WriteLine(names[i]);
            }

            for (int i = 0; i < appropriateFiles.Count; i++)
            {
                appropriateFiles[i] = $"C:\\{names[i]}{i + 1:00}\\{appropriateFiles[i]}";
                Console.WriteLine(appropriateFiles[i]);
            }
        }
    }
}
