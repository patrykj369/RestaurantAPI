using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class TemperatureRequest
    {
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set;  }
    }
}
