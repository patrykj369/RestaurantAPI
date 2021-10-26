using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string message) : base(message)
        {
            
        }
    }
}
