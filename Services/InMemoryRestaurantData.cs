using System;
using System.Collections.Generic;
using System.Linq;
using HariFood.Models;

namespace HariFood.Services {
    public class InMemoryRestaurantData : IRestaurantData {

        List<Restaurant> _restaurants;

        public InMemoryRestaurantData () {
            _restaurants = new List<Restaurant> {
                new Restaurant { Id = 1, Name = "Kathryns Samosas", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 2, Name = "Haridas Chevda", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Zulu", Cuisine = CuisineType.None },
                new Restaurant { Id = 4, Name = "Walk", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 5, Name = "Yo", Cuisine = CuisineType.Chinese },
                new Restaurant { Id = 6, Name = "Prashad", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll () {
            return _restaurants.OrderBy (r => r.Name);
        }

        public Restaurant Get (int id) {
            return _restaurants.FirstOrDefault (r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            var id = _restaurants.Max(r => r.Id) + 1;
            restaurant.Id = id;
            _restaurants.Add(restaurant);
            return restaurant;
        }
    }
}