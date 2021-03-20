using System;

namespace Ref___Out
{
    class Program
    {
        static void Main(string[] args)
        {
            //Muss vorher initalisiert werden!
            int numberRef = 10;
            refThis(ref numberRef);

            //muss nicht vorher initalisiert werden
            int numberOut;
            outThis(out numberOut);


            //Liste kann auch mit komma getrennt uebergeben werden
            paramList(0, "something", 1, 2, 3, 4, 5, 6);
        }

        public static void refThis(ref int number)
        {
            //ref kann werte auslesen
            int here = number;

            //und werte setzen
            number = 0;
        }

        public static void outThis(out int number)
        {
            //geht nicht, da out auch nicht initalisiert sein kann
            //int here = number;

            number = 0;
        }

        //params muss immer am ende stehen!
        public static void paramList(int something, string somethinelse, params int[] paramList)
        {
            foreach (var value in paramList)
            {
                //Do something with params
            }
        }
    }
}