using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CookyBakeri
{
    enum CookieType { Chocolate, Raisins, Nonstop, Icing };

    public class Bakery
    {
        private readonly int _cookiesPerDay;
        private int _cookiesSold;
        private readonly List<Cookie> _cookies = new List<Cookie>();

        public Bakery()
        {
            _cookiesPerDay = Root.CookiesPerDay;
        }

        // om det er flere igjen i ovnen
        public bool InOven => _cookies.Count < _cookiesPerDay;

	    // om det er flere igjen i kurven
        public bool InStock => _cookiesSold < _cookiesPerDay;

	    public void Work()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (InOven)
            {
                if (stopwatch.ElapsedMilliseconds < Root.BakingTime) continue;

                AddCookie();
                stopwatch.Restart();
            }
        }

        public void AddCookie()
        {
            if (_cookies.Count >= _cookiesPerDay) return;

            var values = Enum.GetValues(typeof(CookieType));
            var rng = new Random();
            var randomCookieType = (CookieType)values.GetValue(rng.Next(values.Length));
            var randomCookie = bakeCookie(randomCookieType);
            _cookies.Add(randomCookie);
                     
            Console.WriteLine("Bakery made cookie #" + _cookies.Count + " with " + randomCookie.Type);
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

        public void SellCookieTo(RegularCustomer customer)
        {
            if (_cookies.Count <= _cookiesSold) return;

            lock (_cookies[_cookiesSold++])
            {
                Console.WriteLine("\t\t\t\t\t" + customer.Name + " received cookie #" + _cookiesSold + " with " + _cookies[(_cookiesSold-1)].Type);
            }
        }
    }
}
