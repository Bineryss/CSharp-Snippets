using System;
using System.Collections.Generic;
using System.Threading;

namespace MasterWorker_Patter
{
    class Program
    {
        static void Start(string[] args)
        {
            int max = 1000;
            int[] numbers = new int[max];
            bool[] results = new bool[max];
            int position = 0;

            Random r = new Random();

            for (int i = 0; i < max; i++)
            {
                numbers[i] = r.Next();
            }

            int threadCount = 10;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < threadCount; i++)
            {
                Worker w = new Worker(ref numbers, ref results);

                Thread t = new Thread(() => w.DoWork(ref position));
                threads.Add(t);
                t.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine(string.Join(":", results));
        }
    }

    internal class Worker
    {
        public static object position_lock = new();
        public static object result_lock = new();

        private int[] numbers;
        private bool[] results;

        public Worker(ref int[] numbers, ref bool[] results)
        {
            this.numbers = numbers;
            this.results = results;
        }


        public void DoWork(ref int position)
        {
            while (position < numbers.Length)
            {
                int cp = -1;
                lock (position_lock)
                {
                    cp = position;
                    position++;
                }

                Console.WriteLine($"CP: {cp}");

                //Do Stuff Parallel
                bool result = numbers[cp] % 2 == 0;

                lock (result_lock)
                {
                    results[cp] = result;
                }
            }
        }
    }
}