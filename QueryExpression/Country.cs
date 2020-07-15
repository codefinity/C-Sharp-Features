using System;
using System.Collections.Generic;
using System.Text;

namespace QueryExpression
{
    internal class Country
    {
        public string Name { get; set; }
        public long Area { get; set; }

        public long Population { get; set; }
        public IList<City> Cities { get; set; }

    }
}
