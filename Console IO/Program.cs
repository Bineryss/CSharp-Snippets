using System;
using System.Collections.Generic;

namespace Console___String_Formatter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //String mit Variablen fuellen
            int number = 0;
            Console.WriteLine($"Das ist die Nummer: {number}");
            //Hier koennen auch ausdruecke rein
            Console.WriteLine($"Ist die Numer gleich 0: {number == 0}");

            //Konsoleneingabe einlesen:
            string s = Console.ReadLine();


            var array = new int[] {1, 2, 3, 4};
            //Nimmt Collections, wie Array, List, etc und fuegt die zusammen
            string join = string.Join(",", array);
            
            
        }
    }
}