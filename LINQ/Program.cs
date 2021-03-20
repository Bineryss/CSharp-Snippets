using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] {2, 6, 4, 3, 9, 76, 1, 2, 5, 4};

            var sortSmaller10 =
                from number in numbers
                where number < 10
                orderby number //descending -> absteigend
                select number;

            var multiplyBy2 =
                from number in numbers
                orderby number
                select new
                {
                    n = number, m = number * 2
                }; //Hier koennen operationsn ausgefuerht werden {}-> annonyme klasse, wie json in js

            foreach (var value in multiplyBy2)
            {
                var number = value.n;
            }
            
            //gruppieren
            var groups =
                from n in numbers
                group n by n % 3 //wird immer hier nach gruppiert -> gibt key und value zurueck
                into g
                select new {rem = g.Key, nums = g};
            
            
            
            //JS schreibweise
            Random random = new Random();
            //20 Plätze             //für jedes der 20 ein rdm
            IEnumerable<int> alle = Enumerable.Range(1, 20).Select(n => random.Next(0, 100));
            //Condition
            IEnumerable<int> ungerade = alle.Where(n => n % 2 != 0);
        }
    }
}