using HariFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace HariFood.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            var controllerName = this.ControllerContext.ActionDescriptor.ControllerName; // Get the controller name.
            var model = new Resturant { Id = 1, Name = "Hari's Dirty Burgers" };
            //new ObjectResult(model);
            return View (model);
        }
    }
}