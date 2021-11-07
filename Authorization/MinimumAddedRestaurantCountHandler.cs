using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Entities;
using RestaurantAPI.Services;

namespace RestaurantAPI.Authorization
{
    public class MinimumAddedRestaurantCountHandler : AuthorizationHandler<MinimumAddedRestaurantCount>
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly ILogger<MinimumAddedRestaurantCountHandler> _logger;

        public MinimumAddedRestaurantCountHandler(RestaurantDbContext dbContext, ILogger<MinimumAddedRestaurantCountHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAddedRestaurantCount requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var addedRestaurantCount = _dbContext.Restaurants.Count(r => r.CreatedById == userId);

            if (addedRestaurantCount >= requirement.MinimumCountRestaurantAdd)
            {
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("User added less than 2 restaurants, authorization failed");
            }
            return Task.CompletedTask;
        }
    }
}
