using HariFood.Models;
using HariFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace HariFood.Controllers {
    public class HomeController : Controller {

        IRestaurantData _restaurantData;
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index () {
            //var controllerName = this.ControllerContext.ActionDescriptor.ControllerName; // Get the controller name.
            var model = _restaurantData.GetAll();
            //new ObjectResult(model);
            return View (model);
        }
    }
}