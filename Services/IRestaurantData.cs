using System.Collections.Generic;
using HariFood.Models;

namespace HariFood.Services
{
    public interface IRestaurantData
    {
         IEnumerable<Restaurant> GetAll();
    }
}