using System.Collections.Generic;
using System.Linq;
using HariFood.Models;

namespace HariFood.Services {
    public class InMemoryRestaurantData : IRestaurantData {

        List<Restaurant> _restaurants;

        public InMemoryRestaurantData () {
            _restaurants = new List<Restaurant> {
                new Restaurant { Id = 2, Name = "Kathryns Samosas" },
                new Restaurant { Id = 1, Name = "Haridas Chevda" },
                new Restaurant { Id = 1, Name = "Zulu" },
                new Restaurant { Id = 1, Name = "Walk" },
                new Restaurant { Id = 1, Name = "Yo" },
                new Restaurant { Id = 3, Name = "Prashad" }
            };
        }

        public IEnumerable<Restaurant> GetAll () {
            return _restaurants.OrderBy (r => r.Name);
        }

        
    }
}