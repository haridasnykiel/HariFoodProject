using System.Collections.Generic;
using HariFood.Models;

namespace HariFood.ViewModels
{
    public class HomeIndexViewModel
    {
        //This model will supply the view with the list of restaurants and the message of the day. 

        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; set; } 
    }
}