using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            Worker w1 = new Worker();
            Worker w2 = new Worker(ref sum);

            Thread t1 = new Thread(() => w1.DoWork(ref sum)); //Methode mit params in lambda
            Thread t2 = new Thread(w2.DoWorkNoParams); //Methode ohne geht auch so

            //starte threat
            t1.Start();
            while (!t1.IsAlive) ; //-> sinnvoll, wenn man warten muss, bis thread gestartet ist
            t2.Start();

            //wartet auf beenden von thread
            t1.Join();
            t2.Join();


            //Task ist wie thread nur besser
            //startet eine Task
            Task T = Task.Run(w1.DoWorkNoParams);
            //wartet auf beenden
            T.Wait();
        }
    }

    class Worker
    {
        //Mutex sperrt zugriff auf diesen bereich
        public static object mutex_lock = new();

        private int sumLocal;

        public Worker()
        {
        }

        public Worker(ref int sum)
        {
            this.sumLocal = sum;
        }

        public void DoWork(ref int sum)
        {
            //wichtig!
            lock (mutex_lock)
            {
                sum++;
            }
        }

        public void DoWorkNoParams()
        {
            lock (mutex_lock)
            {
                sumLocal++;
            }
        }

        private void threadPool(int amount)
        {
            //bestimmt anzahl an threads erstellen
            int threadCount = amount;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < threadCount; i++)
            {
                Worker w = new Worker();

                Thread t = new Thread(w.DoWorkNoParams);
                threads.Add(t);
                t.Start();
            }


            //auf alle threads warten
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}