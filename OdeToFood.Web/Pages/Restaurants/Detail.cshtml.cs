using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IRestaurantData data;

        public DetailModel(IRestaurantData data)
        {
            this.data = data;
        }
        public Restaurant Restaurant { get; set; }         
        public IActionResult OnGet(int restaurantId)
        {

            Restaurant = data.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}