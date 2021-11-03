using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Authorization
{
    public class MinimumAddedRestaurantCountHandler : AuthorizationHandler<MinimumAddedRestaurantCount>
    {
        private readonly RestaurantDbContext _dbContext;

        public MinimumAddedRestaurantCountHandler(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAddedRestaurantCount requirement)
        {
            var user = context.User.
            var addedRestaurant = _dbContext.Restaurants.Where(x => x.CreatedById == context.User).GroupBy(z => z);
        }
    }
}
