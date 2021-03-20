using System;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            // constant original string
            // note, that all functions return a copy
            const string original = "Hallo 12345 Ende";
            Console.WriteLine("Original:          '" + original + "'");

            string sStart;
            int pos;
            bool b;

            // contains some text?
            b = original.Contains("Ende"); // true

            // looks for position of some text
            pos = original.IndexOf('0');                        // -1
            pos = original.IndexOf('1');                        // 6

            // extracts text 
            sStart = original.Substring(pos);
            sStart = original.Substring(pos, 5);                     // start, len

            // replaces text
            sStart = original.Replace("l", "L");                    // replace all

            // converts to lower or upper case
            sStart = original.ToLower();
            sStart = original.ToUpper();

            // inserts or removes text 
            sStart = original.Insert(5, "!");
            sStart = original.Remove(7, 3);                         // start, len

            // removes white space
            sStart = original.Trim(); // entfernt leerzeichen am anfang und ende

            // use escape-seq.
            sStart = "\\123\\456\t789";
            // use as it is given
            sStart = @"\123\456\t789"; //keine escape sequenz

            // splits text, assigns array elements []
            string[] a = original.Split(' ');
        }
    }
}
