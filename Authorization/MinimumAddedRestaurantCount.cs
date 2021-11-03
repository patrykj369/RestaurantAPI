using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class MinimumAddedRestaurantCount : IAuthorizationRequirement
    {
        public int MinimumCountRestaurantAdd { get; }

        public MinimumAddedRestaurantCount(int minimumCountRestaurantAdd)
        {
            MinimumCountRestaurantAdd = minimumCountRestaurantAdd;
        }
    }
}
