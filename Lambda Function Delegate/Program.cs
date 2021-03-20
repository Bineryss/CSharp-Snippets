using System;

namespace Lambda_Function_Delegate
{
    class Program
    {
        //Wie Interface nur fuer eine Methode
        delegate double MathFunction(double x);


        static void Main(string[] args)
        {
            MathFunction sin = Math.Sin;

            MathFunction add = d => d + 1; // wenn einzeiler, kein retur noetig

            MathFunction add2 = (d) => { return d + 2; }; // bei {} return noetig!

            double e = sin(0);


            //Lamda in Line, der letzte wert ist der Rueckgabwert
            Func<string, double, double> lambda = (s, d) =>
            {
                Console.WriteLine(s);
                return d + 1;
            };
        }
    }
}