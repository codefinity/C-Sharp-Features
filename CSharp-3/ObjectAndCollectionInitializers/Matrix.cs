using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectAndCollectionInitializers
{
    //Starting with C# 6, object initializers can set indexers, in addition to assigning fields and properties. 
    //Consider this basic Matrix class:
    public class Matrix
    {
        private double[,] storage = new double[3, 3];

        public double this[int row, int column]
        {
            // The embedded array will throw out of range exceptions as appropriate.
            get { return storage[row, column]; }
            set { storage[row, column] = value; }
        }
    }
}
