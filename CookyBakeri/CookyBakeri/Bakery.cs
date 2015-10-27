using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CookyBakeri
{
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

        public void bakeCookie()
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

            Random rng = new Random();
            int type = rng.Next(1, 5);
            string typeText = "";
            switch (type)
            {
                case 1:
                    typeText = "chocolate";
                    break;
                case 2:
                    typeText = "raisins";
                    break;
                case 3:
                    typeText = "nonstop";
                    break;
                case 4:
                    typeText = "icing";
                    break;
                default:
                    typeText = "chocolate";
                    break;
            }
            cookies.Add(new Cookie(typeText));
                     
            Console.WriteLine("Bakery made cookie #" + cookies.Count + " with " + typeText);
        }

        public void sellCookieTo(RegularCustomer customer)
        {
            if (cookies.Count <= cookiesSold) return;

            lock (cookies[cookiesSold++])
            {
                Console.WriteLine("\t\t\t\t" + customer.name + " received cookie #" + cookiesSold + " with " + cookies[(cookiesSold-1)].Type);
            }
        }
    }
}
