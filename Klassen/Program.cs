using System;

namespace Klassen
{
    class Program
    {
        static void Main(string[] args)
        {
            BeispielKlasse b = new BeispielKlasse();
            b.Number = 10;

            BeispielSuperKlasse s = b as BeispielSuperKlasse; //as -> castet und gibt bei problem null zurueck

            int test = (int) b; //casting durch methode von Beispielklasse

            int indice = b[0];
        }
    }

    class BeispielKlasse : BeispielSuperKlasse, IInterface //interface wird genauso angebunden
    {
        private int number;

        public int Number //Number als properties, private number koennte auch weggelassen werden
        {
            get => number;
            set => number = value;
        }

        //Casting von B zu int
        public static explicit operator double(BeispielKlasse b)
        {
            return b.number;
        }

        //Casting von int zu B
        public static explicit operator BeispielKlasse(double d)
        {
            return new BeispielKlasse();
        }

        //operator schreibweise, kann fuer +,-,*,/, ==, != genutzt werden
        public static BeispielKlasse operator +(BeispielKlasse a, BeispielKlasse b)
        {
            return new BeispielKlasse();
        }

        // indicer, also possible this[int i, int j] etc
        public int this[int s] //-> kann auch string nehmen
        {
            get { return (s == 0) ? number : -1; }
        }

        public override void abstractMethode()
        {
            throw new NotImplementedException();
        }

        public override void virtualMethode()
        {
            Console.WriteLine("Ich bin die Unterklasse");
        }

        public void interfaceMethode()
        {
            throw new NotImplementedException();
        }
    }

    abstract class BeispielSuperKlasse
    {
        //abstract muss ueberschreiben werden
        public abstract void abstractMethode();


        //virtual -> kann uebercshriebn werden, dann wird funtkionalitaet von unter klasse genutzt, sonnst die normale
        public virtual void virtualMethode()
        {
            Console.WriteLine("Ich bin die Superklasse!");
        }

        public void normalMethode()
        {
        }
    }

    //Generische Klasse mit Type constraint, T kann nur eine Klasse sein, die von "BSP" Erbt
    class GenerischeKlasse<T> where T : BeispielSuperKlasse
    {
        private T value;

        public T returnT()
        {
            return value;
        }
    }

    interface IInterface
    {
        public void interfaceMethode();
    }

    struct Point //struct -> erzeugt immer eine neue kopie, bei veraenderung
    {
        public int x, y;

        public override string ToString()
        {
            return string.Format("x={0}; y={1}", this.x, this.y);
        }
    }
}