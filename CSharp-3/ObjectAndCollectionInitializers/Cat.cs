using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectAndCollectionInitializers
{
    public class Cat
    {
        // Auto-implemented properties.
        public int Age { get; set; }
        public string Name { get; set; }

        public Cat()
        {
        }

        public Cat(string name)
        {
            this.Name = name;
        }
    }
}
