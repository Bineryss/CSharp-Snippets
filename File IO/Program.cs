using System;
using System.Collections.Generic;
using System.IO;

namespace File_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "../../../bundesliga";

            //ganzes Dokumetn einlesen, eine Zeile -> ein element
            string[] lines = File.ReadAllLines(fileName + "-0.txt");

            //Text in dokument schreiben
            File.WriteAllLines(fileName + "-1.txt", lines);


            // stream version -> read line
            var headlines = new List<string>();
            using (StreamReader reader = new StreamReader(fileName + "-1.txt")) //-> closed reader automatisch
            {
                string oneline;

                oneline = reader.ReadLine(); // null if end of line
                while (oneline != null)
                {
                    headlines.Add(oneline);

                    oneline = reader.ReadLine();
                }
            }


            // write modified lines but with better technique -> using keyword
            StreamWriter writer = new StreamWriter(fileName + "-2.txt");
            using (writer) // uebernimmt das close am ende automatisch
            {
                foreach (string headline in headlines)
                {
                    writer.WriteLine("club: " + headline);
                }
            }
        }
    }
}