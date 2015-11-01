using System.Diagnostics;

namespace CookyBakeri
{
    public class RegularCustomer
    {
        public string Name;

        // stamkunder må ha navn
	    public RegularCustomer(string name)
        {
            Name = name;
        }
        public void GetCookiesFrom(Bakery bakery)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (bakery.InStock)
            {
                if (stopwatch.ElapsedMilliseconds < Root.BuyingTime) continue;

                bakery.SellCookieTo(this);
                stopwatch.Restart();
            }
        }
    }
}
