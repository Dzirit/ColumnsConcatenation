using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ColumnConcatenation
{
    class Program
    {
        const string writePath = @".\Out.csv";
        const string readPath = @".\In — копия.csv";
        
        static int i, j ,c= 0;
        private static List<string> list;

        static void Main(string[] args)
        {
            int numberOfLines = System.IO.File.ReadAllLines(readPath).Length;

            using (StreamReader sr=new StreamReader(readPath))
            {
                string[] dataInLine = sr.ReadLine().Split(";");
                //for (c = 0; c < numberOfLines*dataInLine.Length; c++)
                //{
                //    list.Add("0");
                //}
                j = 0;
                string[] array = new string[numberOfLines * dataInLine.Length];
                for(i=0;i<numberOfLines;i++)
                {

                    j = i;
                    foreach (var data in dataInLine)
                    {
                        if (data!=null)
                        {
                            array[j] = data;
                            j += numberOfLines;
                        }
                    }
                    if(!sr.EndOfStream)
                        dataInLine = sr.ReadLine().Split(";");
                }
                using(StreamWriter sw =new StreamWriter(writePath))
                {
                    foreach (var l in array)
                    {
                        sw.WriteLine(l);
                        Console.WriteLine(l);
                    }
                    sw.Flush();
                    sw.Close();
                }
                
                    
            }
        }
    }
}
