using System;
using System.Collections.Generic;

namespace Enumerator_Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int j in Multiply(6))
            {
                Console.Write($" {j}");
            }
        }
        
        private static IEnumerable<int> Multiply(int amount)
        {
            int result = 1;
            for (int i = 0; i < amount; i++)
            {
                //bricht die methode nicht ab sonder haelt sie nur an
                yield return result++;
            }
        }
    }
}