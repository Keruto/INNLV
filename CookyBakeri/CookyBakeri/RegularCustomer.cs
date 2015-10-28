using System.Diagnostics;

namespace CookyBakeri
{
    public class RegularCustomer
    {
        public string name;

        // stamkunder må ha navn
        private RegularCustomer(){}

        public RegularCustomer(string name)
        {
            this.name = name;
        }
        public void getCookiesFrom(Bakery bakery)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (bakery.inStock)
            {
                if (stopwatch.ElapsedMilliseconds < root.buyingTime) continue;

                bakery.sellCookieTo(this);
                stopwatch.Restart();
            }
        }
    }
}
