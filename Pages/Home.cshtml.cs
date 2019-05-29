using HariFood.Services;
using HariFood.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HariFood.Pages {
    public class HomeModel : PageModel {

        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeIndexViewModel HomeIndexViewModel { get; private set; }

        public HomeModel (IRestaurantData restaurantData, IGreeter greeter) {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public void OnGet () {
            HomeIndexViewModel = new HomeIndexViewModel {
                Restaurants = _restaurantData.GetAll (),
                Message = _greeter.MessageOfTheDay ()
            };
        }
    }
}