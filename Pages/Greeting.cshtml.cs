using HariFood.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HariFood.Pages {
    public class GreetingModel : PageModel {
        private IGreeter _greeter;

        public string Greeting { get; private set; }

        public GreetingModel (IGreeter greeter) {
            _greeter = greeter;
        }

        public void OnGet (string name) {
            Greeting = name + " : " + _greeter.MessageOfTheDay();
        }

    }
}