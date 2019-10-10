using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AsciiArtCombiner
{
    class Program
    {
        static List<string[]> listOfReadFiles = new List<string[]>();
        static void Main(string[] args)
        {
            if (args.Length > 2 && args[0] == "run")
            {

                foreach (var file in args.Skip(1).ToArray())
                {
                    if (!ReadFile(file)) return;
                    
                }
                foreach (var read in listOfReadFiles)
                {
                    printArray(read);

                }
                Combiner.Combiner c = new Combiner.Combiner();
                if (c.checkFiles(listOfReadFiles))
                {
                    string[] result = listOfReadFiles[0];
                    for (int i =1; i< listOfReadFiles.Count; i++)
                    {
                        result=c.Combine(result, listOfReadFiles[i]);
                        printArray(result);
                    }                    
                }
                else
                {
                    Console.WriteLine("Error in files height/length");
                }
            }
            else
            {
                Console.WriteLine("Error");
                Console.WriteLine("Please enter:");
                Console.WriteLine("Combiner file1.txt file2.txt file3.txt ...");
            }
        }

        private static void printArray(string[] v)
        {
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
        }

        private static bool ReadFile(string fileName)
        {
            try
            { 
                var input = System.IO.File.ReadAllLines(fileName);
                listOfReadFiles.Add(input);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

    }
}
