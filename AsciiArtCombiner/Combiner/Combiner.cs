using System;
using System.Collections.Generic;

namespace Combiner
{
    public class Combiner
    {

        public Combiner()
        {

        }
        public bool checkFiles(List<string[]> list)
        {
            var height = list[0].Length;
            var length = list[0][0].Length;
            foreach (var element in list)
            {
                if (height != element.Length)
                {
                    return false;
                }
                foreach (var line in element)
                {
                    if (line.Length != length)
                    {
                        return false;
                    }
                }


            }
            return true;
        }
        public string[] Combine(string[] file1, string[] file2)
        {
            //result with new height of file1
            string[] result = new string[file1.Length];

            for (int i = 0; i < file1.Length; i++)
            {
                //get the lines
                var arr = file1[i].ToCharArray();
                var arr2 = file2[i].ToCharArray();


                for (int c = 0; c < arr.Length; c++)
                {
                    if (arr[c] == ' ')
                    {
                        result[i] += arr2[c];
                    }
                    else
                    {
                        result[i] += arr[c];
                    }
                }

            }
            return result;
        }
    }
}
