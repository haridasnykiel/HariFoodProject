using HariFood.Models;
using HariFood.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HariFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData _restaurantData;

        public Restaurant Restaurant {get; private set;} 
        
        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public void OnGet(int id) {
            Restaurant  = _restaurantData.Get(id);
        }
    }
}