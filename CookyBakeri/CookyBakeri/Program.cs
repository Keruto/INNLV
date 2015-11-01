using System;
using System.Threading;

namespace CookyBakeri
{
    // globale variabler
    public static class Root
    {
        public static int BakingTime = 667; // millisekunder
        public static int BuyingTime = 1000; // millisekunder
        public static int CookiesPerDay = 20;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bakery = new Bakery();
            var bakeryT = new Thread(bakery.Work);
            bakeryT.Start();

            var fred = new RegularCustomer("Fred");
            var ted = new RegularCustomer("Ted");
            var greg = new RegularCustomer("Greg");
            var fredT = new Thread(() => fred.GetCookiesFrom(bakery));
            var tedT = new Thread(() => ted.GetCookiesFrom(bakery));
            var gregT = new Thread(() => greg.GetCookiesFrom(bakery));
            fredT.Start();
            tedT.Start();
            gregT.Start();

            while (true)
            {
                if (bakery.InStock) continue;

                Console.ReadKey();
                break;
            }
        }


    }
}
