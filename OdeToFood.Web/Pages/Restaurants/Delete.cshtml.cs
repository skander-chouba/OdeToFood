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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData data;

        public DeleteModel(IRestaurantData data)
        {
            this.data = data;
        }
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = data.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = data.GetById(restaurantId);
            if (restaurant == null)
            {
                return RedirectToPage("NotFound");
            }
            restaurant = data.Delete(restaurant.Id);
            data.Commit();
            if (restaurant == null)
            {
                return RedirectToPage("NotFound");
            }
            TempData["Message"] = $"The restaurant {restaurant.Name} deleted Succesfully";
            return RedirectToPage("List");
        }
    }
}