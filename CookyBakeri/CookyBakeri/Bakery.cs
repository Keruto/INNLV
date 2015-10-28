using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CookyBakeri
{
    enum CookieType { Chocolate, Raisins, Nonstop, Icing };

    public class Bakery
    {
        private const int cookiesPerDay = 20;
        private int cookiesSold;
        private List<Cookie> cookies = new List<Cookie>();

        // om det er flere igjen i ovnen
        public bool inOven
        {
            get { return cookies.Count < cookiesPerDay; }
        }

        // om det er flere igjen i kurven
        public bool inStock
        {
            get { return cookiesSold < cookiesPerDay; }
        }

        public void work()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (inOven)
            {
                if (stopwatch.ElapsedMilliseconds < root.bakingTime) continue;

                addCookie();
                stopwatch.Restart();
            }
        }

        public void addCookie()
        {
            if (cookies.Count >= cookiesPerDay) return;

            Array values = Enum.GetValues(typeof(CookieType));
            Random rng = new Random();
            CookieType randomCookieType = (CookieType)values.GetValue(rng.Next(values.Length));
            Cookie randomCookie = bakeCookie(randomCookieType);
            cookies.Add(randomCookie);
                     
            Console.WriteLine("Bakery made cookie #" + cookies.Count + " with " + randomCookie.Type);
        }

        private Cookie bakeCookie(CookieType type)
        {
            Cookie cookie = null;

            switch (type)
            {
                case CookieType.Chocolate:
                    cookie = new Chocolate();
                    break;
                case CookieType.Raisins:
                    cookie = new Raisins();
                    break;
                case CookieType.Nonstop:
                    cookie = new Nonstop();
                    break;
                case CookieType.Icing:
                    cookie = new Icing();
                    break;
                default:
                    cookie = new Chocolate();
                    break;
            }
            return cookie;
        }

        public void sellCookieTo(RegularCustomer customer)
        {
            if (cookies.Count <= cookiesSold) return;

            lock (cookies[cookiesSold++])
            {
                Console.WriteLine("\t\t\t\t\t" + customer.name + " received cookie #" + cookiesSold + " with " + cookies[(cookiesSold-1)].Type);
            }
        }
    }
}
