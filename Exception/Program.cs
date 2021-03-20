using System;

namespace Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Exception werfen
                throw new IndexOutOfRangeException("oops, wrong index");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("2) exception reason: " + e.Message);
            }
            //wird immer am ende ausgefuehrt
            finally
            {
                
            }
        }
    }
}