using System;

namespace Nice_To_Know
{
    class Program
    {
        static void Main(string[] args)
        {
           //Nullables -> typen, die kein null haben duerfen, koennen auch null bekommen
           int? nullable = null;

           //wird nur zugewiesen, wenn links null ist
           nullable ??= 10;

           string? test = null;

           //-> wird nur ausgefuerht, wenn der wert vor ? nicht null ist!
           test?.Insert(0,"This");
        }
    }
}