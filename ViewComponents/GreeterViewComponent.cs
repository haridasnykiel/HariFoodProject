using HariFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace HariFood.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke() {
            var model = _greeter.MessageOfTheDay();
            return View("Default", model);
        }
    }
}