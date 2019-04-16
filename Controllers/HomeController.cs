using HariFood.Models;
using HariFood.Services;
using HariFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HariFood.Controllers {
    public class HomeController : Controller {

        IRestaurantData _restaurantData;
        IGreeter _greeter;

        public HomeController (IRestaurantData restaurantData, IGreeter greeter) {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index () {
            //var controllerName = this.ControllerContext.ActionDescriptor.ControllerName; // Get the controller name.
            var model = new HomeIndexViewModel () {
                Restaurants = _restaurantData.GetAll (),
                Message = _greeter.MessageOfTheDay ()
            };

            //new ObjectResult(model);
            return View (model);
        }

        public IActionResult Details (int id) {
            var model = _restaurantData.Get (id);
            if (model == null) {
                return RedirectToAction (nameof (Index));
            }
            return View (model);
        }

        [HttpGet]
        public IActionResult Create () {
            return View ();
        }

        [HttpPost]
        public IActionResult Create (RestaurantEditModel restaurantEdit) {
            var restaurant = new Restaurant {
                Name = restaurantEdit.Name,
                Cuisine = restaurantEdit.Cuisine
            };

            restaurant = _restaurantData.Add(restaurant);

            return RedirectToAction(nameof(Details), new{id = restaurant.Id});
        }
    }
}