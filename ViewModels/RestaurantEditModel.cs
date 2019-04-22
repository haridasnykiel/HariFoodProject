using System.ComponentModel.DataAnnotations;
using HariFood.Models;

namespace HariFood.ViewModels {
    public class RestaurantEditModel {

        
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}