using HariFood.Models;
using HariFood.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HariFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData _restaurantData;

        [BindProperty]
        public Restaurant Restaurant {get; private set;} 
        
        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id) {
            Restaurant  = _restaurantData.Get(id);
            if(Restaurant == null) {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public IActionResult OnPost() {
            if(ModelState.IsValid) {

            }
            return Page();
        }
    }
}