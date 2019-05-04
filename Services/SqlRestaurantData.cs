using System.Collections.Generic;
using System.Linq;
using HariFood.Data;
using HariFood.Models;

namespace HariFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private HariFoodDbContext _context;

        public SqlRestaurantData(HariFoodDbContext context)
        {
            _context = context;
        }

        //In alot of programs it is better to have a separate method to save changes to the database. 
        //As you can save multiple changes in 1 transaction. 
        //A difference between the in memeory data store the sql database is that the id will be generated automatically.
        //When the save changes method is called. 
        //Save Changes will run an insert sql query.
        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }
    }
}