using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookyBakeri
{
    class Cookie
    {
        private string type;

        // må ha type
        private Cookie() {}

        public Cookie(string type)
        {
            this.type = type;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
