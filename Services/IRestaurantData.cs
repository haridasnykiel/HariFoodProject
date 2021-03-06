using System.Collections.Generic;
using HariFood.Models;

namespace HariFood.Services {
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetAll ();
        Restaurant Get (int id);

        Restaurant Add (Restaurant restaurant);

        string Delete (Restaurant restaurant);

        Restaurant Update (Restaurant restaurant);
    }
}