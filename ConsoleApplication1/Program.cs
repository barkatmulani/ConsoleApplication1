using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirpath;
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a directory path:");
                dirpath = Console.ReadLine();
            }
            else
                dirpath = args[0];

            Console.WriteLine("Please enter a date, any text files older than this date will be deleted:");
            var dateentered = Console.ReadLine();

            DateTime compareDate;
            try { compareDate = DateTime.Parse(dateentered); }
            catch { compareDate = DateTime.Now.AddMonths(-3); }

            string[] filelist = Directory.GetFiles(dirpath, "*.*");
            string filepath;

            for (int i = 0; i < filelist.Count(); i++)
            {
                FileInfo fi = new FileInfo(filelist[i]);
                filepath = fi.FullName;

                if (fi.CreationTime.CompareTo(compareDate) == -1)
                {
                    try
                    {
                        File.Delete(filepath);
                        Console.WriteLine("{0} deleted.", filepath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error occured.");
                    }
                }
            }
        }
    }
}
