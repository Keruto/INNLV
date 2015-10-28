namespace CookyBakeri
{
    interface Cookie
    {
        string Type
        {
            get;
        }
    }

    class Chocolate : Cookie
    {
        public string Type
        {
            get
            {
                return "chocolate";
            }
        }
    }
    class Raisins : Cookie
    {
        public string Type
        {
            get
            {
                return "raisins";
            }
        }
    }
    class Nonstop : Cookie
    {
        public string Type
        {
            get
            {
                return "nonstop";
            }
        }
    }
    class Icing : Cookie
    {
        public string Type
        {
            get
            {
                return "icing";
            }
        }
    }
}
