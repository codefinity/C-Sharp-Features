using System;
using System.Collections.Generic;
using System.Text;

namespace PartialMethods
{
    internal partial class Coordinates
    {
        private readonly int latitude;
        private readonly int longitude;

        public Coordinates(int latitude, int longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
