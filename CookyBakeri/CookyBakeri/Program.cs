using System;
using System.Threading;

namespace CookyBakeri
{
    // globale variabler
    public static class root
    {
        public static int bakingTime = 667; // millisekunder
        public static int buyingTime = 1000; // millisekunder
        public static int cookiesPerDay = 20;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bakery bakery = new Bakery();
            Thread bakeryT = new Thread(bakery.work);
            bakeryT.Start();

            RegularCustomer fred = new RegularCustomer("Fred");
            RegularCustomer ted = new RegularCustomer("Ted");
            RegularCustomer greg = new RegularCustomer("Greg");
            Thread fredT = new Thread(() => fred.getCookiesFrom(bakery));
            Thread tedT = new Thread(() => ted.getCookiesFrom(bakery));
            Thread gregT = new Thread(() => greg.getCookiesFrom(bakery));
            fredT.Start();
            tedT.Start();
            gregT.Start();

            while (true)
            {
                if (bakery.inStock) continue;

                Console.ReadKey();
                break;
            }
        }


    }
}
