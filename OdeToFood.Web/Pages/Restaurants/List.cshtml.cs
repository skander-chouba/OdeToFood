using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant>  Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
            Restaurants = new List<Restaurant>();
        }
        public void OnGet()
        {

            Restaurants = restaurantData.GetAllByName(SearchTerm);
        }
    }
}