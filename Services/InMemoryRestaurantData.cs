using System;
using System.Collections.Generic;
using System.Linq;
using HariFood.Models;

namespace HariFood.Services {
    public class InMemoryRestaurantData : IRestaurantData {

        List<Restaurant> _restaurants;

        public InMemoryRestaurantData () {
            _restaurants = new List<Restaurant> {
                new Restaurant { Id = 2, Name = "Kathryns Samosas", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 1, Name = "Haridas Chevda", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 1, Name = "Zulu", Cuisine = CuisineType.None },
                new Restaurant { Id = 1, Name = "Walk", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 1, Name = "Yo", Cuisine = CuisineType.Chinese },
                new Restaurant { Id = 3, Name = "Prashad", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll () {
            return _restaurants.OrderBy (r => r.Name);
        }

        public Restaurant Get (int id) {
            return _restaurants.FirstOrDefault (r => r.Id == id);
        }
    }
}