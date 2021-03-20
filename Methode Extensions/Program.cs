using System;

namespace Methode_Extensions
{
    //-> muss static sein!
    static class Program
    {
        static void Main(string[] args)
        {
            string test = "abcd";
            //-> ueber methode extension wie als wuere es normal exsitieren
            char ch = test.nthChar(2);
            string turn = test.turn();
        }

        /// - extension method with a parameter
        /// - has to be public static in a static class
        /// - the class to be extended is given by "this"
        public static char nthChar(this string str, int idx)
        {
            return str[idx];
        }

        public static string turn(this string str)
        {
            char[] a = str.ToCharArray();
            Array.Reverse(a);
            return new string(a);
        }
    }
}