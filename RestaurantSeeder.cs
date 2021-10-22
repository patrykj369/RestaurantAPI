using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC to najlepsza restauracja serwujaca kurczaki",
                    ContactEmail = "123456@amrest.eu",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Kubełek 15/15",
                            Price = 45.95M,
                        },

                        new Dish()
                        {
                            Name = "Grander",
                            Price = 16.95M,
                        }
                    },

                    Address = new Address()
                    {
                        City = "Nowy Sącz",
                        Street = "Lwowska 34",
                        PostalCode = "33-300"
                    }

                }
            };

            return restaurants;
        }
    }
}
